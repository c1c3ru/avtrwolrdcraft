using System;
using System.Collections.Generic;
using System.IO;
using AvatarWorld.Core.Economy;
using UnityEngine;
using UnityEngine.UI;

namespace AvatarWorld.Runtime
{
    /// <summary>Navegacao e estado local da Home, sem dependencias de servicos online.</summary>
    public sealed class HomeActions : MonoBehaviour
    {
        const string SoundKey = "home.sound.enabled";
        const string SfxKey = "home.sfx.enabled";
        const string MusicKey = "home.music.enabled";
        readonly List<Button> boundButtons = new List<Button>();
        GameObject panel;
        RectTransform content;
        SaveStore saves;
        PlayerState state;
        OfflineHomeService offline;
        StoreVisualView storeVisual;
        Font font;
        readonly List<Canvas> homeCanvases = new List<Canvas>();
        GameObject settingsMenu;
        GameObject chatLanguagesPanel;
        Button sfxButton;
        Button musicButton;
        GameObject sfxOn;
        GameObject sfxOff;
        GameObject musicOn;
        GameObject musicOff;
        AvatarGpuRuntime avatarEditor;
        bool inGameplay;
        public string CurrentPage { get; private set; }
        public int BoundButtonCount => boundButtons.Count;

        Action play;
        Action coinActivity;
        public readonly List<string> PendingButtons = new List<string>();

