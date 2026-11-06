using System;
using System.Collections.Generic;
using AvatarWorld.Core.Economy;
using UnityEngine;
using UnityEngine.UI;

namespace AvatarWorld.Runtime
{
    /// <summary>
    /// Mapa World do original (level4) como cena jogavel offline: arte e posicoes extraidas
    /// (Resources/WorldSlice, tools/export_world_map.py), camera que rola ao arrastar, toque nos
    /// predios. Por enquanto so a quadra de basquete (MiniBasketball_L1) abre uma sala; predios em
    /// obras ou sem cena mostram um aviso neutro. Nao reproduz scripts do original (clima, luz).
    /// </summary>
    public sealed class WorldMapRuntime : MonoBehaviour
    {
        const string DataResource = "WorldSlice/world";
        const string SpritePrefix = "WorldSlice/sprites/";
        const float TapMaxPixels = 18f;
        const float TapMaxSeconds = 0.45f;

        Action _onBack;
        Action _onOpenBasketball;
        Action _onOpenSlots;
        Camera _camera;
        WorldMapData _data;
        RectTransform _backRect;
        Text _toast;
        float _toastUntil;
        bool _pressing;
        Vector2 _pressStart, _lastPos;
        float _pressTime;
        bool _movedTooFar;
        bool _opening;
        int _weather;
        WorldMapMotion _motion;
        readonly List<SpriteRenderer> _weatherRenderers = new List<SpriteRenderer>();
        readonly List<int> _weatherRendererIndex = new List<int>();
        readonly List<RectTransform> _uiRects = new List<RectTransform>();
        readonly Dictionary<int, RectTransform> _weatherIcons = new Dictionary<int, RectTransform>();
        RectTransform _weatherPill;
        readonly Dictionary<string, Sprite> _uiSprites = new Dictionary<string, Sprite>();
        const int SpritesPerFrame = 24;
        readonly Dictionary<string, Texture2D> _textures = new Dictionary<string, Texture2D>();

        public WorldMapData Data => _data;
        public Camera MapCamera => _camera;

        /// <summary>Monta o mapa em varios quadros; onReady dispara quando tudo esta pronto (esconde o loading).</summary>
        public void Begin(Action onBack, Action onOpenBasketball, Action onReady = null, Action onOpenSlots = null)
        {
            _onOpenSlots = onOpenSlots;
            _onBack = onBack;
            _onOpenBasketball = onOpenBasketball;
            var json = Resources.Load<TextAsset>(DataResource);
            if (json == null) throw new InvalidOperationException("WorldSlice/world.json ausente em Resources");
            _data = JsonUtility.FromJson<WorldMapData>(json.text);
            _weather = LoadWeather();
            BuildCamera();
            BuildOverlay();
            StartCoroutine(BuildSprites(onReady));
        }

        void BuildCamera()
        {
            _camera = new GameObject("WorldCamera", typeof(Camera)).GetComponent<Camera>();
            _camera.transform.SetParent(transform, false);
            _camera.tag = "MainCamera";
            _camera.orthographic = true;
            _camera.orthographicSize = _data.camera.orthoSize;
            _camera.clearFlags = CameraClearFlags.SolidColor;
            _camera.backgroundColor = new Color(0.97f, 0.78f, 0.82f);
            _camera.transform.position = new Vector3(ClampX(_data.camera.startX), _data.camera.startY, -10f);
        }

        float HalfWidth => _camera.orthographicSize * _camera.aspect;

        float ClampX(float x)
        {
            float half = _camera != null ? HalfWidth : 11f;
            float min = _data.camera.minX + half, max = _data.camera.maxX - half;
            return min > max ? (min + max) * 0.5f : Mathf.Clamp(x, min, max);
        }

