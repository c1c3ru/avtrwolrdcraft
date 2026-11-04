using System;
using System.Collections.Generic;
using System.IO;
using AvatarWorld.Core.Economy;
using AvatarWorld.Core.Literacy;
using UnityEngine;
using UnityEngine.UI;

namespace AvatarWorld.Runtime
{
    /// <summary>
    /// Loja com a moldura do original (cena Store: voltar, contador de moedas, trilho de categorias, cartoes de
    /// combos com rolagem). A logica e local: compra so com moedas do jogo; sem moedas, a categoria "Moedas AW" e o
    /// aviso de compra levam a desafios pedagogicos que pagam moedas. Sem dinheiro real nem RESTORE PURCHASES.
    /// Arte em Resources/Store; posicoes em unidades do canvas 2048x1024 (level237 + prints 16.03.10-16.07.35).
    /// </summary>
    public sealed class StoreScreen : MonoBehaviour
    {
        static readonly Color Purple = new Color(0.42f, 0.22f, 0.62f);
        static readonly Color TextDark = new Color(0.2f, 0.1f, 0.3f);

        PlayerState _state;
        SaveStore _saves;
        Action _onClose;
        Action<int> _onEarnCoins;
        Font _font;
        Transform _root;
        RectTransform _content;
        Text _coinText;
        string _category;
        GameObject _modal;
        Text _toast;
        float _toastUntil;
        readonly Dictionary<string, Sprite> _sprites = new Dictionary<string, Sprite>();
        readonly Dictionary<string, Image> _railButtons = new Dictionary<string, Image>();

        public string Category => _category;
        public int ShownCardCount => _content != null ? _content.childCount : 0;

        /// <summary>onEarnCoins(preco) abre os desafios cuja dificuldade corresponde ao preco.</summary>
        public void Begin(PlayerState state, SaveStore saves, Action onClose, Action<int> onEarnCoins)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
            _saves = saves;
            _onClose = onClose;
            _onEarnCoins = onEarnCoins;
            _font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            UiSceneBuilder.EnsureEventSystem();
            BuildFrame();
            SelectCategory(StoreCatalog.CategoryFeatured);
        }

        public void RefreshCoins()
        {
            if (_coinText != null) _coinText.text = _state.PazuCurrency.ToString();
        }

        // ---------- moldura ----------

