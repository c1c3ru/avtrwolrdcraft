using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace AvatarWorld.Runtime
{
    /// <summary>
    /// Tela de loading do original (LoadingScreenScreen, sharedassets1): fundo em degradê amarelo
    /// (LoadingScreenBackground: _BottomColor/_TopColor), avatar abraçando o gato no centro, relógio
    /// com ponteiros girando no canto inferior direito e o LoadingCircle. Arte em Resources/Loading.
    /// A ancoragem do circulo e o pivo dos ponteiros nao foram decodificados: sao aproximados.
    /// </summary>
    public sealed class LoadingScreen : MonoBehaviour
    {
        const string Res = "Loading/";
        const float Scale = 1.6f; // referencia 2048x1024; o original mostra a arte maior que o tamanho nativo
        const float FadeOut = 0.2f;

        static LoadingScreen _instance;

        CanvasGroup _group;
        RectTransform _circle, _hours, _minutes;
        float _shownAt;
        Coroutine _hiding;

        /// <summary>Cobre a tela imediatamente. Chamar Hide quando o trabalho terminar.</summary>
        public static void Show()
        {
            if (_instance == null)
            {
                var go = new GameObject("LoadingScreen");
                DontDestroyOnLoad(go);
                _instance = go.AddComponent<LoadingScreen>();
                _instance.Build();
            }
            _instance.Present();
        }

        /// <summary>Some depois de ficar visivel por pelo menos minVisible segundos (evita piscar).</summary>
        public static void Hide(float minVisible = 0.6f)
        {
            if (_instance != null) _instance.BeginHide(minVisible);
        }

        void Present()
        {
            if (_hiding != null) { StopCoroutine(_hiding); _hiding = null; }
            gameObject.SetActive(true);
            _group.alpha = 1f;
            _group.blocksRaycasts = true;
            _shownAt = Time.unscaledTime;
        }

        void BeginHide(float minVisible)
        {
            if (!gameObject.activeSelf) return;
            if (_hiding != null) StopCoroutine(_hiding);
            _hiding = StartCoroutine(HideRoutine(minVisible));
        }

        IEnumerator HideRoutine(float minVisible)
        {
            while (Time.unscaledTime - _shownAt < minVisible) yield return null;
            for (float t = 0f; t < FadeOut; t += Time.unscaledDeltaTime)
            {
                _group.alpha = 1f - t / FadeOut;
                yield return null;
            }
            _group.alpha = 0f;
            _group.blocksRaycasts = false;
            _hiding = null;
            gameObject.SetActive(false);
        }

        void Update()
        {
            float t = Time.unscaledTime;
            if (_circle != null) _circle.localRotation = Quaternion.Euler(0, 0, -t * 270f);
            if (_minutes != null) _minutes.localRotation = Quaternion.Euler(0, 0, -t * 360f);
            if (_hours != null) _hours.localRotation = Quaternion.Euler(0, 0, -t * 30f);
        }

        void Build()
        {
            UiSceneBuilder.EnsureEventSystem();
            var canvasGo = gameObject;
            var rootRect = canvasGo.AddComponent<RectTransform>();
            var canvas = canvasGo.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.overrideSorting = true;
            canvas.sortingOrder = 2000;
            var scaler = canvasGo.AddComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(2048f, 1024f);
            scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
            canvasGo.AddComponent<GraphicRaycaster>();
            _group = canvasGo.AddComponent<CanvasGroup>();

            Stretch(Child("Background", rootRect), Vector2.zero, Vector2.one);
            var bg = rootRect.Find("Background").gameObject.AddComponent<RawImage>();
            bg.texture = Gradient(new Color(0.996f, 0.682f, 0.078f), new Color(1f, 0.855f, 0.098f));

            var character = Sprite("Character", rootRect, "character", new Vector2(0.5f, 0.5f), new Vector2(-20.5f, 0f) * Scale);
            character.sizeDelta *= Scale;

            // ClockBody: ancora (1,0), posicao (-178.5, 166), 210x219; ponteiros/nariz em (0,-11.5) do corpo.
            var clock = Sprite("ClockBody", rootRect, "clock_body", new Vector2(1f, 0f), new Vector2(-178.5f, 166f) * Scale);
            clock.sizeDelta *= Scale;
            _hours = Hand(clock, "ClockHours", "clock_hours");
            _minutes = Hand(clock, "ClockMinutes", "clock_minutes");
            var nose = Sprite("ClockNose", clock, "clock_nose", new Vector2(0.5f, 0.5f), new Vector2(0f, -11.5f) * Scale);
            nose.sizeDelta *= Scale;

            // Posicao do circulo nao decodificada: embaixo, centralizado.
            _circle = Sprite("LoadingCircle", rootRect, "loading_circle", new Vector2(0.5f, 0f), new Vector2(0f, 60f));
            _circle.sizeDelta *= 0.6f;
        }

        RectTransform Hand(RectTransform clock, string name, string res)
        {
            var rect = Sprite(name, clock, res, new Vector2(0.5f, 0.5f), new Vector2(0f, -11.5f) * Scale);
            rect.sizeDelta *= Scale;
            rect.pivot = new Vector2(0.5f, 0.1f); // gira em torno da base do ponteiro (aproximado)
            return rect;
        }

        static RectTransform Child(string name, RectTransform parent)
        {
            var go = new GameObject(name, typeof(RectTransform));
            go.transform.SetParent(parent, false);
            return (RectTransform)go.transform;
        }

        static void Stretch(RectTransform rect, Vector2 min, Vector2 max)
        {
            rect.anchorMin = min; rect.anchorMax = max;
            rect.offsetMin = rect.offsetMax = Vector2.zero;
        }

        static RectTransform Sprite(string name, RectTransform parent, string res, Vector2 anchor, Vector2 position)
        {
            var rect = Child(name, parent);
            rect.anchorMin = rect.anchorMax = anchor;
            rect.pivot = new Vector2(0.5f, 0.5f);
            rect.anchoredPosition = position;
            var image = rect.gameObject.AddComponent<Image>();
            image.raycastTarget = false;
            var tex = Resources.Load<Texture2D>(Res + res);
            if (tex != null)
            {
                image.sprite = UnityEngine.Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100f);
                rect.sizeDelta = new Vector2(tex.width, tex.height);
            }
            else Debug.LogWarning("LoadingScreen: textura ausente " + res);
            return rect;
        }

        static Texture2D Gradient(Color bottom, Color top)
        {
            const int h = 64;
            var tex = new Texture2D(1, h, TextureFormat.RGBA32, false) { wrapMode = TextureWrapMode.Clamp, filterMode = FilterMode.Bilinear };
            for (int y = 0; y < h; y++) tex.SetPixel(0, y, Color.Lerp(bottom, top, y / (h - 1f)));
            tex.Apply();
            return tex;
        }
    }
}
