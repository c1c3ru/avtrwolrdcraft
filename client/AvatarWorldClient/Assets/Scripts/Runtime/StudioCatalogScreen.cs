using AvatarWorld.Core.Avatar;
using AvatarWorld.Core.Economy;
using AvatarWorld.Core.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace AvatarWorld.Runtime
{
    /// <summary>
    /// Catalogos abertos ao jogador (so leitura), aberta pelas Configuracoes. No original sao ferramentas internas do estudio
    /// (EditorApp: busca de itens com previa e navegacao de skins por diretorio); aqui viram duas abas no padrao do app:
    /// "Itens da loja" (store_catalog.json) e "Roupas e skins" (AvatarCatalog), com busca por texto, chips de categoria e
    /// detalhe. A logica de busca/filtro/paginacao e <see cref="CatalogView"/> (Core, testada). Sem compra: a loja continua
    /// sendo o unico caminho de aquisicao.
    /// Limite: so as maiores categorias viram chips (ChipCount); as demais continuam acessiveis pela busca, que tambem casa o nome da categoria.
    /// </summary>
    public sealed class StudioCatalogScreen : MonoBehaviour
    {
        const int Cols = 4, Rows = 3, PageSize = Cols * Rows, ChipCount = 7;
        static readonly Color Purple = new Color(0.42f, 0.22f, 0.62f);
        static readonly Color Card = new Color(1f, 0.93f, 0.98f);
        static readonly Color TextDark = new Color(0.2f, 0.1f, 0.3f);

        PlayerState _state;
        Action _onClose;
        Font _font;
        Transform _root, _grid, _chipRow;
        Text _count, _pageLabel, _empty;
        InputField _search;
        GameObject _modal;
        readonly Dictionary<string, Image> _chipImages = new Dictionary<string, Image>();
        readonly Dictionary<string, Sprite> _sprites = new Dictionary<string, Sprite>();
        readonly Image[] _tabImages = new Image[2];
        CatalogView[] _views;
        Dictionary<string, CatalogItem> _items;
        int _tab;

        public int Tab => _tab;
        public CatalogView View => _views[_tab];

        public void Begin(PlayerState state, Action onClose)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
            _onClose = onClose;
            _font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            var json = Resources.Load<TextAsset>("Store/items");
            if (json == null) throw new InvalidOperationException("Store/items.json ausente em Resources");
            var file = JsonUtility.FromJson<ItemCatalogFile>(json.text);
            _items = file.items.Select(e => new CatalogItem { Guid = e.g, Name = e.n, Category = e.c }).ToDictionary(i => i.Guid, i => i);
            var itemEntries = _items.Values.Select(i => new CatalogEntry(i.Guid, i.DisplayName, i.Category));
            var pieceEntries = AvatarCatalog.OptionsByCategory
                .SelectMany(p => p.Value.Select(id => new CatalogEntry(id, id.Replace('_', ' '), p.Key)));
            _views = new[] { new CatalogView(itemEntries, PageSize), new CatalogView(pieceEntries, PageSize) };
            UiSceneBuilder.EnsureEventSystem();
            BuildFrame();
            SelectTab(0);
        }

        Sprite Art(string path)
        {
            if (_sprites.TryGetValue(path, out var s)) return s;
            var tex = Resources.Load<Texture2D>(path);
            if (tex == null) return null;
            return _sprites[path] = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100f);
        }

        void BuildFrame()
        {
            var go = new GameObject("StudioCatalogCanvas", typeof(RectTransform), typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
            go.transform.SetParent(transform, false);
            _root = go.transform;
            var canvas = go.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.overrideSorting = true;
            canvas.sortingOrder = 860;
            var scaler = go.GetComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(2048f, 1024f);
            scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;

            var bg = Img("Background", _root, null, Purple);
            Stretch(bg.rectTransform);
            bg.raycastTarget = true;
            var back = Img("Back", _root, Art("Store/ui/back"), Color.white);
            Place(back.rectTransform, new Vector2(0, 1), new Vector2(111f, -98f), new Vector2(155f, 154f));
            Click(back.gameObject, () => { UiSound.PlayClick(); _onClose?.Invoke(); });

            var title = Txt("Title", _root, 56, TextAnchor.MiddleCenter, Color.white);
            Place(title.rectTransform, new Vector2(0.5f, 1), new Vector2(0f, -70f), new Vector2(900f, 90f));
            title.text = Loc.Get("catalog.title");

            string[] tabKeys = { "catalog.tab.items", "catalog.tab.pieces" };
            for (int t = 0; t < 2; t++)
            {
                int tab = t;
                var chip = Img("Tab_" + t, _root, null, Card);
                Place(chip.rectTransform, new Vector2(0, 1), new Vector2(380f + t * 330f, -190f), new Vector2(310f, 80f));
                var label = Txt("Label", chip.transform, 34, TextAnchor.MiddleCenter, TextDark);
                Stretch(label.rectTransform);
                label.text = Loc.Get(tabKeys[t]);
                Click(chip.gameObject, () => { UiSound.PlayClick(); SelectTab(tab); });
                _tabImages[t] = chip;
            }

            var field = Img("Search", _root, null, Color.white);
            Place(field.rectTransform, new Vector2(1, 1), new Vector2(-560f, -190f), new Vector2(900f, 80f));
            field.raycastTarget = true;
            var text = Txt("Text", field.transform, 40, TextAnchor.MiddleLeft, TextDark);
            Stretch(text.rectTransform);
            text.rectTransform.offsetMin = new Vector2(24f, 4f);
            text.rectTransform.offsetMax = new Vector2(-24f, -4f);
            text.horizontalOverflow = HorizontalWrapMode.Overflow;
            text.supportRichText = false;
            var placeholder = Txt("Placeholder", field.transform, 40, TextAnchor.MiddleLeft, new Color(0.2f, 0.1f, 0.3f, 0.45f));
            Stretch(placeholder.rectTransform);
            placeholder.rectTransform.offsetMin = new Vector2(24f, 4f);
            placeholder.rectTransform.offsetMax = new Vector2(-24f, -4f);
            placeholder.text = Loc.Get("catalog.search");
            _search = field.gameObject.AddComponent<InputField>();
            _search.targetGraphic = field;
            _search.textComponent = text;
            _search.placeholder = placeholder;
            _search.lineType = InputField.LineType.SingleLine;
            _search.onValueChanged.AddListener(OnQuery);

            _chipRow = new GameObject("Chips", typeof(RectTransform)).transform;
            _chipRow.SetParent(_root, false);
            Stretch((RectTransform)_chipRow);

            _grid = new GameObject("Grid", typeof(RectTransform)).transform;
            _grid.SetParent(_root, false);
            Stretch((RectTransform)_grid);

            Arrow("Prev", "‹", new Vector2(-180f, 60f), -1);
            Arrow("Next", "›", new Vector2(180f, 60f), +1);
            _pageLabel = Txt("PageLabel", _root, 44, TextAnchor.MiddleCenter, Color.white);
            Place(_pageLabel.rectTransform, new Vector2(0.5f, 0), new Vector2(0f, 60f), new Vector2(360f, 80f));
            _count = Txt("Count", _root, 36, TextAnchor.MiddleLeft, new Color(1f, 1f, 1f, 0.8f));
            Place(_count.rectTransform, new Vector2(0, 0), new Vector2(330f, 60f), new Vector2(500f, 80f));
            _empty = Txt("Empty", _root, 52, TextAnchor.MiddleCenter, Color.white);
            Place(_empty.rectTransform, new Vector2(0.5f, 0.5f), new Vector2(0f, -40f), new Vector2(1200f, 120f));
            _empty.text = Loc.Get("catalog.empty");
            _empty.enabled = false;
        }

        void Arrow(string name, string glyph, Vector2 position, int delta)
        {
            var image = Img(name, _root, null, new Color(1f, 1f, 1f, 0.25f));
            Place(image.rectTransform, new Vector2(0.5f, 0), new Vector2(position.x * 2f, position.y), new Vector2(150f, 80f));
            var t = Txt("Glyph", image.transform, 64, TextAnchor.MiddleCenter, Color.white);
            Stretch(t.rectTransform);
            t.text = glyph;
            Click(image.gameObject, () => { UiSound.PlayClick(); View.Move(delta); Refresh(); });
        }

        public void SelectTab(int tab)
        {
            _tab = tab;
            for (int i = 0; i < 2; i++)
            {
                var c = _tabImages[i].color;
                c.a = i == tab ? 1f : 0.45f;
                _tabImages[i].color = c;
            }
            _search.SetTextWithoutNotify(View.Query);
            BuildChips();
            Refresh();
        }

        public void SetQuery(string query)
        {
            _search.SetTextWithoutNotify(query ?? "");
            OnQuery(query ?? "");
        }

        public void SetCategory(string category)
        {
            View.SetCategory(category);
            UpdateChipColors();
            Refresh();
        }

        void OnQuery(string query)
        {
            View.SetQuery(query);
            Refresh();
        }

        void BuildChips()
        {
            for (int i = _chipRow.childCount - 1; i >= 0; i--)
            {
                var child = _chipRow.GetChild(i).gameObject;
                child.SetActive(false);
                Destroy(child);
            }
            _chipImages.Clear();
            var categories = new List<string> { "" };
            categories.AddRange(View.TopCategories(ChipCount));
            float x = 330f;
            foreach (var category in categories)
            {
                string c = category;
                var chip = Img("Chip_" + (c.Length == 0 ? "all" : c), _chipRow, null, CategoryColor(c));
                Place(chip.rectTransform, new Vector2(0, 1), new Vector2(x, -290f), new Vector2(200f, 70f));
                var label = Txt("Label", chip.transform, 30, TextAnchor.MiddleCenter, TextDark);
                Stretch(label.rectTransform);
                label.text = c.Length == 0 ? Loc.Get("catalog.all") : c;
                Click(chip.gameObject, () => { UiSound.PlayClick(); SetCategory(c); });
                _chipImages[c] = chip;
                x += 215f;
            }
            UpdateChipColors();
        }

        void UpdateChipColors()
        {
            foreach (var pair in _chipImages)
            {
                var color = CategoryColor(pair.Key);
                color.a = pair.Key == View.Category ? 1f : 0.45f;
                pair.Value.color = color;
            }
        }

        void Refresh()
        {
            for (int i = _grid.childCount - 1; i >= 0; i--)
            {
                var child = _grid.GetChild(i).gameObject;
                child.SetActive(false);
                Destroy(child);
            }
            var page = View.CurrentPage;
            for (int i = 0; i < page.Count; i++) BuildCard(page[i], i);
            _pageLabel.text = (View.Page + 1) + " / " + View.PageCount;
            _count.text = Loc.Format("catalog.count", View.Count, View.Total);
            _empty.enabled = View.Count == 0;
        }

        /// <summary>Cor deterministica por categoria (hash do nome -> matiz); "" (todas) fica neutra.</summary>
        static Color CategoryColor(string category)
        {
            if (string.IsNullOrEmpty(category)) return new Color(0.9f, 0.9f, 0.95f);
            int hash = category.GetHashCode();
            return Color.HSVToRGB((hash & 0xFFFF) / (float)0xFFFF, 0.45f, 0.95f);
        }

        void BuildCard(CatalogEntry entry, int slot)
        {
            int col = slot % Cols, row = slot / Cols;
            var card = Img("Card_" + entry.Id, _grid, null, Card);
            Place(card.rectTransform, new Vector2(0, 1), new Vector2(430f + col * 415f, -430f - row * 190f), new Vector2(395f, 170f));
            var accent = Img("Accent", card.transform, null, CategoryColor(entry.Category));
            Place(accent.rectTransform, new Vector2(0.5f, 1), new Vector2(0f, -5f), new Vector2(395f, 10f));
            var name = Txt("Name", card.transform, 30, TextAnchor.UpperCenter, TextDark);
            Place(name.rectTransform, new Vector2(0.5f, 1), new Vector2(0f, -50f), new Vector2(370f, 84f));
            name.text = entry.Title;
            name.verticalOverflow = VerticalWrapMode.Truncate;
            string subtitle = Subtitle(entry, out bool owned);
            var sub = Txt("Sub", card.transform, 32, TextAnchor.MiddleCenter, owned ? new Color(0.1f, 0.5f, 0.2f) : TextDark);
            Place(sub.rectTransform, new Vector2(0.5f, 0), new Vector2(0f, 30f), new Vector2(370f, 50f));
            sub.text = subtitle ?? entry.Category;
            var captured = entry;
            Click(card.gameObject, () => { UiSound.PlayClick(); OpenDetail(captured); });
        }

        /// <summary>Itens da loja: "Adquirido" ou o preco. Pecas de avatar: sem subtitulo proprio (usa a categoria).</summary>
        string Subtitle(CatalogEntry entry, out bool owned)
        {
            owned = false;
            if (_tab != 0 || !_items.TryGetValue(entry.Id, out var item)) return null;
            owned = _state.GetClaimCount(item.Guid) >= 1;
            return owned ? Loc.Get("store.owned") : Loc.Format("item.price", item.Price);
        }

        void OpenDetail(CatalogEntry entry)
        {
            CloseModal();
            _modal = new GameObject("Modal", typeof(RectTransform));
            _modal.transform.SetParent(_root, false);
            Stretch((RectTransform)_modal.transform);
            var dim = Img("Dim", _modal.transform, null, new Color(0, 0, 0, 0.7f));
            Stretch(dim.rectTransform);
            Click(dim.gameObject, CloseModal);
            var panel = Img("Panel", _modal.transform, null, Card);
            Place(panel.rectTransform, new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(1300f, 620f));
            panel.raycastTarget = true;
            var head = Txt("Name", panel.transform, 52, TextAnchor.MiddleCenter, TextDark);
            Place(head.rectTransform, new Vector2(0.5f, 1), new Vector2(0f, -100f), new Vector2(1200f, 150f));
            head.text = entry.Title;
            string detail = Loc.Get("catalog.category") + ": " + entry.Category + "\n" + Loc.Get("catalog.code") + ": " + entry.Id;
            var sub = Subtitle(entry, out _);
            if (sub != null) detail += "\n" + Loc.Get("catalog.price") + ": " + sub;
            var body = Txt("Detail", panel.transform, 38, TextAnchor.MiddleCenter, TextDark);
            Place(body.rectTransform, new Vector2(0.5f, 0.5f), new Vector2(0f, -10f), new Vector2(1200f, 260f));
            body.text = detail;
            var b = Img("Btn_close", panel.transform, Art("Icons/pill_green"), Color.white);
            Place(b.rectTransform, new Vector2(0.5f, 0), new Vector2(0f, 80f), new Vector2(400f, 110f));
            var t = Txt("Label", b.transform, 42, TextAnchor.MiddleCenter, TextDark);
            Stretch(t.rectTransform);
            t.text = Loc.Get("item.close");
            Click(b.gameObject, () => { UiSound.PlayClick(); CloseModal(); });
        }

        void CloseModal() { if (_modal != null) Destroy(_modal); _modal = null; }

        // ---------- helpers de UI (iguais aos das outras telas) ----------

        Image Img(string name, Transform parent, Sprite sprite, Color color)
        {
            var go = new GameObject(name, typeof(RectTransform), typeof(Image));
            go.transform.SetParent(parent, false);
            var i = go.GetComponent<Image>();
            i.sprite = sprite; i.color = color; i.raycastTarget = false;
            return i;
        }

        Text Txt(string name, Transform parent, int size, TextAnchor anchor, Color color)
        {
            var go = new GameObject(name, typeof(RectTransform), typeof(Text));
            go.transform.SetParent(parent, false);
            var t = go.GetComponent<Text>();
            t.font = _font; t.fontSize = size; t.alignment = anchor; t.color = color;
            t.horizontalOverflow = HorizontalWrapMode.Wrap; t.raycastTarget = false;
            return t;
        }

        static void Click(GameObject go, Action action)
        {
            var image = go.GetComponent<Image>();
            if (image != null) image.raycastTarget = true;
            var b = go.GetComponent<Button>() ?? go.AddComponent<Button>();
            b.targetGraphic = image;
            b.onClick.AddListener(() => action());
        }

        static void Place(RectTransform r, Vector2 anchor, Vector2 pos, Vector2 size)
        {
            r.anchorMin = r.anchorMax = anchor; r.pivot = new Vector2(0.5f, 0.5f);
            r.anchoredPosition = pos; r.sizeDelta = size;
        }

        static void Stretch(RectTransform r)
        {
            r.anchorMin = Vector2.zero; r.anchorMax = Vector2.one; r.offsetMin = r.offsetMax = Vector2.zero;
        }
    }
}
