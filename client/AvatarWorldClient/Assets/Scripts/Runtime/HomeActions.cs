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
        readonly List<Button> boundButtons = new List<Button>();
        GameObject panel;
        RectTransform content;
        SaveStore saves;
        PlayerState state;
        Font font;
        public string CurrentPage { get; private set; }
        public int BoundButtonCount => boundButtons.Count;

        Action play;
        public readonly List<string> PendingButtons = new List<string>();

        public void Initialize(IReadOnlyList<GameObject> objects, SaveStore saveStore,
            PlayerState sharedState, Action openPlay)
        {
            saves = saveStore ?? throw new ArgumentNullException(nameof(saveStore));
            state = sharedState ?? throw new ArgumentNullException(nameof(sharedState));
            play = openPlay ?? throw new ArgumentNullException(nameof(openPlay));
            font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            AudioListener.pause = PlayerPrefs.GetInt(SoundKey, 1) == 0;
            BuildPanel();
            foreach (var go in objects)
            {
                if (go.name == "MultiplayerCanvas" || go.name == "MultiplayerClickBlocker" ||
                    go.name == "SignedUserButton " || go.name == "NotSignedUserButton" ||
                    go.name == "SettingsMenu" || go.name == "UserMenu") go.SetActive(false);
                var button = go.GetComponent<Button>();
                if (button == null) continue;
                string action = go.name.Trim();
                // Preserva os listeners existentes, inclusive o som de clique.
                switch (action)
                {
                    case "PlayButton":
                    case "SettingsButton":
                    case "AccountButton":
                    case "AchievementsAppWidget":
                        button.onClick.AddListener(() => Open(action));
                        boundButtons.Add(button);
                        break;
                    default:
                        // Sem implementacao real: nao conta modal de aviso como funcionalidade.
                        button.interactable = false;
                        PendingButtons.Add(action);
                        break;
                }
            }
        }

        public void Open(string action)
        {
            switch (action)
            {
                case "PlayButton": Close(); play(); break;
                case "SettingsButton": ShowSettings(); break;
                case "AccountButton": ShowProfile(); break;
                case "AchievementsAppWidget": ShowProgress(); break;
            }
        }

        void ShowProgress()
        {
            Show("Progresso", $"Desafios concluídos: {state.CompletedChallenges.Count}\nMoedas: {state.PazuCurrency}\nPontos: {state.LoyaltyPoints}");
            foreach (var id in state.CompletedChallenges) AddText(id, 24);
        }

        public void Close()
        {
            panel.SetActive(false);
            CurrentPage = null;
        }

        void ShowSettings()
        {
            Show("Configurações", "Preferências deste aparelho.");
            bool enabled = PlayerPrefs.GetInt(SoundKey, 1) != 0;
            AddButton("Som: " + (enabled ? "ligado" : "desligado"), () =>
            {
                bool next = PlayerPrefs.GetInt(SoundKey, 1) == 0;
                PlayerPrefs.SetInt(SoundKey, next ? 1 : 0);
                PlayerPrefs.Save();
                AudioListener.pause = !next;
                ShowSettings();
            });
        }

        void ShowProfile()
        {
            Show("Perfil local", $"Progresso salvo neste aparelho.\nMoedas: {state.PazuCurrency}\nPontos: {state.LoyaltyPoints}");
            AddButton("Salvar progresso", SaveProgress);
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
            canvas.sortingOrder = 100;
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
            card.GetComponent<Image>().color = new Color(0.96f, 0.94f, 1);

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
            image.color = new Color(0.45f, 0.2f, 0.6f);
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
            text.color = Color.white;
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