        System.Collections.IEnumerator BuildSprites(Action onReady)
        {
            var sprites = new Dictionary<string, Sprite>();
            var byName = new Dictionary<string, List<GameObject>>();
            int built = 0;
            foreach (var r in _data.renderers)
            {
                if (++built % SpritesPerFrame == 0) yield return null;
                string key = r.sprite + "|" + r.pivotX + "|" + r.pivotY + "|" + r.ppu;
                if (!sprites.TryGetValue(key, out var sprite))
                {
                    if (!_textures.TryGetValue(r.sprite, out var tex))
                    {
                        tex = Resources.Load<Texture2D>(SpritePrefix + r.sprite);
                        _textures[r.sprite] = tex;
                    }
                    if (tex == null) { Debug.LogWarning("WorldMap: sprite ausente " + r.sprite); continue; }
                    sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(r.pivotX, r.pivotY), r.ppu);
                    sprites[key] = sprite;
                }
                var go = new GameObject(r.go);
                go.transform.SetParent(transform, false);
                if (!byName.TryGetValue(r.go, out var named)) byName[r.go] = named = new List<GameObject>();
                named.Add(go);
                go.transform.position = new Vector3(r.x, r.y, 0f);
                go.transform.rotation = Quaternion.Euler(0, 0, r.rot * Mathf.Rad2Deg);
                go.transform.localScale = new Vector3(Mathf.Abs(r.sx), Mathf.Abs(r.sy), 1f);
                var renderer = go.AddComponent<SpriteRenderer>();
                renderer.sprite = sprite;
                renderer.sortingOrder = r.rank;
                renderer.flipX = r.flipX != (r.sx < 0f);
                renderer.flipY = r.flipY != (r.sy < 0f);
                renderer.color = new Color(r.color[0], r.color[1], r.color[2], r.color[3]);
                if (r.weathers != null && r.weathers.Length > 0)
                {
                    _weatherRenderers.Add(renderer);
                    _weatherRendererIndex.Add(built - 1);
                }
            }
            ApplyWeather(_weather);
            _motion = gameObject.AddComponent<WorldMapMotion>();
            _motion.Begin(_data, _weather, byName);
            Debug.Log("WorldMap: " + _data.renderers.Count + " elementos, " + _data.buildings.Count + " predios");
            onReady?.Invoke();
        }

        void BuildOverlay()
        {
            UiSceneBuilder.EnsureEventSystem();
            var root = new GameObject("WorldOverlay", typeof(RectTransform), typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
            root.transform.SetParent(transform, false);
            var canvas = root.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.overrideSorting = true;
            canvas.sortingOrder = 600;
            var scaler = root.GetComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(2048f, 1024f);
            scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;

            // Botao voltar do mapa original (BackButton, 146x143, ancorado no canto superior esquerdo).
            var tex = Resources.Load<Texture2D>("WorldSlice/back_button");
            var back = new GameObject("BackButton", typeof(RectTransform), typeof(Image), typeof(Button));
            back.transform.SetParent(root.transform, false);
            _backRect = (RectTransform)back.transform;
            _backRect.anchorMin = _backRect.anchorMax = new Vector2(0, 1);
            _backRect.pivot = new Vector2(0.5f, 0.5f);
            _backRect.anchoredPosition = new Vector2(92.5f, -91f);
            _backRect.sizeDelta = new Vector2(146f, 143f);
            var image = back.GetComponent<Image>();
            if (tex != null) image.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100f);
            back.GetComponent<Button>().targetGraphic = image;
            back.GetComponent<Button>().onClick.AddListener(() => { if (_opening) return; UiSound.PlayClick(); _onBack?.Invoke(); });

            var toast = new GameObject("Toast", typeof(RectTransform), typeof(Text));
            toast.transform.SetParent(root.transform, false);
            var rect = (RectTransform)toast.transform;
            rect.anchorMin = new Vector2(0.15f, 0.05f);
            rect.anchorMax = new Vector2(0.85f, 0.16f);
            rect.offsetMin = rect.offsetMax = Vector2.zero;
            _toast = toast.GetComponent<Text>();
            _toast.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            _toast.fontSize = 44;
            _toast.alignment = TextAnchor.MiddleCenter;
            _toast.color = Color.white;
            _toast.raycastTarget = false;
            var shadow = toast.AddComponent<Outline>();
            shadow.effectColor = new Color(0.2f, 0.1f, 0.3f, 1f);
            _toast.enabled = false;

            BuildTopBar(root.transform);
        }

