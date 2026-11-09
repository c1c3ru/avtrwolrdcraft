using System;
using System.Collections.Generic;
using AvatarWorld.Core.Avatar;
using AvatarWorld.Core.Economy;
using UnityEngine;
using UnityEngine.UI;

namespace AvatarWorld.Runtime
{
    /// <summary>
    /// Editor de pet com o pet animado a esquerda e o painel a direita: especie (10), e
    /// - especies simples: variante (setas);
    /// - cao e gato (em camadas): abas Raca, Padrao, Cor, Cor do padrao, Sobrancelha, Cor da sobrancelha, Olhos, Cor dos olhos e Boca,
    ///   com grade rolavel de opcoes ou amostras de cor. Concluir grava no slot; Voltar descarta.
    /// Layout no canvas 2048x1024 do resto do editor de avatar.
    /// </summary>
    public sealed class PetEditorScreen : MonoBehaviour
    {
        static readonly Vector3 PetPosition = new Vector3(-3.2f, -2.2f, 0f);
        const float PetScale = 1.3f;
        static readonly Color Ink = new Color(0.45f, 0.2f, 0.6f);
        static readonly Color Pink = new Color(1f, 0.58f, 0.82f), Light = new Color(1f, 0.9f, 0.95f);

        enum Tab { Breed, Pattern, BodyColor, PatternColor, Eyebrow, EyebrowColor, Eyes, EyesColor, Mouth, Mane, ManeColor, Tail, TailColor }

        static string TabLabel(Tab tab)
        {
            switch (tab)
            {
                case Tab.Breed: return "Raça";
                case Tab.Pattern: return "Padrão";
                case Tab.BodyColor: return "Cor";
                case Tab.PatternColor: return "Cor padrão";
                case Tab.Eyebrow: return "Sobrancelha";
                case Tab.EyebrowColor: return "Cor sobr.";
                case Tab.Mane: return "Crina";
                case Tab.ManeColor: return "Cor crina";
                case Tab.Tail: return "Cauda";
                case Tab.TailColor: return "Cor cauda";
                case Tab.Eyes: return "Olhos";
                case Tab.EyesColor: return "Cor olhos";
                default: return "Boca";
            }
        }

        SaveStore _saves;
        PlayerState _state;
        int _slot;
        Action _onClose;
        PetAppearance _working;
        PetGpuRuntime _runtime;
        Camera _camera;
        Canvas _canvas;
        Text _variantLabel, _toast;
        float _toastUntil;
        bool _closing;
        Font _font;
        Tab _tab = Tab.Breed;
        GameObject _simpleGroup, _layeredGroup;
        RectTransform _grid;
        ScrollRect _scroll;
        readonly Dictionary<string, Image> _speciesButtons = new Dictionary<string, Image>();
        readonly Dictionary<Tab, Image> _tabButtons = new Dictionary<Tab, Image>();
        readonly Dictionary<string, Sprite> _art = new Dictionary<string, Sprite>();

        public bool Saved { get; private set; }
        public PetAppearance Working => _working;