        public void Initialize(IReadOnlyList<GameObject> objects, SaveStore saveStore,
            PlayerState sharedState, Action openPlay, Action openCoinActivity)
        {
            saves = saveStore ?? throw new ArgumentNullException(nameof(saveStore));
            state = sharedState ?? throw new ArgumentNullException(nameof(sharedState));
            offline = new OfflineHomeService(state, () => saves.Save(state));
            play = openPlay ?? throw new ArgumentNullException(nameof(openPlay));
            coinActivity = openCoinActivity ?? throw new ArgumentNullException(nameof(openCoinActivity));
            font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            foreach (var go in objects)
            {
                var canvas = go.GetComponent<Canvas>();
                if (canvas != null && canvas.isRootCanvas) homeCanvases.Add(canvas);
            }
            if (!PlayerPrefs.HasKey(SfxKey) && PlayerPrefs.HasKey(SoundKey))
            {
                int legacyEnabled = PlayerPrefs.GetInt(SoundKey, 1);
                PlayerPrefs.SetInt(SfxKey, legacyEnabled);
                PlayerPrefs.SetInt(MusicKey, legacyEnabled);
                PlayerPrefs.Save();
            }
            UiSound.SetMuted(PlayerPrefs.GetInt(SfxKey, 1) == 0);
            BackgroundMusic.SetMuted(PlayerPrefs.GetInt(MusicKey, 1) == 0);
            BuildPanel();
            settingsMenu = FindObject(objects, "SettingsMenu");
            chatLanguagesPanel = FindObject(objects, "ChatLanguagesPanel");
            sfxButton = FindButton(objects, "SFX");
            musicButton = FindButton(objects, "Music");
            sfxOn = FindObject(objects, "On", sfxButton != null ? sfxButton.transform : null);
            sfxOff = FindObject(objects, "Off", sfxButton != null ? sfxButton.transform : null);
            musicOn = FindObject(objects, "On", musicButton != null ? musicButton.transform : null);
            musicOff = FindObject(objects, "Off", musicButton != null ? musicButton.transform : null);
            SyncAudioToggles();
            var settingsBackdrop = FindObject(objects, "Background", settingsMenu != null ? settingsMenu.transform : null);
            if (settingsBackdrop != null)
            {
                var backdropButton = settingsBackdrop.GetComponent<Button>();
                if (backdropButton == null) backdropButton = settingsBackdrop.AddComponent<Button>();
                backdropButton.targetGraphic = settingsBackdrop.GetComponent<Graphic>();
                backdropButton.onClick.AddListener(() => settingsMenu.SetActive(false));
            }
            foreach (var go in objects)
            {
                if (go.name == "MultiplayerCanvas" || go.name == "MultiplayerClickBlocker" ||
                    go.name == "SignedUserButton " || go.name == "ComingSoonButton" ||
                    go.name == "UserMenu") go.SetActive(false);
                // O presente avulso exportado está sem View; o GiftBadge visível é o acesso
                // aos presentes. Evita um hitbox invisível sobre o Starter Pack.
                if (go.name == "NewUserGiftCurrency" && go.transform.Find("View") is Transform giftView &&
                    !giftView.gameObject.activeSelf) go.SetActive(false);
                var button = go.GetComponent<Button>();
                if (go.name == "GiftBadge" && button == null)
                {
                    button = go.AddComponent<Button>();
                    button.targetGraphic = go.GetComponent<Graphic>();
                    if (button.targetGraphic != null) button.targetGraphic.raycastTarget = true;
                }
                if (button == null) continue;
                string action = go.name.Trim();
                // Preserva os listeners existentes, inclusive o som de clique.
                switch (action)
                {
                    case "PlayButton":
                    case "SettingsButton":
                    case "AccountButton":
                    case "AchievementsAppWidget":
                    case "ShopButton":
                    case "World_ShopButton":
                    case "World_ShopButton StarterPack":
                    case "NewUserGiftCurrency":
                    case "AvatarPassButton":
                    case "AvatarPassButton_Small":
                    case "AvatarPassChangeWidget":
                    case "HolidayButton":
                    case "GiftsWidget":
                    case "GiftsWidget (2)":
                    case "GiftBadge":
                    case "ClothesDropGiftsWidget":
                    case "WorldResetButton":
                        button.onClick.AddListener(() => Open(action));
                        boundButtons.Add(button);
                        break;
                    case "NotSignedUserButton":
                        button.onClick.AddListener(ShowProfile);
                        boundButtons.Add(button);
                        break;
                    case "Background" when go == settingsBackdrop:
                        // O backdrop recebe o listener de fechar acima e deve continuar clicável.
                        button.interactable = true;
                        break;
                    case "SFX":
                        button.onClick.AddListener(ToggleSfx);
                        boundButtons.Add(button);
                        break;
                    case "Music":
                        button.onClick.AddListener(ToggleMusic);
                        boundButtons.Add(button);
                        break;
                    case "ChatLanguageButton":
                        button.onClick.AddListener(() =>
                        {
                            if (chatLanguagesPanel != null) chatLanguagesPanel.SetActive(!chatLanguagesPanel.activeSelf);
                        });
                        boundButtons.Add(button);
                        break;
                    case "ptButton":
                    case "enButton":
                    case "esButton":
                    case "idButton":
                        button.onClick.AddListener(() =>
                        {
                            PlayerPrefs.SetString("home.chat.language", action.Substring(0, 2));
                            PlayerPrefs.Save();
                            if (chatLanguagesPanel != null) chatLanguagesPanel.SetActive(false);
                        });
                        boundButtons.Add(button);
                        break;
                    default:
                        // Sem implementacao real: nao conta modal de aviso como funcionalidade.
                        button.interactable = false;
                        PendingButtons.Add(action);
                        break;
                }
            }
            foreach (var button in boundButtons) button.interactable = true;
            // Arte decorativa exportada não pode bloquear controles que ficam atrás dela.
            foreach (var go in objects)
            {
                var graphic = go.GetComponent<Graphic>();
                if (graphic != null && go != settingsBackdrop && go.GetComponentInParent<Button>() == null)
                    graphic.raycastTarget = false;
            }
        }

