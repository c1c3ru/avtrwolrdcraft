using UnityEngine;

namespace AvatarWorld.Runtime
{
    /// <summary>
    /// Musica de fundo em loop. Nao ha confirmacao de qual clipe o original usa na Home (so um
    /// "PWC.GameMusicMuteButton" foi achado em level3.json, sem referencia ao AudioClip em si - esse
    /// dado nao esta no MonoBehaviour dump). Vacation_Theme_Loop foi escolhida por conteudo (combina
    /// com o banner "ON THE ROAD" da propria Home), nao e um mapeamento confirmado do original.
    /// </summary>
    public static class BackgroundMusic
    {
        static AudioSource _source;
        static string _currentTrack;

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
            }

            _source.clip = clip;
            _source.Play();
            _currentTrack = resourcePath;
        }

        public static void Stop()
        {
            if (_source != null) _source.Stop();
            _currentTrack = null;
        }
    }
}
