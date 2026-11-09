using System;
using System.Collections;
using System.Collections.Generic;
using AvatarWorld.Core.Economy;
using UnityEngine;
using UnityEngine.UI;

namespace AvatarWorld.Runtime
{
    /// <summary>
    /// Interior de um predio do mapa, lido de Resources/Interiors/&lt;chave&gt;/&lt;chave&gt;.json (formato WorldMapData,
    /// gerado por tools/build_interior_slice.py a partir da cena original). Camera que rola ao arrastar no vazio, botao
    /// voltar, o avatar salvo do jogador (toque no chao = anda ate la) e os itens do original (LevelItem, marcados por
    /// tools/mark_interior_items.py em &lt;chave&gt;_items.json) que podem ser arrastados. Nao reproduz as regras dos itens
    /// (comer, cozinhar, encaixe), npcs, luz nem som do original.
    /// </summary>
    public sealed class InteriorRuntime : MonoBehaviour
    {
        Camera _camera;
        WorldMapData _data;
        RectTransform _backRect;
        Action _onBack;
        bool _pressing;
        Vector2 _lastPos;
        SaveStore _saves;
        PlayerState _state;
        readonly List<SpriteRenderer> _items = new List<SpriteRenderer>();
        SpriteRenderer _dragged;
        Vector3 _dragOffset;
        int _dragBaseOrder;
        Vector2 _downPos;
        float _downTime;
        bool _moved;
        int _topRank;
        AvatarGpuRuntime _avatar;
        float _walkTarget;
        bool _walking;
        const float WalkSpeed = 3.2f;
        const float AvatarY = -2.45f;
        const float AvatarScale = 0.6f;

        [Serializable] class InteriorExtras { public List<int> items = new List<int>(); }

        public WorldMapData Data => _data;

        public void Begin(string key, SaveStore saves, PlayerState state, Action onBack)
        {
            _onBack = onBack;
            _saves = saves;
            _state = state;
            var json = Resources.Load<TextAsset>("Interiors/" + key + "/" + key);
            if (json == null) throw new InvalidOperationException("Interiors/" + key + " ausente em Resources");
            _data = JsonUtility.FromJson<WorldMapData>(json.text);
            BuildCamera();
            var extras = Resources.Load<TextAsset>("Interiors/" + key + "/" + key + "_items");
            var itemIndices = new HashSet<int>(extras != null ? JsonUtility.FromJson<InteriorExtras>(extras.text).items : new List<int>());
            BuildSprites("Interiors/" + key + "/sprites/", itemIndices);
            BuildAvatar();
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

        void BuildSprites(string prefix, HashSet<int> itemIndices)
        {
            var textures = new Dictionary<string, Texture2D>();
            var sprites = new Dictionary<string, Sprite>();
            for (int index = 0; index < _data.renderers.Count; index++)
            {
                var r = _data.renderers[index];
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
                _topRank = Mathf.Max(_topRank, r.rank);
                if (itemIndices.Contains(index)) _items.Add(sr);
            }
            foreach (var spine in _data.animations?.spines ?? new List<WorldSpineData>()) MapSpineLayer.Create(transform, spine, _camera);
            Debug.Log("Interior: " + _data.renderers.Count + " elementos, " + _items.Count + " itens arrastaveis");
        }

        // Avatar salvo do jogador, a frente do cenario; sem save (testes) o interior fica so com a arte.
        void BuildAvatar()
        {
            if (_saves == null || _state == null) return;
            var host = new GameObject("Avatar do jogador");
            host.transform.SetParent(transform, false);
            _avatar = host.AddComponent<AvatarGpuRuntime>();
            _avatar.ConfigureAsWorldAvatar(_saves, _state, new Vector3(_camera.transform.position.x, AvatarY, 0f), AvatarScale, _topRank + 5);
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
            UpdateWalk();
            if (_camera == null || !TryPointer(out bool down, out bool up, out bool held, out Vector2 pos)) { _pressing = false; EndDrag(); return; }
            if (down && !RectTransformUtility.RectangleContainsScreenPoint(_backRect, pos, null))
            {
                _pressing = true; _lastPos = _downPos = pos; _downTime = Time.unscaledTime; _moved = false;
                var world = ToWorld(pos);
                _dragged = PickItem(world);
                if (_dragged != null)
                {
                    UiSound.PlayClick();
                    _dragBaseOrder = _dragged.sortingOrder;
                    _dragged.sortingOrder = _topRank + 10; // levantado, acima de tudo
                    _dragOffset = _dragged.transform.position - world;
                }
            }
            else if (_pressing && held)
            {
                if ((pos - _downPos).sqrMagnitude > 24f * 24f) _moved = true;
                if (_dragged != null)
                {
                    var p = ToWorld(pos) + _dragOffset;
                    p.z = 0f;
                    _dragged.transform.position = p;
                }
                else
                {
                    float unitsPerPixel = _camera.orthographicSize * 2f / Screen.height;
                    var p = _camera.transform.position;
                    p.x = ClampX(p.x - (pos.x - _lastPos.x) * unitsPerPixel);
                    _camera.transform.position = p;
                }
                _lastPos = pos;
            }
            if (up)
            {
                if (_pressing && _dragged == null && !_moved && Time.unscaledTime - _downTime < 0.45f) WalkTo(ToWorld(pos).x);
                EndDrag();
                _pressing = false;
            }
        }

        Vector3 ToWorld(Vector2 screen) => _camera.ScreenToWorldPoint(new Vector3(screen.x, screen.y, -_camera.transform.position.z));

        // Item arrastavel mais a frente (maior sortingOrder) sob o ponto.
        SpriteRenderer PickItem(Vector3 world)
        {
            SpriteRenderer best = null;
            foreach (var item in _items)
            {
                if (item == null || item.sprite == null) continue;
                var bounds = item.bounds;
                if (world.x < bounds.min.x || world.x > bounds.max.x || world.y < bounds.min.y || world.y > bounds.max.y) continue;
                if (best == null || item.sortingOrder > best.sortingOrder) best = item;
            }
            return best;
        }

        void EndDrag()
        {
            if (_dragged == null) return;
            _dragged.sortingOrder = _dragBaseOrder; // solto: volta a ordem de desenho original
            _dragged = null;
        }

        void WalkTo(float x)
        {
            if (_avatar == null || !_avatar.IsReady) return;
            _walkTarget = Mathf.Clamp(x, _data.camera.minX, _data.camera.maxX);
            _walking = true;
            _avatar.PlayAnimation("Movement_Cycles/Walk", true);
        }

        void UpdateWalk()
        {
            if (!_walking || _avatar == null || !_avatar.IsReady) return;
            var t = _avatar.AvatarTransform;
            float dx = _walkTarget - t.position.x;
            _avatar.SetFacing(dx < 0f);
            float step = WalkSpeed * Time.deltaTime;
            if (Mathf.Abs(dx) <= step)
            {
                t.position = new Vector3(_walkTarget, t.position.y, t.position.z);
                _walking = false;
                _avatar.PlayAnimation("Idle_Stand_1", true);
                return;
            }
            t.position += new Vector3(Mathf.Sign(dx) * step, 0f, 0f);
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