        public void Open(string action)
        {
            switch (action)
            {
                case "PlayButton":
                    Close();
                    inGameplay = true;
                    SetHomeVisible(false);
                    play();
                    break;
                case "SettingsButton": ShowSettings(); break;
                case "AccountButton": ShowProfile(); break;
                case "AchievementsAppWidget": ShowProgress(); break;
                case "ShopButton":
                case "World_ShopButton":
                case "World_ShopButton StarterPack": ShowShop(); break;
                case "NewUserGiftCurrency":
                case "GiftsWidget":
                case "GiftsWidget (2)": ShowGifts(); break;
                case "GiftBadge": ShowGifts(); break;
                case "AvatarPassButton":
                case "AvatarPassButton_Small":
                case "AvatarPassChangeWidget": ShowPass(); break;
                case "HolidayButton": ShowDailyActivity(); break;
                case "ClothesDropGiftsWidget": OpenAvatarEditor(); break;
                case "WorldResetButton":
                    Close();
                    Show("Reiniciar ambiente", "Abrir a quadra com bola e placar reiniciados? Suas moedas e seu avatar serão mantidos.");
                    AddButton("Reiniciar quadra", () => Open("PlayButton"));
                    break;
            }
        }

        void ShowShop(string message = "") => ShowVisualPage("shop", "Loja offline", message);
        void ShowGifts(string message = "") => ShowVisualPage("gifts", "Presentes offline", message);
        void ShowPass(string message = "") => ShowVisualPage("pass", "Passe offline", message);
        void ShowDailyActivity() => ShowGifts();

        void ShowVisualPage(string page, string title, string message)
        {
            Close();
            if (storeVisual == null)
            {
                var go = new GameObject("OriginalStoreVisual", typeof(RectTransform));
                go.transform.SetParent(transform, false);
                storeVisual = go.AddComponent<StoreVisualView>();
                storeVisual.Initialize(state, offline, Close, OpenAvatarEditor, OpenCoinActivity);
            }
            CurrentPage = title;
            storeVisual.Show(page, message);
        }

        void OpenCoinActivity()
        {
            Close();
            SetHomeVisible(false);
            coinActivity();
        }

        void OpenAvatarEditor()
        {
            if (avatarEditor != null) return;
            Debug.Log("Home: abrindo editor visual do avatar");
            Close();
            SetHomeVisible(false);
            var host = new GameObject("AvatarEditorSession");
            host.transform.SetParent(transform, false);
            avatarEditor = host.AddComponent<AvatarGpuRuntime>();
            avatarEditor.Configure(saves, state, CloseAvatarEditor);
        }

        void CloseAvatarEditor()
        {
            avatarEditor = null;
            SetHomeVisible(true);
        }

        public void ReturnFromGameplay() => ReturnToHome();

        public void ReturnToHome()
        {
            inGameplay = false;
            SetHomeVisible(true);
        }

        void SetHomeVisible(bool visible)
        {
            foreach (var canvas in homeCanvases)
            {
                if (canvas == null) continue;
                canvas.enabled = visible;
                var raycaster = canvas.GetComponent<GraphicRaycaster>();
                if (raycaster != null) raycaster.enabled = visible;
            }
        }

        void ShowProgress()
        {
            Show("Progresso", $"Desafios concluídos: {state.CompletedChallenges.Count}\nMoedas: {state.PazuCurrency}\nPontos: {state.LoyaltyPoints}");
            foreach (var id in state.CompletedChallenges) AddText(id, 24);
            AddButton("Desafio pedagógico: ganhar moedas", () =>
            {
                Close();
                SetHomeVisible(false);
                coinActivity();
            });
        }

        public void Close()
        {
            panel.SetActive(false);
            if (storeVisual != null) storeVisual.gameObject.SetActive(false);
            if (settingsMenu != null) settingsMenu.SetActive(false);
            CurrentPage = null;
        }

        void ShowSettings()
        {
            Close();
            if (settingsMenu != null) settingsMenu.SetActive(true);
        }

        void ShowProfile()
        {
            Show("Perfil local", $"Progresso salvo neste aparelho.\nMoedas: {state.PazuCurrency}\nPontos: {state.LoyaltyPoints}");
            AddButton("Editar meu avatar", OpenAvatarEditor);
            AddButton("Salvar progresso", SaveProgress);
        }