        Sprite Art(string path, Vector4 border = default)
        {
            string key = path + "|" + border;
            if (_sprites.TryGetValue(key, out var cached)) return cached;
            var tex = Resources.Load<Texture2D>(path);
            if (tex == null) { Debug.LogWarning("Store: arte ausente " + path); return null; }
            var sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100f, 0,
                SpriteMeshType.FullRect, border);
            _sprites[key] = sprite;
            return sprite;
        }

        void BuildFrame()
        {
            var rootGo = new GameObject("StoreCanvas", typeof(RectTransform), typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
            rootGo.transform.SetParent(transform, false);
            _root = rootGo.transform;
            var canvas = rootGo.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.overrideSorting = true;
            canvas.sortingOrder = 800;
            var scaler = rootGo.GetComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(2048f, 1024f);
            scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;

            var bg = NewImage("Background", _root, null, Purple);
            Stretch(bg.rectTransform, Vector2.zero, Vector2.one);
            bg.raycastTarget = true;

            // Voltar: BackButton do original (155x154, topo-esquerda).
            var back = NewImage("BackButton", _root, Art("Store/ui/back"), Color.white);
            Anchor(back.rectTransform, new Vector2(0, 1), new Vector2(111.2f, -98.2f), new Vector2(155f, 154f));
            Click(back.gameObject, () => { UiSound.PlayClick(); _onClose?.Invoke(); });

            // Contador de moedas (PazuCurrencyViewer: pilula escura + icone + valor).
            var pill = NewImage("CurrencyViewer", _root, Art("Store/ui/currency_bg"), Color.white);
            Anchor(pill.rectTransform, new Vector2(1, 1), new Vector2(-169f, -68f), new Vector2(284f, 91f));
            var coin = NewImage("Coin", pill.transform, Art("Store/ui/coin"), Color.white);
            Anchor(coin.rectTransform, new Vector2(0.5f, 0.5f), new Vector2(-102.1f, -2.3f), new Vector2(100f, 100f));
            _coinText = NewText("Value", pill.transform, 52, TextAnchor.MiddleRight, Color.white);
            Anchor(_coinText.rectTransform, new Vector2(0.5f, 0.5f), new Vector2(26f, 0f), new Vector2(190f, 92f));
            RefreshCoins();

            BuildRail();

            var scrollGo = new GameObject("Items", typeof(RectTransform), typeof(RectMask2D), typeof(ScrollRect), typeof(Image));
            scrollGo.transform.SetParent(_root, false);
            var scrollRect = (RectTransform)scrollGo.transform;
            scrollRect.anchorMin = Vector2.zero; scrollRect.anchorMax = Vector2.one;
            scrollRect.offsetMin = new Vector2(250f, 90f); scrollRect.offsetMax = new Vector2(-60f, -210f);
            scrollGo.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            var contentGo = new GameObject("Content", typeof(RectTransform), typeof(HorizontalLayoutGroup), typeof(ContentSizeFitter));
            _content = (RectTransform)contentGo.transform;
            _content.SetParent(scrollGo.transform, false);
            _content.anchorMin = new Vector2(0, 0); _content.anchorMax = new Vector2(0, 1);
            _content.pivot = new Vector2(0, 0.5f);
            _content.sizeDelta = Vector2.zero;
            var layout = contentGo.GetComponent<HorizontalLayoutGroup>();
            layout.spacing = 48f; layout.padding = new RectOffset(24, 24, 0, 0);
            layout.childAlignment = TextAnchor.MiddleLeft;
            layout.childControlWidth = layout.childControlHeight = true;
            layout.childForceExpandWidth = layout.childForceExpandHeight = false;
            contentGo.GetComponent<ContentSizeFitter>().horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
            var scroll = scrollGo.GetComponent<ScrollRect>();
            scroll.viewport = scrollRect; scroll.content = _content;
            scroll.horizontal = true; scroll.vertical = false;
            scroll.movementType = ScrollRect.MovementType.Clamped;
            scroll.scrollSensitivity = 40f;

            _toast = NewText("Toast", _root, 46, TextAnchor.MiddleCenter, Color.white);
            Anchor(_toast.rectTransform, new Vector2(0.5f, 0f), new Vector2(0f, 52f), new Vector2(1500f, 90f));
            _toast.gameObject.AddComponent<Outline>().effectColor = new Color(0.2f, 0.05f, 0.35f);
            _toast.enabled = false;
        }

        static string RailArt(string category)
        {
            switch (category)
            {
                case StoreCatalog.CategoryCoins: return "cat_coins";
                case StoreCatalog.CategoryFeatured: return "cat_featured";
                case StoreCatalog.CategoryHouses: return "cat_houses";
                case StoreCatalog.CategoryFashion: return "cat_fashion";
                case StoreCatalog.CategoryPets: return "cat_pets";
                default: return "cat_combos";
            }
        }

        /// <summary>Trilho lateral so com icones do original (Static/Pressed), sem texto.</summary>
        void BuildRail()
        {
            float y = -268f;
            foreach (var category in StoreCatalog.Categories)
            {
                string cat = category;
                var button = NewImage("Cat_" + cat, _root, Art("Store/ui/" + RailArt(cat)), Color.white);
                button.preserveAspect = true;
                Anchor(button.rectTransform, new Vector2(0, 1), new Vector2(124f, y), new Vector2(132f, 128f));
                Click(button.gameObject, () => { UiSound.PlayClick(); SelectCategory(cat); });
                _railButtons[cat] = button;
                y -= 138f;
            }
        }

        public void SelectCategory(string category)
        {
            _category = category;
            foreach (var pair in _railButtons)
            {
                bool active = pair.Key == category;
                string art = "Store/ui/" + RailArt(pair.Key) + (active ? "_on" : "");
                pair.Value.sprite = Art(art);
                pair.Value.rectTransform.localScale = Vector3.one * (active ? 1.12f : 1f);
            }
            for (int i = _content.childCount - 1; i >= 0; i--)
            {
                var child = _content.GetChild(i).gameObject;
                child.SetActive(false);
                Destroy(child);
            }
            if (category == StoreCatalog.CategoryCoins) BuildActivityCards();
            else foreach (var offer in StoreCatalog.InCategory(category)) BuildOfferCard(offer);
            _content.anchoredPosition = Vector2.zero;
        }

        // ---------- cartoes ----------

        void BuildOfferCard(StoreOffer offer)
        {
            var card = new GameObject("Card_" + offer.Id, typeof(RectTransform), typeof(LayoutElement));
            card.transform.SetParent(_content, false);
            card.GetComponent<LayoutElement>().preferredWidth = 520f;
            card.GetComponent<LayoutElement>().preferredHeight = 700f;

            var art = NewImage("Art", card.transform, Art("Store/packs/" + offer.Art), Color.white);
            Anchor(art.rectTransform, new Vector2(0.5f, 0.5f), new Vector2(0f, -22f), new Vector2(480f, 610f));
            art.preserveAspect = true;
            StoreOffer captured = offer;
            Click(art.gameObject, () => { UiSound.PlayClick(); OnOfferTapped(captured); });

            var title = NewText("Title", card.transform, 38, TextAnchor.MiddleCenter, Color.white);
            title.gameObject.AddComponent<Outline>().effectColor = new Color(0.15f, 0.04f, 0.3f);
            Anchor(title.rectTransform, new Vector2(0.5f, 1f), new Vector2(0f, 8f), new Vector2(520f, 56f));
            title.text = offer.Title;
            title.raycastTarget = false;

            bool owned = StoreCatalog.IsOwned(_state, offer);
            var pill = NewImage("Price", card.transform, Art("Store/ui/currency_bg"), Color.white);
            Anchor(pill.rectTransform, new Vector2(1f, 0f), new Vector2(-150f, 70f), new Vector2(250f, 80f));
            pill.raycastTarget = false;
            if (owned)
            {
                var own = NewText("Owned", pill.transform, 38, TextAnchor.MiddleCenter, new Color(0.6f, 1f, 0.7f));
                Stretch(own.rectTransform, Vector2.zero, Vector2.one);
                own.text = "Adquirido";
            }
            else
            {
                var icon = NewImage("Coin", pill.transform, Art("Store/ui/coin"), Color.white);
                Anchor(icon.rectTransform, new Vector2(0f, 0.5f), new Vector2(46f, 0f), new Vector2(84f, 84f));
                var price = NewText("Value", pill.transform, 46, TextAnchor.MiddleRight, Color.white);
                Anchor(price.rectTransform, new Vector2(1f, 0.5f), new Vector2(-105f, 0f), new Vector2(150f, 80f));
                price.text = offer.Price.ToString();
            }
        }

        void BuildActivityCards()
        {
            foreach (var price in new[] { 300, 700, 1000 })
            {
                int target = price;
                int level = ChallengeDifficulty.ForPrice(price);
                var card = new GameObject("Activity_" + level, typeof(RectTransform), typeof(LayoutElement));
                card.transform.SetParent(_content, false);
                card.GetComponent<LayoutElement>().preferredWidth = 520f;
                card.GetComponent<LayoutElement>().preferredHeight = 660f;
                var panel = NewImage("Panel", card.transform, Art("Store/ui/bubble", new Vector4(70, 70, 70, 70)), new Color(1f, 0.93f, 0.98f));
                panel.type = Image.Type.Sliced;
                Stretch(panel.rectTransform, Vector2.zero, Vector2.one);
                Click(panel.gameObject, () => { UiSound.PlayClick(); _onEarnCoins?.Invoke(target); });

                var title = NewText("Title", card.transform, 62, TextAnchor.MiddleCenter, TextDark);
                Anchor(title.rectTransform, new Vector2(0.5f, 1f), new Vector2(0f, -110f), new Vector2(460f, 90f));
                title.text = ChallengeDifficulty.LabelFor(level);
                var body = NewText("Body", card.transform, 36, TextAnchor.MiddleCenter, TextDark);
                Anchor(body.rectTransform, new Vector2(0.5f, 0.5f), new Vector2(0f, 10f), new Vector2(440f, 250f));
                body.text = "Desafios de português e matemática para ganhar moedas";
                var reward = NewText("Reward", card.transform, 46, TextAnchor.MiddleCenter, new Color(0.45f, 0.2f, 0.6f));
                Anchor(reward.rectTransform, new Vector2(0.5f, 0f), new Vector2(0f, 150f), new Vector2(460f, 80f));
                reward.text = "+" + ChallengeDifficulty.RewardFor(level) + " moedas por acerto";
                title.raycastTarget = body.raycastTarget = reward.raycastTarget = false;
            }
        }

        // ---------- compra ----------

        void OnOfferTapped(StoreOffer offer)
        {
            if (StoreCatalog.IsOwned(_state, offer)) { ShowToast("Você já tem este combo."); return; }
            OpenModal(offer);
        }

        void OpenModal(StoreOffer offer)
        {
            CloseModal();
            bool canPay = _state.PazuCurrency >= offer.Price;
            _modal = new GameObject("Modal", typeof(RectTransform));
            _modal.transform.SetParent(_root, false);
            Stretch((RectTransform)_modal.transform, Vector2.zero, Vector2.one);
            var dim = NewImage("Dim", _modal.transform, null, new Color(0, 0, 0, 0.7f));
            Stretch(dim.rectTransform, Vector2.zero, Vector2.one);
            Click(dim.gameObject, CloseModal);

            var panel = NewImage("Panel", _modal.transform, Art("Store/ui/bubble", new Vector4(70, 70, 70, 70)), new Color(1f, 0.93f, 0.98f));
            panel.type = Image.Type.Sliced;
            Anchor(panel.rectTransform, new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(1180f, 760f));
            panel.raycastTarget = true;

            var cover = NewImage("Cover", panel.transform, Art("Store/covers/" + offer.Art), Color.white);
            Anchor(cover.rectTransform, new Vector2(0.5f, 1f), new Vector2(0f, -80f - 190f), new Vector2(676f, 386f));
            cover.preserveAspect = true;
            cover.raycastTarget = false;

            var message = NewText("Message", panel.transform, 44, TextAnchor.MiddleCenter, TextDark);
            Anchor(message.rectTransform, new Vector2(0.5f, 0f), new Vector2(0f, 230f), new Vector2(1060f, 120f));
            message.raycastTarget = false;
            message.text = canPay
                ? "Comprar \"" + offer.Title + "\" por " + offer.Price + " moedas?"
                : "Faltam " + (offer.Price - _state.PazuCurrency) + " moedas para \"" + offer.Title + "\".";

            var primary = PillButton(panel.transform, canPay ? "Comprar" : "Ganhar moedas", new Vector2(-250f, 90f));
            Click(primary, () =>
            {
                UiSound.PlayClick();
                if (canPay) Purchase(offer);
                else { CloseModal(); _onEarnCoins?.Invoke(offer.Price); }
            });
            var cancel = PillButton(panel.transform, "Cancelar", new Vector2(250f, 90f));
            Click(cancel, () => { UiSound.PlayClick(); CloseModal(); });
        }

        GameObject PillButton(Transform parent, string label, Vector2 position)
        {
            var image = NewImage("Button_" + label, parent, Art("Icons/pill_green", new Vector4(60, 0, 60, 0)), Color.white);
            image.type = Image.Type.Sliced;
            Anchor(image.rectTransform, new Vector2(0.5f, 0f), position, new Vector2(440f, 120f));
            var text = NewText("Label", image.transform, 44, TextAnchor.MiddleCenter, TextDark);
            Stretch(text.rectTransform, Vector2.zero, Vector2.one);
            text.text = label;
            text.raycastTarget = false;
            return image.gameObject;
        }

        void CloseModal()
        {
            if (_modal != null) Destroy(_modal);
            _modal = null;
        }

        /// <summary>Compra com moedas; falha de escrita restaura o estado em memoria (regra da Home offline).</summary>
        void Purchase(StoreOffer offer)
        {
            string snapshot = JsonUtility.ToJson(_state);
            var result = StoreCatalog.Buy(_state, offer);
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
            SelectCategory(_category);
            ShowToast("Combo adquirido!");
        }

        void ShowToast(string message)
        {
            _toast.text = message;
            _toast.enabled = true;
            _toastUntil = Time.unscaledTime + 2f;
        }

        void Update()
        {
            if (_toast != null && _toast.enabled && Time.unscaledTime > _toastUntil) _toast.enabled = false;
        }

        // ---------- helpers de UI ----------

        Image NewImage(string name, Transform parent, Sprite sprite, Color color)
        {
            var go = new GameObject(name, typeof(RectTransform), typeof(Image));
            go.transform.SetParent(parent, false);
            var image = go.GetComponent<Image>();
            image.sprite = sprite;
            image.color = color;
            image.raycastTarget = false;
            return image;
        }

        Text NewText(string name, Transform parent, int size, TextAnchor anchor, Color color)
        {
            var go = new GameObject(name, typeof(RectTransform), typeof(Text));
            go.transform.SetParent(parent, false);
            var text = go.GetComponent<Text>();
            text.font = _font; text.fontSize = size; text.alignment = anchor; text.color = color;
            text.horizontalOverflow = HorizontalWrapMode.Wrap;
            text.raycastTarget = false;
            return text;
        }

        static void Click(GameObject go, Action action)
        {
            var image = go.GetComponent<Image>();
            if (image != null) image.raycastTarget = true;
            var button = go.GetComponent<Button>() ?? go.AddComponent<Button>();
            button.targetGraphic = image;
            button.onClick.AddListener(() => action());
        }

        static void Anchor(RectTransform rect, Vector2 anchor, Vector2 position, Vector2 size)
        {
            rect.anchorMin = rect.anchorMax = anchor;
            rect.pivot = new Vector2(0.5f, 0.5f);
            rect.anchoredPosition = position;
            rect.sizeDelta = size;
        }

        static void Stretch(RectTransform rect, Vector2 min, Vector2 max)
        {
            rect.anchorMin = min; rect.anchorMax = max;
            rect.offsetMin = rect.offsetMax = Vector2.zero;
        }
    }
}
