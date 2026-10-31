using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AvatarWorld.Runtime
{
    /// <summary>Layout do cliente offline; nao reproduz os scripts AFC do original.</summary>
    public static class HomeLayout
    {
        public static void Apply(IReadOnlyList<GameObject> objects)
        {
            foreach (var go in objects)
            {
                var canvas = go.GetComponent<Canvas>();
                if (canvas == null || !canvas.isRootCanvas) continue;

                bool background = go.name == "CanvasBackground";
                // Ordem explicita: a ordem de exportacao coloca o fundo por ultimo.
                canvas.sortingOrder = background ? -1 : 0;
                var scaler = go.GetComponent<CanvasScaler>();
                if (scaler != null)
                {
                    // Referencia confirmada em out/mb/UnityEngine.UI.CanvasScaler.
                    scaler.referenceResolution = new Vector2(2048f, 1024f);
                    // Mantem toda a area de controles visivel em telas mais estreitas.
                    scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
                }
                if (!background) continue;

                var raycaster = go.GetComponent<GraphicRaycaster>();
                if (raycaster != null) raycaster.enabled = false;
                foreach (var image in go.GetComponentsInChildren<Image>(true))
                    image.raycastTarget = false;

                var art = go.transform.Find("Background");
                if (art == null) continue;
                var rect = (RectTransform)art;
                rect.localScale = Vector3.one;
                rect.pivot = new Vector2(0.5f, 0.5f);
                rect.anchoredPosition = Vector2.zero;
                var imageComponent = art.GetComponent<Image>();
                if (imageComponent == null) continue;
                // Envelope cobre a tela sem deformar a arte, inclusive apos resize.
                var fitter = art.GetComponent<AspectRatioFitter>();
                if (fitter == null) fitter = art.gameObject.AddComponent<AspectRatioFitter>();
                fitter.aspectRatio = imageComponent.sprite != null
                    ? imageComponent.sprite.rect.width / imageComponent.sprite.rect.height : 2f;
                fitter.aspectMode = AspectRatioFitter.AspectMode.EnvelopeParent;
            }

            // Os botoes exportados podem ter a imagem num filho chamado Graphic.
            foreach (var go in objects)
            {
                var button = go.GetComponent<Button>();
                if (button == null || button.targetGraphic != null) continue;
                var graphic = go.transform.Find("Graphic");
                if (graphic != null) button.targetGraphic = graphic.GetComponent<Graphic>();
            }
        }
    }
}
