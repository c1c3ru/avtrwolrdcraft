using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace AvatarWorld.Runtime
{
    /// <summary>Monta uma hierarquia de UI (Canvas, Image, TextMeshPro, Button) a partir de uma SceneDescription.</summary>
    public static class UiSceneBuilder
    {
        /// <summary>Resolucao de referencia do CanvasScaler. O original nao foi lido; ajustavel pelo chamador.</summary>
        public static Vector2 ReferenceResolution = new Vector2(1920f, 1080f);

        /// <param name="loadSprite">Resolve a chave de sprite do JSON em um Sprite (pode devolver null).</param>
        /// <param name="actions">Acoes de clique, procuradas pelo nome do objeto e depois pelo nome do metodo.</param>
        /// <returns>Um GameObject por no, na mesma ordem de desc.nodes.</returns>
        public static List<GameObject> Build(SceneDescription desc, Func<string, Sprite> loadSprite,
            IDictionary<string, Action> actions = null, Transform parent = null)
        {
            if (desc == null) throw new ArgumentNullException(nameof(desc));
            var objs = new List<GameObject>(desc.nodes.Count);

            foreach (var n in desc.nodes)
            {
                if (n.parent >= objs.Count)
                    throw new InvalidOperationException($"no '{n.name}' referencia pai {n.parent} que ainda nao existe");

                var go = n.hasRect ? new GameObject(n.name, typeof(RectTransform)) : new GameObject(n.name);
                go.transform.SetParent(n.parent < 0 ? parent : objs[n.parent].transform, false);
                objs.Add(go);

                bool rootCanvas = n.isCanvas && n.parent < 0;
                if (n.hasRect && !rootCanvas)
                {
                    var rt = (RectTransform)go.transform;
                    rt.anchorMin = n.anchorMin;
                    rt.anchorMax = n.anchorMax;
                    rt.pivot = n.pivot;
                    rt.anchoredPosition = n.anchoredPosition;
                    rt.sizeDelta = n.sizeDelta;
                }
                if (!rootCanvas)
                {
                    go.transform.localScale = n.localScale;
                    go.transform.localRotation = n.localRotation;
                    if (!n.hasRect) go.transform.localPosition = n.localPosition;
                }

                if (n.isCanvas) AddCanvas(go, n.parent < 0);
                if (n.hasImage) AddImage(go, n.image, loadSprite);
                if (n.hasText) AddText(go, n.text);
                if (n.hasButton) AddButton(go, n, actions);
            }

            // Ativacao por ultimo: SetActive(false) num pai desativaria a montagem dos filhos.
            for (int i = 0; i < objs.Count; i++)
                if (!desc.nodes[i].active) objs[i].SetActive(false);

            return objs;
        }

        static void AddCanvas(GameObject go, bool isRoot)
        {
            var canvas = go.AddComponent<Canvas>();
            if (isRoot) canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            if (!isRoot) return;
            var scaler = go.AddComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = ReferenceResolution;
            scaler.matchWidthOrHeight = 0.5f;
            go.AddComponent<GraphicRaycaster>();
        }

        static void AddImage(GameObject go, ImageDescription d, Func<string, Sprite> loadSprite)
        {
            var img = go.AddComponent<Image>();
            if (!string.IsNullOrEmpty(d.sprite) && loadSprite != null) img.sprite = loadSprite(d.sprite);
            img.color = d.color;
            img.type = (Image.Type)d.imageType;
            img.preserveAspect = d.preserveAspect;
            img.raycastTarget = d.raycastTarget;
            img.enabled = d.enabled;
        }

        static void AddText(GameObject go, TextDescription d)
        {
            var t = go.AddComponent<TextMeshProUGUI>();
            t.text = d.text;
            t.fontSize = d.fontSize;
            t.color = d.color;
            t.horizontalAlignment = (HorizontalAlignmentOptions)d.hAlign;
            t.verticalAlignment = (VerticalAlignmentOptions)d.vAlign;
            t.enableAutoSizing = d.autoSize;
            if (d.autoSize) { t.fontSizeMin = d.minSize; t.fontSizeMax = d.maxSize; }
            t.enabled = d.enabled;
        }

        static void AddButton(GameObject go, NodeDescription n, IDictionary<string, Action> actions)
        {
            var b = go.AddComponent<Button>();
            b.interactable = n.button.interactable;
            b.targetGraphic = go.GetComponent<Graphic>();
            if (b.targetGraphic == null)
            {
                // Substitui o NonDrawingGraphic omitido na exportacao: area inteira clicavel.
                var hitArea = go.AddComponent<Image>();
                hitArea.color = Color.clear;
                hitArea.raycastTarget = true;
                b.targetGraphic = hitArea;
                b.transition = Selectable.Transition.None;
            }
            if (actions == null) return;

            Action action;
            if (actions.TryGetValue(n.name, out action)) { b.onClick.AddListener(() => action()); return; }
            foreach (var call in n.button.onClick)
                if (actions.TryGetValue(call.method, out action)) { var a = action; b.onClick.AddListener(() => a()); }
        }

        /// <summary>Garante um EventSystem; sem ele nenhum botao recebe clique.</summary>
        public static void EnsureEventSystem()
        {
            if (UnityEngine.Object.FindFirstObjectByType<EventSystem>() != null) return;
            var go = new GameObject("EventSystem", typeof(EventSystem));
#if ENABLE_INPUT_SYSTEM && !ENABLE_LEGACY_INPUT_MANAGER
            go.AddComponent<UnityEngine.InputSystem.UI.InputSystemUIInputModule>();
#else
            go.AddComponent<StandaloneInputModule>();
#endif
        }
    }
}
