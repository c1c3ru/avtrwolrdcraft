"""Static proof of the world-camera pan (GameCameraBase) and of which game code reads touch input.

Reads libil2cpp.so and global-metadata.dat only; nothing is executed. The consumer scan sees
direct bl/b call sites only (interface, virtual and delegate calls are invisible) and attributes
a call site to the nearest preceding named method.
"""
import argparse
import bisect
import struct
from pathlib import Path

import numpy as np

import recon_load_scene_pipeline as pipe
import recon_navigation as nav
import recon_t031_dispatch as dispatch

WINDOWS = {
    'Update': (0x206e7ec, 0x206e8fc),
    'PlayEndDragTween': (0x206e8fc, 0x206e9e0),
    'OnDrag': (0x206e9e0, 0x206eb8c),
    'Awake': (0x206dca0, 0x206dd5c),
    'OnBeginDrag': (0x206ed44, 0x206ed74),
    'OnEndDrag': (0x206ed74, 0x206ed90),
}
OF = {'ShouldConsiderCShapes': 0x78, 'LastMouse': 0x7C, 'IsPointerDown': 0x88, 'IsDragging': 0x89, 'DragFactor': 0x8C,
      'IsDraggable': 0x90, 'OnPointerDownAction': 0xA8, 'CShapeRaycaster': 0x70, 'AllowMovementWhenZoomNotDefault': 0xC0,
      'IsZoomNotDefault': 0xC1, 'WiderThanScreen': 0x38}
HEIGHT = 10.24
SCAN = {  # UnityEngine.Input entry points -> exact set of direct-call owners expected
    'get_touchCount': (0x3d0c8f0, {'LTGUI.firstTouch', 'UnityEngine.EventSystems.BaseInput.get_touchCount', 'Input.get_touchCount'}),
    'GetTouch': (0x3d0c41c, {'Input.GetTouch', 'UnityEngine.EventSystems.BaseInput.GetTouch'}),
    'get_mouseScrollDelta': (0x3d0c6c0, {'PWC.SUTSystem.SUTSystemTester.Update', 'UnityEngine.EventSystems.BaseInput.get_mouseScrollDelta'}),
    'get_touches': (0x3d0c9cc, {'CShapes.CShapeRaycaster.IsTouchBeginPhase', 'LTGUI.firstTouch', 'PWC.PWCUtils.GetPointerScreenPosition',
                                'Reporter.getDownPos', 'Reporter.getDrag', 'Reporter.isDoubleClickDone', 'Reporter.isGestureDone'}),
    'set_multiTouchEnabled': (0x3d0c968, {'PazuCore.AF.ActionBar.HubCanvas.Awake', 'PazuCore.AF.ActionBar.HubCanvas.OnDestroy',
                                          'PazuCore.SettingsManager.InitExtraSettings'}),
}


LDR_W = lambda w: pipe.decode(w, 0xffc00000, 0xb9400000, {**pipe.REG, 'imm': lambda w: ((w >> 10) & 0xfff) * 4})
LDP_X = lambda w: pipe.decode(w, 0xffc00000, 0xa9400000, {**pipe.REG, 'imm': lambda w: ((w >> 15) & 0x7f) * 8})


def stur_xzr(rn, imm):
    return 0xf8000000 | ((imm & 0x1ff) << 12) | (rn << 5) | 31


def f32(elf, vaddr):
    return struct.unpack_from('<f', elf.data, elf.offset(vaddr, 4))[0]


def at(elf, address, word):
    nav.require(nav.word(elf, address) == word, f'instruction mismatch at {address:#x}: {nav.word(elf, address):#x} != {word:#x}')


def branch(elf, address, kind, target):
    control = nav.branch(address, nav.word(elf, address))
    nav.require(control and control['kind'] == kind and control['target'] == target, f'branch mismatch at {address:#x}')


