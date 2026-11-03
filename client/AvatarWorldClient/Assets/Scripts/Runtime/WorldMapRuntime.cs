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
        Camera _camera;
        WorldMapData _data;
        RectTransform _backRect;
        Text _toast;
        float _toastUntil;
        bool _pressing;
        Vector2 _pressStart, _lastPos;
        float _pressTime;
        bool _movedTooFar;
        readonly Dictionary<string, Texture2D> _textures = new Dictionary<string, Texture2D>();

        public WorldMapData Data => _data;
        public Camera MapCamera => _camera;

        public void Begin(Action onBack, Action onOpenBasketball)
        {
            _onBack = onBack;
            _onOpenBasketball = onOpenBasketball;
            var json = Resources.Load<TextAsset>(DataResource);
            if (json == null) throw new InvalidOperationException("WorldSlice/world.json ausente em Resources");
            _data = JsonUtility.FromJson<WorldMapData>(json.text);
            BuildCamera();
            BuildSprites();
            BuildOverlay();
            Debug.Log("WorldMap: " + _data.renderers.Count + " elementos, " + _data.buildings.Count + " predios");
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

        void BuildSprites()
        {
            var sprites = new Dictionary<string, Sprite>();
            foreach (var r in _data.renderers)
            {
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
                go.transform.position = new Vector3(r.x, r.y, 0f);
                go.transform.rotation = Quaternion.Euler(0, 0, r.rot * Mathf.Rad2Deg);
                go.transform.localScale = new Vector3(Mathf.Abs(r.sx), Mathf.Abs(r.sy), 1f);
                var renderer = go.AddComponent<SpriteRenderer>();
                renderer.sprite = sprite;
                renderer.sortingOrder = r.rank;
                renderer.flipX = r.flipX != (r.sx < 0f);
                renderer.flipY = r.flipY != (r.sy < 0f);
                renderer.color = new Color(r.color[0], r.color[1], r.color[2], r.color[3]);
            }
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
            back.GetComponent<Button>().onClick.AddListener(() => { UiSound.PlayClick(); _onBack?.Invoke(); });

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
        }

        void Update()
        {
            if (_toast != null && _toast.enabled && Time.unscaledTime > _toastUntil) _toast.enabled = false;
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

        bool IsOverBack(Vector2 screen) =>
            _backRect != null && RectTransformUtility.RectangleContainsScreenPoint(_backRect, screen, null);

        void OnTap(Vector2 screen)
        {
            Vector3 world = _camera.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 10f));
            var building = _data.HitTest(world);
            if (building == null) return;
            if (building.IsBasketball)
            {
                UiSound.PlayClick();
                _onOpenBasketball?.Invoke();
                return;
            }
            ShowToast(building.defaultLevel == 0
                ? "Este lugar ainda está em obras."
                : "Este lugar ainda não está disponível.");
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
