using System.IO;
using UnityEngine;

namespace AvatarWorld.EditorTools
{
    /// <summary>Diagnostico: renderiza um cubo vermelho simples via Camera+RenderTexture pra isolar
    /// se o problema de imagem em branco (205,205,205,205) e geral do pipeline headless ou especifico
    /// do material/shader Spine. unity build . --target Android --execute-method AvatarWorld.EditorTools.RenderSanityProbe.Render</summary>
    public static class RenderSanityProbe
    {
        public static void Render()
        {
            var root = Path.GetFullPath(Path.Combine(Application.dataPath, "../../.."));
            Debug.Log($"RenderSanityProbe: DISPLAY={System.Environment.GetEnvironmentVariable("DISPLAY")} graphicsDeviceType={SystemInfo.graphicsDeviceType} graphicsDeviceName={SystemInfo.graphicsDeviceName} graphicsDeviceVendor={SystemInfo.graphicsDeviceVendor} batchmode={UnityEngine.Application.isBatchMode} supportsRT={SystemInfo.supportsRenderTextures}");
            var cubeGo = GameObject.CreatePrimitive(PrimitiveType.Cube);
            var renderer = cubeGo.GetComponent<Renderer>();
            renderer.material = new Material(Shader.Find("Unlit/Color")) { color = Color.red };
            cubeGo.transform.position = Vector3.zero;

            var cameraGo = new GameObject("SanityCamera");
            var camera = cameraGo.AddComponent<Camera>();
            camera.clearFlags = CameraClearFlags.SolidColor;
            camera.backgroundColor = Color.green;
            camera.cullingMask = ~0;
            cameraGo.transform.position = new Vector3(0, 0, -5f);
            cameraGo.transform.LookAt(Vector3.zero);

            var rt = new RenderTexture(256, 256, 24, RenderTextureFormat.ARGB32);
            camera.targetTexture = rt;
            camera.Render();

            var prev = RenderTexture.active;
            RenderTexture.active = rt;
            var output = new Texture2D(256, 256, TextureFormat.RGBA32, false);
            output.ReadPixels(new Rect(0, 0, 256, 256), 0, 0);
            output.Apply();
            RenderTexture.active = prev;

            var centerPixel = output.GetPixel(128, 128);
            var cornerPixel = output.GetPixel(5, 5);
            Debug.Log($"RenderSanityProbe: centerPixel(deve ser vermelho)={centerPixel} cornerPixel(deve ser verde)={cornerPixel}");

            File.WriteAllBytes(Path.Combine(root, "out/render-sanity-probe.png"), output.EncodeToPNG());

            Object.DestroyImmediate(output);
            rt.Release();
            Object.DestroyImmediate(rt);
            Object.DestroyImmediate(cameraGo);
            Object.DestroyImmediate(cubeGo);
        }
    }
}
