using System;
using System.Collections;
using System.IO;
using AvatarWorld.Core.Economy;
using UnityEngine;
using UnityEngine.UI;

namespace AvatarWorld.Runtime
{
    /// <summary>
    /// Tela de compra da vaga extra de veículo (2º slot da aba "car" da tela de slots): fundo roxo com
    /// brilhos que derivam lentamente (sem shader, só RectTransform animado), a arte do item ao centro e
    /// duas faixas de preço lado a lado - Padrão (100 moedas) e Premium (300 moedas, com bônus e destaque
    /// visual). Sem esqueleto de "carro do avatar" extraído ainda (docs/AVATAR_PETS_VEHICLES_PLAN.md): a
    /// compra só reserva o slot na tela de slots, que passa a mostrá-lo como adquirido.
    /// </summary>
    public sealed class VehicleSlotPurchaseScreen : MonoBehaviour
    {
        static readonly Color BgBottom = new Color(0.14f, 0.05f, 0.26f);
        static readonly Color BgTop = new Color(0.46f, 0.2f, 0.62f);
        static readonly Color TextDark = new Color(0.2f, 0.1f, 0.3f);
        static readonly Color StandardAccent = new Color(0.78f, 0.74f, 0.9f);
        static readonly Color PremiumAccent = new Color(1f, 0.82f, 0.35f);

        PlayerState _state;
        SaveStore _saves;
        Action _onClose;
        Action<int> _onEarnCoins;
        Font _font;
        Transform _root;
        Transform _cardsRoot;
        Text _coinText;
        Text _toast;
        float _toastUntil;
        readonly System.Collections.Generic.Dictionary<string, Sprite> _sprites = new System.Collections.Generic.Dictionary<string, Sprite>();
        RectTransform _glowA, _glowB, _itemImage, _ring;
        float _t0;
        bool _busy;

        public void Begin(PlayerState state, SaveStore saves, Action onClose, Action<int> onEarnCoins = null)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
            _saves = saves;
            _onClose = onClose;
            _onEarnCoins = onEarnCoins;
            _font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            _t0 = Time.unscaledTime;
            UiSceneBuilder.EnsureEventSystem();
            BuildFrame();
        }

        /// <summary>Reconstrói as faixas apos ganhar moedas nos desafios (mesmo padrao da StoreScreen).</summary>
        public void RefreshCoins()
        {
            if (_coinText != null) _coinText.text = _state.PazuCurrency.ToString();
            BuildCards();
        }

        // ---------- moldura ----------

