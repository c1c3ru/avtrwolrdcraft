using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AvatarWorld.Core.Economy;
using UnityEngine;
using UnityEngine.UI;

namespace AvatarWorld.Runtime
{
    /// <summary>
    /// Loja por item: os GUIDs de store_catalog.json por categoria, 12 por pagina, com preco de ItemPricing
    /// (3 faixas, invencao local) e compra unica via LocalStoreService. Aberta pelo botao "Itens" da loja.
    /// Sem arte por item (as imagens dos itens ainda nao foram exportadas): cartoes de texto.
    /// </summary>
    public sealed class ItemBrowserScreen : MonoBehaviour
    {
        const int Cols = 4, Rows = 3, PageSize = Cols * Rows, ChipCount = 8;
        static readonly Color Purple = new Color(0.42f, 0.22f, 0.62f);
        static readonly Color Card = new Color(1f, 0.93f, 0.98f);
        static readonly Color TextDark = new Color(0.2f, 0.1f, 0.3f);

        ItemCatalogIndex _index;
        PlayerState _state;
        SaveStore _saves;
        Action _onClose;
        Font _font;
        Transform _root, _grid;
        Text _coins, _pageLabel, _toast;
        float _toastUntil;
        GameObject _modal;
        IReadOnlyList<string> _chips;
        readonly Dictionary<string, Image> _chipImages = new Dictionary<string, Image>();
        readonly Dictionary<string, Sprite> _sprites = new Dictionary<string, Sprite>();
        string _category;
        int _page;

        public string Category => _category;
        public int Page => _page;
        public ItemCatalogIndex Index => _index;

        public void Begin(PlayerState state, SaveStore saves, Action onClose)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
            _saves = saves;
            _onClose = onClose;
            _font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            var json = Resources.Load<TextAsset>("Store/items");
            if (json == null) throw new InvalidOperationException("Store/items.json ausente em Resources");
            var file = JsonUtility.FromJson<ItemCatalogFile>(json.text);
            _index = new ItemCatalogIndex(file.items.Select(e => new CatalogItem { Guid = e.g, Name = e.n, Category = e.c }));
            UiSceneBuilder.EnsureEventSystem();
            BuildFrame();
            Select(_chips[0], 0);
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
            var go = new GameObject("ItemBrowserCanvas", typeof(RectTransform), typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
            go.transform.SetParent(transform, false);
            _root = go.transform;
            var canvas = go.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.overrideSorting = true;
            canvas.sortingOrder = 850;
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
            var pill = Img("Coins", _root, Art("Store/ui/currency_bg"), Color.white);
            Place(pill.rectTransform, new Vector2(1, 1), new Vector2(-169f, -68f), new Vector2(284f, 91f));
            var coin = Img("Coin", pill.transform, Art("Store/ui/coin"), Color.white);
            Place(coin.rectTransform, new Vector2(0.5f, 0.5f), new Vector2(-102f, -2f), new Vector2(100f, 100f));
            _coins = Txt("Value", pill.transform, 52, TextAnchor.MiddleRight, Color.white);
            Place(_coins.rectTransform, new Vector2(0.5f, 0.5f), new Vector2(26f, 0f), new Vector2(190f, 92f));
            RefreshCoins();

            var title = Txt("Title", _root, 56, TextAnchor.MiddleCenter, Color.white);
            Place(title.rectTransform, new Vector2(0.5f, 1), new Vector2(0f, -70f), new Vector2(900f, 90f));
            title.text = "Itens (" + _index.Count + ")";

            _chips = _index.Categories(ChipCount);
            float x = 330f;
            foreach (var category in _chips)
            {
                string c = category;
                var chip = Img("Chip_" + c, _root, null, Color.white);
                Place(chip.rectTransform, new Vector2(0, 1), new Vector2(x, -190f), new Vector2(200f, 70f));
                var label = Txt("Label", chip.transform, 34, TextAnchor.MiddleCenter, TextDark);
                Stretch(label.rectTransform);
                label.text = c;
                Click(chip.gameObject, () => { UiSound.PlayClick(); Select(c, 0); });
                _chipImages[c] = chip;
                x += 215f;
            }

            _grid = new GameObject("Grid", typeof(RectTransform)).transform;
            _grid.SetParent(_root, false);
            Stretch((RectTransform)_grid);

            Arrow("Prev", "‹", new Vector2(-180f, 60f), -1);
            Arrow("Next", "›", new Vector2(180f, 60f), +1);
            _pageLabel = Txt("PageLabel", _root, 44, TextAnchor.MiddleCenter, Color.white);
            Place(_pageLabel.rectTransform, new Vector2(0.5f, 0), new Vector2(0f, 60f), new Vector2(360f, 80f));

            _toast = Txt("Toast", _root, 46, TextAnchor.MiddleCenter, Color.white);
            Place(_toast.rectTransform, new Vector2(0.5f, 0), new Vector2(0f, 150f), new Vector2(1500f, 90f));
            _toast.gameObject.AddComponent<Outline>().effectColor = new Color(0.2f, 0.05f, 0.35f);
            _toast.enabled = false;
        }

        void Arrow(string name, string glyph, Vector2 position, int delta)
        {
            var image = Img(name, _root, null, new Color(1f, 1f, 1f, 0.25f));
            Place(image.rectTransform, new Vector2(0.5f, 0), new Vector2(position.x * 2f, position.y), new Vector2(150f, 80f));
            var t = Txt("Glyph", image.transform, 64, TextAnchor.MiddleCenter, Color.white);
            Stretch(t.rectTransform);
            t.text = glyph;
            Click(image.gameObject, () => { UiSound.PlayClick(); Go(delta); });
        }

