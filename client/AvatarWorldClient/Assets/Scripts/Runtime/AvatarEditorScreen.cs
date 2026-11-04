using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using AvatarWorld.Core.Avatar;
using AvatarWorld.Core.Economy;
using UnityEngine;
using UnityEngine.UI;

namespace AvatarWorld.Runtime
{
    /// <summary>
    /// Editor de avatar com o layout da cena AvatarMaker do original (level234 + prefab CharacterMenu de
    /// resources.assets): voltar (topo-esquerda), concluir/desfazer/refazer (base-esquerda) e, a direita, o menu com a
    /// coluna de categorias (127), divisor e grade de miniaturas (cela 217x207). Posicoes em unidades do canvas 2048x1024.
    /// Mostra so as 5 categorias que o avatar local suporta (cabelo, camisa, calca, sapato, acessorio), 2 opcoes cada.
    /// Aproximado: fundo/cor do painel (sem print do original), miniaturas geradas do proprio avatar (o original usa icones),
    /// sem coluna de cores nem pacotes de expansao. Concluir grava; voltar descarta as mudancas da sessao.
    /// </summary>
    public sealed class AvatarEditorScreen : MonoBehaviour
    {
        const float PanelWidth = 823f;
        static readonly Vector3 AvatarPosition = new Vector3(-4.0f, -2.35f, 0f);
        const float AvatarScale = 1f;
        const int ThumbSize = 256;

        struct CategoryView { public string key; public string art; public float centerY, half; }

        static readonly CategoryView[] Views =
        {
            new CategoryView { key = AvatarCatalog.CategoryHair,      art = "hair",      centerY = 3.50f, half = 1.45f },
            new CategoryView { key = AvatarCatalog.CategoryShirt,     art = "shirt",     centerY = 1.65f, half = 0.95f },
            new CategoryView { key = AvatarCatalog.CategoryBottom,    art = "bottom",    centerY = 0.85f, half = 0.85f },
            new CategoryView { key = AvatarCatalog.CategoryShoes,     art = "shoes",     centerY = 0.30f, half = 0.70f },
            new CategoryView { key = AvatarCatalog.CategoryAccessory, art = "accessory", centerY = 3.10f, half = 1.30f },
        };

        SaveStore _saves;
        PlayerState _state;
        Action _onClose;
        Camera _camera, _thumbCamera;
        Canvas _backCanvas, _frontCanvas;
        RectTransform _panel, _grid;
        AvatarGpuRuntime _avatar;
        AvatarEditHistory _history;
        string _category;
        Image _undo, _redo;
        Text _toast;
        float _toastUntil;
        bool _closing;
        Font _font;
        readonly Dictionary<string, Sprite> _art = new Dictionary<string, Sprite>();
        readonly Dictionary<string, Sprite> _thumbs = new Dictionary<string, Sprite>();
        readonly Dictionary<string, Image> _categoryButtons = new Dictionary<string, Image>();
        readonly Dictionary<string, Image> _cells = new Dictionary<string, Image>();

        public string Category => _category;
        public bool ThumbsReady { get; private set; }

        public void Begin(SaveStore saves, PlayerState state, Action onClose)
        {
            _saves = saves ?? throw new ArgumentNullException(nameof(saves));
            _state = state ?? throw new ArgumentNullException(nameof(state));
            _onClose = onClose;
            _font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            _history = new AvatarEditHistory(_state.Appearance);
            UiSceneBuilder.EnsureEventSystem();
            BuildCameras();
            _backCanvas = NewCanvas("Back", 0);
            _frontCanvas = NewCanvas("Front", 10);
            BuildBackground();

            var host = new GameObject("Avatar em edicao");
            host.transform.SetParent(transform, false);
            _avatar = host.AddComponent<AvatarGpuRuntime>();
            _avatar.ConfigureAsWorldAvatar(_saves, _state, AvatarPosition, AvatarScale);

            BuildFront();
            SelectCategory(AvatarCatalog.CategoryHair);
            StartCoroutine(BuildThumbnails());
        }

        // ---------- camera e canvas ----------

        void BuildCameras()
        {
            _camera = new GameObject("EditorCamera", typeof(Camera)).GetComponent<Camera>();
            _camera.transform.SetParent(transform, false);
            _camera.tag = "MainCamera";
            _camera.orthographic = true;
            _camera.orthographicSize = 5.12f; // 1 unidade do mundo = 100 unidades do canvas
            _camera.clearFlags = CameraClearFlags.SolidColor;
            _camera.backgroundColor = new Color(0.97f, 0.89f, 0.89f);
            _camera.transform.position = new Vector3(0, 0, -10);

            _thumbCamera = new GameObject("ThumbCamera", typeof(Camera)).GetComponent<Camera>();
            _thumbCamera.transform.SetParent(transform, false);
            _thumbCamera.orthographic = true;
            _thumbCamera.clearFlags = CameraClearFlags.SolidColor;
            _thumbCamera.backgroundColor = new Color(1f, 1f, 1f, 0f);
            _thumbCamera.enabled = false; // so renderiza sob demanda (Camera.Render)
        }

