using UnityEngine;

namespace AvatarWorld.Runtime
{
    /// <summary>
    /// Musica de fundo em loop. HomeManager da level3 serializa _themeSoundName como
    /// On_The_Go_Splash_Screen_Loop; este clip foi mapeado ao arquivo local extraído com esse nome.
    /// </summary>
    public static class BackgroundMusic
    {
        static AudioSource _source;
        static string _currentTrack;
        static bool _muted;
        public static bool IsMuted => _muted;

        /// <summary>Toca em loop; nao reinicia se o mesmo trilho ja estiver tocando (ex.: voltar pra
        /// Home depois de fechar os desafios nao deve cortar a musica e comecar de novo).</summary>
        public static void Play(string resourcePath)
        {
            if (_currentTrack == resourcePath && _source != null && _source.isPlaying) return;

            var clip = Resources.Load<AudioClip>(resourcePath);
            if (clip == null) { Debug.LogWarning("BackgroundMusic: clipe nao encontrado em " + resourcePath); return; }

            if (_source == null)
            {
                var go = new GameObject("BackgroundMusic");
                if (Application.isPlaying) Object.DontDestroyOnLoad(go);
                _source = go.AddComponent<AudioSource>();
                _source.playOnAwake = false;
                _source.loop = true;
                _source.spatialBlend = 0f;
                _source.volume = 0.5f;
                _source.mute = _muted;
            }

            _source.clip = clip;
            _source.mute = _muted;
            _source.Play();
            _currentTrack = resourcePath;
        }

        public static void Stop()
        {
            if (_source != null) _source.Stop();
            _currentTrack = null;
        }

        public static void SetMuted(bool muted)
        {
            _muted = muted;
            if (_source != null) _source.mute = muted;
        }
    }
}
