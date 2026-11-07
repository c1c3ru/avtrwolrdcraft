#if UNITY_EDITOR
using System.Collections;
using AvatarWorld.Core.Avatar;
using AvatarWorld.Runtime;
using NUnit.Framework;
using Spine.Unity;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.TestTools;

namespace AvatarWorld.PlayModeTests
{
    /// <summary>
    /// Toddler e animais (Dog, Cat) no mesmo fluxo do Character: mouse virtual -> CharacterDragController -> SkeletonAnimation real.
    /// Esqueletos ficam em Tests/PlayMode/Fixtures (fora de Resources, nao entram no build). Paginas do atlas viram 1x1 transparente.
    /// </summary>
    public class CharacterFamiliesPlayTests
    {
        const string Fixtures = "Assets/Tests/PlayMode/Fixtures/";

        GameObject _go;
        SkeletonAnimation _spine;
        CharacterDragController _controller;
        Mouse _mouse;
        InputSettings.EditorInputBehaviorInPlayMode _oldEditorBehavior;
        InputSettings.BackgroundBehavior _oldBackground;

        void Build(string baseName, LocomotionFamily family, PostureKind posture, bool hasRunning)
        {
            var shader = Shader.Find("Spine/Skeleton");
            Assert.IsNotNull(shader, "shader Spine/Skeleton");
            var atlasText = AssetDatabase.LoadAssetAtPath<TextAsset>(Fixtures + baseName + ".atlas.txt");
            var skeletonBinary = AssetDatabase.LoadAssetAtPath<TextAsset>(Fixtures + baseName + ".skel.bytes");
            Assert.IsNotNull(atlasText, baseName + " atlas");
            Assert.IsNotNull(skeletonBinary, baseName + " skel");

            var pages = AvatarAtlasLoader.ParsePageNames(atlasText.text);
            var materials = new Material[pages.Length];
            for (int i = 0; i < pages.Length; i++)
            {
                var texture = new Texture2D(1, 1, TextureFormat.RGBA32, false) { name = pages[i] };
                texture.SetPixel(0, 0, Color.clear);
                texture.Apply(false, true);
                materials[i] = new Material(shader) { name = pages[i], mainTexture = texture };
            }
            var atlas = SpineAtlasAsset.CreateRuntimeInstance(atlasText, materials, true);
            var data = SkeletonDataAsset.CreateRuntimeInstance(skeletonBinary, atlas, true, 0.01f);

            _go = new GameObject("PlayTest_" + baseName);
            _spine = SkeletonAnimation.AddToGameObject(_go, data);
            _spine.Initialize(false);
            Assert.IsTrue(_spine.valid, baseName + " SkeletonAnimation.valid");

            _controller = _go.AddComponent<CharacterDragController>();
            _controller.Skeleton = _spine;
            _controller.Family = family;
            _controller.Posture = posture;
            _controller.HasRunningAnimations = hasRunning;
            _controller.DeltaTimeOverride = 0.016f;          // 40 px = 0.4 u -> 25 u/s por quadro
            _controller.ScreenToWorld = s => s / 100f;

            _oldEditorBehavior = InputSystem.settings.editorInputBehaviorInPlayMode;
            _oldBackground = InputSystem.settings.backgroundBehavior;
            InputSystem.settings.editorInputBehaviorInPlayMode = InputSettings.EditorInputBehaviorInPlayMode.AllDeviceInputAlwaysGoesToGameView;
            InputSystem.settings.backgroundBehavior = InputSettings.BackgroundBehavior.IgnoreFocus;
            _mouse = InputSystem.AddDevice<Mouse>();
        }

        [TearDown]
        public void TearDown()
        {
            if (_mouse == null) return;
            InputSystem.settings.editorInputBehaviorInPlayMode = _oldEditorBehavior;
            InputSystem.settings.backgroundBehavior = _oldBackground;
            InputSystem.RemoveDevice(_mouse);
            Object.Destroy(_go);
        }

        string Current { get { var e = _spine.AnimationState.GetCurrent(0); return e == null ? null : e.Animation.Name; } }

        IEnumerator MoveMouse(Vector2 position, bool pressed)
        {
            var state = new MouseState { position = position };
            if (pressed) state = state.WithButton(MouseButton.Left);
            InputSystem.QueueStateEvent(_mouse, state);
            _mouse.MakeCurrent();
            yield return null;
        }

        IEnumerator Drag()
        {
            yield return MoveMouse(new Vector2(0f, 0f), true);
            yield return MoveMouse(new Vector2(40f, 0f), true);
        }

        [UnityTest]
        public IEnumerator ToddlerStandingWalksAndCrawlsWhenSitting()
        {
            Build("Toddler_Spine", LocomotionFamily.Toddler, PostureKind.Standing, false);
            foreach (var n in new[] { "General/Stand_Idle", "Movement_Cycles/Walking_Loop", "Movement_Cycles/Crawling_Loop" })
                Assert.IsNotNull(_spine.Skeleton.Data.FindAnimation(n), "Toddler " + n);
            yield return null;
            Assert.AreEqual("General/Stand_Idle", Current);
            yield return Drag();
            Assert.AreEqual("Movement_Cycles/Walking_Loop", Current);
            yield return MoveMouse(new Vector2(40f, 0f), false);
            Assert.AreEqual("General/Stand_Idle", Current);

            _controller.Posture = PostureKind.Sitting;
            yield return Drag();
            Assert.AreEqual("Movement_Cycles/Crawling_Loop", Current);
        }

        [UnityTest]
        public IEnumerator ToddlerNeverRunsEvenAtHighSpeed()
        {
            Build("Toddler_Spine", LocomotionFamily.Toddler, PostureKind.Standing, true);
            yield return null;
            yield return Drag();
            yield return MoveMouse(new Vector2(80f, 0f), true);
            Assert.AreEqual(MovementKind.Walk, _controller.Movement);
            Assert.AreEqual("Movement_Cycles/Walking_Loop", Current);
        }

        [UnityTest]
        public IEnumerator DogWalksThenRunsWhenFastAndHasRunningAnimations()
        {
            Build("Pet_Dog_Spine", LocomotionFamily.Animal, PostureKind.Standing, true);
            foreach (var n in new[] { "General/Standing_Idle", "General/Walking", "General/Running" })
                Assert.IsNotNull(_spine.Skeleton.Data.FindAnimation(n), "Dog " + n);
            yield return null;
            Assert.AreEqual("General/Standing_Idle", Current);
            yield return Drag();
            Assert.AreEqual("General/Walking", Current);
            yield return MoveMouse(new Vector2(80f, 0f), true);          // 25 u/s > 18: Walk -> Run
            Assert.AreEqual("General/Running", Current);
            yield return MoveMouse(new Vector2(80f, 0f), false);
            Assert.AreEqual("General/Standing_Idle", Current);
        }

        [UnityTest]
        public IEnumerator CatWithoutRunningAnimationsStaysWalking()
        {
            Build("Pet_Cat_Spine", LocomotionFamily.Animal, PostureKind.Standing, false);
            yield return null;
            yield return Drag();
            yield return MoveMouse(new Vector2(80f, 0f), true);
            Assert.AreEqual("General/Walking", Current);
        }
    }
}
#endif
