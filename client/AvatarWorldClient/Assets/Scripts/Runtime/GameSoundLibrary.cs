using AvatarWorld.Core.Audio;
using UnityEngine;

namespace AvatarWorld.Runtime
{
    /// <summary>Carrega Resources/Sound/sound-registry.json e entrega AudioClips por nome (Resources.Load pelo caminho do registro).</summary>
    public static class GameSoundLibrary
    {
        const string RegistryPath = "Sound/sound-registry";
        static SoundRegistry _registry;

        public static SoundRegistry Registry
        {
            get
            {
                if (_registry != null) return _registry;
                var text = Resources.Load<TextAsset>(RegistryPath);
                if (text == null)
                {
                    Debug.LogError("GameSoundLibrary: " + RegistryPath + " nao encontrado");
                    return null;
                }
                _registry = new SoundRegistry(JsonUtility.FromJson<SoundRegistryData>(text.text));
                return _registry;
            }
        }

        /// <summary>Clipe pelo nome do registro (aceita pasta, extensao e pares; devolve o primeiro que resolver).</summary>
        public static AudioClip GetClip(string soundName)
        {
            var registry = Registry;
            if (registry == null) return null;
            foreach (var entry in registry.Resolve(soundName))
            {
                var clip = Resources.Load<AudioClip>(entry.resourcePath);
                if (clip != null) return clip;
                Debug.LogError("GameSoundLibrary: clipe ausente em Resources: " + entry.resourcePath);
            }
            return null;
        }

        public static void Reset() { _registry = null; }
    }
}
