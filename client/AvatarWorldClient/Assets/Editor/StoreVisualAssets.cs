using System;
using System.IO;
using System.Reflection;
using AvatarWorld.Core.Economy;
using AvatarWorld.Runtime;
using UnityEditor;
using UnityEngine;

namespace AvatarWorld.EditorTools
{
    public static class StoreVisualAssets
    {
        public static void RenderScreens()
        {
            var host = new GameObject("StoreScreenshot", typeof(RectTransform));
            var cameraHost = new GameObject("StoreScreenshotCamera", typeof(Camera));
            var target = new RenderTexture(1600, 800, 24);
            var pixels = new Texture2D(1600, 800, TextureFormat.RGBA32, false);
            var previous = RenderTexture.active;
            try
            {
                var state = PlayerState.CreateNew(75);
                var view = host.AddComponent<StoreVisualView>();
                view.Initialize(state, new OfflineHomeService(state, () => { }), () => { }, () => { }, () => { });
                var camera = cameraHost.GetComponent<Camera>();
                camera.clearFlags = CameraClearFlags.SolidColor;
                camera.backgroundColor = Color.black;
                camera.targetTexture = target;
                var canvas = host.GetComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceCamera;
                canvas.worldCamera = camera;
                canvas.planeDistance = 1;
                string output = Path.GetFullPath(Path.Combine(Application.dataPath, "../../../out"));
                Directory.CreateDirectory(output);
                foreach (string page in new[] { "shop", "gifts", "pass" })
                {
                    view.Show(page);
                    Canvas.ForceUpdateCanvases();
                    camera.Render();
                    RenderTexture.active = target;
                    pixels.ReadPixels(new Rect(0, 0, 1600, 800), 0, 0);
                    pixels.Apply();
                    File.WriteAllBytes(Path.Combine(output, "store-visual-" + page + ".png"), pixels.EncodeToPNG());
                }
                camera.targetTexture = null;
            }
            finally
            {
                RenderTexture.active = previous;
                UnityEngine.Object.DestroyImmediate(host);
                UnityEngine.Object.DestroyImmediate(cameraHost);
                UnityEngine.Object.DestroyImmediate(target);
                UnityEngine.Object.DestroyImmediate(pixels);
            }
        }

        public static void RenderPreviews()
        {
            string folder = "Assets/Resources/StoreVisual";
            Directory.CreateDirectory(folder);
            for (int index = 0; index < 3; index++)
            {
                var state = PlayerState.CreateNew(100);
                new OfflineHomeService(state, () => { }).Outfit(index);
                var host = new GameObject("StorePreview");
                var camGo = new GameObject("PreviewCamera", typeof(Camera));
                var target = new RenderTexture(512, 640, 24);
                var pixels = new Texture2D(512, 640, TextureFormat.RGBA32, false);
                var previous = RenderTexture.active;
                try
                {
                    var avatar = host.AddComponent<AvatarGpuRuntime>();
                    avatar.ConfigureAsWorldAvatar(new SaveStore(Path.Combine(Path.GetTempPath(), "unused-store-preview.json")), state, Vector3.zero, 1);
                    typeof(AvatarGpuRuntime).GetMethod("Start", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(avatar, null);
                    foreach (var t in host.GetComponentsInChildren<Transform>()) t.gameObject.layer = 30;
                    var renderer = host.GetComponentInChildren<MeshRenderer>();
                    if (renderer == null) throw new InvalidOperationException("Avatar preview did not render");
                    var camera = camGo.GetComponent<Camera>();
                    camera.orthographic = true;
                    camera.cullingMask = 1 << 30;
                    camera.clearFlags = CameraClearFlags.SolidColor;
                    camera.backgroundColor = Color.clear;
                    camera.orthographicSize = renderer.bounds.extents.y * 1.12f;
                    camera.transform.position = new Vector3(renderer.bounds.center.x, renderer.bounds.center.y, -10);
                    camera.targetTexture = target;
                    camera.Render();
                    RenderTexture.active = target;
                    pixels.ReadPixels(new Rect(0, 0, 512, 640), 0, 0);
                    pixels.Apply();
                    File.WriteAllBytes(folder + "/outfit-" + index + ".png", pixels.EncodeToPNG());
                    camera.targetTexture = null;
                }
                finally
                {
                    RenderTexture.active = previous;
                    UnityEngine.Object.DestroyImmediate(camGo);
                    UnityEngine.Object.DestroyImmediate(host);
                    UnityEngine.Object.DestroyImmediate(target);
                    UnityEngine.Object.DestroyImmediate(pixels);
                }
            }
            AssetDatabase.Refresh();
            foreach (var file in Directory.GetFiles(folder, "*.png"))
            {
                var importer = (TextureImporter)AssetImporter.GetAtPath(file);
                importer.textureType = TextureImporterType.Sprite;
                importer.spriteImportMode = SpriteImportMode.Single;
                importer.alphaIsTransparency = true;
                importer.mipmapEnabled = false;
                importer.SaveAndReimport();
            }
            Debug.Log("StoreVisualAssets: 3 previews generated from original Spine assets");
        }
    }
}
