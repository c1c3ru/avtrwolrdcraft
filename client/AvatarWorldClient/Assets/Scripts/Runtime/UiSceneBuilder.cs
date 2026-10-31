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
                    // ScreenScripts.FitToScreen no original (EffectType.XY, keepAspectRatio=false,
                    // confirmado no MonoBehaviour real da Home) estica o fundo pra cobrir X e Y
                    // exatamente - a posicao/tamanho fixos exportados valiam so pra resolucao de
                    // referencia do editor e NAO reproduzem isso sozinhos.
                    if (n.ignoredComponents != null && n.ignoredComponents.Contains("ScreenScripts.FitToScreen"))
                    {
                        rt.anchorMin = Vector2.zero;
                        rt.anchorMax = Vector2.one;
                        rt.pivot = new Vector2(0.5f, 0.5f);
                        rt.anchoredPosition = Vector2.zero;
                        rt.sizeDelta = Vector2.zero;
                    }
                    else
                    {
                        rt.anchorMin = n.anchorMin;
                        rt.anchorMax = n.anchorMax;
                        rt.pivot = n.pivot;
                        rt.anchoredPosition = n.anchoredPosition;
                        rt.sizeDelta = n.sizeDelta;
                    }
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

        /// <summary>
        /// Reproduz PazuCore.PazuCoreAddressables.AFC.AFCCanvasScalerRangeToScreen do original: em
        /// telas muito largas (ratio >= 2.0 - a maioria dos celulares atuais, 18:9 a 21:9) a altura de
        /// referencia encolhe de 1080 ate 1024, dando mais espaco horizontal aos elementos de borda em
        /// vez de deixa-los fora de tela. Valores confirmados no MonoBehaviour real da cena Home
        /// (out/mb/PazuCore.PazuCoreAddressables.AFC.AFCCanvasScalerRangeToScreen.jsonl.gz, _file=level3):
        /// screenType=2 (VeryWide), propertyType=Height, ratio 2.0..2.164, altura 1106..1024.
        /// matchWidthOrHeight ja satura em 1.0 nessa faixa (regra screenType=1 para ratio 1.6..1.778),
        /// entao so a altura de referencia precisa variar aqui.
        /// </summary>
        static Vector2 ResolveReferenceResolution()
        {
            float ratio = Screen.width > 0 && Screen.height > 0
                ? (float)System.Math.Max(Screen.width, Screen.height) / System.Math.Min(Screen.width, Screen.height)
                : 16f / 9f;
            float height = ratio <= 2.0f ? ReferenceResolution.y : Mathf.Lerp(1106f, 1024f, Mathf.InverseLerp(2.0f, 2.1643f, ratio));
            return new Vector2(ReferenceResolution.x, height);
        }

        static void AddCanvas(GameObject go, bool isRoot)
        {
            var canvas = go.AddComponent<Canvas>();
            if (isRoot) canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            if (!isRoot) return;
            var scaler = go.AddComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = ResolveReferenceResolution();
            // Casa pela altura: a maioria dos nos da Home usa ancora central com deslocamento fixo em
            // pixel (herdado do original), entao em telas mais largas que a referencia isso da MAIS
            // espaco horizontal em vez de cortar os elementos das bordas.
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
            // Diagnostico temporario: confirma se o clique chega ao Unity antes de qualquer outra logica.
            string nodeName = n.name;
            b.onClick.AddListener(() => Debug.Log("BUTTON CLICK: " + nodeName));
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
            if (UnityEngine.Object.FindFirstObjectByType<EventSystem>() != null)
            {
                Debug.Log("EnsureEventSystem: ja existia um EventSystem");
                return;
            }
            var go = new GameObject("EventSystem", typeof(EventSystem));
#if ENABLE_INPUT_SYSTEM && !ENABLE_LEGACY_INPUT_MANAGER
            go.AddComponent<UnityEngine.InputSystem.UI.InputSystemUIInputModule>();
            Debug.Log("EnsureEventSystem: criado com InputSystemUIInputModule");
#else
            go.AddComponent<StandaloneInputModule>();
            Debug.Log("EnsureEventSystem: criado com StandaloneInputModule");
#endif
        }
    }
}
