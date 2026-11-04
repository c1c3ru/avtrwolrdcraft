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
        /// <summary>Resolucao de referencia serializada nos CanvasScaler da Home original.</summary>
        public static Vector2 ReferenceResolution = new Vector2(2048f, 1024f);

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
                    // O fundo (ScreenScripts.FitToScreen no original) e tratado por HomeLayout.Apply,
                    // chamado depois do Build() em HomeBootstrap - ve-lo aqui so duplicaria/conflitaria.
                }
                if (!rootCanvas)
                {
                    go.transform.localScale = n.localScale;
                    go.transform.localRotation = n.localRotation;
                    if (!n.hasRect) go.transform.localPosition = n.localPosition;
                }

                // Uma excecao num unico componente (dado estranho de um dos ~150 nos) nao pode
                // abortar o Build() inteiro: isso pularia o loop final que desativa os nos
                // active=false, deixando dialogos (Settings, AvatarID...) presos visiveis por cima
                // de tudo. Contem por no e loga o nome pra diagnostico.
                try
                {
                    if (n.isCanvas) AddCanvas(go, n.parent < 0);
                    if (n.hasImage) AddImage(go, n.image, loadSprite);
                    // Botoes do original sem sprite usam NonDrawingGraphic (grafico invisivel, so pra
                    // capturar clique) - nosso exportador nao marca isso como hasImage. Sem NENHUM
                    // Graphic no objeto o GraphicRaycaster nao acerta nada ali e o clique nunca chega
                    // ao Button. Mas so quando o no tambem NAO tem texto: UI_BTTN_Logout tem botao e
                    // texto no MESMO objeto (sem imagem) - o proprio TextMeshProUGUI (adicionado
                    // abaixo) ja serve de Graphic/alvo de clique; empilhar Image+TMP no mesmo
                    // GameObject e o que lancava NullReferenceException em AddText.
                    else if (n.hasButton && !n.hasText) AddInvisibleRaycastTarget(go);
                    if (n.hasText) AddText(go, n.text);
                    if (n.hasButton) AddButton(go, n, actions);
                }
                catch (Exception e)
                {
                    Debug.LogError("UiSceneBuilder: falha no no '" + n.name + "' (indice " + (objs.Count - 1) + "): " + e);
                }
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
            scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
            scaler.matchWidthOrHeight = 1f;
            go.AddComponent<GraphicRaycaster>();
        }

        static void AddInvisibleRaycastTarget(GameObject go)
        {
            var img = go.AddComponent<Image>();
            img.color = new Color(0, 0, 0, 0);
        }

        static void AddImage(GameObject go, ImageDescription d, Func<string, Sprite> loadSprite)
        {
            var img = go.AddComponent<Image>();
            if (!string.IsNullOrEmpty(d.sprite) && loadSprite != null) img.sprite = loadSprite(d.sprite);
            img.color = d.color;
            img.type = (Image.Type)d.imageType;
            img.preserveAspect = d.preserveAspect;
            img.pixelsPerUnitMultiplier = d.pixelsPerUnitMultiplier > 0f ? d.pixelsPerUnitMultiplier : 1f;
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
            // Som de clique em todo botao interativo, mesmo os ainda sem acao ligada (nao-funcional
            // != mudo): da feedback sonoro consistente, igual ao original.
            b.onClick.AddListener(UiSound.PlayClick);
            if (actions == null) return;

            Action action;
            if (actions.TryGetValue(n.name, out action)) { b.onClick.AddListener(() => action()); return; }
            foreach (var call in n.button.onClick)
                if (actions.TryGetValue(call.method, out action)) { var a = action; b.onClick.AddListener(() => a()); }
        }

        /// <summary>Garante um EventSystem; sem ele nenhum botao recebe clique.</summary>
        public static void EnsureEventSystem()
        {
            var systems = UnityEngine.Object.FindObjectsByType<EventSystem>();
            EventSystem system = systems.Length > 0 ? systems[0] : null;
            if (system == null) system = new GameObject("EventSystem", typeof(EventSystem)).GetComponent<EventSystem>();
            for (int i = 1; i < systems.Length; i++)
                if (systems[i] != null && systems[i] != system) systems[i].gameObject.SetActive(false);
#if ENABLE_INPUT_SYSTEM && !ENABLE_LEGACY_INPUT_MANAGER
            var legacy = system.GetComponent<StandaloneInputModule>();
            if (legacy != null)
            {
                legacy.enabled = false;
                UnityEngine.Object.Destroy(legacy);
            }
            var inputSystemModule = system.GetComponent<UnityEngine.InputSystem.UI.InputSystemUIInputModule>();
            if (inputSystemModule == null) inputSystemModule = system.gameObject.AddComponent<UnityEngine.InputSystem.UI.InputSystemUIInputModule>();
            inputSystemModule.AssignDefaultActions();
#elif ENABLE_INPUT_SYSTEM
            // Projeto em modo Both: mantém um único módulo. O atual suporta toque/Pointer e API legada.
            var legacy = system.GetComponent<StandaloneInputModule>();
            if (legacy != null)
            {
                legacy.enabled = false;
                UnityEngine.Object.Destroy(legacy);
            }
            var inputSystemModule = system.GetComponent<UnityEngine.InputSystem.UI.InputSystemUIInputModule>();
            if (inputSystemModule == null) inputSystemModule = system.gameObject.AddComponent<UnityEngine.InputSystem.UI.InputSystemUIInputModule>();
            inputSystemModule.AssignDefaultActions();
#else
            if (system.GetComponent<BaseInputModule>() == null) system.gameObject.AddComponent<StandaloneInputModule>();
#endif
        }
    }
}
