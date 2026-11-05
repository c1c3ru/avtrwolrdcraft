using System.Collections;
using AvatarWorld.Core.Avatar;
using AvatarWorld.Runtime;
using NUnit.Framework;
using Spine.Unity;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.TestTools;

namespace AvatarWorld.PlayModeTests
{
    /// <summary>
    /// Fluxo completo com o Avatar_Spine real: mouse virtual (Input System) -> CharacterDragController -> SkeletonAnimation.
    /// Texturas de pagina ausentes viram 1x1 transparente (AvatarAtlasLoader), o que basta para animacao.
    /// </summary>
    public class CharacterSpineDragPlayTests
    {
        GameObject _go;
        SkeletonAnimation _spine;
        CharacterDragController _controller;
        Mouse _mouse;

        [SetUp]
        public void SetUp()
        {
            var shader = Shader.Find("Spine/Skeleton");
            Assert.IsNotNull(shader, "shader Spine/Skeleton");
            var atlasText = Resources.Load<TextAsset>("AvatarSpine/Avatar_Spine.atlas");
            var skeletonBinary = Resources.Load<TextAsset>("AvatarSpine/Avatar_Spine.skel");
            Assert.IsNotNull(atlasText, "atlas");
            Assert.IsNotNull(skeletonBinary, "skel");

            var atlas = AvatarAtlasLoader.Create(atlasText, shader, null, out _);
            var data = SkeletonDataAsset.CreateRuntimeInstance(skeletonBinary, atlas, true, 0.01f);

            _go = new GameObject("PlayTestCharacter");
            _spine = SkeletonAnimation.AddToGameObject(_go, data);
            _spine.Initialize(false);
            Assert.IsTrue(_spine.valid, "SkeletonAnimation.valid");

            _controller = _go.AddComponent<CharacterDragController>();
            _controller.Skeleton = _spine;
            _controller.ScreenToWorld = s => s / 100f;

            // Em batchmode nenhum Game View tem foco; sem isto o Input System descarta os eventos do mouse virtual.
            _oldEditorBehavior = InputSystem.settings.editorInputBehaviorInPlayMode;
            _oldBackground = InputSystem.settings.backgroundBehavior;
            InputSystem.settings.editorInputBehaviorInPlayMode = InputSettings.EditorInputBehaviorInPlayMode.AllDeviceInputAlwaysGoesToGameView;
            InputSystem.settings.backgroundBehavior = InputSettings.BackgroundBehavior.IgnoreFocus;
            _mouse = InputSystem.AddDevice<Mouse>();
        }

        InputSettings.EditorInputBehaviorInPlayMode _oldEditorBehavior;
        InputSettings.BackgroundBehavior _oldBackground;

        [TearDown]
        public void TearDown()
        {
            InputSystem.settings.editorInputBehaviorInPlayMode = _oldEditorBehavior;
            InputSystem.settings.backgroundBehavior = _oldBackground;
            if (_mouse != null) InputSystem.RemoveDevice(_mouse);
            Object.Destroy(_go);
        }

        string Current { get { var e = _spine.AnimationState.GetCurrent(0); return e == null ? null : e.Animation.Name; } }

        IEnumerator MoveMouse(Vector2 position, bool pressed)
        {
            var state = new MouseState { position = position };
            if (pressed) state = state.WithButton(MouseButton.Left);
            InputSystem.QueueStateEvent(_mouse, state);
            _mouse.MakeCurrent();
            yield return null;   // um quadro: o evento e processado antes do Update do controller
        }

        [UnityTest]
        public IEnumerator AvatarSpineHasEveryAnimationTheCharacterContractUses()
        {
            yield return null;
            foreach (var name in new[] { "Idle_Stand_1", "Movement_Cycles/Walk", "Movement_Cycles/Run", "Lift_Idle" })
                Assert.IsNotNull(_spine.Skeleton.Data.FindAnimation(name), name);
        }

        [UnityTest]
        public IEnumerator StartsInIdleStand1()
        {
            yield return null;
            Assert.AreEqual("Idle_Stand_1", Current);
        }

        [UnityTest]
        public IEnumerator DraggingPlaysWalkAndReleasingReturnsToIdle()
        {
            yield return null;
            yield return MoveMouse(new Vector2(0f, 0f), true);          // pressiona sobre o personagem
            Assert.AreEqual("Idle_Stand_1", Current, "pressionar nao muda a animacao");
            yield return MoveMouse(new Vector2(40f, 0f), true);         // 40 px: passa do limiar de 10 px
            yield return MoveMouse(new Vector2(80f, 0f), true);
            Assert.AreEqual(MovementKind.Walk, _controller.Movement);
            Assert.AreEqual("Movement_Cycles/Walk", Current);
            Assert.Greater(_go.transform.position.x, 0.3f, "o personagem acompanhou o ponteiro");
            yield return MoveMouse(new Vector2(80f, 0f), false);        // solta
            Assert.AreEqual("Idle_Stand_1", Current);
            Assert.AreEqual(MovementKind.Stand, _controller.Movement);
        }

        [UnityTest]
        public IEnumerator HoldingStillWhileDraggingReturnsToIdleThenWalksAgainWhenMoving()
        {
            yield return null;
            yield return MoveMouse(new Vector2(0f, 0f), true);
            yield return MoveMouse(new Vector2(40f, 0f), true);
            Assert.AreEqual("Movement_Cycles/Walk", Current);
            yield return MoveMouse(new Vector2(40f, 0f), true);         // parado, ainda pressionado: velocidade 0
            Assert.AreEqual("Idle_Stand_1", Current);
            Assert.AreEqual(DragPhaseOf(_controller), AvatarWorld.Core.Pointer.DragPhase.Dragging);
            yield return MoveMouse(new Vector2(90f, 0f), true);         // volta a mover
            Assert.AreEqual("Movement_Cycles/Walk", Current);
        }

        static AvatarWorld.Core.Pointer.DragPhase DragPhaseOf(CharacterDragController c) { return c.Phase; }

        [UnityTest]
        public IEnumerator ATapThatStaysUnderTenPixelsIsAClickAndKeepsIdle()
        {
            int clicks = 0;
            _controller.Clicked += () => clicks++;
            yield return null;
            yield return MoveMouse(new Vector2(0f, 0f), true);
            yield return MoveMouse(new Vector2(4f, 0f), true);
            yield return MoveMouse(new Vector2(4f, 0f), false);
            Assert.AreEqual(1, clicks);
            Assert.AreEqual("Idle_Stand_1", Current);
            Assert.AreEqual(0f, _go.transform.position.x, 0.0001f);
        }
    }
}