def prove_update(elf, meta, resolve):
    calls = pipe.controls(elf, resolve, *WINDOWS['Update'])
    names = [pipe.label(c['rows'][0]) for _, c in sorted(calls.items()) if c['rows']]
    nav.require(names == ['Input.GetMouseButtonDown', 'Input.GetMouseButton', 'Behaviour.get_enabled', 'Behaviour.set_enabled',
                          'GameCameraBase.PlayEndDragTween', 'GameCameraBase.OnDrag'], 'Update call sequence changed')
    pipe.at(elf, 0x206e804, pipe.LDR_X, rn=19, imm=OF['OnPointerDownAction'])
    pipe.at(elf, 0x206e81c, pipe.LDRB, rn=19, imm=OF['IsDraggable'])
    branch(elf, 0x206e820, 'CBZ', 0x206e8dc)
    pipe.at(elf, 0x206e824, pipe.LDRB, rn=19, imm=OF['AllowMovementWhenZoomNotDefault'])
    branch(elf, 0x206e828, 'CBZ', 0x206e8d4)
    pipe.at(elf, 0x206e8d4, pipe.LDRB, rn=19, imm=OF['IsZoomNotDefault'])
    branch(elf, 0x206e8d8, 'CBZ', 0x206e82c)
    branch(elf, 0x206e838, 'TBZ', 0x206e864)                      # button not held -> release path
    pipe.at(elf, 0x206e83c, pipe.LDRB, rn=19, imm=OF['ShouldConsiderCShapes'])
    branch(elf, 0x206e840, 'CBZ', 0x206e8e4)                      # not considering shapes -> drag
    pipe.at(elf, 0x206e844, pipe.LDR_X, rn=19, imm=OF['CShapeRaycaster'])
    pipe.at(elf, 0x206e84c, LDR_W, imm=0x30)                      # raycaster.LastResultCount
    at(elf, 0x206e850, 0x7100051f)                               # cmp w8,#1  (LastResultCount < 1 -> drag)
    nav.require(nav.branch(0x206e854, nav.word(elf, 0x206e854))['target'] == 0x206e8e4, 'LastResultCount branch mismatch')
    at(elf, 0x206e858, stur_xzr(19, 0x81))                        # a CShape is under the pointer: forget the last position,
    at(elf, 0x206e85c, stur_xzr(19, OF['LastMouse']))             # and do not drag the camera
    pipe.at(elf, 0x206e8e8, pipe.STRB, rn=19, imm=OF['IsPointerDown'])
    branch(elf, 0x206e8f4, 'B', 0x206e9e0)                        # tail call OnDrag
    # Release path.
    pipe.at(elf, 0x206e864, pipe.LDRB, rn=19, imm=OF['IsPointerDown'])
    at(elf, 0x206e888, 0x52800021)                                # raycaster.enabled = true
    pipe.at(elf, 0x206e894, pipe.LDRB, rn=19, imm=OF['IsDragging'])
    pipe.at(elf, 0x206e89c, pipe.LDRB, rn=19, imm=OF['WiderThanScreen'])
    branch(elf, 0x206e8a0, 'CBNZ', 0x206e8ac)                     # wider than screen: no inertia tween
    pipe.at(elf, 0x206e8b4, LDP_X, imm=0x1e8)                     # vtable slot load for OnEndDrag
    nav.require(dispatch.slot_from_offset(0x1e8) == 11 and dispatch.virtual_slots(meta, 'PWC', 'GameCameraBase')[11][0] == 'OnEndDrag',
                'release does not dispatch OnEndDrag')
    pipe.at(elf, 0x206e8bc, pipe.STRB, rt=31, rn=19, imm=OF['IsDragging'])
    pipe.at(elf, 0x206e8cc, pipe.STRB, rt=8, rn=19, imm=OF['ShouldConsiderCShapes'])
    return {
        'pointer': 'primary only: Input.GetMouseButton(0) / GetMouseButtonDown(0); no touchCount/GetTouch',
        'gate': 'isDraggable && (AllowMovementWhenZoomNotDefault || !IsZoomNotDefault)',
        'ui_vs_world': 'while the button is held, if ShouldConsiderCShapes and CShapeRaycaster.LastResultCount >= 1 the '
                       'camera does not pan and the last position is forgotten',
        'release': ['CShapeRaycaster.enabled = true',
                    'if IsDragging: PlayEndDragTween() unless _isCameraWiderThanScreen; OnEndDrag(); IsDragging = false',
                    'last position = null; ShouldConsiderCShapes = true', '_isPointerDown is not cleared in Update'],
        'pointer_down_event': 'OnPointerDownAction invoked on GetMouseButtonDown(0) before the gate',
    }