        void ToggleSfx()
        {
            bool enabled = PlayerPrefs.GetInt(SfxKey, 1) == 0;
            PlayerPrefs.SetInt(SfxKey, enabled ? 1 : 0);
            PlayerPrefs.Save();
            UiSound.SetMuted(!enabled);
            SyncAudioToggles();
        }

        void ToggleMusic()
        {
            bool enabled = PlayerPrefs.GetInt(MusicKey, 1) == 0;
            PlayerPrefs.SetInt(MusicKey, enabled ? 1 : 0);
            PlayerPrefs.Save();
            BackgroundMusic.SetMuted(!enabled);
            SyncAudioToggles();
        }

        void SyncAudioToggles()
        {
            bool soundEnabled = PlayerPrefs.GetInt(SfxKey, 1) != 0;
            bool musicEnabled = PlayerPrefs.GetInt(MusicKey, 1) != 0;
            if (sfxOn != null) sfxOn.SetActive(soundEnabled);
            if (sfxOff != null) sfxOff.SetActive(!soundEnabled);
            if (musicOn != null) musicOn.SetActive(musicEnabled);
            if (musicOff != null) musicOff.SetActive(!musicEnabled);
        }

        static GameObject FindObject(IReadOnlyList<GameObject> objects, string name, Transform parent = null)
        {
            foreach (var go in objects)
                if (go != null && go.name == name && (parent == null || go.transform.IsChildOf(parent))) return go;
            return null;
        }

        static Button FindButton(IReadOnlyList<GameObject> objects, string name)
        {
            var go = FindObject(objects, name);
            return go != null ? go.GetComponent<Button>() : null;
        }

        void SaveProgress()
        {
            TryStorage(() => { saves.Save(state); Show("Perfil local", "Progresso salvo neste aparelho."); });
        }

        void TryStorage(Action action)
        {
            try { action(); }
            catch (Exception e) when (e is IOException || e is UnauthorizedAccessException)
            {
                Debug.LogWarning("Home: falha no armazenamento local: " + e.GetType().Name);
                Show("Armazenamento", "Não foi possível acessar o salvamento. Confira o espaço livre e tente novamente.");
            }
        }

        void BuildPanel()
        {
            panel = new GameObject("HomeNavigation", typeof(RectTransform), typeof(Canvas),
                typeof(CanvasScaler), typeof(GraphicRaycaster));
            panel.transform.SetParent(transform, false);
            var canvas = panel.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.overrideSorting = true;
            canvas.sortingOrder = 1000;
            var scaler = panel.GetComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1280, 720);
            scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
            var shade = new GameObject("Backdrop", typeof(RectTransform), typeof(Image), typeof(Button));
            shade.transform.SetParent(panel.transform, false);
            Stretch((RectTransform)shade.transform, Vector2.zero, Vector2.one);
            shade.GetComponent<Image>().color = new Color(0, 0, 0, 0.65f);
            shade.GetComponent<Button>().onClick.AddListener(Close);
            var card = new GameObject("Card", typeof(RectTransform), typeof(Image));
            card.transform.SetParent(panel.transform, false);
            Stretch((RectTransform)card.transform, new Vector2(0.12f, 0.08f), new Vector2(0.88f, 0.92f));
            card.GetComponent<Image>().sprite = Resources.Load<Sprite>("StoreVisual/resources.assets_187542");