        void Go(int delta)
        {
            int pages = Math.Max(1, _index.PageCount(_category, PageSize));
            Select(_category, ((_page + delta) % pages + pages) % pages);
        }

        public void Select(string category, int page)
        {
            _category = category;
            _page = page;
            foreach (var pair in _chipImages)
                pair.Value.color = pair.Key == category ? Color.white : new Color(1f, 1f, 1f, 0.45f);
            for (int i = _grid.childCount - 1; i >= 0; i--)
            {
                var child = _grid.GetChild(i).gameObject;
                child.SetActive(false);
                Destroy(child);
            }
            var items = _index.Page(category, page, PageSize);
            for (int i = 0; i < items.Count; i++) BuildCard(items[i], i);
            _pageLabel.text = (page + 1) + " / " + Math.Max(1, _index.PageCount(category, PageSize));
        }

        void BuildCard(CatalogItem item, int slot)
        {
            int col = slot % Cols, row = slot / Cols;
            var card = Img("Card_" + item.Guid, _grid, null, Card);
            Place(card.rectTransform, new Vector2(0, 1), new Vector2(430f + col * 415f, -380f - row * 190f), new Vector2(395f, 170f));
            var name = Txt("Name", card.transform, 32, TextAnchor.UpperCenter, TextDark);
            Place(name.rectTransform, new Vector2(0.5f, 1), new Vector2(0f, -50f), new Vector2(370f, 90f));
            name.text = item.DisplayName;
            name.verticalOverflow = VerticalWrapMode.Truncate;
            bool owned = _state.GetClaimCount(item.Guid) >= 1;
            var price = Txt("Price", card.transform, 40, TextAnchor.MiddleCenter, owned ? new Color(0.1f, 0.5f, 0.2f) : TextDark);
            Place(price.rectTransform, new Vector2(0.5f, 0), new Vector2(0f, 32f), new Vector2(370f, 56f));
            price.text = owned ? "Adquirido" : item.Price + " moedas";
            var captured = item;
            Click(card.gameObject, () => { UiSound.PlayClick(); OnTapped(captured); });
        }

        void OnTapped(CatalogItem item)
        {
            if (_state.GetClaimCount(item.Guid) >= 1) { ShowToast("Você já tem este item."); return; }
            OpenModal(item);
        }

        void OpenModal(CatalogItem item)
        {
            CloseModal();
            bool canPay = _state.PazuCurrency >= item.Price;
            _modal = new GameObject("Modal", typeof(RectTransform));
            _modal.transform.SetParent(_root, false);
            Stretch((RectTransform)_modal.transform);
            var dim = Img("Dim", _modal.transform, null, new Color(0, 0, 0, 0.7f));
            Stretch(dim.rectTransform);
            Click(dim.gameObject, CloseModal);
            var panel = Img("Panel", _modal.transform, null, Card);
            Place(panel.rectTransform, new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(1100f, 520f));
            panel.raycastTarget = true;
            var msg = Txt("Message", panel.transform, 44, TextAnchor.MiddleCenter, TextDark);
            Place(msg.rectTransform, new Vector2(0.5f, 1), new Vector2(0f, -170f), new Vector2(1000f, 220f));
            msg.text = canPay
                ? "Comprar \"" + item.DisplayName + "\" por " + item.Price + " moedas?"
                : "Faltam " + (item.Price - _state.PazuCurrency) + " moedas para \"" + item.DisplayName + "\".";
            if (canPay) Button(panel.transform, "Comprar", new Vector2(-250f, 80f), () => Purchase(item));
            Button(panel.transform, canPay ? "Cancelar" : "Fechar", new Vector2(canPay ? 250f : 0f, 80f), CloseModal);
        }

        void Button(Transform parent, string label, Vector2 pos, Action action)
        {
            var b = Img("Btn_" + label, parent, Art("Icons/pill_green"), Color.white);
            Place(b.rectTransform, new Vector2(0.5f, 0), pos, new Vector2(400f, 110f));
            var t = Txt("Label", b.transform, 42, TextAnchor.MiddleCenter, TextDark);
            Stretch(t.rectTransform);
            t.text = label;
            Click(b.gameObject, () => { UiSound.PlayClick(); action(); });
        }

        void Purchase(CatalogItem item)
        {
            string snapshot = JsonUtility.ToJson(_state);
            var result = new LocalStoreService(_state).Claim(item.ToStoreItem());
            if (!result.Success)
            {
                CloseModal();
                ShowToast(result.Error == ClaimError.InsufficientFunds ? "Moedas insuficientes." : "Não foi possível comprar agora.");
                return;
            }
            try { _saves?.Save(_state); }
            catch (Exception e) when (e is IOException || e is UnauthorizedAccessException)
            {
                JsonUtility.FromJsonOverwrite(snapshot, _state);
                CloseModal();
                ShowToast("Não foi possível salvar. A compra foi desfeita.");
                return;
            }
            CloseModal();
            RefreshCoins();
            Select(_category, _page);
            ShowToast("Item adquirido!");
        }

        void CloseModal() { if (_modal != null) Destroy(_modal); _modal = null; }

        void RefreshCoins() { if (_coins != null) _coins.text = _state.PazuCurrency.ToString(); }

        void ShowToast(string m) { _toast.text = m; _toast.enabled = true; _toastUntil = Time.unscaledTime + 2f; }

        void Update() { if (_toast != null && _toast.enabled && Time.unscaledTime > _toastUntil) _toast.enabled = false; }

        // ---------- helpers de UI ----------

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
