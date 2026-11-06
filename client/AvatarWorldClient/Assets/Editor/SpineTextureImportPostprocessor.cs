using UnityEditor;
using UnityEngine;

namespace AvatarWorld.EditorTools
{
    /// <summary>
    /// Importacao das paginas de atlas Spine do original (Resources/Spine, tools/import_spine_original.py), so no primeiro import:
    /// sem mipmaps, sem redimensionar paginas NPOT (as regioes do atlas dependem do tamanho exato), bilinear, clamp, alfa como
    /// transparencia, sem leitura pela CPU (o alfa direto e tratado no shader, ver SpineLibrary) e tamanho maximo 8192.
    /// A compressao fica no padrao do Unity (o original usava ETC2/ASTC; o PNG guarda os pixels ja decodificados).
    /// </summary>
    public sealed class SpineTextureImportPostprocessor : AssetPostprocessor
    {
        const string Root = "Assets/Resources/Spine/";

        void OnPreprocessTexture()
        {
            if (!assetPath.StartsWith(Root)) return;
            if (!assetImporter.importSettingsMissing) return;
            var t = (TextureImporter)assetImporter;
            t.textureType = TextureImporterType.Default;
            t.mipmapEnabled = false;
            t.filterMode = FilterMode.Bilinear;
            t.wrapMode = TextureWrapMode.Clamp;
            t.alphaIsTransparency = true;
            t.npotScale = TextureImporterNPOTScale.None;
            t.isReadable = false;
            t.maxTextureSize = 8192;
            t.sRGBTexture = true;
        }
    }
}
