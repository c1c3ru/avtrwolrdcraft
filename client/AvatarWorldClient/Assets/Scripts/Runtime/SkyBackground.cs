using System;
using AvatarWorld.Core.World;
using UnityEngine;

namespace AvatarWorld.Runtime
{
    /// <summary>
    /// Gradiente do ceu do mapa: um quad atras de tudo, preso a camera, com uma textura vertical regerada quando o
    /// clima ou a hora muda. Cores/parametros do BackgroundSky do original; horarios e curva sao aproximacoes
    /// (ver SkyGradient). Sem o sky.json mantem a cor lisa da camera.
    /// </summary>
    public sealed class SkyBackground : MonoBehaviour
    {
        const int Steps = 64;
        const float RefreshSeconds = 5f;

        Camera _camera;
        SkyFile _file;
        SpriteRenderer _renderer;
        Texture2D _texture;
        Func<int> _weather;
        int _lastWeather = int.MinValue;
        int _lastMinute = -1;
        float _nextCheck;

        public static SkyBackground Attach(Camera camera, Func<int> weather)
        {
            var json = Resources.Load<TextAsset>("WorldSlice/sky");
            if (json == null) return null;
            var go = new GameObject("SkyBackground");
            go.transform.SetParent(camera.transform, false);
            go.transform.localPosition = new Vector3(0f, 0f, 20f);
            var sky = go.AddComponent<SkyBackground>();
            sky._camera = camera;
            sky._weather = weather;
            sky._file = JsonUtility.FromJson<SkyFile>(json.text);
            sky._texture = new Texture2D(1, Steps, TextureFormat.RGBA32, false) { wrapMode = TextureWrapMode.Clamp, filterMode = FilterMode.Bilinear };
            sky._renderer = go.AddComponent<SpriteRenderer>();
            sky._renderer.sortingOrder = -30000;
            sky._renderer.sprite = Sprite.Create(sky._texture, new Rect(0, 0, 1, Steps), new Vector2(0.5f, 0.5f), 1f);
            sky.Refresh();
            return sky;
        }

        void OnDestroy() { if (_texture != null) Destroy(_texture); }

        void LateUpdate()
        {
            // Cobre a vista inteira mesmo se a proporcao da tela mudar.
            float h = _camera.orthographicSize * 2f + 2f;
            float w = h * _camera.aspect + 2f;
            transform.localScale = new Vector3(w, h / Steps, 1f);
            if (Time.unscaledTime < _nextCheck) return;
            _nextCheck = Time.unscaledTime + RefreshSeconds;
            Refresh();
        }

        void Refresh()
        {
            int weather = _weather != null ? _weather() : WorldWeather.Clear;
            var now = DateTime.Now;
            int minute = now.Hour * 60 + now.Minute;
            if (weather == _lastWeather && minute == _lastMinute) return;
            _lastWeather = weather; _lastMinute = minute;
            var config = _file.For(weather) ?? _file.For(WorldWeather.Clear);
            if (config == null) return;
            SkyGradient.ColorsAt(config, now.Hour + now.Minute / 60f, out var top, out var bottom);
            var pixels = new Color32[Steps];
            for (int i = 0; i < Steps; i++)
            {
                var c = SkyGradient.Mix(top, bottom, i / (float)(Steps - 1), config.Smoothness, config.Middle);
                pixels[i] = new Color32((byte)(c.R * 255f + 0.5f), (byte)(c.G * 255f + 0.5f), (byte)(c.B * 255f + 0.5f), 255);
            }
            _texture.SetPixels32(pixels);
            _texture.Apply(false);
        }
    }
}