        static int LoadWeather()
        {
            try
            {
                int saved = PlayerPrefs.GetInt(WorldWeather.PrefsKey, WorldWeather.Clear);
                return WorldWeather.IsSupported(saved) ? saved : WorldWeather.Clear;
            }
            catch (Exception) { return WorldWeather.Clear; }
        }

        ParticleSystem _precip;
        Texture2D _dotTexture;

        static Texture2D MakeDot()
        {
            const int n = 32;
            var t = new Texture2D(n, n, TextureFormat.RGBA32, false) { wrapMode = TextureWrapMode.Clamp };
            for (int y = 0; y < n; y++)
                for (int x = 0; x < n; x++)
                {
                    float d = Vector2.Distance(new Vector2(x, y), new Vector2(n / 2f - 0.5f, n / 2f - 0.5f)) / (n / 2f);
                    t.SetPixel(x, y, new Color(1, 1, 1, Mathf.Clamp01(1.4f - d * 1.4f)));
                }
            t.Apply();
            return t;
        }

        // Chuva/neve caindo sobre a area visivel (sistema de particulas preso a camera).
        void UpdatePrecipitation(int weather)
        {
            if (_camera == null) return;
            if (_precip == null)
            {
                var go = new GameObject("WeatherParticles", typeof(ParticleSystem));
                go.transform.SetParent(_camera.transform, false);
                float h = _camera.orthographicSize;
                go.transform.localPosition = new Vector3(0f, h + 0.5f, 5f);
                go.transform.localRotation = Quaternion.identity;
                _precip = go.GetComponent<ParticleSystem>();
                var r = go.GetComponent<ParticleSystemRenderer>();
                _dotTexture = MakeDot();
                var shader = Shader.Find("Sprites/Default");
                r.material = new Material(shader) { mainTexture = _dotTexture };
                r.sortingOrder = 500;
                var shape = _precip.shape;
                shape.shapeType = ParticleSystemShapeType.Box;
                shape.scale = new Vector3(HalfWidth * 2f + 4f, 0.1f, 0.1f);
                var main0 = _precip.main;
                main0.simulationSpace = ParticleSystemSimulationSpace.World;
            }
            var main = _precip.main;
            var emission = _precip.emission;
            var rend = _precip.GetComponent<ParticleSystemRenderer>();
            if (weather == WorldWeather.Rain)
            {
                main.startLifetime = 0.9f;
                main.startSpeed = 0f;
                main.startSize = 0.09f;
                main.startColor = new Color(0.75f, 0.85f, 1f, 0.75f);
                main.maxParticles = 1500;
                var vel = _precip.velocityOverLifetime;
                vel.enabled = true;
                vel.space = ParticleSystemSimulationSpace.World;
                vel.x = new ParticleSystem.MinMaxCurve(-1.5f);
                vel.y = new ParticleSystem.MinMaxCurve(-13f);
                vel.z = new ParticleSystem.MinMaxCurve(0f);
                emission.rateOverTime = 260f;
                rend.renderMode = ParticleSystemRenderMode.Stretch;
                rend.lengthScale = 6f; rend.velocityScale = 0.06f;
                if (!_precip.isPlaying) _precip.Play();
            }
            else if (weather == WorldWeather.Snow)
            {
                main.startLifetime = 5f;
                main.startSpeed = 0f;
                main.startSize = new ParticleSystem.MinMaxCurve(0.08f, 0.2f);
                main.startColor = new Color(1f, 1f, 1f, 0.95f);
                main.maxParticles = 800;
                var vel = _precip.velocityOverLifetime;
                vel.enabled = true;
                vel.space = ParticleSystemSimulationSpace.World;
                vel.x = new ParticleSystem.MinMaxCurve(-0.6f, 0.6f);
                vel.y = new ParticleSystem.MinMaxCurve(-1.6f, -0.9f);
                vel.z = new ParticleSystem.MinMaxCurve(0f, 0f);
                emission.rateOverTime = 110f;
                rend.renderMode = ParticleSystemRenderMode.Billboard;
                if (!_precip.isPlaying) _precip.Play();
            }
            else
            {
                _precip.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            }
            if (_camera != null)
                _camera.backgroundColor = weather == WorldWeather.Rain ? new Color(0.62f, 0.66f, 0.78f)
                    : weather == WorldWeather.Snow ? new Color(0.85f, 0.9f, 0.98f) : new Color(0.97f, 0.78f, 0.82f);
        }

