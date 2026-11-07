using UnityEngine;
using UnityEngine.UI;

namespace AvatarWorld.Runtime
{
    /// <summary>Exibe a composição de loading do jogo durante a inicialização local da Home.</summary>
    public sealed class LoadingScreenView : MonoBehaviour
    {
        public static LoadingScreenView Show()
        {
            var root = new GameObject("LoadingScreen", typeof(RectTransform), typeof(Canvas),
                typeof(CanvasScaler), typeof(GraphicRaycaster), typeof(LoadingScreenView));
            var canvas = root.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.overrideSorting = true;
            canvas.sortingOrder = 5000;
            var scaler = root.GetComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1600, 720);
            scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;

            var background = new GameObject("OrangeBackground", typeof(RectTransform), typeof(Image));
            background.transform.SetParent(root.transform, false);
            Stretch((RectTransform)background.transform, Vector2.zero, Vector2.one);
            background.GetComponent<Image>().color = new Color32(255, 201, 0, 255);

            AddArtwork(root.transform, "MascotAndCat", "Loading/loading_mascot",
                new Vector2(.5f, .52f), new Vector2(.5f, .52f), new Vector2(305, 390));
            AddArtwork(root.transform, "Clock", "Loading/loading_clock",
                new Vector2(.94f, .13f), new Vector2(.94f, .13f), new Vector2(170, 150));
            return root.GetComponent<LoadingScreenView>();
        }

        public void Hide() => Destroy(gameObject);

        static void AddArtwork(Transform parent, string name, string resource, Vector2 anchorMin,
            Vector2 anchorMax, Vector2 size)
        {
            var go = new GameObject(name, typeof(RectTransform), typeof(Image));
            go.transform.SetParent(parent, false);
            var rect = (RectTransform)go.transform;
            rect.anchorMin = anchorMin;
            rect.anchorMax = anchorMax;
            rect.pivot = new Vector2(.5f, .5f);
            rect.anchoredPosition = Vector2.zero;
            rect.sizeDelta = size;
            var image = go.GetComponent<Image>();
            image.sprite = Resources.Load<Sprite>(resource);
            image.preserveAspect = true;
            image.raycastTarget = false;
        }

        static void Stretch(RectTransform rect, Vector2 min, Vector2 max)
        {
            rect.anchorMin = min;
            rect.anchorMax = max;
            rect.offsetMin = rect.offsetMax = Vector2.zero;
        }
    }
}