        Canvas NewCanvas(string name, int order)
        {
            var go = new GameObject("EditorCanvas_" + name, typeof(RectTransform), typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
            go.transform.SetParent(transform, false);
            var canvas = go.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            canvas.worldCamera = _camera;
            canvas.planeDistance = 10f;
            canvas.overrideSorting = true;
            canvas.sortingOrder = order;
            var scaler = go.GetComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(2048f, 1024f);
            scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
            return canvas;
        }

        void BuildBackground()
        {
            var tex = new Texture2D(1, 64, TextureFormat.RGBA32, false) { wrapMode = TextureWrapMode.Clamp, filterMode = FilterMode.Bilinear };
            for (int y = 0; y < 64; y++)
            {
                float band = Mathf.Exp(-Mathf.Pow((y / 63f - 0.55f) / 0.12f, 2f));
                tex.SetPixel(0, y, Color.Lerp(new Color(0.98f, 0.91f, 0.91f), new Color(0.96f, 0.82f, 0.83f), band));
            }
            tex.Apply();
            var bg = new GameObject("Background", typeof(RectTransform), typeof(RawImage));
            bg.transform.SetParent(_backCanvas.transform, false);
            Stretch((RectTransform)bg.transform);
            bg.GetComponent<RawImage>().texture = tex;
            bg.GetComponent<RawImage>().raycastTarget = false;

            // Painel do menu (CharacterMenu): ancorado a direita, altura total.
            var panel = NewImage("Panel", _backCanvas.transform, null, new Color(0.995f, 0.94f, 0.96f));
            _panel = panel.rectTransform;
            _panel.anchorMin = new Vector2(1, 0); _panel.anchorMax = new Vector2(1, 1);
            _panel.pivot = new Vector2(1, 0.5f);
            _panel.sizeDelta = new Vector2(PanelWidth, 0);
            _panel.anchoredPosition = Vector2.zero;
            panel.raycastTarget = true;
            var divider = NewImage("Divider", _panel, null, new Color(0.95f, 0.72f, 0.84f));
            var dr = divider.rectTransform;
            dr.anchorMin = new Vector2(0, 0); dr.anchorMax = new Vector2(0, 1);
            dr.pivot = new Vector2(0.5f, 0.5f); dr.anchoredPosition = new Vector2(132.5f, 0); dr.sizeDelta = new Vector2(11f, 0);
        }

        // ---------- frente ----------

        void BuildFront()
        {
            Button(_frontCanvas.transform, "BackButton", Art("Slots/back"), new Vector2(0, 1), new Vector2(92.5f, -91f), new Vector2(146f, 143f), Back);
            Button(_frontCanvas.transform, "DoneButton", Art("AvatarMaker/done"), new Vector2(0, 0), new Vector2(95f, 94f), new Vector2(151f, 149f), Done);
            _undo = Button(_frontCanvas.transform, "UndoButton", Art("AvatarMaker/undo"), new Vector2(0, 0), new Vector2(271f, 94f), new Vector2(151f, 149f), Undo);
            _redo = Button(_frontCanvas.transform, "RedoButton", Art("AvatarMaker/redo"), new Vector2(0, 0), new Vector2(447f, 94f), new Vector2(151f, 149f), Redo);

            // Categorias (icones do original; so as suportadas).
            float y = -170f;
            foreach (var view in Views)
            {
                var v = view;
                var backdrop = NewImage("Indicator_" + v.key, _panel, Art("AvatarMaker/indicator"), Color.white);
                Place(backdrop.rectTransform, new Vector2(0, 1), new Vector2(64f, y), new Vector2(105f, 107f));
                var icon = Button(_panel, "Category_" + v.key, Art("AvatarMaker/cat_" + v.art), new Vector2(0, 1), new Vector2(64f, y), new Vector2(105f, 107f),
                    () => { UiSound.PlayClick(); SelectCategory(v.key); });
                icon.preserveAspect = true;
                _categoryButtons[v.key] = icon;
                backdrop.gameObject.name = "Indicator_" + v.key;
                y -= 150f;
            }

            _grid = new GameObject("Grid", typeof(RectTransform)).GetComponent<RectTransform>();
            _grid.SetParent(_panel, false);
            Stretch(_grid);

            _toast = new GameObject("Toast", typeof(RectTransform), typeof(Text)).GetComponent<Text>();
            _toast.transform.SetParent(_frontCanvas.transform, false);
            var rect = _toast.rectTransform;
            rect.anchorMin = rect.anchorMax = new Vector2(0.35f, 0f);
            rect.anchoredPosition = new Vector2(0, 260f); rect.sizeDelta = new Vector2(1100f, 90f);
            _toast.font = _font; _toast.fontSize = 44; _toast.alignment = TextAnchor.MiddleCenter; _toast.color = new Color(0.45f, 0.2f, 0.6f);
            _toast.raycastTarget = false; _toast.enabled = false;
            RefreshHistoryButtons();
        }

        // ---------- categorias e grade ----------

        public void SelectCategory(string category)
        {
            _category = category;
            foreach (var view in Views)
            {
                bool selected = view.key == category;
                var button = _categoryButtons[view.key];
                button.sprite = Art("AvatarMaker/cat_" + view.art + (selected ? "_sel" : ""));
                _panel.Find("Indicator_" + view.key).gameObject.SetActive(selected);
            }
            RebuildGrid();
        }

        void RebuildGrid()
        {
            for (int i = _grid.childCount - 1; i >= 0; i--) { var c = _grid.GetChild(i).gameObject; c.SetActive(false); Destroy(c); }
            _cells.Clear();
            var options = AvatarCatalog.OptionsByCategory[_category];
            for (int i = 0; i < options.Length; i++)
            {
                string id = options[i];
                float x = 154f + 108.5f + (i % 3) * 225f;
                float y = -150f - 103.5f - (i / 3) * 215f;
                var frame = NewImage("Cell_" + id, _grid, Art("AvatarMaker/indicator"), Color.white);
                frame.type = Image.Type.Sliced;
                Place(frame.rectTransform, new Vector2(0, 1), new Vector2(x, y), new Vector2(217f, 207f));
                frame.raycastTarget = true;
                var button = frame.gameObject.AddComponent<Button>();
                button.targetGraphic = frame;
                button.onClick.AddListener(() => { UiSound.PlayClick(); Choose(id); });
                _cells[id] = frame;

                var item = NewImage("Item", frame.transform, ThumbFor(id), Color.white);
                item.preserveAspect = true;
                Place(item.rectTransform, new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(190f, 180f));
                item.enabled = item.sprite != null;
                if (item.sprite == null)
                {
                    var label = NewText("Loading", frame.transform, 30, new Color(0.5f, 0.25f, 0.55f));
                    Place(label.rectTransform, new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(190f, 60f));
                    label.text = "...";
                }
            }
            RefreshSelection();
        }

        Sprite ThumbFor(string id) => _thumbs.TryGetValue(id, out var sprite) ? sprite : null;

        void RefreshSelection()
        {
            if (_avatar == null || !_avatar.IsReady) return;
            string current = _avatar.CurrentAppearance.Get(_category);
            foreach (var pair in _cells)
                pair.Value.color = pair.Key == current ? new Color(1f, 0.58f, 0.82f) : new Color(1f, 0.9f, 0.95f);
        }

        void Choose(string itemId)
        {
            if (_avatar == null || !_avatar.IsReady) return;
            _avatar.SelectOption(_category, itemId);
            _history.Push(_avatar.CurrentAppearance);
            RefreshSelection();
            RefreshHistoryButtons();
        }

        // ---------- historico ----------

        void Undo()
        {
            if (!_history.CanUndo) return;
            UiSound.PlayClick();
            _avatar.ApplyAppearance(_history.Undo());
            RefreshSelection(); RefreshHistoryButtons();
        }

        void Redo()
        {
            if (!_history.CanRedo) return;
            UiSound.PlayClick();
            _avatar.ApplyAppearance(_history.Redo());
            RefreshSelection(); RefreshHistoryButtons();
        }

        void RefreshHistoryButtons()
        {
            if (_undo != null) _undo.color = new Color(1, 1, 1, _history.CanUndo ? 1f : 0.4f);
            if (_redo != null) _redo.color = new Color(1, 1, 1, _history.CanRedo ? 1f : 0.4f);
        }

        // ---------- sair ----------

        void Done()
        {
            if (_closing) return;
            UiSound.PlayClick();
            var before = _history.Initial;
            try { _saves.Save(_state); }
            catch (Exception e) when (e is IOException || e is UnauthorizedAccessException)
            {
                _avatar.ApplyAppearance(before); // falha de escrita: volta ao que estava salvo
                RefreshSelection();
                ShowToast("Não foi possível salvar. Nada foi alterado.");
                return;
            }
            Close();
        }

        void Back()
        {
            if (_closing) return;
            UiSound.PlayClick();
            if (_history.HasChanges) _avatar.ApplyAppearance(_history.Initial); // descarta a sessao
            Close();
        }

        void Close()
        {
            _closing = true;
            var close = _onClose;
            _onClose = null;
            close?.Invoke();
        }

        // ---------- miniaturas ----------

        /// <summary>Renderiza cada opcao no proprio avatar (camera ortografica recortada) e volta a aparencia original.</summary>
        IEnumerator BuildThumbnails()
        {
            while (_avatar != null && !_avatar.IsReady) yield return null;
            if (_avatar == null) yield break;
            yield return null;
            var original = _avatar.CurrentAppearance.Clone();
            var rt = new RenderTexture(ThumbSize, ThumbSize, 16, RenderTextureFormat.ARGB32);
            _thumbCamera.targetTexture = rt;
            foreach (var view in Views)
                foreach (var id in AvatarCatalog.OptionsByCategory[view.key])
                {
                    _avatar.ApplyAppearance(original); // so a opcao testada varia (sem herdar a anterior)
                    _avatar.ApplyAppearance(original); // so a categoria testada varia (senao o cabelo anterior vaza)
                    _avatar.SelectOption(view.key, id);
                    float half = view.half * AvatarScale;
                    _thumbCamera.orthographicSize = half;
                    _thumbCamera.transform.position = new Vector3(AvatarPosition.x, AvatarPosition.y + view.centerY * AvatarScale, -10f);
                    _thumbCamera.Render();
                    RenderTexture.active = rt;
                    var tex = new Texture2D(ThumbSize, ThumbSize, TextureFormat.RGBA32, false);
                    tex.ReadPixels(new Rect(0, 0, ThumbSize, ThumbSize), 0, 0);
                    tex.Apply();
                    RenderTexture.active = null;
                    _thumbs[id] = Sprite.Create(tex, new Rect(0, 0, ThumbSize, ThumbSize), new Vector2(0.5f, 0.5f), 100f);
                }
            _thumbCamera.targetTexture = null;
            rt.Release();
            Destroy(rt);
            _avatar.ApplyAppearance(original);
            ThumbsReady = true;
            RebuildGrid();
        }

        void ShowToast(string message)
        {
            _toast.text = message; _toast.enabled = true; _toastUntil = Time.unscaledTime + 2.2f;
        }

        void Update()
        {
            if (_toast != null && _toast.enabled && Time.unscaledTime > _toastUntil) _toast.enabled = false;
        }

        // ---------- helpers ----------

        Sprite Art(string path)
        {
            if (_art.TryGetValue(path, out var cached)) return cached;
            var tex = Resources.Load<Texture2D>(path);
            if (tex == null) { Debug.LogWarning("Editor: arte ausente " + path); return null; }
            Vector4 border = path.EndsWith("indicator") ? new Vector4(40, 40, 40, 40) : Vector4.zero;
            var sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100f, 0, SpriteMeshType.FullRect, border);
            _art[path] = sprite;
            return sprite;
        }

