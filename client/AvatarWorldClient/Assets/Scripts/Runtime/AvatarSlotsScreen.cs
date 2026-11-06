using System;
using AvatarWorld.Core.Avatar;
using AvatarWorld.Core.Economy;
using UnityEngine;
using UnityEngine.UI;

namespace AvatarWorld.Runtime
{
    /// <summary>
    /// Tela de slots (AvatarMakerLobby do original, prints 16.07.17 e 16.07.35): voltar, abas humano/pet/carro,
    /// slots com silhueta tracejada e lixeira. Cada slot humano mostra o avatar salvo (ou a silhueta para criar) e abre o editor;
    /// os slots humanos 1-3 criam/editam avatares; pets e veiculos ainda nao existem offline (aviso: sem arte/esqueleto extraidos). O slot de veiculo bloqueado leva a loja.
    /// Posicoes em unidades do canvas 2048x1024 convertidas dos prints (x1,42); arte em Resources/Slots.
    /// O pedestal rosa nao foi extraido: e desenhado em codigo.
    /// </summary>
    public sealed class AvatarSlotsScreen : MonoBehaviour
    {
        public const string TabHuman = "human", TabPet = "pet", TabCar = "car";
        const float SlotSpacing = 455f;

        SaveStore _saves;
        PlayerState _state;
        Action _onClose, _onOpenStore;
        Camera _camera;
        Canvas _backCanvas, _frontCanvas;
        Transform _slotsRoot;
        Text _toast;
        float _toastUntil;
        GameObject _editorHost;
        readonly System.Collections.Generic.List<GameObject> _avatarHosts = new System.Collections.Generic.List<GameObject>();
        GameObject _picker;
        int _editingSlot, _returnSlot;
        bool _editingNew;
        readonly System.Collections.Generic.Dictionary<string, Sprite> _sprites = new System.Collections.Generic.Dictionary<string, Sprite>();
        readonly System.Collections.Generic.Dictionary<string, Image> _tabs = new System.Collections.Generic.Dictionary<string, Image>();
        Font _font;

        public string Tab { get; private set; }
        public bool EditorOpen => _editorHost != null;

        public void Begin(SaveStore saves, PlayerState state, Action onClose, Action onOpenStore)
        {
            _saves = saves; _state = state; _onClose = onClose; _onOpenStore = onOpenStore;
            _font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            UiSceneBuilder.EnsureEventSystem();
            BuildCamera();
            _backCanvas = NewCanvas("Back", 0);
            _frontCanvas = NewCanvas("Front", 10);
            BuildBackground();
            _slotsRoot = Rect("Slots", _backCanvas.transform);
            BuildFront();
            SelectTab(TabHuman);
        }

        void BuildCamera()
        {
            _camera = new GameObject("SlotsCamera", typeof(Camera)).GetComponent<Camera>();
            _camera.transform.SetParent(transform, false);
            _camera.tag = "MainCamera";
            _camera.orthographic = true;
            _camera.orthographicSize = 5.12f; // 1 unidade do mundo = 100 unidades do canvas 2048x1024
            _camera.clearFlags = CameraClearFlags.SolidColor;
            _camera.backgroundColor = new Color(0.97f, 0.89f, 0.89f);
            _camera.transform.position = new Vector3(0, 0, -10);
        }