def prove_drag(elf, meta, resolve):
    calls = pipe.controls(elf, resolve, *WINDOWS['OnDrag'])
    names = [pipe.label(c['rows'][0]) for _, c in sorted(calls.items()) if c['rows']]
    nav.require(names == ['Input.get_mousePosition', 'Transform.get_position', 'CameraMovementClampper.GetCameraXBounds',
                          'Behaviour.get_enabled', 'Behaviour.set_enabled', 'CameraMovementClampper.SetPosition'],
                'OnDrag call sequence changed')
    threshold = f32(elf, 0xb30030)
    nav.require(abs(threshold - 0.01) < 1e-6, 'drag threshold changed')
    for address, word in [(0x206ea78, 0x1e20390d), (0x206ea80, 0xbd408e6f), (0x206ea90, 0x1e2f09a0), (0x206ea98, 0x1e2039cd),
                          (0x206eaa4, 0x1e2121a0), (0x206eaa8, 0x1e2dcc21), (0x206eaac, 0x1e2021a0), (0x206eab0, 0x1e205c2d),
                          (0x206eabc, 0xbd403100), (0x206eac0, 0x7eaed5a1), (0x206eac4, 0x1e202020), (0x206ead4, 0xa95d8509),
                          (0x206eb10, 0x1e2a3920), (0x206eb18, 0x1e2f0800), (0x206eb20, 0x1e203961), (0x206eb00, 0x2a1f03e1)]:
        at(elf, address, word)  # float math: dx*factor, clamp, |dx|>threshold, dy*factor, raycaster.enabled=false
    branch(elf, 0x206eac8, 'B.cond', 0x206eb0c)
    nav.require(dispatch.slot_from_offset(0x1d8) == 10 and dispatch.virtual_slots(meta, 'PWC', 'GameCameraBase')[10][0] == 'OnBeginDrag',
                'drag start does not dispatch OnBeginDrag')
    pipe.at(elf, 0x206eae4, pipe.STRB, rn=19, imm=OF['IsDragging'])
    branch(elf, 0x206eab4, 'CBNZ', 0x206eb0c)                       # already dragging -> straight to the vertical term
    # OnBeginDrag = StopTween() then OnBeginDragAction; OnEndDrag = OnEndDragAction.
    begin = [pipe.label(c['rows'][0]) for _, c in sorted(pipe.controls(elf, resolve, *WINDOWS['OnBeginDrag']).items()) if c['rows']]
    nav.require(begin == ['CameraMovementClampper.StopTween'], 'OnBeginDrag body changed')
    pipe.at(elf, 0x206ed50, pipe.LDR_X, rn=19, imm=0x98)            # OnBeginDragAction
    pipe.at(elf, 0x206ed74, pipe.LDR_X, rn=0, imm=0xa0)             # OnEndDragAction
    at(elf, 0x206ea44, 0x3847ce88)                                  # ldrb w8,[x20,#0x7c]! (x20 = this) : last-position HasValue
    # Awake: dragFactor = HEIGHT / Screen.height.
    awake = [pipe.label(c['rows'][0]) for _, c in sorted(pipe.controls(elf, resolve, *WINDOWS['Awake']).items()) if c['rows']]
    nav.require(awake[0] == 'Screen.get_height', 'Awake does not read Screen.height')
    nav.require(abs(f32(elf, 0xb30090) - HEIGHT) < 1e-5, 'drag-factor numerator is not HEIGHT')
    at(elf, 0x206dcf8, 0xbd008e60)                                  # str s0,[x19,#0x8c]
    # Inertia tween.
    tween = [pipe.label(c['rows'][0]) for _, c in sorted(pipe.controls(elf, resolve, *WINDOWS['PlayEndDragTween']).items()) if c['rows']]
    nav.require(tween == ['Input.get_mousePosition', 'Component.get_transform', 'Transform.get_position',
                          'CameraMovementClampper.TweenToXPosition', 'LTDescr.setEaseOutExpo'], 'inertia call sequence changed')
    at(elf, 0x206e988, 0x1e349000)                                  # fmov s0,#-10.0
    return {
        'drag_factor': f'HEIGHT({HEIGHT}) / Screen.height world units per pixel, set in Awake',
        'pan': 'x = clamp(camX - (mouse.x - last.x) * factor, GetCameraXBounds()); y = camY - (mouse.y - last.y) * factor; '
               'SetPosition(x, y, z)',
        'begin_drag': f'OnBeginDrag() once |clampedX - camX| > {threshold:.2f} world units; then IsDragging = true and '
                      'CShapeRaycaster.enabled = false',
        'vertical': 'y is applied every frame even before IsDragging; only horizontal motion triggers OnBeginDrag',
        'on_begin_drag': 'StopTween(), then OnBeginDragAction',
        'inertia': 'PlayEndDragTween: TweenToXPosition(...) then setEaseOutExpo, skipped when _isCameraWiderThanScreen',
        'decoded_not_asserted': [
            'z is kept (z + factor * -0.0)', 'inertia target x = camX + (-10 * factor * dx), duration |factor * dx| '
            '(dx = mouse.x - last.x at release)'],
    }