            var scrollGo = new GameObject("Scroll", typeof(RectTransform), typeof(Image), typeof(Mask), typeof(ScrollRect));
            scrollGo.transform.SetParent(card.transform, false);
            Stretch((RectTransform)scrollGo.transform, new Vector2(0.04f, 0.16f), new Vector2(0.96f, 0.96f));
            scrollGo.GetComponent<Mask>().showMaskGraphic = false;
            var contentGo = new GameObject("Content", typeof(RectTransform), typeof(VerticalLayoutGroup), typeof(ContentSizeFitter));
            content = (RectTransform)contentGo.transform;
            content.SetParent(scrollGo.transform, false);
            content.anchorMin = new Vector2(0, 1);
            content.anchorMax = Vector2.one;
            content.pivot = new Vector2(0.5f, 1);
            content.sizeDelta = Vector2.zero;
            var layout = contentGo.GetComponent<VerticalLayoutGroup>();
            layout.spacing = 16;
            layout.childControlWidth = layout.childControlHeight = true;
            layout.childForceExpandWidth = true;
            layout.childForceExpandHeight = false;
            contentGo.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
            var scroll = scrollGo.GetComponent<ScrollRect>();
            scroll.viewport = (RectTransform)scrollGo.transform;
            scroll.content = content;
            scroll.horizontal = false;
            scroll.movementType = ScrollRect.MovementType.Clamped;
            var close = MakeButton(card.transform, "Voltar à home", Close);
            Stretch((RectTransform)close.transform, new Vector2(0.1f, 0.025f), new Vector2(0.9f, 0.13f));
            // O ScrollRect ocupa quase todo o Card. Garante que o botão permaneça no topo
            // da ordem de raycast depois de criar a máscara/viewport.
            close.transform.SetAsLastSibling();
            Close();
        }

        void Show(string title, string message)
        {
            for (int i = content.childCount - 1; i >= 0; i--)
            {
                var child = content.GetChild(i).gameObject;
                child.SetActive(false);
                if (Application.isPlaying) Destroy(child);
                else DestroyImmediate(child);
            }
            CurrentPage = title;
            panel.SetActive(true);
            AddText(title, 36);
            AddText(message, 26);
            content.anchoredPosition = Vector2.zero;
        }

        void AddText(string value, int size)
        {
            var go = new GameObject("Text", typeof(RectTransform), typeof(Text));
            go.transform.SetParent(content, false);
            var text = go.GetComponent<Text>();
            text.font = font;
            text.text = value;
            text.fontSize = size;
            text.color = new Color(0.18f, 0.12f, 0.24f);
            text.raycastTarget = false;
        }

        void AddButton(string label, Action action) => MakeButton(content, label, action);

        GameObject MakeButton(Transform parent, string label, Action action)
        {
            var go = new GameObject(label, typeof(RectTransform), typeof(Image), typeof(Button), typeof(LayoutElement));
            go.transform.SetParent(parent, false);
            go.GetComponent<LayoutElement>().preferredHeight = 64;
            var image = go.GetComponent<Image>();
            image.sprite = Resources.Load<Sprite>("StoreVisual/resources.assets_184451");
            var button = go.GetComponent<Button>();
            button.targetGraphic = image;
            button.onClick.AddListener(() => { UiSound.PlayClick(); action(); });
            var caption = new GameObject("Label", typeof(RectTransform), typeof(Text));
            caption.transform.SetParent(go.transform, false);
            Stretch((RectTransform)caption.transform, Vector2.zero, Vector2.one);
            var text = caption.GetComponent<Text>();
            text.font = font;
            text.text = label;
            text.fontSize = 24;
            text.alignment = TextAnchor.MiddleCenter;
            text.color = Color.black;
            text.raycastTarget = false;
            return go;
        }

        static void Stretch(RectTransform rect, Vector2 min, Vector2 max)
        {
            rect.anchorMin = min;
            rect.anchorMax = max;
            rect.offsetMin = rect.offsetMax = Vector2.zero;
        }

        void Update()
        {
            if (panel == null || !panel.activeSelf) return;
#if ENABLE_INPUT_SYSTEM && !ENABLE_LEGACY_INPUT_MANAGER
            if (UnityEngine.InputSystem.Keyboard.current != null &&
                UnityEngine.InputSystem.Keyboard.current.escapeKey.wasPressedThisFrame) Close();
#else
            if (Input.GetKeyDown(KeyCode.Escape)) Close();
#endif
        }

    }
}
