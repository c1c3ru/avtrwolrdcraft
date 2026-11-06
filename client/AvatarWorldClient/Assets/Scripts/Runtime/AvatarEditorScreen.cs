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
    /// Usa as categorias e IDs presentes em AvatarCatalog. O catálogo contém 2.174 opções nas quatro categorias
    /// principais, com distribuição provisória derivada dos recursos extraídos; cabelo, boca, sobrancelha e cabelo
    /// traseiro têm listas separadas. O gate de pacotes do original ainda não está reproduzido.
    /// Aproximado: fundo/cor do painel (sem print do original), miniaturas geradas do proprio avatar (o original usa icones),
    /// sem pacotes de expansao. Concluir grava; voltar descarta as mudancas da sessao.
    /// </summary>
    public sealed class AvatarEditorScreen : MonoBehaviour
    {
        const float PanelWidth = 928f; // categorias 127 + divisor + miniaturas 685 + coluna de cores 95
        static readonly Vector3 AvatarPosition = new Vector3(-4.0f, -2.35f, 0f);
        const float AvatarScale = 1f;
        const int ThumbSize = 160;

        struct CategoryView { public string key; public string art; public float centerY, half; }

        // Ordem da coluna de categorias; Skin/Eyes sao de cor (amostras da paleta oficial, sem miniatura).
        static readonly (string key, string art)[] MenuCategories =
        {
            (AvatarCatalog.CategoryHair, "hair"), (AvatarCatalog.CategoryShirt, "shirt"), (AvatarCatalog.CategoryBottom, "bottom"),
            (AvatarCatalog.CategoryShoes, "shoes"), (AvatarCatalog.CategoryAccessory, "accessory"), (AvatarCatalog.CategoryMouth, "mouth"),
            (AvatarCatalog.CategoryEyebrows, "eyebrows"),
            (AvatarCatalog.CategorySkin, "skin"), (AvatarCatalog.CategoryEyes, "eyes"),
        };

        static readonly CategoryView[] Views =
        {
            new CategoryView { key = AvatarCatalog.CategoryHair,      art = "hair",      centerY = 3.50f, half = 1.45f },
            new CategoryView { key = AvatarCatalog.CategoryShirt,     art = "shirt",     centerY = 1.65f, half = 0.95f },
            new CategoryView { key = AvatarCatalog.CategoryBottom,    art = "bottom",    centerY = 0.85f, half = 0.85f },
            new CategoryView { key = AvatarCatalog.CategoryShoes,     art = "shoes",     centerY = 0.30f, half = 0.70f },
            new CategoryView { key = AvatarCatalog.CategoryAccessory, art = "accessory", centerY = 3.10f, half = 1.30f },
            new CategoryView { key = AvatarCatalog.CategoryMouth,     art = "mouth",     centerY = 2.75f, half = 0.70f },
            new CategoryView { key = AvatarCatalog.CategoryHairBack,  art = "hair",      centerY = 3.30f, half = 1.60f },
            new CategoryView { key = AvatarCatalog.CategoryEyebrows,  art = "eyebrows",  centerY = 3.50f, half = 0.70f },
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
        readonly HashSet<string> _thumbFailed = new HashSet<string>();
        int _thumbCount;
        readonly Dictionary<string, Image> _categoryButtons = new Dictionary<string, Image>();
        readonly Dictionary<string, Image> _cells = new Dictionary<string, Image>();
        readonly Dictionary<string, Image> _cellIcons = new Dictionary<string, Image>();
        readonly Dictionary<int, Image> _colorRings = new Dictionary<int, Image>();
        ScrollRect _scroll;
        GridLayoutGroup _gridLayout;
        RectTransform _colorsColumn;
        GameObject _hairTabs;
        readonly Dictionary<string, Image> _hairTabButtons = new Dictionary<string, Image>();
        readonly Dictionary<int, Image> _itemColorRings = new Dictionary<int, Image>();

        public string Category => _category;
        public int VisibleItemCount => _cells.Count;

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
            StartCoroutine(ThumbnailWorker());
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
            float y = -110f;
            foreach (var entry in MenuCategories)
            {
                string key = entry.key;
                var backdrop = NewImage("Indicator_" + key, _panel, Art("AvatarMaker/indicator"), Color.white);
                Place(backdrop.rectTransform, new Vector2(0, 1), new Vector2(64f, y), new Vector2(105f, 107f));
                var icon = Button(_panel, "Category_" + key, Art("AvatarMaker/cat_" + entry.art), new Vector2(0, 1), new Vector2(64f, y), new Vector2(105f, 107f),
                    () => { UiSound.PlayClick(); SelectCategory(key); });
                icon.preserveAspect = true;
                _categoryButtons[key] = icon;
                y -= 100f;
            }

            // Grade de miniaturas com rolagem vertical (centenas de itens): 3 colunas de celas 217x207.
            var viewport = new GameObject("Viewport", typeof(RectTransform), typeof(RectMask2D), typeof(ScrollRect), typeof(Image));
            viewport.transform.SetParent(_panel, false);
            var vr = (RectTransform)viewport.transform;
            vr.anchorMin = Vector2.zero; vr.anchorMax = Vector2.one;
            vr.offsetMin = new Vector2(146f, 20f); vr.offsetMax = new Vector2(-111f, -110f);
            viewport.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            _grid = new GameObject("Grid", typeof(RectTransform), typeof(GridLayoutGroup), typeof(ContentSizeFitter)).GetComponent<RectTransform>();
            _grid.SetParent(viewport.transform, false);
            _grid.anchorMin = new Vector2(0, 1); _grid.anchorMax = new Vector2(1, 1); _grid.pivot = new Vector2(0.5f, 1f);
            _grid.sizeDelta = Vector2.zero;
            var layout = _gridLayout = _grid.GetComponent<GridLayoutGroup>();
            layout.cellSize = new Vector2(217f, 207f);
            layout.spacing = new Vector2(8f, 8f);
            layout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            layout.constraintCount = 3;
            layout.padding = new RectOffset(4, 4, 8, 24);
            _grid.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
            BuildColorsColumn();
            BuildHairTabs();
            _scroll = viewport.GetComponent<ScrollRect>();
            _scroll.viewport = vr; _scroll.content = _grid;
            _scroll.horizontal = false; _scroll.vertical = true;
            _scroll.movementType = ScrollRect.MovementType.Clamped;
            _scroll.scrollSensitivity = 40f;

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

        static string MenuKeyOf(string category) => category == AvatarCatalog.CategoryHairBack ? AvatarCatalog.CategoryHair : category;

        public void SelectCategory(string category)
        {
            _category = category;
            if (_hairTabs != null) _hairTabs.SetActive(MenuKeyOf(category) == AvatarCatalog.CategoryHair);
            RefreshHairTabs();
            foreach (var entry in MenuCategories)
            {
                bool selected = entry.key == MenuKeyOf(category);
                _categoryButtons[entry.key].sprite = Art("AvatarMaker/cat_" + entry.art + (selected ? "_sel" : ""));
                _panel.Find("Indicator_" + entry.key).gameObject.SetActive(selected);
            }
            RebuildGrid();
        }

        // Subcategorias de Cabelo (Subcategories do CharacterMenu): frente (skins Hair_Front) e atras (coques, rabos).
        void BuildHairTabs()
        {
            _hairTabs = new GameObject("HairTabs", typeof(RectTransform));
            _hairTabs.transform.SetParent(_panel, false);
            var rect = (RectTransform)_hairTabs.transform;
            rect.anchorMin = rect.anchorMax = new Vector2(0, 1);
            rect.pivot = new Vector2(0, 1);
            rect.anchoredPosition = new Vector2(146f, -14f);
            rect.sizeDelta = new Vector2(520f, 84f);
            var tabs = new[] { (AvatarCatalog.CategoryHair, "Frente"), (AvatarCatalog.CategoryHairBack, "Atrás") };
            for (int i = 0; i < tabs.Length; i++)
            {
                string key = tabs[i].Item1;
                var tab = NewImage("Tab_" + key, _hairTabs.transform, Art("AvatarMaker/indicator"), Color.white);
                tab.type = Image.Type.Sliced;
                tab.raycastTarget = true;
                Place(tab.rectTransform, new Vector2(0, 0.5f), new Vector2(120f + i * 250f, 0f), new Vector2(230f, 76f));
                var button = tab.gameObject.AddComponent<Button>();
                button.targetGraphic = tab;
                button.onClick.AddListener(() => { UiSound.PlayClick(); SelectCategory(key); });
                var label = NewText("Label", tab.transform, 34, new Color(0.35f, 0.12f, 0.45f));
                Stretch(label.rectTransform);
                label.text = tabs[i].Item2;
                _hairTabButtons[key] = tab;
            }
            _hairTabs.SetActive(false);
        }

        void RefreshHairTabs()
        {
            foreach (var pair in _hairTabButtons)
                pair.Value.color = pair.Key == _category ? new Color(1f, 0.58f, 0.82f) : new Color(1f, 0.9f, 0.95f);
        }

        // Coluna de cores (paleta General) a direita do menu, como o CharacterMenu/Colors do original; so aparece
        // quando o item escolhido na categoria aceita tinta (_color).
        void BuildColorsColumn()
        {
            var column = new GameObject("Colors", typeof(RectTransform), typeof(RectMask2D), typeof(ScrollRect), typeof(Image));
            column.transform.SetParent(_panel, false);
            var cr = (RectTransform)column.transform;
            cr.anchorMin = new Vector2(1, 0); cr.anchorMax = new Vector2(1, 1);
            cr.pivot = new Vector2(1, 0.5f);
            cr.sizeDelta = new Vector2(100f, -130f);
            cr.anchoredPosition = new Vector2(-6f, -40f);
            column.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            var content = new GameObject("Content", typeof(RectTransform), typeof(GridLayoutGroup), typeof(ContentSizeFitter)).GetComponent<RectTransform>();
            content.SetParent(column.transform, false);
            content.anchorMin = new Vector2(0, 1); content.anchorMax = new Vector2(1, 1); content.pivot = new Vector2(0.5f, 1f);
            content.sizeDelta = Vector2.zero;
            var layout = content.GetComponent<GridLayoutGroup>();
            layout.cellSize = new Vector2(84f, 84f); layout.spacing = new Vector2(0f, 8f);
            layout.constraint = GridLayoutGroup.Constraint.FixedColumnCount; layout.constraintCount = 1;
            layout.childAlignment = TextAnchor.UpperCenter; layout.padding = new RectOffset(0, 0, 8, 24);
            content.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
            var scroll = column.GetComponent<ScrollRect>();
            scroll.viewport = cr; scroll.content = content; scroll.horizontal = false; scroll.vertical = true;
            scroll.movementType = ScrollRect.MovementType.Clamped; scroll.scrollSensitivity = 40f;
            _colorsColumn = cr;
            _colorsContent = content;
            column.SetActive(false);
        }

        RectTransform _colorsContent;

        // Cria as amostras uma vez (a paleta General e fixa) assim que o avatar fica pronto.
        void EnsureColorSwatches()
        {
            if (_itemColorRings.Count > 0 || _avatar == null || !_avatar.IsReady) return;
            for (int i = 0; i < _avatar.GeneralPaletteCount; i++)
            {
                int index = i;
                var ring = NewImage("ItemColor_" + index, _colorsContent, Art("AvatarMaker/indicator"), Color.white);
                ring.type = Image.Type.Sliced;
                ring.raycastTarget = true;
                var button = ring.gameObject.AddComponent<Button>();
                button.targetGraphic = ring;
                button.onClick.AddListener(() => { UiSound.PlayClick(); ChooseItemColor(index); });
                _itemColorRings[index] = ring;
                var swatch = NewImage("Color", ring.transform, Art("AvatarMaker/indicator"), _avatar.GeneralSwatch(index));
                swatch.type = Image.Type.Sliced;
                Place(swatch.rectTransform, new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(66f, 66f));
            }
        }

        void ChooseItemColor(int index)
        {
            if (_avatar == null || !_avatar.IsReady) return;
            _avatar.SelectItemColor(AvatarCatalog.ColorKey(_category), index);
            _history.Push(_avatar.CurrentAppearance);
            RefreshSelection();
            RefreshHistoryButtons();
        }

        void RefreshColorsColumn()
        {
            if (_colorsColumn == null) return;
            bool show = _avatar != null && _avatar.IsReady && !AvatarCatalog.IsColorCategory(_category) &&
                        AvatarCatalog.IsColorItem(_avatar.CurrentAppearance.Get(_category));
            _colorsColumn.gameObject.SetActive(show);
            if (!show) return;
            EnsureColorSwatches();
            int selected = _avatar.CurrentAppearance.GetItemColor(AvatarCatalog.ColorKey(_category));
            foreach (var pair in _itemColorRings) pair.Value.color = pair.Key == selected ? new Color(1f, 0.25f, 0.65f) : Color.white;
        }

        // Itens da categoria que existem no esqueleto (peca sem skin "Templates/..." e escondida).
        List<string> AvailableIds(string category)
        {
            var list = new List<string>();
            if (_avatar == null || !_avatar.IsReady || AvatarCatalog.IsColorCategory(category)) return list;
            foreach (var id in AvatarCatalog.OptionsByCategory[category])
                if (_avatar.IsItemAvailable(id)) list.Add(id);
            return list;
        }

        void RebuildGrid()
        {
            for (int i = _grid.childCount - 1; i >= 0; i--) { var c = _grid.GetChild(i).gameObject; c.SetActive(false); Destroy(c); }
            _cells.Clear();
            _cellIcons.Clear();
            _colorRings.Clear();
            _grid.anchoredPosition = Vector2.zero;
            bool colorMode = AvatarCatalog.IsColorCategory(_category);
            _gridLayout.cellSize = colorMode ? new Vector2(98f, 98f) : new Vector2(217f, 207f);
            _gridLayout.constraintCount = colorMode ? 6 : 3;
            if (colorMode) { BuildColorCells(); return; }
            foreach (var id in AvailableIds(_category))
            {
                string itemId = id;
                var frame = NewImage("Cell_" + itemId, _grid, Art("AvatarMaker/indicator"), Color.white);
                frame.type = Image.Type.Sliced;
                frame.raycastTarget = true;
                var button = frame.gameObject.AddComponent<Button>();
                button.targetGraphic = frame;
                button.onClick.AddListener(() => { UiSound.PlayClick(); Choose(itemId); });
                _cells[itemId] = frame;
                bool locked = PackGate.IsLocked(_state, itemId);

                var item = NewImage("Item", frame.transform, ThumbFor(itemId), Color.white);
                item.preserveAspect = true;
                Place(item.rectTransform, new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(190f, 180f));
                item.enabled = item.sprite != null;
                _cellIcons[itemId] = item;
                if (locked)
                {
                    // Peca de combo da loja ainda nao comprado: miniatura esmaecida e etiqueta.
                    item.color = new Color(0.4f, 0.4f, 0.45f, 0.8f);
                    var tag = new GameObject("Locked", typeof(RectTransform), typeof(Text)).GetComponent<Text>();
                    tag.transform.SetParent(frame.transform, false);
                    Place(tag.rectTransform, new Vector2(0.5f, 0f), new Vector2(0f, 26f), new Vector2(200f, 44f));
                    tag.font = _font; tag.fontSize = 30; tag.alignment = TextAnchor.MiddleCenter;
                    tag.color = new Color(0.45f, 0.2f, 0.6f); tag.raycastTarget = false;
                    tag.text = "Na loja";
                }
            }
            RefreshSelection();
        }

        // Amostras da paleta oficial (AWSpineColorsList): anel + circulo de cor; o anel destaca a escolha atual.
        void BuildColorCells()
        {
            if (_avatar == null || !_avatar.IsReady) return;
            int count = AvatarCatalog.ColorCount(_category);
            for (int i = 0; i < count; i++)
            {
                int index = i;
                var ring = NewImage("Swatch_" + index, _grid, Art("AvatarMaker/indicator"), Color.white);
                ring.type = Image.Type.Sliced;
                ring.raycastTarget = true;
                var button = ring.gameObject.AddComponent<Button>();
                button.targetGraphic = ring;
                button.onClick.AddListener(() => { UiSound.PlayClick(); ChooseColor(index); });
                _colorRings[index] = ring;
                var swatch = NewImage("Color", ring.transform, Art("AvatarMaker/indicator"), _avatar.PaletteSwatch(_category, index));
                swatch.type = Image.Type.Sliced;
                Place(swatch.rectTransform, new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(78f, 78f));
            }
            RefreshSelection();
        }

        void ChooseColor(int index)
        {
            if (_avatar == null || !_avatar.IsReady) return;
            _avatar.SelectColor(_category, index);
            _history.Push(_avatar.CurrentAppearance);
            RefreshSelection();
            RefreshHistoryButtons();
        }

        Sprite ThumbFor(string id) => _thumbs.TryGetValue(id, out var sprite) ? sprite : null;

        void RefreshSelection()
        {
            if (_avatar == null || !_avatar.IsReady) return;
            RefreshColorsColumn();
            if (AvatarCatalog.IsColorCategory(_category))
            {
                int selected = _avatar.CurrentAppearance.GetColorIndex(_category);
                foreach (var pair in _colorRings)
                    pair.Value.color = pair.Key == selected ? new Color(1f, 0.25f, 0.65f) : Color.white;
                return;
            }
            string current = _avatar.CurrentAppearance.Get(_category);
            foreach (var pair in _cells)
                pair.Value.color = pair.Key == current ? new Color(1f, 0.58f, 0.82f) : new Color(1f, 0.9f, 0.95f);
        }

        void Choose(string itemId)
        {
            if (_avatar == null || !_avatar.IsReady) return;
            if (PackGate.IsLocked(_state, itemId))
            {
                ShowToast("Peça do combo \"" + PackGate.OfferTitleFor(itemId) + "\" da loja.");
                return;
            }
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

        /// <summary>
        /// Gera as miniaturas aos poucos (uma por quadro), comecando pela categoria aberta: aplica o item no proprio avatar,
        /// renderiza o recorte numa camera ortografica, devolve o item anterior e libera as texturas usadas.
        /// </summary>
        IEnumerator ThumbnailWorker()
        {
            while (_avatar != null && !_avatar.IsReady) yield return null;
            if (_avatar == null) yield break;
            yield return null;
            RebuildGrid(); // agora a disponibilidade dos itens ja pode ser consultada
            var rt = new RenderTexture(ThumbSize, ThumbSize, 16, RenderTextureFormat.ARGB32);
            _thumbCamera.targetTexture = rt;
            while (!_closing && _avatar != null)
            {
                string next = null;
                foreach (var id in AvailableIds(_category))
                    if (!_thumbs.ContainsKey(id) && !_thumbFailed.Contains(id)) { next = id; break; }
                if (next == null) { yield return null; continue; }
                float started = Time.realtimeSinceStartup;
                bool captured = true;
                try { Capture(_category, next, rt); }
                catch (Exception e)
                {
                    captured = false;
                    _thumbFailed.Add(next);
                    Debug.LogError("Editor: falha na miniatura de " + next + ": " + e);
                }
                if (!captured) { yield return null; continue; }
                if (++_thumbCount <= 5 || _thumbCount % 20 == 0)
                    Debug.Log("Editor: miniatura " + _thumbCount + " (" + next + ") em " + Mathf.RoundToInt((Time.realtimeSinceStartup - started) * 1000f) + " ms");
                if (_cellIcons.TryGetValue(next, out var icon) && icon != null)
                {
                    icon.sprite = _thumbs[next];
                    icon.enabled = true;
                }
                yield return null;
            }
            _thumbCamera.targetTexture = null;
            rt.Release();
            Destroy(rt);
        }

        void Capture(string category, string itemId, RenderTexture rt)
        {
            CategoryView view = Views[0];
            foreach (var v in Views) if (v.key == category) view = v;
            string previous = _avatar.CurrentAppearance.Get(category);
            try
            {
                _avatar.SelectOption(category, itemId);
                _thumbCamera.orthographicSize = view.half * AvatarScale;
                _thumbCamera.transform.position = new Vector3(AvatarPosition.x, AvatarPosition.y + view.centerY * AvatarScale, -10f);
                _thumbCamera.Render();
                RenderTexture.active = rt;
                var tex = new Texture2D(ThumbSize, ThumbSize, TextureFormat.RGBA32, false);
                tex.ReadPixels(new Rect(0, 0, ThumbSize, ThumbSize), 0, 0);
                tex.Apply();
                RenderTexture.active = null;
                _thumbs[itemId] = Sprite.Create(tex, new Rect(0, 0, ThumbSize, ThumbSize), new Vector2(0.5f, 0.5f), 100f);
            }
            finally
            {
                // Mesmo se a miniatura falhar, o avatar volta ao item anterior (senao o estado fica preso e e salvo).
                RenderTexture.active = null;
                _avatar.SelectOption(category, previous);
                _avatar.ReleaseUnselected();
            }
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
