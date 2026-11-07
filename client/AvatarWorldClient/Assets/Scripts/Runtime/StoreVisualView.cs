using System;
using AvatarWorld.Core.Economy;
using UnityEngine;
using UnityEngine.UI;

namespace AvatarWorld.Runtime
{
    /// <summary>UI gráfica com sprites extraídos da loja level237 e previews do avatar Spine real.</summary>
    public sealed class StoreVisualView : MonoBehaviour
    {
        PlayerState state;
        OfflineHomeService service;
        Action close, editor, coins;
        Transform surface;
        Font font;
        Texture2D gradientTexture;
        Sprite gradientSprite;

        public void Initialize(PlayerState playerState, OfflineHomeService economy, Action onClose, Action onEditor, Action onCoins)
        {
            state = playerState; service = economy; close = onClose; editor = onEditor; coins = onCoins;
            font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            // Cores serializadas do material StoreBGGradient em sharedassets237.assets, path_id 2.
            gradientTexture = new Texture2D(1, 32, TextureFormat.RGBA32, false);
            for (int y = 0; y < 32; y++) gradientTexture.SetPixel(0, y,
                Color.Lerp(new Color32(186, 63, 244, 255), new Color32(124, 54, 243, 255), y / 31f));
            gradientTexture.Apply();
            gradientSprite = Sprite.Create(gradientTexture, new Rect(0, 0, 1, 32), new Vector2(.5f, .5f));
            var canvas = gameObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.sortingOrder = 1500;
            var scaler = gameObject.AddComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1600, 800);
            scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
            gameObject.AddComponent<GraphicRaycaster>();
        }

        public void Show(string page, string message = "")
        {
            gameObject.SetActive(true);
            if (surface != null)
            {
                surface.gameObject.SetActive(false);
                if (Application.isPlaying) Destroy(surface.gameObject); else DestroyImmediate(surface.gameObject);
            }
            surface = new GameObject("StoreSurface", typeof(RectTransform)).transform;
            surface.SetParent(transform, false);
            Place((RectTransform)surface, Vector2.zero, Vector2.one);
            var bg = Art("StoreBackground", surface, null, Vector2.zero, Vector2.one);
            bg.sprite = gradientSprite;
            bg.raycastTarget = true;
            Art("OriginalSidebar", surface, "sharedassets237.assets_15", Vector2.zero, new Vector2(.20f, 1));
            Button("Voltar à home", surface, "resources.assets_129461", new Vector2(.015f, .83f), new Vector2(.085f, .98f), close, false);
            var balance = Art("CurrencyCounter", surface, "resources.assets_190344", new Vector2(.79f, .885f), new Vector2(.98f, .98f));
            Art("OriginalCoin", balance.transform, "resources.assets_150542", new Vector2(.02f, .06f), new Vector2(.28f, .94f));
            Label(balance.transform, "Moedas: " + state.PazuCurrency, new Vector2(.30f, 0), Vector2.one, 27, Color.white);
            Sidebar("Visuais", "StoreWidget_CharactersPack_64600", .58f, () => Show("shop"));
            Sidebar("Presentes", "Gifts_Static_92702", .34f, () => Show("gifts"));
            Sidebar("Passe", "AvatarPass_Static_67114", .10f, () => Show("pass"));
            Label(surface, page == "shop" ? "VISUAIS" : page == "gifts" ? "PRESENTES" : "PASSE OFFLINE",
                new Vector2(.23f, .88f), new Vector2(.77f, .97f), 35, Color.white);
            if (page == "shop") Catalog();
            else if (page == "gifts") Gifts();
            else Pass();
            Label(surface, message, new Vector2(.24f, .015f), new Vector2(.98f, .09f), 22, Color.white);
        }

        void Sidebar(string title, string sprite, float y, Action action)
        {
            Button(title, surface, sprite, new Vector2(.035f, y), new Vector2(.17f, y + .19f), action, false);
            Label(surface, title.ToUpperInvariant(), new Vector2(.015f, y - .04f), new Vector2(.19f, y), 20, Color.white);
        }

        void Catalog()
        {
            for (int i = 0; i < 3; i++)
            {
                int index = i;
                float x = .23f + i * .25f;
                var card = Art("OutfitCard" + i, surface, "UI_Panel_White", new Vector2(x, .20f), new Vector2(x + .235f, .85f));
                card.preserveAspect = false;
                Art("AvatarPreview", card.transform, "outfit-" + i, new Vector2(.10f, .19f), new Vector2(.90f, .85f));
                Label(card.transform, OfflineHomeService.OutfitNames[i], new Vector2(.05f, .84f), new Vector2(.95f, .98f), 28, Color.black);
                string price = service.OwnsOutfit(i) ? "Aplicar (adquirido)" : OfflineHomeService.OutfitPrices[i] + " moedas";
                string actionName = OfflineHomeService.OutfitNames[i] + " — " + price;
                var buy = Button(actionName, card.transform, "resources.assets_184451", new Vector2(.06f, .025f), new Vector2(.94f, .18f),
                    () => Transact("shop", () => service.Outfit(index)), false);
                Label(buy.transform, price, Vector2.zero, Vector2.one, 23, Color.black);
            }
            Button("Ver meu avatar", surface, "resources.assets_184451", new Vector2(.26f, .10f), new Vector2(.57f, .18f), editor);
            Button("Ganhar moedas jogando", surface, "resources.assets_184451", new Vector2(.62f, .10f), new Vector2(.95f, .18f), coins);
        }

