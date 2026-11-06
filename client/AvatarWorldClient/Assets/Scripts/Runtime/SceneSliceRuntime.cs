using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AvatarWorld.Runtime
{
    // Formato gerado por tools/export_scene_slices.py (Resources/Scenes/<nome>/scene.json).

    [Serializable]
    public sealed class SceneSliceRenderer
    {
        public string sprite, go;
        public float x, y, sx = 1f, sy = 1f, rot, pivotX = 0.5f, pivotY = 0.5f, ppu = 100f, drawW, drawH;
        public int rank;
        public float[] color = { 1f, 1f, 1f, 1f };
        public bool flipX, flipY;
        public int[] weathers;
    }

    [Serializable]
    public sealed class SceneSliceData
    {
        public string name;
        public int levelType;
        public float orthoSize = 5.12f, minX, maxX, minY, maxY;
        public List<SceneSliceRenderer> renderers = new List<SceneSliceRenderer>();
    }

    [Serializable] public sealed class SceneSliceEntry { public int levelType; public string name; public int renderers, sprites; }
    [Serializable] public sealed class SceneSliceIndex { public List<SceneSliceEntry> scenes = new List<SceneSliceEntry>(); }

    /// <summary>
    /// Carregador generico dos ambientes do original (cenas Level_* abertas pelos predios do mapa World):
    /// monta os SpriteRenderers extraidos, rola a camera ao arrastar e tem o botao voltar do mapa.
    /// So arte e layout; sem personagens, Spine, itens arrastaveis nem scripts da cena (ver NOT_REPRODUCED.md).
    /// </summary>
    public sealed class SceneSliceRuntime : MonoBehaviour
    {
        const string Root = "Scenes/";
        const int SpritesPerFrame = 32;

        static SceneSliceIndex _index;
        Action _onBack;
        Camera _camera;
        SceneSliceData _data;
        bool _pressing;
        Vector2 _lastPos;

        public SceneSliceData Data => _data;
        public Camera SceneCamera => _camera;

        public static SceneSliceIndex Index
        {
            get
            {
                if (_index != null) return _index;
                var text = Resources.Load<TextAsset>(Root + "index");
                _index = text == null ? new SceneSliceIndex() : JsonUtility.FromJson<SceneSliceIndex>(text.text);
                return _index;
            }
        }

        /// <summary>Nome da pasta em Resources/Scenes para o LevelType do predio; nulo se a cena nao foi importada.</summary>
        public static string NameFor(int levelType)
        {
            foreach (var e in Index.scenes) if (e.levelType == levelType) return e.name;
            return null;
        }

        public static bool Has(int levelType) => NameFor(levelType) != null;

        /// <summary>Monta a cena em varios quadros; onReady dispara quando tudo esta pronto.</summary>
        public bool Begin(int levelType, Action onBack, Action onReady = null)
        {
            string name = NameFor(levelType);
            if (name == null) return false;
            var json = Resources.Load<TextAsset>(Root + name + "/scene");
            if (json == null) { Debug.LogError("SceneSlice: scene.json ausente para " + name); return false; }
            _data = JsonUtility.FromJson<SceneSliceData>(json.text);
            _onBack = onBack;
            BuildCamera();
            BuildOverlay();
            StartCoroutine(BuildSprites(name, onReady));
            return true;
        }

        void BuildCamera()
        {
            _camera = new GameObject("SceneCamera", typeof(Camera)).GetComponent<Camera>();
            _camera.transform.SetParent(transform, false);
            _camera.tag = "MainCamera";
            _camera.orthographic = true;
            _camera.orthographicSize = _data.orthoSize;
            _camera.clearFlags = CameraClearFlags.SolidColor;
            _camera.backgroundColor = Color.black;
            _camera.transform.position = new Vector3(ClampX((_data.minX + _data.maxX) * 0.5f), 0f, -10f);
        }

        float ClampX(float x)
        {
            float half = _camera != null ? _data.orthoSize * _camera.aspect : 11f;
            float min = _data.minX + half, max = _data.maxX - half;
            return min > max ? (min + max) * 0.5f : Mathf.Clamp(x, min, max);
        }

        static int Weather()
        {
            try
            {
                int saved = PlayerPrefs.GetInt(WorldWeather.PrefsKey, WorldWeather.Clear);
                return WorldWeather.IsSupported(saved) ? saved : WorldWeather.Clear;
            }
            catch (Exception) { return WorldWeather.Clear; }
        }

        System.Collections.IEnumerator BuildSprites(string scene, Action onReady)
        {
            int weather = Weather();
            var textures = new Dictionary<string, Texture2D>();
            var sprites = new Dictionary<string, Sprite>();
            int built = 0, missing = 0;
            foreach (var r in _data.renderers)
            {
                if (++built % SpritesPerFrame == 0) yield return null;
                string key = r.sprite + "|" + r.pivotX + "|" + r.pivotY + "|" + r.ppu;
                if (!sprites.TryGetValue(key, out var sprite))
                {
                    if (!textures.TryGetValue(r.sprite, out var tex))
                    {
                        tex = Resources.Load<Texture2D>(Root + scene + "/sprites/" + r.sprite);
                        textures[r.sprite] = tex;
                    }
                    if (tex == null) { missing++; continue; }
                    sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(r.pivotX, r.pivotY), r.ppu);
                    sprites[key] = sprite;
                }
                var go = new GameObject(r.go);
                go.transform.SetParent(transform, false);
                go.transform.position = new Vector3(r.x, r.y, 0f);
                go.transform.rotation = Quaternion.Euler(0, 0, r.rot * Mathf.Rad2Deg);
                float sx = Mathf.Abs(r.sx), sy = Mathf.Abs(r.sy);
                if (r.drawW > 0f && r.drawH > 0f)
                {
                    // sliced/tiled no original: estica ate o drawSize (aproximacao)
                    var size = sprite.bounds.size;
                    if (size.x > 0f && size.y > 0f) { sx = r.drawW / size.x; sy = r.drawH / size.y; }
                }
                go.transform.localScale = new Vector3(sx, sy, 1f);
                var sr = go.AddComponent<SpriteRenderer>();
                sr.sprite = sprite;
                sr.sortingOrder = r.rank;
                sr.flipX = r.flipX != (r.sx < 0f);
                sr.flipY = r.flipY != (r.sy < 0f);
                sr.color = new Color(r.color[0], r.color[1], r.color[2], r.color[3]);
                if (r.weathers != null && r.weathers.Length > 0)
                {
                    bool visible = false;
                    foreach (var w in r.weathers) if (w == weather) visible = true;
                    sr.enabled = visible;
                }
            }
            if (missing > 0) Debug.LogWarning("SceneSlice " + scene + ": " + missing + " sprites ausentes");
            Debug.Log("SceneSlice " + scene + ": " + _data.renderers.Count + " elementos");
            onReady?.Invoke();
        }

        RectTransform _backRect;

        void BuildOverlay()
        {
            UiSceneBuilder.EnsureEventSystem();
            var root = new GameObject("SceneOverlay", typeof(RectTransform), typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
            root.transform.SetParent(transform, false);
            var canvas = root.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.overrideSorting = true;
            canvas.sortingOrder = 32000;
            var scaler = root.GetComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(2048f, 1024f);
            scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;

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
            back.GetComponent<Button>().onClick.AddListener(() => { UiSound.PlayClick(); _onBack?.Invoke(); });
        }

        void Update()
        {
            if (_camera == null || !ReadPointer(out bool down, out bool up, out bool held, out Vector2 pos)) return;
            bool overBack = _backRect != null && RectTransformUtility.RectangleContainsScreenPoint(_backRect, pos, null);
            if (down && !overBack) { _pressing = true; _lastPos = pos; }
            else if (_pressing && held)
            {
                float unitsPerPixel = _camera.orthographicSize * 2f / Screen.height;
                var p = _camera.transform.position;
                p.x = ClampX(p.x - (pos.x - _lastPos.x) * unitsPerPixel);
                _camera.transform.position = p;
                _lastPos = pos;
            }
            if (up) _pressing = false;
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
