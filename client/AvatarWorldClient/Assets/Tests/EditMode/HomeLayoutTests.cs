using System.Collections.Generic;
using AvatarWorld.Runtime;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace AvatarWorld.Core.Tests
{
    public class HomeLayoutTests
    {
        List<GameObject> objects;

        [TearDown]
        public void TearDown()
        {
            if (objects == null) return;
            foreach (var go in objects)
                if (go != null && go.transform.parent == null) Object.DestroyImmediate(go);
        }

        void BuildHome()
        {
            var json = Resources.Load<TextAsset>("HomeSlice/level3");
            Assert.IsNotNull(json);
            objects = UiSceneBuilder.Build(JsonUtility.FromJson<SceneDescription>(json.text),
                key => Resources.Load<Sprite>("HomeSlice/sprites/" + key));
            HomeLayout.Apply(objects);
        }

        GameObject Find(string name) => objects.Find(go => go.name == name);

        [Test]
        public void Home_BackgroundStaysBehindControlsAndCannotInterceptClicks()
        {
            BuildHome();
            var background = Find("CanvasBackground");
            Assert.Less(background.GetComponent<Canvas>().sortingOrder,
                Find("Canvas").GetComponent<Canvas>().sortingOrder);
            Assert.IsFalse(background.GetComponent<GraphicRaycaster>().enabled);
            foreach (var graphic in background.GetComponentsInChildren<Image>(true))
                Assert.IsFalse(graphic.raycastTarget);
            Assert.IsTrue(Find("PlayButton").activeInHierarchy);
            Assert.IsNotNull(Find("PlayButton").GetComponent<Button>().targetGraphic);
            Assert.IsNotNull(Find("ShopButton").GetComponent<Button>().targetGraphic);
        }

        [TestCase(1600f, 720f)]
        [TestCase(1920f, 1080f)]
        [TestCase(2400f, 1080f)]
        [TestCase(1024f, 768f)]
        public void Background_CoversViewportWithoutDistortion(float width, float height)
        {
            BuildHome();
            var background = Find("CanvasBackground");
            var art = (RectTransform)background.transform.Find("Background");
            var fitter = art.GetComponent<AspectRatioFitter>();
            Assert.AreEqual(AspectRatioFitter.AspectMode.EnvelopeParent, fitter.aspectMode);
            // Usa um pai de tamanho controlado para exercitar o fitter no EditMode.
            var viewport = new GameObject("TestViewport", typeof(RectTransform));
            objects.Add(viewport);
            var rect = (RectTransform)viewport.transform;
            rect.sizeDelta = new Vector2(width, height);
            art.SetParent(rect, false);
            fitter.enabled = false;
            fitter.enabled = true;
            Canvas.ForceUpdateCanvases();
            Assert.GreaterOrEqual(art.rect.width + 0.1f, width);
            Assert.GreaterOrEqual(art.rect.height + 0.1f, height);
            Assert.That(art.rect.width / art.rect.height, Is.EqualTo(fitter.aspectRatio).Within(0.001f));
        }

        [Test]
        public void Home_UsesExportedReferenceResolutionAndCanBeAppliedTwice()
        {
            BuildHome();
            HomeLayout.Apply(objects);
            foreach (var name in new[] { "Canvas", "CanvasBackground" })
            {
                var scaler = Find(name).GetComponent<CanvasScaler>();
                Assert.AreEqual(new Vector2(2048f, 1024f), scaler.referenceResolution);
                Assert.AreEqual(CanvasScaler.ScreenMatchMode.MatchWidthOrHeight, scaler.screenMatchMode);
                Assert.AreEqual(1f, scaler.matchWidthOrHeight);
            }
            Assert.AreEqual(1, Find("CanvasBackground").transform.Find("Background")
                .GetComponents<AspectRatioFitter>().Length);
        }

        [TestCase(1f, 0.7f, 1024f)]
        [TestCase(1.1666667f, 0.85f, 1024f)]
        [TestCase(1.6f, 0.5f, 1024f)]
        [TestCase(1.688889f, 0.75f, 1024f)]
        [TestCase(2f, 1f, 1106f)]
        [TestCase(2.0821255f, 1f, 1065f)]
        [TestCase(2.164251f, 1f, 1024f)]
        public void Home_ReproducesOriginalAdaptiveScalerRanges(float ratio, float match, float height)
        {
            var go = new GameObject("ScalerTest", typeof(RectTransform), typeof(CanvasScaler));
            objects = new List<GameObject> { go };
            var scaler = go.GetComponent<CanvasScaler>();

            HomeLayout.ConfigureScaler(scaler, ratio, true);

            Assert.AreEqual(CanvasScaler.ScaleMode.ScaleWithScreenSize, scaler.uiScaleMode);
            Assert.AreEqual(CanvasScaler.ScreenMatchMode.MatchWidthOrHeight, scaler.screenMatchMode);
            Assert.That(scaler.matchWidthOrHeight, Is.EqualTo(match).Within(0.0001f));
            Assert.That(scaler.referenceResolution.x, Is.EqualTo(2048f).Within(0.0001f));
            Assert.That(scaler.referenceResolution.y, Is.EqualTo(height).Within(0.001f));
        }
    }
}
