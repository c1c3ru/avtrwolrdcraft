using UnityEngine;

namespace AvatarWorld.Runtime
{
    /// <summary>
    /// Efeitos sonoros de UI. Clipes reaproveitados do jogo original (Resources/Audio),
    /// nao gerados do zero: click/correct/wrong/coin ja existiam no pacote de audio extraido.
    /// </summary>
    public static class UiSound
    {
        static AudioSource _source;

        static AudioSource Source
        {
            get
            {
                if (_source != null) return _source;
                var go = new GameObject("UiSound");
                // DontDestroyOnLoad so e valido em Play mode; testes de EditMode simulam onClick
                // diretamente (sem rodar o jogo) e essa chamada lancaria InvalidOperationException ali.
                if (Application.isPlaying) Object.DontDestroyOnLoad(go);
                _source = go.AddComponent<AudioSource>();
                _source.playOnAwake = false;
                // AudioSource criado por script comeca com spatialBlend=1 (3D) por padrao, mesmo com
                // o clipe importado como 2D - sem isso o som atenua por distancia do AudioListener
                // de forma imprevisivel (a UI nao tem posicao no espaco).
                _source.spatialBlend = 0f;
                return _source;
            }
        }

        public static void PlayClick() => Play("Audio/click");
        public static void PlayCorrect() => Play("Audio/correct");
        public static void PlayWrong() => Play("Audio/wrong");
        public static void PlayCoin() => Play("Audio/coin");

        static void Play(string resourcePath)
        {
            var clip = Resources.Load<AudioClip>(resourcePath);
            if (clip == null) { Debug.LogWarning("UiSound: clipe nao encontrado em " + resourcePath); return; }
            Source.PlayOneShot(clip);
        }
    }
}