        public void Begin(SaveStore saves, PlayerState state, int slot, Action onClose)
        {
            _saves = saves ?? throw new ArgumentNullException(nameof(saves));
            _state = state ?? throw new ArgumentNullException(nameof(state));
            _slot = slot;
            _onClose = onClose;
            _font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            _working = (_state.GetPet(slot) ?? PetAppearance.CreateDefault()).Clone();
            UiSceneBuilder.EnsureEventSystem();

            _camera = new GameObject("PetEditorCamera", typeof(Camera)).GetComponent<Camera>();
            _camera.transform.SetParent(transform, false);
            _camera.tag = "MainCamera";
            _camera.orthographic = true;
            _camera.orthographicSize = 5.12f; // 1 unidade do mundo = 100 unidades do canvas 2048x1024
            _camera.clearFlags = CameraClearFlags.SolidColor;
            _camera.backgroundColor = new Color(0.97f, 0.89f, 0.89f);
            _camera.transform.position = new Vector3(0, 0, -10);

            var canvasGo = new GameObject("PetEditorCanvas", typeof(RectTransform), typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
            canvasGo.transform.SetParent(transform, false);
            _canvas = canvasGo.GetComponent<Canvas>();
            _canvas.renderMode = RenderMode.ScreenSpaceCamera;
            _canvas.worldCamera = _camera;
            _canvas.planeDistance = 10f;
            _canvas.overrideSorting = true;
            _canvas.sortingOrder = 10;
            var scaler = canvasGo.GetComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(2048f, 1024f);
            scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;

            var host = new GameObject("Pet em edicao");
            host.transform.SetParent(transform, false);
            _runtime = host.AddComponent<PetGpuRuntime>();
            _runtime.Configure(_working, PetPosition, PetScale);

            BuildUi();
            Refresh();
        }

        void BuildUi()
        {
            var root = _canvas.transform;
            Button("BackButton", root, Art("Slots/back"), new Vector2(0, 1), new Vector2(92.5f, -91f), new Vector2(146f, 143f), Back);
            Button("DoneButton", root, Art("AvatarMaker/done"), new Vector2(0, 0), new Vector2(95f, 94f), new Vector2(151f, 149f), Done);

            var panel = NewImage("Panel", root, null, new Color(0.995f, 0.94f, 0.96f));
            var pr = panel.rectTransform;
            pr.anchorMin = new Vector2(1, 0); pr.anchorMax = new Vector2(1, 1);
            pr.pivot = new Vector2(1, 0.5f);
            pr.sizeDelta = new Vector2(860f, 0f);
            pr.anchoredPosition = Vector2.zero;
            panel.raycastTarget = true;

            // Especies: 5 colunas x 2 linhas no topo do painel.
            var species = PetCatalog.Species;
            for (int i = 0; i < species.Length; i++)
            {
                string key = species[i];
                float x = -330f + (i % 5) * 165f;
                float y = -50f - (i / 5) * 84f;
                var button = Button("Species_" + key, panel.transform, null, new Vector2(0.5f, 1), new Vector2(x, y), new Vector2(155f, 74f), () => SelectSpecies(key));
                var label = NewText("Label", button.transform, 32, Ink);
                Stretch(label.rectTransform);
                label.text = PetCatalog.DisplayName(key);
                _speciesButtons[key] = button;
            }

            // Especies simples: seletor de variante.
            _simpleGroup = new GameObject("Simple", typeof(RectTransform));
            _simpleGroup.transform.SetParent(panel.transform, false);
            Stretch((RectTransform)_simpleGroup.transform);
            var variantTitle = NewText("VariantTitle", _simpleGroup.transform, 52, Ink);
            Place(variantTitle.rectTransform, new Vector2(0.5f, 1), new Vector2(0f, -380f), new Vector2(760f, 80f));
            variantTitle.text = "Variante";
            var prev = Button("Prev", _simpleGroup.transform, null, new Vector2(0.5f, 1), new Vector2(-270f, -520f), new Vector2(150f, 130f), () => StepVariant(-1));
            prev.color = new Color(0.95f, 0.72f, 0.84f);
            var prevLabel = NewText("Label", prev.transform, 70, Color.white); Stretch(prevLabel.rectTransform); prevLabel.text = "<";
            var next = Button("Next", _simpleGroup.transform, null, new Vector2(0.5f, 1), new Vector2(270f, -520f), new Vector2(150f, 130f), () => StepVariant(1));
            next.color = new Color(0.95f, 0.72f, 0.84f);
            var nextLabel = NewText("Label", next.transform, 70, Color.white); Stretch(nextLabel.rectTransform); nextLabel.text = ">";
            _variantLabel = NewText("VariantLabel", _simpleGroup.transform, 50, Ink);
            Place(_variantLabel.rectTransform, new Vector2(0.5f, 1), new Vector2(0f, -520f), new Vector2(360f, 100f));

            // Cao e gato: abas (3 colunas) e grade rolavel.
            _layeredGroup = new GameObject("Layered", typeof(RectTransform));
            _layeredGroup.transform.SetParent(panel.transform, false);
            Stretch((RectTransform)_layeredGroup.transform);
            var tabs = (Tab[])Enum.GetValues(typeof(Tab));
            for (int i = 0; i < tabs.Length; i++)
            {
                var tab = tabs[i];
                float x = -280f + (i % 3) * 280f;
                float y = -330f - (i / 3) * 70f;
                var button = Button("Tab_" + tab, _layeredGroup.transform, null, new Vector2(0.5f, 1), new Vector2(x, y), new Vector2(268f, 62f), () => { UiSound.PlayClick(); _tab = tab; Refresh(); });
                var label = NewText("Label", button.transform, 32, Ink);
                Stretch(label.rectTransform);
                label.text = TabLabel(tab);
                _tabButtons[tab] = button;
            }
            var viewport = new GameObject("Viewport", typeof(RectTransform), typeof(RectMask2D), typeof(ScrollRect), typeof(Image));
            viewport.transform.SetParent(_layeredGroup.transform, false);
            var vr = (RectTransform)viewport.transform;
            vr.anchorMin = new Vector2(0, 0); vr.anchorMax = new Vector2(1, 1);
            vr.offsetMin = new Vector2(24f, 20f); vr.offsetMax = new Vector2(-24f, -640f);
            viewport.GetComponent<Image>().color = new Color(0, 0, 0, 0.001f);
            var content = new GameObject("Grid", typeof(RectTransform), typeof(GridLayoutGroup), typeof(ContentSizeFitter));
            content.transform.SetParent(viewport.transform, false);
            _grid = (RectTransform)content.transform;
            _grid.anchorMin = new Vector2(0, 1); _grid.anchorMax = new Vector2(1, 1);
            _grid.pivot = new Vector2(0.5f, 1);
            _grid.sizeDelta = Vector2.zero;
            var layout = content.GetComponent<GridLayoutGroup>();
            layout.cellSize = new Vector2(104f, 104f);
            layout.spacing = new Vector2(8f, 8f);
            layout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            layout.constraintCount = 7;
            content.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
            _scroll = viewport.GetComponent<ScrollRect>();
            _scroll.content = _grid;
            _scroll.horizontal = false;
            _scroll.vertical = true;
            _scroll.movementType = ScrollRect.MovementType.Clamped;
            _scroll.scrollSensitivity = 40f;

            _toast = NewText("Toast", root, 46, Ink);
            Place(_toast.rectTransform, new Vector2(0.5f, 0), new Vector2(-300f, 52f), new Vector2(1100f, 90f));
            _toast.enabled = false;
        }

        void SelectSpecies(string species)
        {
            UiSound.PlayClick();
            if (!_working.TrySelectSpecies(species)) return;
            _tab = Tab.Breed;
            _runtime.Apply(_working);
            Refresh();
        }

        void StepVariant(int delta)
        {
            UiSound.PlayClick();
            var list = PetCatalog.Variants(_working.Species);
            int index = Array.IndexOf(list, _working.VariantId);
            index = (index + delta + list.Length) % list.Length;
            if (_working.TrySelectVariant(list[index])) { _runtime.Apply(_working); Refresh(); }
        }

        bool TabAvailable(Tab tab)
        {
            switch (tab)
            {
                case Tab.Eyebrow: return PetCatalog.Eyebrows(_working.Species, _working.BreedId).Length > 0;
                case Tab.EyebrowColor: return PetCatalog.ColorCount(_working.Species, PetColorRole.Eyebrows) > 0 && !string.IsNullOrEmpty(_working.EyebrowId);
                case Tab.PatternColor: return !string.IsNullOrEmpty(_working.PatternId);
                case Tab.Mane: return PetCatalog.Layers(_working.Species).Manes.Length > 0;
                case Tab.ManeColor: return PetCatalog.Layers(_working.Species).Manes.Length > 0 && PetCatalog.ColorCount(_working.Species, PetColorRole.Mane) > 0;
                case Tab.Tail: return PetCatalog.Layers(_working.Species).Tails.Length > 0;
                case Tab.TailColor: return PetCatalog.Layers(_working.Species).Tails.Length > 0 && PetCatalog.ColorCount(_working.Species, PetColorRole.Tail) > 0;
                default: return true;
            }
        }

        void Refresh()
        {
            foreach (var pair in _speciesButtons) pair.Value.color = pair.Key == _working.Species ? Pink : Light;
            bool layered = PetCatalog.IsLayered(_working.Species);
            _simpleGroup.SetActive(!layered);
            _layeredGroup.SetActive(layered);
            if (!layered)
            {
                var list = PetCatalog.Variants(_working.Species);
                _variantLabel.text = (Array.IndexOf(list, _working.VariantId) + 1) + " / " + list.Length;
                return;
            }
            if (!TabAvailable(_tab)) _tab = Tab.Breed;
            foreach (var pair in _tabButtons)
            {
                bool available = TabAvailable(pair.Key);
                pair.Value.gameObject.SetActive(available);
                pair.Value.color = pair.Key == _tab ? Pink : Light;
            }
            RebuildGrid();
        }

        void RebuildGrid()
        {
            for (int i = _grid.childCount - 1; i >= 0; i--) { var c = _grid.GetChild(i).gameObject; c.SetActive(false); Destroy(c); }
            _grid.anchoredPosition = Vector2.zero;
            string species = _working.Species;
            var layers = PetCatalog.Layers(species);
            switch (_tab)
            {
                case Tab.Breed:
                    foreach (var id in layers.Breeds) { string v = id; AddCell(Label(id), null, _working.BreedId == v, () => Choose(_working.TrySelectBreed(v))); }
                    break;
                case Tab.Pattern:
                    AddCell("∅", null, string.IsNullOrEmpty(_working.PatternId), () => Choose(_working.TrySelectPattern("")));
                    foreach (var id in PetCatalog.Patterns(species, _working.BreedId)) { string v = id; AddCell(Label(id), null, _working.PatternId == v, () => Choose(_working.TrySelectPattern(v))); }
                    break;
                case Tab.Eyebrow:
                    AddCell("∅", null, string.IsNullOrEmpty(_working.EyebrowId), () => Choose(_working.TrySelectEyebrow("")));
                    foreach (var id in PetCatalog.Eyebrows(species, _working.BreedId)) { string v = id; AddCell(Label(id), null, _working.EyebrowId == v, () => Choose(_working.TrySelectEyebrow(v))); }
                    break;
                case Tab.Eyes:
                    foreach (var id in layers.Eyes) { string v = id; AddCell(Label(id), null, _working.EyesId == v, () => Choose(_working.TrySelectEyes(v))); }
                    break;
                case Tab.Mouth:
                    foreach (var id in layers.Mouths) { string v = id; AddCell(Label(id), null, _working.MouthId == v, () => Choose(_working.TrySelectMouth(v))); }
                    break;
                case Tab.Mane:
                    foreach (var id in layers.Manes) { string v = id; AddCell(Label(id), null, _working.ManeId == v, () => Choose(_working.TrySelectMane(v))); }
                    break;
                case Tab.Tail:
                    foreach (var id in layers.Tails) { string v = id; AddCell(Label(id), null, _working.TailId == v, () => Choose(_working.TrySelectTail(v))); }
                    break;
                case Tab.ManeColor: AddColorCells(PetColorRole.Mane); break;
                case Tab.TailColor: AddColorCells(PetColorRole.Tail); break;
                case Tab.BodyColor: AddColorCells(PetColorRole.Body); break;
                case Tab.PatternColor: AddColorCells(PetColorRole.Pattern); break;
                case Tab.EyebrowColor: AddColorCells(PetColorRole.Eyebrows); break;
                case Tab.EyesColor: AddColorCells(PetColorRole.Eyes); break;
            }
        }

        // "breed_a" -> "A"; "pattern_3" -> "3": a parte depois do ultimo "_" em maiuscula.
        static string Label(string id) => id.Substring(id.LastIndexOf('_') + 1).ToUpperInvariant();

        void AddColorCells(PetColorRole role)
        {
            int count = PetCatalog.ColorCount(_working.Species, role);
            int selected = _working.GetColor(role);
            for (int i = 0; i < count; i++)
            {
                int index = i;
                AddCell(null, PetGpuRuntime.Swatch(_working.Species, role, i), selected == i, () => Choose(_working.TrySelectColor(role, index)));
            }
        }

        void Choose(bool changed)
        {
            UiSound.PlayClick();
            if (!changed) return;
            _runtime.Apply(_working);
            Refresh();
        }

        void AddCell(string label, Color? swatch, bool selected, Action onClick)
        {
            var cell = NewImage("Cell", _grid, null, selected ? Pink : Light);
            cell.raycastTarget = true;
            var button = cell.gameObject.AddComponent<Button>();
            button.targetGraphic = cell;
            button.onClick.AddListener(() => onClick());
            if (swatch.HasValue)
            {
                var inner = NewImage("Swatch", cell.transform, null, swatch.Value);
                Stretch(inner.rectTransform);
                inner.rectTransform.offsetMin = new Vector2(10f, 10f);
                inner.rectTransform.offsetMax = new Vector2(-10f, -10f);
            }
            if (label != null)
            {
                var text = NewText("Label", cell.transform, 44, Ink);
                Stretch(text.rectTransform);
                text.text = label;
            }
        }

        void Done()
        {
            if (_closing) return;
            UiSound.PlayClick();
            if (!_state.SetPet(_slot, _working)) { ShowToast("Pet inválido."); return; }
            try { _saves.Save(_state); }
            catch (Exception e) when (e is System.IO.IOException || e is UnauthorizedAccessException)
            {
                ShowToast("Não foi possível salvar.");
                return;
            }
            Saved = true;
            Close();
        }

        void Back()
        {
            if (_closing) return;
            UiSound.PlayClick();
            Close();
        }

        void Close()
        {
            _closing = true;
            var close = _onClose;
            _onClose = null;
            close?.Invoke();
        }

        void ShowToast(string message) { _toast.text = message; _toast.enabled = true; _toastUntil = Time.unscaledTime + 2.2f; }

        void Update()
        {
            if (_toast != null && _toast.enabled && Time.unscaledTime > _toastUntil) _toast.enabled = false;
        }

        // ---------- helpers ----------

        Sprite Art(string path)
        {
            if (_art.TryGetValue(path, out var cached)) return cached;
            var tex = Resources.Load<Texture2D>(path);
            if (tex == null) { Debug.LogWarning("PetEditor: arte ausente " + path); return null; }
            var sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100f);
            _art[path] = sprite;
            return sprite;
        }

        static void Stretch(RectTransform rect) { rect.anchorMin = Vector2.zero; rect.anchorMax = Vector2.one; rect.offsetMin = rect.offsetMax = Vector2.zero; }

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

        static Image Button(string name, Transform parent, Sprite sprite, Vector2 anchor, Vector2 position, Vector2 size, Action onClick)
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