        Canvas NewCanvas(string name, int order)
        {
            var go = new GameObject("SlotsCanvas_" + name, typeof(RectTransform), typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
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
            // Degradê rosa dos prints (faixa central mais escura).
            var tex = new Texture2D(1, 64, TextureFormat.RGBA32, false) { wrapMode = TextureWrapMode.Clamp, filterMode = FilterMode.Bilinear };
            for (int y = 0; y < 64; y++)
            {
                float t = y / 63f;
                float band = Mathf.Exp(-Mathf.Pow((t - 0.55f) / 0.12f, 2f));
                tex.SetPixel(0, y, Color.Lerp(new Color(0.98f, 0.91f, 0.91f), new Color(0.96f, 0.82f, 0.83f), band));
            }
            tex.Apply();
            var bg = new GameObject("Background", typeof(RectTransform), typeof(RawImage));
            bg.transform.SetParent(_backCanvas.transform, false);
            Stretch((RectTransform)bg.transform);
            bg.GetComponent<RawImage>().texture = tex;
            bg.GetComponent<RawImage>().raycastTarget = false;
        }

        // ---------- frente: voltar, abas, lixeira ----------

        void BuildFront()
        {
            var back = Button("BackButton", _frontCanvas.transform, Art("Slots/back"), new Vector2(0, 1), new Vector2(92.5f, -91f), new Vector2(146f, 143f),
                () => { UiSound.PlayClick(); _onClose?.Invoke(); });
            AddTab(TabHuman, "human", -92.5f);
            AddTab(TabPet, "pet", -244f);
            AddTab(TabCar, "car", -400f);
            Button("DeleteButton", _frontCanvas.transform, Art("Slots/delete"), new Vector2(0.5f, 0.5f), new Vector2(0f, -375f), new Vector2(146f, 143f),
                () => { UiSound.PlayClick(); ShowToast("Não há nada para remover."); });
            _toast = new GameObject("Toast", typeof(RectTransform), typeof(Text)).GetComponent<Text>();
            _toast.transform.SetParent(_frontCanvas.transform, false);
            var rect = _toast.rectTransform;
            rect.anchorMin = rect.anchorMax = new Vector2(0.5f, 0f);
            rect.anchoredPosition = new Vector2(0, 52f); rect.sizeDelta = new Vector2(1500f, 90f);
            _toast.font = _font; _toast.fontSize = 46; _toast.alignment = TextAnchor.MiddleCenter; _toast.color = new Color(0.45f, 0.2f, 0.6f);
            _toast.raycastTarget = false; _toast.enabled = false;
        }

        void AddTab(string tab, string art, float x)
        {
            string captured = tab;
            var image = Button("Tab_" + tab, _frontCanvas.transform, Art("Slots/" + art), new Vector2(1, 1), new Vector2(x, -91f), new Vector2(146f, 143f),
                () => { UiSound.PlayClick(); SelectTab(captured); });
            _tabs[tab] = image;
        }

        public void SelectTab(string tab)
        {
            Tab = tab;
            _tabs[TabHuman].sprite = Art(tab == TabHuman ? "Slots/human_sel" : "Slots/human");
            _tabs[TabPet].sprite = Art(tab == TabPet ? "Slots/pet_sel" : "Slots/pet");
            _tabs[TabCar].sprite = Art(tab == TabCar ? "Slots/car_sel" : "Slots/car");
            for (int i = _slotsRoot.childCount - 1; i >= 0; i--) { var c = _slotsRoot.GetChild(i).gameObject; c.SetActive(false); Destroy(c); }
            ClearAvatarHosts();
            if (tab == TabHuman) BuildHumanSlots();
            else if (tab == TabPet) BuildPetSlots();
            else BuildCarSlots();
        }

        // ---------- slots ----------

        void BuildHumanSlots()
        {
            // Um slot por avatar humano: o avatar salvo (mesmo runtime Spine da quadra, sem camera propria) sobre o pedestal,
            // ou a silhueta tracejada para criar um novo. Slots extras mostram uma copia so de leitura (PlayerState temporario).
            for (int slot = 0; slot < PlayerState.HumanSlotCount; slot++)
            {
                int captured = slot;
                float x = SlotSpacing * slot;
                if (_state.HasHumanAvatar(slot))
                {
                    var pedestal = NewImage("Pedestal" + (slot + 1), _slotsRoot, PedestalSprite(), Color.white);
                    Place(pedestal.rectTransform, new Vector2(x, -205f), new Vector2(420f, 130f));
                    var hit = Button("Slot" + (slot + 1), _slotsRoot, null, new Vector2(0.5f, 0.5f), new Vector2(x, 0f), new Vector2(330f, 480f), () => OpenEditor(captured));
                    hit.color = new Color(0, 0, 0, 0);
                    var host = new GameObject("Avatar salvo no slot " + (slot + 1));
                    host.transform.SetParent(transform, false);
                    var shown = slot == _state.ActiveHumanSlot ? _state : new PlayerState { Appearance = _state.GetHumanAppearance(slot).Clone() };
                    host.AddComponent<AvatarGpuRuntime>().ConfigureAsWorldAvatar(_saves, shown, new Vector3(x / 100f, -1.95f, 0f), 0.9f);
                    _avatarHosts.Add(host);
                    var kindLabel = NewText("Kind" + (slot + 1), _slotsRoot, 40, new Color(0.45f, 0.2f, 0.6f));
                    Place(kindLabel.rectTransform, new Vector2(x, -300f), new Vector2(420f, 60f));
                    kindLabel.text = AvatarKinds.DisplayName(_state.GetHumanAppearance(slot).Kind);
                }
                else
                {
                    Button("Slot" + (slot + 1), _slotsRoot, Art("Slots/empty_human"), new Vector2(0.5f, 0.5f), new Vector2(x, 3f), new Vector2(279f, 461f),
                        () => ShowKindPicker(captured));
                    var plus = NewImage("Plus" + (slot + 1), _slotsRoot, Art("Slots/plus"), Color.white);
                    Place(plus.rectTransform, new Vector2(x, 3f), new Vector2(110f, 110f));
                }
            }
        }

        void BuildCarSlots()
        {
            var pedestal = NewImage("Pedestal", _slotsRoot, PedestalSprite(), Color.white);
            Place(pedestal.rectTransform, new Vector2(0f, -190f), new Vector2(620f, 130f));
            Button("CarSlot1", _slotsRoot, Art("Slots/empty_vehicle"), new Vector2(0.5f, 0.5f), new Vector2(0f, 20f), new Vector2(519f, 217f),
                () => { UiSound.PlayClick(); ShowToast("Veículos ainda não estão disponíveis."); });
            // Slot bloqueado (laranja) com o carrinho de compras do original: leva a loja.
            Button("CarSlot2", _slotsRoot, Art("Slots/banner_vehicle"), new Vector2(0.5f, 0.5f), new Vector2(SlotSpacing + 90f, 20f), new Vector2(437f, 218f),
                () => { UiSound.PlayClick(); _onOpenStore?.Invoke(); });
            var cartLabel = NewText("OpenStore", _slotsRoot, 40, new Color(0.45f, 0.2f, 0.6f));
            Place(cartLabel.rectTransform, new Vector2(SlotSpacing + 90f, -120f), new Vector2(520f, 60f));
            cartLabel.text = "Toque para abrir a loja";
        }

        void BuildPetSlots()
        {
            for (int i = 0; i < 3; i++)
                Button("PetSlot" + (i + 1), _slotsRoot, Art("Slots/empty_pet"), new Vector2(0.5f, 0.5f), new Vector2(-455f + SlotSpacing * i, 0f), new Vector2(262f, 260f),
                    () => { UiSound.PlayClick(); ShowToast("Pets ainda não estão disponíveis."); });
        }

        // ---------- editor do avatar (slot 1) ----------

        void ClearAvatarHosts()
        {
            foreach (var host in _avatarHosts) if (host != null) Destroy(host);
            _avatarHosts.Clear();
        }

        // Escolha do tipo (adulto, crianca, bebe) ao criar um avatar num slot vazio.
        void ShowKindPicker(int slot)
        {
            if (_picker != null) return;
            UiSound.PlayClick();
            _picker = new GameObject("KindPicker", typeof(RectTransform));
            _picker.transform.SetParent(_frontCanvas.transform, false);
            Stretch((RectTransform)_picker.transform);
            var dim = NewImage("Dim", _picker.transform, null, new Color(0f, 0f, 0f, 0.5f));
            Stretch(dim.rectTransform);
            dim.raycastTarget = true;
            var title = NewText("Title", _picker.transform, 62, Color.white);
            Place(title.rectTransform, new Vector2(0f, 270f), new Vector2(1400f, 100f));
            title.text = "Escolha o tipo de avatar";
            var kinds = AvatarKinds.All;
            for (int i = 0; i < kinds.Length; i++)
            {
                var kind = kinds[i];
                var card = Button("Kind_" + kind, _picker.transform, null, new Vector2(0.5f, 0.5f), new Vector2((i - 1) * 440f, 20f), new Vector2(390f, 330f),
                    () => { HideKindPicker(); OpenEditor(slot, kind); });
                card.color = new Color(1f, 0.93f, 0.96f);
                var label = NewText("Label", card.transform, 58, new Color(0.45f, 0.2f, 0.6f));
                Stretch(label.rectTransform);
                label.text = AvatarKinds.DisplayName(kind);
            }
            var cancel = Button("Cancel", _picker.transform, null, new Vector2(0.5f, 0.5f), new Vector2(0f, -250f), new Vector2(360f, 100f),
                () => { UiSound.PlayClick(); HideKindPicker(); });
            cancel.color = new Color(0.95f, 0.72f, 0.84f);
            var cancelLabel = NewText("Label", cancel.transform, 46, Color.white);
            Stretch(cancelLabel.rectTransform);
            cancelLabel.text = "Cancelar";
        }

        void HideKindPicker()
        {
            if (_picker != null) Destroy(_picker);
            _picker = null;
        }

        void OpenEditor(int slot, AvatarKind kind = AvatarKind.Adult)
        {
            if (_editorHost != null) return;
            UiSound.PlayClick();
            SetVisible(false);
            ClearAvatarHosts();
            // O slot escolhido vira o avatar ativo (o editor e o mundo leem PlayerState.Appearance).
            _editingSlot = slot; _returnSlot = _state.ActiveHumanSlot;
            _editingNew = _state.SwitchHumanSlot(slot, kind);
            _editorHost = new GameObject("AvatarEditorSession");
            _editorHost.transform.SetParent(transform, false);
            // Editor com o layout da cena AvatarMaker do original (AvatarEditorScreen).
            _editorHost.AddComponent<AvatarEditorScreen>().Begin(_saves, _state, CloseEditor);
        }

        void CloseEditor()
        {
            bool saved = _editorHost != null && _editorHost.GetComponent<AvatarEditorScreen>().Saved;
            if (_editorHost != null) Destroy(_editorHost);
            _editorHost = null;
            if (_editingNew && !saved)
            {
                // Criacao cancelada: o slot volta a ficar vazio e o avatar anterior continua ativo.
                _state.DiscardHumanSlot(_editingSlot, _returnSlot);
            }
            else
            {
                // Persiste a troca de slot ativo (o Concluir do editor ja gravou o resto).
                try { _saves.Save(_state); }
                catch (System.Exception e) when (e is System.IO.IOException || e is UnauthorizedAccessException) { Debug.LogWarning("Slots: nao gravou slot ativo: " + e.Message); }
            }
            _editingNew = false;
            SetVisible(true);
            SelectTab(Tab);
        }

        void SetVisible(bool visible)
        {
            _camera.enabled = visible;
            _backCanvas.enabled = visible;
            _frontCanvas.enabled = visible;
        }

        void ShowToast(string message)
        {
            _toast.text = message; _toast.enabled = true; _toastUntil = Time.unscaledTime + 2f;
        }

        void Update()
        {
            if (_toast != null && _toast.enabled && Time.unscaledTime > _toastUntil) _toast.enabled = false;
        }

        // ---------- helpers ----------

        Sprite Art(string path)
        {
            if (_sprites.TryGetValue(path, out var cached)) return cached;
            var tex = Resources.Load<Texture2D>(path);
            if (tex == null) { Debug.LogWarning("Slots: arte ausente " + path); return null; }
            var sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100f);
            _sprites[path] = sprite;
            return sprite;
        }