def direct_callers(elf, rows, targets):
    named = sorted((int(r['vaddr'], 16), r['declaring_type'] + '.' + r['name']) for r in rows if r.get('vaddr'))
    starts = [a for a, _ in named]
    delta = int(rows[0]['vaddr'], 16) - int(rows[0]['file_offset'], 16)
    words = np.frombuffer(elf.data[:len(elf.data) // 4 * 4], dtype='<u4')
    idx = np.nonzero((words & 0x7c000000) == 0x14000000)[0]
    imm = (words[idx] & 0x3ffffff).astype(np.int64)
    imm = np.where(imm & 0x2000000, imm - 0x4000000, imm)
    source = idx.astype(np.int64) * 4 + delta
    destination = source + imm * 4
    owners = {}
    for name, address in targets.items():
        owners[name] = {named[bisect.bisect_right(starts, int(a)) - 1][1] for a in source[destination == address]}
    return owners


def prove_input_consumers(elf, meta, resolve, rows):
    found = direct_callers(elf, [r for r in rows if r.get('vaddr')], {n: a for n, (a, _) in SCAN.items()})
    for name, (_, expected) in SCAN.items():
        nav.require(found[name] == expected, f'consumer set changed for {name}: {sorted(found[name] ^ expected)}')
        nav.require(not any(o.startswith(('Game.', 'PWC.Level')) for o in found[name]), f'gameplay reads {name}')
    return {'scope': 'direct call sites of UnityEngine.Input; attribution = nearest preceding named method',
            'consumers': {name: sorted(owners) for name, owners in found.items()},
            'reading': ['no gameplay (Game.* / PWC.Level*) code calls touchCount, GetTouch, touches or mouseScrollDelta',
                        'touches only in CShapeRaycaster.IsTouchBeginPhase and PWCUtils.GetPointerScreenPosition (pointer position)',
                        'scroll wheel only in the QA tool SUTSystemTester',
                        'multiTouchEnabled written by PazuCore SettingsManager (value from GameExtraSettings.multiTouchEnabled, '
                        'not recovered) and by HubCanvas (saves, sets false, restores)']}


def probe(source):
    binary = (source / 'libil2cpp.so').read_bytes()
    metadata = (source / 'global-metadata.dat').read_bytes()
    nav.verify_pair(binary, metadata)
    elf, meta = nav.Elf(binary), nav.Metadata(metadata)
    rows, resolve = nav.load_index(source / 'metadata_methods.jsonl', elf, meta)
    for name, (start, stop) in WINDOWS.items():
        owner = resolve(start)
        nav.require(len(owner) == 1 and owner[0]['name'] == name, f'{name} identity mismatch at {start:#x}')
        following = min(int(r['vaddr'], 16) for r in rows if r['vaddr'] and int(r['vaddr'], 16) > start)
        nav.require(following == stop, f'{name} next-method boundary mismatch')
    return {'schema_version': 1, 'scope': 'bounded static proof; no execution',
            'native_sha256': nav.sha(binary), 'metadata_sha256': nav.sha(metadata),
            'GameCameraBase.Update': prove_update(elf, meta, resolve),
            'GameCameraBase.OnDrag': prove_drag(elf, meta, resolve),
            'input_consumers': prove_input_consumers(elf, meta, resolve, rows)}


if __name__ == '__main__':
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--source', type=Path, default=nav.ROOT / 'out/recon/il2cpp')
    parser.add_argument('--report', type=Path, default=nav.ROOT / 'out/recon/camera_drag.json')
    args = parser.parse_args()
    nav.atomic_json(args.report, probe(args.source))
    print(f'Camera drag proof written to {args.report}')