        void ApplyWeather(int weather)
        {
            _weather = weather;
            UpdatePrecipitation(weather);
            if (_motion != null) _motion.SetWeather(weather);
            for (int i = 0; i < _weatherRenderers.Count; i++)
                _weatherRenderers[i].enabled = _data.renderers[_weatherRendererIndex[i]].VisibleIn(weather);
            foreach (var pair in _weatherIcons)
            {
                bool selected = pair.Key == weather;
                pair.Value.localScale = Vector3.one * (selected ? 1.3f : 0.95f);
                pair.Value.GetComponent<Image>().color = selected ? Color.white : new Color(1f, 1f, 1f, 0.7f);
            }
        }

        void SetWeather(int weather)
        {
            if (weather == _weather) return;
            ApplyWeather(weather);
            try { PlayerPrefs.SetInt(WorldWeather.PrefsKey, weather); PlayerPrefs.Save(); } catch (Exception) { }
        }

        Sprite UiSprite(string name, Vector4 border = default)
        {
            if (_uiSprites.TryGetValue(name, out var cached)) return cached;
            var tex = Resources.Load<Texture2D>("WorldSlice/ui/" + name);
            if (tex == null) { Debug.LogWarning("WorldMap: arte de UI ausente " + name); return null; }
            var sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100f, 0,
                SpriteMeshType.FullRect, border);
            _uiSprites[name] = sprite;
            return sprite;
        }

        RectTransform MakeUiButton(Transform parent, string name, string art, Vector2 anchor, Vector2 pivot, Vector2 position,
            Vector2 size, Action onClick, Vector4 border = default)
        {
            var go = new GameObject(name, typeof(RectTransform), typeof(Image), typeof(Button));
            go.transform.SetParent(parent, false);
            var rect = (RectTransform)go.transform;
            rect.anchorMin = rect.anchorMax = anchor;
            rect.pivot = pivot;
            rect.anchoredPosition = position;
            rect.sizeDelta = size;
            var image = go.GetComponent<Image>();
            image.sprite = UiSprite(art, border);
            if (border != default) image.type = Image.Type.Sliced;
            go.GetComponent<Button>().targetGraphic = image;
            if (onClick != null) go.GetComponent<Button>().onClick.AddListener(() => { UiSound.PlayClick(); onClick(); });
            else image.raycastTarget = false;
            return rect;
        }

        /// <summary>
        /// Barra superior do mapa (WorldCanvas/ZV_Navigation_Bar do original): botao de clima que abre as opcoes
        /// sol/chuva/neve, globo, avatar+ e editar casa. Posicoes em unidades do canvas 2048x1024 (print 16.08.14).
        /// Globo, avatar+ e editar casa ainda nao tem funcionalidade offline: mostram um aviso.
        /// </summary>
        void BuildTopBar(Transform root)
        {
            var topLeft = new Vector2(0, 1);
            var topRight = new Vector2(1, 1);
            var half = new Vector2(0, 0.5f);
            var center = new Vector2(0.5f, 0.5f);

            // Opcoes de clima: pilula (sprite fatiado) com os tres icones; o botao de clima abre/fecha.
            _weatherPill = MakeUiButton(root, "WeatherPill", "weather_pill", topLeft, half, new Vector2(330f, -91f),
                new Vector2(400f, 114f), null, new Vector4(57f, 0f, 57f, 0f));
            var options = new[] { (WorldWeather.Clear, "weather_clear"), (WorldWeather.Rain, "weather_rain"), (WorldWeather.Snow, "weather_snow") };
            float x = 75f;
            foreach (var (weather, art) in options)
            {
                int value = weather;
                var icon = MakeUiButton(_weatherPill, "Weather_" + art, art, half, center, new Vector2(x + 25f, 0f),
                    new Vector2(98f, 96f), () => SetWeather(value));
                _weatherIcons[weather] = icon;
                x += 125f;
            }
            _weatherPill.gameObject.SetActive(false);
            var toggle = MakeUiButton(root, "WeatherToggle", "weather_toggle", topLeft, center, new Vector2(268f, -91f),
                new Vector2(146f, 143f), () => _weatherPill.gameObject.SetActive(!_weatherPill.gameObject.activeSelf));
            var globe = MakeUiButton(root, "WorldButton", "globe", topLeft, center, new Vector2(444f, -91f),
                new Vector2(146f, 143f), () => ShowToast("Os outros mundos ainda não estão disponíveis."));
            var avatar = MakeUiButton(root, "AddAvatarButton", "add_avatar", topRight, center, new Vector2(-242.5f, -91f),
                new Vector2(146f, 143f), () =>
                {
                    if (_onOpenSlots != null) _onOpenSlots();
                    else ShowToast("Adicionar avatares ainda não está disponível.");
                });
            var house = MakeUiButton(root, "EditHouseButton", "edit_house", topRight, center, new Vector2(-92.5f, -91f),
                new Vector2(146f, 143f), () => ShowToast("Editar a casa ainda não está disponível."));
            _uiRects.AddRange(new[] { toggle, globe, avatar, house });
            ApplyWeather(_weather);
        }

        void Update()
        {
            if (_toast != null && _toast.enabled && Time.unscaledTime > _toastUntil) _toast.enabled = false;
            if (_opening) return;
            if (!ReadPointer(out bool down, out bool up, out bool held, out Vector2 position)) return;

            if (down && !IsOverBack(position))
            {
                _pressing = true; _movedTooFar = false;
                _pressStart = _lastPos = position; _pressTime = Time.unscaledTime;
            }
            else if (_pressing && held)
            {
                float unitsPerPixel = _camera.orthographicSize * 2f / Screen.height;
                float dx = (position.x - _lastPos.x) * unitsPerPixel;
                var p = _camera.transform.position;
                p.x = ClampX(p.x - dx);
                _camera.transform.position = p;
                _lastPos = position;
                if (Vector2.Distance(position, _pressStart) > TapMaxPixels) _movedTooFar = true;
            }
            if (_pressing && up)
            {
                _pressing = false;
                if (!_movedTooFar && Time.unscaledTime - _pressTime <= TapMaxSeconds) OnTap(position);
            }
        }

        bool IsOverBack(Vector2 screen)
        {
            if (_backRect != null && RectTransformUtility.RectangleContainsScreenPoint(_backRect, screen, null)) return true;
            foreach (var rect in _uiRects)
                if (RectTransformUtility.RectangleContainsScreenPoint(rect, screen, null)) return true;
            return _weatherPill != null && _weatherPill.gameObject.activeSelf &&
                   RectTransformUtility.RectangleContainsScreenPoint(_weatherPill, screen, null);
        }

        void OnTap(Vector2 screen)
        {
            Vector3 world = _camera.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 10f));
            var building = _data.HitTest(world);
            if (building == null) return;
            StartCoroutine(PulseBuilding(building));
            if (building.IsBasketball)
            {
                UiSound.PlayClick();
                StartCoroutine(OpenCourtRoutine());
                return;
            }
            if (OnOpenLevel != null && SceneSliceRuntime.Has(building.defaultLevel))
            {
                UiSound.PlayClick();
                StartCoroutine(OpenLevelRoutine(building.defaultLevel));
                return;
            }
            ShowToast(building.defaultLevel == 0
                ? "Este lugar ainda está em obras."
                : "Este lugar ainda não está disponível.");
        }

        /// <summary>Abre o ambiente (SceneSliceRuntime) do LevelType do predio tocado; definido por quem hospeda o mapa.</summary>
        public Action<int> OnOpenLevel;

        System.Collections.IEnumerator OpenLevelRoutine(int levelType)
        {
            _opening = true; _pressing = false;
            yield return new WaitForSecondsRealtime(0.18f);
            LoadingScreen.Show();
            yield return null;
            yield return null;
            _opening = false;
            OnOpenLevel?.Invoke(levelType);
        }

        // Destaque, loading, um quadro para renderizar e so entao troca para a quadra.
        System.Collections.IEnumerator OpenCourtRoutine()
        {
            _opening = true; _pressing = false;
            // Deixa o destaque do predio terminar (PulseBuilding) antes de cobrir a tela.
            yield return new WaitForSecondsRealtime(0.18f);
            LoadingScreen.Show();
            yield return null;
            yield return null;
            _opening = false;
            _onOpenBasketball?.Invoke();
        }

        /// <summary>
        /// Feedback de toque: escurece por um instante os sprites que ficam dentro da caixa do predio
        /// (os renderers nao carregam o id do predio; sprites bem maiores que a caixa, como o fundo, ficam de fora).
        /// </summary>
        System.Collections.IEnumerator PulseBuilding(WorldBuildingData building)
        {
            var targets = new List<SpriteRenderer>();
            var originals = new List<Color>();
            float w = building.x1 - building.x0, h = building.y1 - building.y0;
            foreach (var r in GetComponentsInChildren<SpriteRenderer>())
            {
                var p = r.transform.position;
                if (p.x < building.x0 || p.x > building.x1 || p.y < building.y0 || p.y > building.y1) continue;
                var size = r.bounds.size;
                if (size.x > w * 1.5f || size.y > h * 1.5f) continue;
                targets.Add(r); originals.Add(r.color);
            }
            const float down = 0.06f, up = 0.12f, minShade = 0.7f; // total (0,18 s) = espera de OpenCourtRoutine
            for (float t = 0f; t < down + up; t += Time.unscaledDeltaTime)
            {
                float shade = t < down ? Mathf.Lerp(1f, minShade, t / down) : Mathf.Lerp(minShade, 1f, (t - down) / up);
                for (int i = 0; i < targets.Count; i++)
                {
                    if (targets[i] == null) continue;
                    var o = originals[i];
                    targets[i].color = new Color(o.r * shade, o.g * shade, o.b * shade, o.a);
                }
                yield return null;
            }
            for (int i = 0; i < targets.Count; i++) if (targets[i] != null) targets[i].color = originals[i];
        }

        void ShowToast(string message)
        {
            if (_toast == null) return;
            _toast.text = message;
            _toast.enabled = true;
            _toastUntil = Time.unscaledTime + 1.8f;
        }

        static bool ReadPointer(out bool down, out bool up, out bool held, out Vector2 position)
        {
            down = up = held = false;
            position = default;
#if ENABLE_INPUT_SYSTEM
            var touchscreen = UnityEngine.InputSystem.Touchscreen.current;
            if (touchscreen != null)
            {
                var touch = touchscreen.primaryTouch;
                if (touch.press.isPressed || touch.press.wasReleasedThisFrame)
                {
                    down = touch.press.wasPressedThisFrame; up = touch.press.wasReleasedThisFrame;
                    held = touch.press.isPressed; position = touch.position.ReadValue();
                    return true;
                }
            }
            var mouse = UnityEngine.InputSystem.Mouse.current;
            if (mouse != null && (mouse.leftButton.isPressed || mouse.leftButton.wasReleasedThisFrame))
            {
                down = mouse.leftButton.wasPressedThisFrame; up = mouse.leftButton.wasReleasedThisFrame;
                held = mouse.leftButton.isPressed; position = mouse.position.ReadValue();
                return true;
            }
#endif
#if ENABLE_LEGACY_INPUT_MANAGER
            if (Input.touchCount > 0)
            {
                var t = Input.GetTouch(0);
                down = t.phase == TouchPhase.Began;
                up = t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled;
                held = !up; position = t.position;
                return true;
            }
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0) || Input.GetMouseButtonUp(0))
            {
                down = Input.GetMouseButtonDown(0); up = Input.GetMouseButtonUp(0);
                held = Input.GetMouseButton(0); position = Input.mousePosition;
                return true;
            }
#endif
            return false;
        }
    }
}