        static void Stretch(RectTransform rect)
        {
            rect.anchorMin = Vector2.zero; rect.anchorMax = Vector2.one; rect.offsetMin = rect.offsetMax = Vector2.zero;
        }

        static void Place(RectTransform rect, Vector2 anchor, Vector2 position, Vector2 size)
        {
            rect.anchorMin = rect.anchorMax = anchor;
            rect.pivot = new Vector2(0.5f, 0.5f);
            rect.anchoredPosition = position; rect.sizeDelta = size;
        }

        static Image NewImage(string name, Transform parent, Sprite sprite, Color color)
        {
            var go = new GameObject(name, typeof(RectTransform), typeof(Image));
            go.transform.SetParent(parent, false);
            var image = go.GetComponent<Image>();
            image.sprite = sprite; image.color = color; image.raycastTarget = false;
            return image;
        }

        Text NewText(string name, Transform parent, int size, Color color)
        {
            var go = new GameObject(name, typeof(RectTransform), typeof(Text));
            go.transform.SetParent(parent, false);
            var text = go.GetComponent<Text>();
            text.font = _font; text.fontSize = size; text.alignment = TextAnchor.MiddleCenter; text.color = color; text.raycastTarget = false;
            return text;
        }

        static Image Button(Transform parent, string name, Sprite sprite, Vector2 anchor, Vector2 position, Vector2 size, Action onClick)
        {
            var image = NewImage(name, parent, sprite, Color.white);
            Place(image.rectTransform, anchor, position, size);
            image.raycastTarget = true;
            var button = image.gameObject.AddComponent<Button>();
            button.targetGraphic = image;
            button.onClick.AddListener(() => onClick());
            return image;
        }
    }
}
