using System;
using System.Collections.Generic;
using AvatarWorld.Core.Economy;
using AvatarWorld.Core.Pointer;
using AvatarWorld.Core.SceneItems;
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
        /// <summary>Indice do LevelItem (arrastavel) a que o sprite pertence; -1 = cenario.</summary>
        public int item = -1;
    }

    [Serializable] public sealed class SceneSliceItem { public string go; public float x, y, bottomWidth; }

    [Serializable]
    public sealed class SceneSliceDropArea
    {
        public string go;
        public int priority;
        public float[] poly;
        public bool allowOverlap, canConsumeCharacters;
        public float maxW, maxH;
    }

    [Serializable]
    public sealed class SceneSliceSpine
    {
        public string skeleton, animation;
        public float x, y, sx = 1f, sy = 1f, offsetX, offsetY;
        public bool loop = true, followCamera;
        public int rank;
    }

    [Serializable]
    public sealed class SceneSliceData
    {
        public string name;
        public int levelType;
        public float orthoSize = 5.12f, minX, maxX, minY, maxY;
        public List<SceneSliceRenderer> renderers = new List<SceneSliceRenderer>();
        public List<SceneSliceSpine> spines = new List<SceneSliceSpine>();
        public List<SceneSliceItem> items = new List<SceneSliceItem>();
        public List<SceneSliceDropArea> dropAreas = new List<SceneSliceDropArea>();
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
        SaveStore _save;
        // itens arrastaveis (LevelItem): raiz por item, seus renderers e as areas de soltar
        readonly List<Transform> _itemRoots = new List<Transform>();
        readonly List<List<SpriteRenderer>> _itemRenderers = new List<List<SpriteRenderer>>();
        readonly List<DropArea> _areas = new List<DropArea>();
        readonly DragIntentDetector _detector = new DragIntentDetector();
        int _grabItem = -1, _dragItem = -1;
        Vector3 _dragOffset, _dragStartPos;
        int[] _dragOrders;
        const int DragSortingBoost = 20000;
        PlayerState _state;
        readonly List<KeyValuePair<Transform, SceneSliceSpine>> _followers = new List<KeyValuePair<Transform, SceneSliceSpine>>();

        public SceneSliceData Data => _data;
        public IReadOnlyList<Transform> ItemRoots => _itemRoots;
        public IReadOnlyList<DropArea> DropAreas => _areas;
        public bool TryGetItemBounds(int item, out Bounds bounds) => ItemBounds(item, out bounds);
        public int DraggingItem => _dragItem;
        public int GrabbedItem => _grabItem;
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
        public bool Begin(int levelType, Action onBack, Action onReady = null, SaveStore save = null, PlayerState state = null)
        {
            string name = NameFor(levelType);
            if (name == null) return false;
            var json = Resources.Load<TextAsset>(Root + name + "/scene");
            if (json == null) { Debug.LogError("SceneSlice: scene.json ausente para " + name); return false; }
            _data = JsonUtility.FromJson<SceneSliceData>(json.text);
            _onBack = onBack;
            _save = save; _state = state;
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
            foreach (var it in _data.items)
            {
                var root = new GameObject("Item " + it.go);
                root.transform.SetParent(transform, false);
                root.transform.position = new Vector3(it.x, it.y, 0f);
                _itemRoots.Add(root.transform);
                _itemRenderers.Add(new List<SpriteRenderer>());
            }
            foreach (var a in _data.dropAreas)
                if (a.poly != null && a.poly.Length >= 6) _areas.Add(new DropArea(a.poly, a.priority, a.go));
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
                if (r.item >= 0 && r.item < _itemRoots.Count)
                {
                    go.transform.SetParent(_itemRoots[r.item], true);
                    _itemRenderers[r.item].Add(sr);
                }
                if (r.weathers != null && r.weathers.Length > 0)
                {
                    bool visible = false;
                    foreach (var w in r.weathers) if (w == weather) visible = true;
                    sr.enabled = visible;
                }
            }
            BuildSpines();
            BuildAvatar();
            if (missing > 0) Debug.LogWarning("SceneSlice " + scene + ": " + missing + " sprites ausentes");
            Debug.Log("SceneSlice " + scene + ": " + _data.renderers.Count + " elementos");
            onReady?.Invoke();
        }

        void BuildSpines()
        {
            int ok = 0;
            foreach (var sp in _data.spines)
            {
                var asset = SpineLibrary.Load(sp.skeleton);
                if (asset == null) continue;
                var go = new GameObject("Spine " + sp.skeleton);
                go.transform.SetParent(transform, false);
                go.transform.position = new Vector3(sp.x, sp.y, 0f);
                go.transform.localScale = new Vector3(sp.sx, sp.sy, 1f);
                var anim = Spine.Unity.SkeletonAnimation.AddToGameObject(go, asset);
                if (!anim.valid) { Destroy(go); continue; }
                string name = PickAnimation(anim, sp);
                if (name != null) anim.state.SetAnimation(0, name, sp.loop);
                var mr = go.GetComponent<MeshRenderer>();
                if (mr != null) mr.sortingOrder = sp.rank;
                if (sp.followCamera) _followers.Add(new KeyValuePair<Transform, SceneSliceSpine>(go.transform, sp));
                ok++;
            }
            if (_data.spines.Count > 0) Debug.Log("SceneSlice: " + ok + "/" + _data.spines.Count + " spines");
        }

        // A cena guarda o nome da animacao inicial; sem nome, so ciclos ambiente (fogo, agua, sol) sao tocados.
        static string PickAnimation(Spine.Unity.SkeletonAnimation anim, SceneSliceSpine sp)
        {
            var data = anim.skeleton.Data;
            if (!string.IsNullOrEmpty(sp.animation) && data.FindAnimation(sp.animation) != null) return sp.animation;
            foreach (var key in new[] { "Idle", "Loop", "Day" })
                foreach (var a in data.Animations)
                    if (a.Name.IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0) return a.Name;
            bool ambient = sp.skeleton.StartsWith("Fire") || sp.skeleton.StartsWith("Water") || sp.skeleton.StartsWith("Sun");
            return ambient && data.Animations.Count > 0 ? data.Animations.Items[0].Name : null;
        }

        // Avatar salvo do jogador, como na quadra; o original o cria em runtime (nao ha personagem serializado na cena).
        void BuildAvatar()
        {
            if (_save == null || _state == null) return;
            var host = new GameObject("Avatar salvo na cena");
            host.transform.SetParent(transform, false);
            var avatar = host.AddComponent<AvatarGpuRuntime>();
            avatar.EmbeddedSortingOrder = 30000;
            avatar.ConfigureAsWorldAvatar(_save, _state, new Vector3(_camera.transform.position.x, -2.7f, 0f), 0.55f);
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

        void LateUpdate()
        {
            if (_camera == null) return;
            foreach (var f in _followers)
                f.Key.position = new Vector3(_camera.transform.position.x + f.Value.offsetX, f.Value.offsetY, 0f);
        }

        Vector3 ToWorld(Vector2 screen) =>
            _camera.ScreenToWorldPoint(new Vector3(screen.x, screen.y, -_camera.transform.position.z));

        bool ItemBounds(int item, out Bounds bounds)
        {
            bounds = default;
            bool any = false;
            foreach (var r in _itemRenderers[item])
            {
                if (r == null || !r.enabled) continue;
                if (!any) { bounds = r.bounds; any = true; } else bounds.Encapsulate(r.bounds);
            }
            return any;
        }

        /// <summary>Item sob o ponto (caixa dos sprites); vence o de maior ordem de desenho. Aproximacao do CShape do original.</summary>
        int HitItem(Vector3 world)
        {
            int best = -1, bestOrder = int.MinValue;
            for (int i = 0; i < _itemRenderers.Count; i++)
                foreach (var r in _itemRenderers[i])
                {
                    if (r == null || !r.enabled) continue;
                    var b = r.bounds;
                    if (world.x < b.min.x || world.x > b.max.x || world.y < b.min.y || world.y > b.max.y) continue;
                    if (r.sortingOrder > bestOrder) { best = i; bestOrder = r.sortingOrder; }
                }
            return best;
        }

        void BeginItemDrag(int item, Vector2 pos)
        {
            _dragItem = item;
            var root = _itemRoots[item];
            _dragStartPos = root.position;
            _dragOffset = root.position - ToWorld(pos);
            var list = _itemRenderers[item];
            _dragOrders = new int[list.Count];
            for (int i = 0; i < list.Count; i++) { _dragOrders[i] = list[i].sortingOrder; list[i].sortingOrder += DragSortingBoost; }
        }

        void EndItemDrag()
        {
            int item = _dragItem;
            _dragItem = -1;
            var list = _itemRenderers[item];
            for (int i = 0; i < list.Count && i < _dragOrders.Length; i++) list[i].sortingOrder = _dragOrders[i];
            var root = _itemRoots[item];
            Vector3 target = _dragStartPos; // sem area valida: volta (aproximacao do ajuste/queda do original)
            if (ItemBounds(item, out var b))
            {
                float x = b.center.x;
                for (float dy = 0f; dy <= 0.6f; dy += 0.05f)
                {
                    var area = DropAreaQuery.Best(_areas, x, b.min.y - dy + 0.02f);
                    if (area != null && area.TopAt(x, out float top))
                    {
                        target = root.position + new Vector3(0f, top - b.min.y, 0f);
                        break;
                    }
                }
            }
            StartCoroutine(SlideTo(root, target, target == _dragStartPos ? 0.2f : 0.12f));
        }

        System.Collections.IEnumerator SlideTo(Transform t, Vector3 target, float seconds)
        {
            var from = t.position;
            for (float e = 0f; e < seconds; e += Time.unscaledDeltaTime)
            {
                t.position = Vector3.Lerp(from, target, e / seconds);
                yield return null;
            }
            t.position = target;
        }

        void Update()
        {
            if (_camera == null || !ReadPointer(out bool down, out bool up, out bool held, out Vector2 pos)) return;
            Step(down, held, up, pos);
        }

        /// <summary>Um passo de entrada (tela em pixels); separado de Update para testes sem dispositivo.</summary>
        public void Step(bool down, bool held, bool up, Vector2 pos)
        {
            bool overBack = _backRect != null && RectTransformUtility.RectangleContainsScreenPoint(_backRect, pos, null);
            if (down && !overBack)
            {
                _pressing = true; _lastPos = pos;
                _detector.PointerDown(pos.x, pos.y);
                _grabItem = HitItem(ToWorld(pos));
            }
            else if (_pressing && held)
            {
                if (_dragItem >= 0)
                {
                    _itemRoots[_dragItem].position = ToWorld(pos) + _dragOffset;
                }
                else if (_grabItem >= 0)
                {
                    if (_detector.PointerMove(pos.x, pos.y)) BeginItemDrag(_grabItem, pos);
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
                if (_dragItem >= 0) EndItemDrag();
                _detector.PointerUp();
                _pressing = false; _grabItem = -1;
            }
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
