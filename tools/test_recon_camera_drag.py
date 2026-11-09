"""Pins the camera-pan proof and the touch-input consumer scan; rejects tampered expectations."""
import unittest

import recon_camera_drag as camera


class CameraDragTests(unittest.TestCase):
    source = camera.nav.ROOT / 'out/recon/il2cpp'

    @classmethod
    def setUpClass(cls):
        cls.report = camera.probe(cls.source)

    def test_pan_uses_primary_pointer_and_cshape_block(self):
        update = self.report['GameCameraBase.Update']
        self.assertIn('Input.GetMouseButton(0)', update['pointer'])
        self.assertIn('CShapeRaycaster.LastResultCount >= 1', update['ui_vs_world'])
        self.assertIn('_isPointerDown is not cleared in Update', update['release'])

    def test_drag_constants(self):
        drag = self.report['GameCameraBase.OnDrag']
        self.assertIn('HEIGHT(10.24) / Screen.height', drag['drag_factor'])
        self.assertIn('> 0.01 world units', drag['begin_drag'])

    def test_no_gameplay_code_reads_touch_or_scroll(self):
        consumers = self.report['input_consumers']['consumers']
        for name in ('get_touchCount', 'GetTouch', 'get_mouseScrollDelta', 'get_touches'):
            self.assertFalse([o for o in consumers[name] if o.startswith(('Game.', 'PWC.Level'))], name)
        self.assertEqual(consumers['get_mouseScrollDelta'],
                         ['PWC.SUTSystem.SUTSystemTester.Update', 'UnityEngine.EventSystems.BaseInput.get_mouseScrollDelta'])

    def test_changed_consumer_expectation_is_rejected(self):
        original = camera.SCAN['get_touches']
        camera.SCAN['get_touches'] = (original[0], original[1] - {'Reporter.getDrag'})
        try:
            with self.assertRaisesRegex(ValueError, 'consumer set changed for get_touches'):
                camera.probe(self.source)
        finally:
            camera.SCAN['get_touches'] = original

    def test_changed_threshold_is_rejected(self):
        original = camera.f32
        camera.f32 = lambda elf, vaddr: 0.5 if vaddr == 0xb30030 else original(elf, vaddr)
        try:
            with self.assertRaisesRegex(ValueError, 'drag threshold changed'):
                camera.probe(self.source)
        finally:
            camera.f32 = original


if __name__ == '__main__':
    unittest.main()