        Sprite PedestalSprite()
        {
            if (_sprites.TryGetValue("pedestal", out var cached)) return cached;
            const int w = 256, h = 80;
            var tex = new Texture2D(w, h, TextureFormat.RGBA32, false) { filterMode = FilterMode.Bilinear };
            for (int y = 0; y < h; y++)
                for (int x = 0; x < w; x++)
                {
                    float nx = (x + 0.5f) / w * 2f - 1f, ny = (y + 0.5f) / h * 2f - 1f;
                    float d = nx * nx + ny * ny;
                    var c = new Color(0.94f, 0.66f, 0.68f, 0f);
                    if (d <= 1f) c.a = d > 0.9f ? 0.9f : 0.45f;
                    tex.SetPixel(x, y, c);
                }
            tex.Apply();
            var sprite = Sprite.Create(tex, new Rect(0, 0, w, h), new Vector2(0.5f, 0.5f), 100f);
            _sprites["pedestal"] = sprite;
            return sprite;
        }

        static Transform Rect(string name, Transform parent)
        {
            var go = new GameObject(name, typeof(RectTransform));
            go.transform.SetParent(parent, false);
            Stretch((RectTransform)go.transform);
            return go.transform;
        }

        static void Stretch(RectTransform rect)
        {
            rect.anchorMin = Vector2.zero; rect.anchorMax = Vector2.one; rect.offsetMin = rect.offsetMax = Vector2.zero;
        }

        static void Place(RectTransform rect, Vector2 position, Vector2 size)
        {
            rect.anchorMin = rect.anchorMax = new Vector2(0.5f, 0.5f);
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

        static Image Button(string name, Transform parent, Sprite sprite, Vector2 anchor, Vector2 position, Vector2 size, Action onClick)
        {
            var image = NewImage(name, parent, sprite, Color.white);
            var rect = image.rectTransform;
            rect.anchorMin = rect.anchorMax = anchor;
            rect.pivot = new Vector2(0.5f, 0.5f);
            rect.anchoredPosition = position; rect.sizeDelta = size;
            image.raycastTarget = true;
            var button = image.gameObject.AddComponent<Button>();
            button.targetGraphic = image;
            button.onClick.AddListener(() => onClick());
            return image;
        }
    }
}
