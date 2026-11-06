using System;
using System.Collections.Generic;
using AvatarWorld.Core.Avatar;
using AvatarWorld.Core.Economy;
using UnityEngine;
using UnityEngine.UI;

namespace AvatarWorld.Runtime
{
    /// <summary>
    /// Editor de pet simples: escolhe a especie e a variante (skin pronto) com o pet animado a esquerda. Concluir grava no slot;
    /// Voltar descarta. Layout no canvas 2048x1024 do resto do editor de avatar (botoes de voltar/concluir do original).
    /// </summary>
    public sealed class PetEditorScreen : MonoBehaviour
    {
        static readonly Vector3 PetPosition = new Vector3(-3.2f, -2.2f, 0f);
        const float PetScale = 1.3f;
        static readonly Color Ink = new Color(0.45f, 0.2f, 0.6f);

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
        readonly Dictionary<string, Image> _speciesButtons = new Dictionary<string, Image>();
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

            // Painel a direita: especies (2 colunas) e seletor de variante.
            var panel = NewImage("Panel", root, null, new Color(0.995f, 0.94f, 0.96f));
            var pr = panel.rectTransform;
            pr.anchorMin = new Vector2(1, 0); pr.anchorMax = new Vector2(1, 1);
            pr.pivot = new Vector2(1, 0.5f);
            pr.sizeDelta = new Vector2(860f, 0f);
            pr.anchoredPosition = Vector2.zero;
            panel.raycastTarget = true;

            var title = NewText("SpeciesTitle", panel.transform, 52, Ink);
            Place(title.rectTransform, new Vector2(0.5f, 1), new Vector2(0f, -70f), new Vector2(760f, 80f));
            title.text = "Espécie";
            var species = PetCatalog.Species;
            for (int i = 0; i < species.Length; i++)
            {
                string key = species[i];
                float x = (i % 2 == 0 ? -200f : 200f);
                float y = -190f - (i / 2) * 120f;
                var button = Button("Species_" + key, panel.transform, null, new Vector2(0.5f, 1), new Vector2(x, y), new Vector2(380f, 100f),
                    () => { UiSound.PlayClick(); if (_working.TrySelectSpecies(key)) { _runtime.Apply(_working); Refresh(); } });
                var label = NewText("Label", button.transform, 44, Ink);
                Stretch(label.rectTransform);
                label.text = PetCatalog.DisplayName(key);
                _speciesButtons[key] = button;
            }

            var variantTitle = NewText("VariantTitle", panel.transform, 52, Ink);
            Place(variantTitle.rectTransform, new Vector2(0.5f, 0), new Vector2(0f, 420f), new Vector2(760f, 80f));
            variantTitle.text = "Variante";
            var prev = Button("Prev", panel.transform, null, new Vector2(0.5f, 0), new Vector2(-270f, 290f), new Vector2(150f, 130f), () => StepVariant(-1));
            prev.color = new Color(0.95f, 0.72f, 0.84f);
            var prevLabel = NewText("Label", prev.transform, 70, Color.white); Stretch(prevLabel.rectTransform); prevLabel.text = "<";
            var next = Button("Next", panel.transform, null, new Vector2(0.5f, 0), new Vector2(270f, 290f), new Vector2(150f, 130f), () => StepVariant(1));
            next.color = new Color(0.95f, 0.72f, 0.84f);
            var nextLabel = NewText("Label", next.transform, 70, Color.white); Stretch(nextLabel.rectTransform); nextLabel.text = ">";
            _variantLabel = NewText("VariantLabel", panel.transform, 50, Ink);
            Place(_variantLabel.rectTransform, new Vector2(0.5f, 0), new Vector2(0f, 290f), new Vector2(360f, 100f));

            _toast = NewText("Toast", root, 46, Ink);
            Place(_toast.rectTransform, new Vector2(0.5f, 0), new Vector2(-300f, 52f), new Vector2(1100f, 90f));
            _toast.enabled = false;
        }

        void StepVariant(int delta)
        {
            UiSound.PlayClick();
            var list = PetCatalog.Variants(_working.Species);
            int index = Array.IndexOf(list, _working.VariantId);
            index = (index + delta + list.Length) % list.Length;
            if (_working.TrySelectVariant(list[index])) { _runtime.Apply(_working); Refresh(); }
        }

        void Refresh()
        {
            foreach (var pair in _speciesButtons)
                pair.Value.color = pair.Key == _working.Species ? new Color(1f, 0.58f, 0.82f) : new Color(1f, 0.9f, 0.95f);
            var list = PetCatalog.Variants(_working.Species);
            _variantLabel.text = (Array.IndexOf(list, _working.VariantId) + 1) + " / " + list.Length;
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
