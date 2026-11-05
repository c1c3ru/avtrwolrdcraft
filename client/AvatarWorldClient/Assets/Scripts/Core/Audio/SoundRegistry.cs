using System;
using System.Collections.Generic;

namespace AvatarWorld.Core.Audio
{
    /// <summary>Entrada do registro de sons (tools/import_audio_original.py). Campos publicos para JsonUtility.</summary>
    [Serializable]
    public class SoundEntry
    {
        public string name;          // nome no PazuCore.AudioClipPaths do original
        public string path;          // caminho original no registro (ex.: "Sound/SFX/Name")
        public string resourcePath;  // caminho de Resources.Load no cliente (sem extensao)
        public string format;        // "original-vorbis" ou "flac-of-decoded-pcm"
        public int channels;
        public int frequency;
        public float length;         // segundos, do AudioClip original
        public int bytes;
    }

    [Serializable]
    public class SoundRegistryData
    {
        public SoundEntry[] entries;
    }

    /// <summary>
    /// Registro de sons por nome, como o do original (PazuCore.AudioClipPaths): o jogo toca por nome e resolve o caminho aqui.
    /// Nomes de handlers do original podem trazer pasta, extensao (.wav/.mp3/.ogg) ou pares "A^B" (ex.: ligar/desligar).
    /// </summary>
    public sealed class SoundRegistry
    {
        readonly Dictionary<string, SoundEntry> _byName = new Dictionary<string, SoundEntry>(StringComparer.OrdinalIgnoreCase);

        public SoundRegistry(SoundRegistryData data)
        {
            if (data == null || data.entries == null) return;
            foreach (var e in data.entries)
                if (e != null && !string.IsNullOrEmpty(e.name) && !_byName.ContainsKey(e.name)) _byName.Add(e.name, e);
        }

        public int Count { get { return _byName.Count; } }

        public IEnumerable<SoundEntry> All { get { return _byName.Values; } }

        public bool TryGet(string name, out SoundEntry entry)
        {
            entry = null;
            return !string.IsNullOrEmpty(name) && _byName.TryGetValue(name, out entry);
        }

        /// <summary>Quebra um nome de handler em candidatos: separa por '^', ';' e '|', tira pasta e extensao.</summary>
        public static IEnumerable<string> Tokens(string soundName)
        {
            if (string.IsNullOrEmpty(soundName)) yield break;
            foreach (var part in soundName.Split('^', ';', '|'))
            {
                string p = part.Trim().Replace('\\', '/');
                int slash = p.LastIndexOf('/');
                if (slash >= 0) p = p.Substring(slash + 1);
                foreach (var ext in new[] { ".wav", ".mp3", ".ogg" })
                    if (p.EndsWith(ext, StringComparison.OrdinalIgnoreCase)) { p = p.Substring(0, p.Length - ext.Length); break; }
                if (p.Length > 0) yield return p;
            }
        }

        /// <summary>Entradas resolvidas de um nome de handler, na ordem dos tokens; tokens sem som no registro sao ignorados.</summary>
        public IEnumerable<SoundEntry> Resolve(string soundName)
        {
            foreach (var t in Tokens(soundName))
            {
                SoundEntry e;
                if (_byName.TryGetValue(t, out e)) yield return e;
            }
        }
    }
}