        Sprite Art(string path, Vector4 border = default)
        {
            string key = path + "|" + border;
            if (_sprites.TryGetValue(key, out var cached)) return cached;
            var tex = Resources.Load<Texture2D>(path);
            if (tex == null) { Debug.LogWarning("VehicleSlotPurchase: arte ausente " + path); return null; }
            var sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100f, 0,
                SpriteMeshType.FullRect, border);
            _sprites[key] = sprite;
            return sprite;
        }

        void BuildFrame()
        {
            var rootGo = new GameObject("VehicleSlotPurchaseCanvas", typeof(RectTransform), typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
            rootGo.transform.SetParent(transform, false);
            _root = rootGo.transform;
            var canvas = rootGo.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.overrideSorting = true;
            canvas.sortingOrder = 850;
            var scaler = rootGo.GetComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(2048f, 1024f);
            scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;

            BuildAnimatedBackground();

            var back = NewImage("BackButton", _root, Art("Slots/back"), Color.white);
            Anchor(back.rectTransform, new Vector2(0, 1), new Vector2(111.2f, -98.2f), new Vector2(146f, 143f));
            Click(back.gameObject, () => { UiSound.PlayClick(); _onClose?.Invoke(); });

            var pill = NewImage("CurrencyViewer", _root, Art("Store/ui/currency_bg"), Color.white);
            Anchor(pill.rectTransform, new Vector2(1, 1), new Vector2(-169f, -68f), new Vector2(284f, 91f));
            var coin = NewImage("Coin", pill.transform, Art("Store/ui/coin"), Color.white);
            Anchor(coin.rectTransform, new Vector2(0.5f, 0.5f), new Vector2(-102.1f, -2.3f), new Vector2(100f, 100f));
            _coinText = NewText("Value", pill.transform, 52, TextAnchor.MiddleRight, Color.white);
            Anchor(_coinText.rectTransform, new Vector2(0.5f, 0.5f), new Vector2(26f, 0f), new Vector2(190f, 92f));
            _coinText.text = _state.PazuCurrency.ToString();

            var title = NewText("Title", _root, 68, TextAnchor.MiddleCenter, Color.white);
            title.gameObject.AddComponent<Outline>().effectColor = new Color(0.15f, 0.04f, 0.3f);
            Anchor(title.rectTransform, new Vector2(0.5f, 1f), new Vector2(0f, -140f), new Vector2(1400f, 100f));
            title.text = "Vaga de Veículo";

            var subtitle = NewText("Subtitle", _root, 36, TextAnchor.MiddleCenter, new Color(1f, 1f, 1f, 0.85f));
            Anchor(subtitle.rectTransform, new Vector2(0.5f, 1f), new Vector2(0f, -210f), new Vector2(1400f, 60f));
            subtitle.text = "Desbloqueie uma vaga extra para o seu carro";

            BuildItemShowcase();

            _cardsRoot = Rect("Cards", _root);

            _toast = NewText("Toast", _root, 46, TextAnchor.MiddleCenter, Color.white);
            Anchor(_toast.rectTransform, new Vector2(0.5f, 0f), new Vector2(0f, 60f), new Vector2(1600f, 90f));
            _toast.gameObject.AddComponent<Outline>().effectColor = new Color(0.2f, 0.05f, 0.35f);
            _toast.enabled = false;

            BuildCards();
        }

        /// <summary>Degradê roxo vertical + brilhos que derivam lentamente (Update), sem depender de shader.</summary>
        void BuildAnimatedBackground()
        {
            var bg = new GameObject("Background", typeof(RectTransform), typeof(RawImage));
            bg.transform.SetParent(_root, false);
            Stretch((RectTransform)bg.transform, Vector2.zero, Vector2.one);
            bg.GetComponent<RawImage>().texture = Gradient(BgBottom, BgTop);
            bg.GetComponent<RawImage>().raycastTarget = false;

            _glowA = Glow("GlowA", new Color(0.85f, 0.55f, 1f, 0.28f), 760f, new Vector2(-480f, 120f));
            _glowB = Glow("GlowB", new Color(1f, 0.78f, 0.9f, 0.22f), 620f, new Vector2(560f, -200f));
        }

        RectTransform Glow(string name, Color color, float size, Vector2 position)
        {
            var image = NewImage(name, _root, GlowSprite(), color);
            image.rectTransform.anchorMin = image.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            image.rectTransform.anchoredPosition = position;
            image.rectTransform.sizeDelta = new Vector2(size, size);
            return image.rectTransform;
        }

        Sprite GlowSprite()
        {
            if (_sprites.TryGetValue("glow", out var cached)) return cached;
            const int size = 128;
            var tex = new Texture2D(size, size, TextureFormat.RGBA32, false) { filterMode = FilterMode.Bilinear };
            for (int y = 0; y < size; y++)
                for (int x = 0; x < size; x++)
                {
                    float nx = (x + 0.5f) / size * 2f - 1f, ny = (y + 0.5f) / size * 2f - 1f;
                    float d = Mathf.Sqrt(nx * nx + ny * ny);
                    float a = Mathf.Clamp01(1f - d);
                    tex.SetPixel(x, y, new Color(1f, 1f, 1f, a * a));
                }
            tex.Apply();
            var sprite = Sprite.Create(tex, new Rect(0, 0, size, size), new Vector2(0.5f, 0.5f), 100f);
            _sprites["glow"] = sprite;
            return sprite;
        }

        static Texture2D Gradient(Color bottom, Color top)
        {
            const int h = 64;
            var tex = new Texture2D(1, h, TextureFormat.RGBA32, false) { wrapMode = TextureWrapMode.Clamp, filterMode = FilterMode.Bilinear };
            for (int y = 0; y < h; y++) tex.SetPixel(0, y, Color.Lerp(bottom, top, y / (h - 1f)));
            tex.Apply();
            return tex;
        }

        /// <summary>Anel de brilho girando devagar atrás da arte do item, que balança suavemente (bob).</summary>
        void BuildItemShowcase()
        {
            var ring = NewImage("Ring", _root, GlowSprite(), new Color(1f, 0.92f, 1f, 0.35f));
            Anchor(ring.rectTransform, new Vector2(0.5f, 0.5f), new Vector2(0f, 60f), new Vector2(560f, 560f));
            _ring = ring.rectTransform;

            var item = NewImage("Item", _root, Art("Slots/banner_vehicle"), Color.white);
            Anchor(item.rectTransform, new Vector2(0.5f, 0.5f), new Vector2(0f, 60f), new Vector2(460f, 230f));
            item.preserveAspect = true;
            _itemImage = item.rectTransform;
        }

        void Update()
        {
            float t = Time.unscaledTime - _t0;
            if (_glowA != null) _glowA.anchoredPosition = new Vector2(-480f + Mathf.Sin(t * 0.25f) * 60f, 120f + Mathf.Cos(t * 0.2f) * 40f);
            if (_glowB != null) _glowB.anchoredPosition = new Vector2(560f + Mathf.Cos(t * 0.22f) * 50f, -200f + Mathf.Sin(t * 0.3f) * 45f);
            if (_ring != null) _ring.localRotation = Quaternion.Euler(0, 0, t * 12f);
            if (_itemImage != null) _itemImage.anchoredPosition = new Vector2(0f, 60f + Mathf.Sin(t * 1.4f) * 10f);
            if (_toast != null && _toast.enabled && Time.unscaledTime > _toastUntil) _toast.enabled = false;
        }

        // ---------- faixas de preço ----------

        void BuildCards()
        {
            for (int i = _cardsRoot.childCount - 1; i >= 0; i--) Destroy(_cardsRoot.GetChild(i).gameObject);

            if (VehicleSlotCatalog.IsUnlocked(_state))
            {
                BuildOwnedNotice();
                return;
            }

            BuildTierCard(VehicleSlotCatalog.Standard, premium: false, position: new Vector2(-300f, -300f));
            BuildTierCard(VehicleSlotCatalog.Premium, premium: true, position: new Vector2(300f, -300f));
        }

        void BuildOwnedNotice()
        {
            var text = NewText("Owned", _cardsRoot, 46, TextAnchor.MiddleCenter, Color.white);
            Anchor(text.rectTransform, new Vector2(0.5f, 0f), new Vector2(0f, -300f), new Vector2(1200f, 140f));
            text.text = VehicleSlotCatalog.IsPremium(_state)
                ? "Vaga premium já desbloqueada!"
                : "Vaga de veículo já desbloqueada!";
        }

        /// <summary>
        /// Cartão de uma faixa de preço. A premium é maior, com moldura dourada, selo "Melhor oferta" e o
        /// bônus de moedas - a diferença visual e funcional entre as duas faixas pedida pelo design.
        /// </summary>
        void BuildTierCard(StoreOffer offer, bool premium, Vector2 position)
        {
            float width = premium ? 560f : 480f;
            float height = premium ? 480f : 420f;
            var accent = premium ? PremiumAccent : StandardAccent;

            var card = NewImage("Card_" + offer.Id, _cardsRoot, Art("Store/ui/bubble", new Vector4(70, 70, 70, 70)), new Color(1f, 0.96f, 0.99f, 0.96f));
            card.type = Image.Type.Sliced;
            Anchor(card.rectTransform, new Vector2(0.5f, 0f), position, new Vector2(width, height));
            card.raycastTarget = true;

            var border = NewImage("Border", card.transform, Art("Store/ui/bubble", new Vector4(70, 70, 70, 70)), accent);
            border.type = Image.Type.Sliced;
            Stretch(border.rectTransform, Vector2.zero, Vector2.one);
            border.rectTransform.sizeDelta = new Vector2(-10f, -10f);
            border.raycastTarget = false;

            if (premium)
            {
                var ribbon = NewText("Ribbon", card.transform, 32, TextAnchor.MiddleCenter, TextDark);
                Anchor(ribbon.rectTransform, new Vector2(0.5f, 1f), new Vector2(0f, -36f), new Vector2(360f, 56f));
                ribbon.gameObject.AddComponent<Outline>().effectColor = Color.white;
                ribbon.text = "★ Melhor oferta ★";
                ribbon.raycastTarget = false;
            }

            var titleText = NewText("Title", card.transform, premium ? 48 : 42, TextAnchor.MiddleCenter, TextDark);
            Anchor(titleText.rectTransform, new Vector2(0.5f, 1f), new Vector2(0f, premium ? -96f : -70f), new Vector2(width - 40f, 70f));
            titleText.text = offer.Title;
            titleText.raycastTarget = false;

            var pill = NewImage("Price", card.transform, Art("Store/ui/currency_bg"), Color.white);
            Anchor(pill.rectTransform, new Vector2(0.5f, 0.5f), new Vector2(0f, premium ? 10f : 0f), new Vector2(260f, 88f));
            pill.raycastTarget = false;
            var coinIcon = NewImage("Coin", pill.transform, Art("Store/ui/coin"), Color.white);
            Anchor(coinIcon.rectTransform, new Vector2(0f, 0.5f), new Vector2(48f, 0f), new Vector2(84f, 84f));
            var priceText = NewText("Value", pill.transform, 46, TextAnchor.MiddleRight, Color.white);
            Anchor(priceText.rectTransform, new Vector2(1f, 0.5f), new Vector2(-106f, 0f), new Vector2(150f, 80f));
            priceText.text = offer.Price.ToString();

            bool affordable = _state.PazuCurrency >= offer.Price;
            if (!affordable) priceText.color = new Color(1f, 0.55f, 0.55f);

            if (premium)
            {
                var bonus = NewText("Bonus", card.transform, 30, TextAnchor.MiddleCenter, new Color(0.25f, 0.5f, 0.2f));
                Anchor(bonus.rectTransform, new Vector2(0.5f, 0f), new Vector2(0f, 128f), new Vector2(width - 40f, 44f));
                bonus.text = "+" + VehicleSlotCatalog.PremiumBonus + " moedas de bônus";
                bonus.raycastTarget = false;
            }

            var cta = NewImage("Cta", card.transform, Art("Icons/pill_green", new Vector4(60, 0, 60, 0)), Color.white);
            cta.type = Image.Type.Sliced;
            Anchor(cta.rectTransform, new Vector2(0.5f, 0f), new Vector2(0f, 42f), new Vector2(300f, 90f));
            var ctaLabel = NewText("Label", cta.transform, 40, TextAnchor.MiddleCenter, TextDark);
            Stretch(ctaLabel.rectTransform, Vector2.zero, Vector2.one);
            ctaLabel.text = affordable ? "Comprar" : "Ganhar moedas";
            ctaLabel.raycastTarget = false;
            StoreOffer captured = offer;
            Click(cta.gameObject, () => OnTierTapped(captured, premium));
        }

        // ---------- compra ----------

        void OnTierTapped(StoreOffer offer, bool premium)
        {
            if (_busy) return;
            UiSound.PlayClick();
            if (_state.PazuCurrency < offer.Price)
            {
                ShowToast("Faltam " + (offer.Price - _state.PazuCurrency) + " moedas.");
                _onEarnCoins?.Invoke(offer.Price);
                return;
            }
            Purchase(offer, premium);
        }

        void Purchase(StoreOffer offer, bool premium)
        {
            string snapshot = JsonUtility.ToJson(_state);
            var result = VehicleSlotCatalog.Buy(_state, offer);
            if (!result.Success)
            {
                ShowToast(result.Error == ClaimError.AlreadyClaimed ? "Você já tem uma vaga de veículo." : "Não foi possível comprar agora.");
                return;
            }
            try { _saves?.Save(_state); }
            catch (Exception e) when (e is IOException || e is UnauthorizedAccessException)
            {
                JsonUtility.FromJsonOverwrite(snapshot, _state);
                ShowToast("Não foi possível salvar. A compra foi desfeita.");
                return;
            }
            _busy = true;
            RefreshCoins();
            ShowToast(premium ? "Vaga premium desbloqueada! +" + VehicleSlotCatalog.PremiumBonus + " moedas de bônus." : "Vaga de veículo desbloqueada!");
            StartCoroutine(CloseAfterDelay(1.1f));
        }

        IEnumerator CloseAfterDelay(float seconds)
        {
            yield return new WaitForSecondsRealtime(seconds);
            _onClose?.Invoke();
        }

        void ShowToast(string message)
        {
            _toast.text = message;
            _toast.enabled = true;
            _toastUntil = Time.unscaledTime + 2f;
        }

        // ---------- helpers de UI ----------

        static Transform Rect(string name, Transform parent)
        {
            var go = new GameObject(name, typeof(RectTransform));
            go.transform.SetParent(parent, false);
            Stretch((RectTransform)go.transform, Vector2.zero, Vector2.one);
            return go.transform;
        }

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
