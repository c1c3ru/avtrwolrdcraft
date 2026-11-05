using UnityEditor;
using UnityEngine;

namespace AvatarWorld.EditorTools
{
    /// <summary>
    /// Configuracoes de importacao dos sons do original (tools/import_audio_original.py), aplicadas so no primeiro import
    /// para nao sobrescrever ajustes manuais:
    /// - Music e Ambience: Streaming (faixas longas), Vorbis qualidade maxima;
    /// - SFX: Decompress On Load, Vorbis qualidade maxima;
    /// - .flac (clipes cujo header Vorbis nao foi recuperavel): PCM, para nao recodificar com perda.
    /// O repositorio guarda o fluxo Vorbis original sem recodificar; o Unity recodifica no build (uma geracao a qualidade maxima).
    /// </summary>
    public sealed class SoundImportPostprocessor : AssetPostprocessor
    {
        const string SoundRoot = "Assets/Resources/Sound/";
        const string PazuRoot = "Assets/Resources/PazuCore/Sound/";

        void OnPreprocessAudio()
        {
            if (!assetPath.StartsWith(SoundRoot) && !assetPath.StartsWith(PazuRoot)) return;
            if (!assetImporter.importSettingsMissing) return;
            var importer = (AudioImporter)assetImporter;
            bool longTrack = assetPath.Contains("/Music/") || assetPath.Contains("/Ambience/");
            var settings = importer.defaultSampleSettings;
            settings.loadType = longTrack ? AudioClipLoadType.Streaming : AudioClipLoadType.DecompressOnLoad;
            settings.compressionFormat = assetPath.EndsWith(".flac") ? AudioCompressionFormat.PCM : AudioCompressionFormat.Vorbis;
            settings.quality = 1f;
            settings.preloadAudioData = !longTrack;
            importer.defaultSampleSettings = settings;
        }
    }
}
