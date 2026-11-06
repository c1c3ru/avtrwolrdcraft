using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AvatarWorld.Runtime
{
    /// <summary>
    /// Interior de um predio do mapa, lido de Resources/Interiors/&lt;chave&gt;/&lt;chave&gt;.json (formato WorldMapData,
    /// gerado por tools/build_interior_slice.py a partir da cena original). So visual: camera que rola ao arrastar
    /// e botao voltar. Nao reproduz itens arrastaveis, luz nem som do original.
    /// </summary>
    public sealed class InteriorRuntime : MonoBehaviour
    {
        Camera _camera;
        WorldMapData _data;
        RectTransform _backRect;
        Action _onBack;
        bool _pressing;
        Vector2 _lastPos;

        public WorldMapData Data => _data;

        public void Begin(string key, Action onBack)
        {
            _onBack = onBack;
            var json = Resources.Load<TextAsset>("Interiors/" + key + "/" + key);
            if (json == null) throw new InvalidOperationException("Interiors/" + key + " ausente em Resources");
            _data = JsonUtility.FromJson<WorldMapData>(json.text);
            BuildCamera();
            BuildSprites("Interiors/" + key + "/sprites/");
            BuildBackButton();
        }

        void BuildCamera()
        {
            _camera = new GameObject("InteriorCamera", typeof(Camera)).GetComponent<Camera>();
            _camera.transform.SetParent(transform, false);
            _camera.tag = "MainCamera";
            _camera.orthographic = true;
            _camera.orthographicSize = _data.camera.orthoSize;
            _camera.clearFlags = CameraClearFlags.SolidColor;
            _camera.backgroundColor = Color.black;
            _camera.transform.position = new Vector3(ClampX(_data.camera.startX), _data.camera.startY, -10f);
        }

        float ClampX(float x)
        {
            float half = _camera.orthographicSize * _camera.aspect;
            float min = _data.camera.minX + half, max = _data.camera.maxX - half;
            return min > max ? (min + max) * 0.5f : Mathf.Clamp(x, min, max);
        }

        void BuildSprites(string prefix)
        {
            var textures = new Dictionary<string, Texture2D>();
            var sprites = new Dictionary<string, Sprite>();
            foreach (var r in _data.renderers)
            {
                string key = r.sprite + "|" + r.pivotX + "|" + r.pivotY + "|" + r.ppu;
                if (!sprites.TryGetValue(key, out var sprite))
                {
                    if (!textures.TryGetValue(r.sprite, out var tex))
                        textures[r.sprite] = tex = Resources.Load<Texture2D>(prefix + r.sprite);
                    if (tex == null) { Debug.LogWarning("Interior: sprite ausente " + r.sprite); continue; }
                    sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(r.pivotX, r.pivotY), r.ppu);
                    sprites[key] = sprite;
                }
                var go = new GameObject(r.go);
                go.transform.SetParent(transform, false);
                go.transform.position = new Vector3(r.x, r.y, 0f);
                go.transform.rotation = Quaternion.Euler(0, 0, r.rot * Mathf.Rad2Deg);
                go.transform.localScale = new Vector3(Mathf.Abs(r.sx), Mathf.Abs(r.sy), 1f);
                var sr = go.AddComponent<SpriteRenderer>();
                sr.sprite = sprite;
                sr.sortingOrder = r.rank;
                sr.flipX = r.flipX != (r.sx < 0f);
                sr.flipY = r.flipY != (r.sy < 0f);
                sr.color = new Color(r.color[0], r.color[1], r.color[2], r.color[3]);
            }
            foreach (var spine in _data.animations?.spines ?? new List<WorldSpineData>()) MapSpineLayer.Create(transform, spine, _camera);
            Debug.Log("Interior: " + _data.renderers.Count + " elementos");
        }

        void BuildBackButton()
        {
            UiSceneBuilder.EnsureEventSystem();
            var root = new GameObject("InteriorOverlay", typeof(RectTransform), typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
            root.transform.SetParent(transform, false);
            var canvas = root.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.overrideSorting = true;
            canvas.sortingOrder = 600;
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
            if (_camera == null || !TryPointer(out bool down, out bool up, out bool held, out Vector2 pos)) { _pressing = false; return; }
            if (down && !RectTransformUtility.RectangleContainsScreenPoint(_backRect, pos, null)) { _pressing = true; _lastPos = pos; }
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

        static bool TryPointer(out bool down, out bool up, out bool held, out Vector2 position)
        {
            down = up = held = false;
            position = default;
#if ENABLE_INPUT_SYSTEM
            var touch = UnityEngine.InputSystem.Touchscreen.current?.primaryTouch;
            if (touch != null && (touch.press.isPressed || touch.press.wasReleasedThisFrame))
            {
                down = touch.press.wasPressedThisFrame; up = touch.press.wasReleasedThisFrame;
                held = touch.press.isPressed; position = touch.position.ReadValue();
                return true;
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
