using UnityEditor;

namespace AvatarWorld.EditorTools
{
    /// <summary>
    /// As texturas de roupa/corpo do avatar sao lidas em runtime (AvatarGpuRuntime.PremultipliedCopy usa GetPixels32),
    /// entao precisam de Read/Write. Sem isto o editor funciona (le qualquer textura) e o aparelho falha com
    /// "texture data is either not readable". tools/avatar_catalog_build.py copia PNGs novos para essas pastas.
    /// </summary>
    public sealed class ClothingTextureImporter : AssetPostprocessor
    {
        const string ClothingFolder = "Assets/Resources/AvatarSpine/Clothing/";
        const string BodyFolder = "Assets/Resources/AvatarSpine/Textures/";

        void OnPreprocessTexture()
        {
            if (!assetPath.StartsWith(ClothingFolder) && !assetPath.StartsWith(BodyFolder)) return;
            var importer = (TextureImporter)assetImporter;
            if (!importer.isReadable) importer.isReadable = true;
        }
    }
}