        void Gifts()
        {
            Art("OriginalGiftArtwork", surface, "Gifts_Static_92702", new Vector2(.25f, .24f), new Vector2(.56f, .81f));
            Label(surface, "Todo dia tem presente!", new Vector2(.58f, .69f), new Vector2(.95f, .80f), 30, Color.white);
            string starter = service.HasStarterGift ? "Presente inicial resgatado" : "Resgatar presente inicial: 25 moedas";
            var first = Button(starter, surface, "resources.assets_184451", new Vector2(.58f, .49f), new Vector2(.96f, .63f),
                () => Transact("gifts", service.StarterGift));
            first.interactable = !service.HasStarterGift;
            string daily = service.HasDailyGift ? "Volte amanhã (UTC)" : "Resgatar presente de hoje: 10 moedas";
            var next = Button(daily, surface, "resources.assets_184451", new Vector2(.58f, .29f), new Vector2(.96f, .43f),
                () => Transact("gifts", service.DailyGift));
            next.interactable = !service.HasDailyGift;
            Button("Jogar desafios", surface, "resources.assets_184451", new Vector2(.58f, .12f), new Vector2(.96f, .24f), coins);
        }

        void Pass()
        {
            Art("OriginalPassArtwork", surface, "AvatarPass_Static_67114", new Vector2(.23f, .30f), new Vector2(.51f, .81f));
            Label(surface, "Desafios concluídos: " + state.CompletedChallenges.Count, new Vector2(.52f, .75f), new Vector2(.96f, .85f), 27, Color.white);
            if (!service.HasPass)
                Button("Ativar passe: 60 moedas", surface, "resources.assets_184451", new Vector2(.55f, .54f), new Vector2(.94f, .69f),
                    () => Transact("pass", service.BuyPass));
            else for (int i = 1; i <= 3; i++)
            {
                int tier = i;
                bool claimed = state.GetClaimCount("offline.pass.reward." + tier) > 0;
                float y = .70f - (i - 1) * .17f;
                var button = Button(claimed ? "Prêmio resgatado" : tier * OfflineHomeService.ChallengesPerTier + " desafios: +25 moedas",
                    surface, "resources.assets_184451", new Vector2(.55f, y - .11f), new Vector2(.94f, y),
                    () => Transact("pass", () => service.ClaimPassReward(tier)));
                button.interactable = !claimed;
            }
            Button("Jogar desafios", surface, "resources.assets_184451", new Vector2(.55f, .10f), new Vector2(.94f, .21f), coins);
        }

        void Transact(string page, Func<string> action)
        {
            try { Show(page, action()); }
            catch (Exception e) when (e is System.IO.IOException || e is UnauthorizedAccessException)
            { Show(page, "Não foi possível salvar. Tente novamente."); }
        }

        static Image Art(string name, Transform parent, string sprite, Vector2 min, Vector2 max)
        {
            var go = new GameObject(name, typeof(RectTransform), typeof(Image));
            go.transform.SetParent(parent, false);
            Place((RectTransform)go.transform, min, max);
            var image = go.GetComponent<Image>();
            if (sprite != null) image.sprite = Resources.Load<Sprite>("StoreVisual/" + sprite);
            image.preserveAspect = sprite != null;
            image.raycastTarget = false;
            return image;
        }

        Button Button(string name, Transform parent, string sprite, Vector2 min, Vector2 max, Action action, bool caption = true)
        {
            var image = Art(name, parent, sprite, min, max);
            if (sprite == "resources.assets_184451") image.preserveAspect = false;
            image.raycastTarget = true;
            var button = image.gameObject.AddComponent<Button>();
            button.targetGraphic = image;
            button.onClick.AddListener(() => { UiSound.PlayClick(); action(); });
            if (caption) Label(image.transform, name, new Vector2(.07f, .05f), new Vector2(.93f, .95f), 23, Color.black);
            return button;
        }

        void Label(Transform parent, string value, Vector2 min, Vector2 max, int size, Color color)
        {
            var go = new GameObject("Label", typeof(RectTransform), typeof(Text));
            go.transform.SetParent(parent, false);
            Place((RectTransform)go.transform, min, max);
            var text = go.GetComponent<Text>();
            text.font = font; text.text = value; text.fontSize = size; text.color = color;
            text.alignment = TextAnchor.MiddleCenter; text.raycastTarget = false;
            text.resizeTextForBestFit = true; text.resizeTextMinSize = 14; text.resizeTextMaxSize = size;
        }

        static void Place(RectTransform rect, Vector2 min, Vector2 max)
        { rect.anchorMin = min; rect.anchorMax = max; rect.offsetMin = rect.offsetMax = Vector2.zero; }

        void OnDestroy()
        {
            if (Application.isPlaying) { Destroy(gradientSprite); Destroy(gradientTexture); }
            else { DestroyImmediate(gradientSprite); DestroyImmediate(gradientTexture); }
        }
    }
}
