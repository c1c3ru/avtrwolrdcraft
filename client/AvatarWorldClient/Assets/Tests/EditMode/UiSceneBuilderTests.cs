using System;
using System.Collections.Generic;
using AvatarWorld.Runtime;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace AvatarWorld.Core.Tests
{
    public class UiSceneBuilderTests
    {
        readonly List<GameObject> _roots = new List<GameObject>();

        [TearDown]
        public void TearDown()
        {
            foreach (var r in _roots) if (r != null) UnityEngine.Object.DestroyImmediate(r);
            _roots.Clear();
        }

        static NodeDescription Node(int id, int parent, string name, bool hasRect = true) =>
            new NodeDescription { id = id, parent = parent, name = name, hasRect = hasRect };

        List<GameObject> Build(SceneDescription d, Func<string, Sprite> loader = null, IDictionary<string, Action> actions = null)
        {
            var objs = UiSceneBuilder.Build(d, loader, actions);
            _roots.Add(objs[0]);
            return objs;
        }

        [Test]
        public void Build_ReproducesHierarchyInOrder()
        {
            var d = new SceneDescription();
            d.nodes.Add(Node(0, -1, "Canvas"));
            d.nodes.Add(Node(1, 0, "Header"));
            d.nodes.Add(Node(2, 1, "Title"));

            var objs = Build(d);

            Assert.AreEqual(3, objs.Count);
            Assert.AreSame(objs[0].transform, objs[1].transform.parent);
            Assert.AreSame(objs[1].transform, objs[2].transform.parent);
            Assert.AreEqual("Title", objs[2].name);
        }

        [Test]
        public void Build_AppliesRectTransformValues()
        {
            var d = new SceneDescription();
            d.nodes.Add(Node(0, -1, "Root"));
            var n = Node(1, 0, "Panel");
            n.anchorMin = new Vector2(0.1f, 0.2f);
            n.anchorMax = new Vector2(0.9f, 0.8f);
            n.pivot = new Vector2(0f, 1f);
            n.anchoredPosition = new Vector2(12f, -34f);
            n.sizeDelta = new Vector2(100f, 50f);
            d.nodes.Add(n);

            var rt = (RectTransform)Build(d)[1].transform;

            Assert.AreEqual(new Vector2(0.1f, 0.2f), rt.anchorMin);
            Assert.AreEqual(new Vector2(0.9f, 0.8f), rt.anchorMax);
            Assert.AreEqual(new Vector2(0f, 1f), rt.pivot);
            Assert.AreEqual(new Vector2(12f, -34f), rt.anchoredPosition);
            Assert.AreEqual(new Vector2(100f, 50f), rt.sizeDelta);
        }

        [Test]
        public void Build_ImageGetsSpriteColorAndType()
        {
            var tex = new Texture2D(4, 4);
            var sprite = Sprite.Create(tex, new Rect(0, 0, 4, 4), Vector2.zero);
            var d = new SceneDescription();
            var n = Node(0, -1, "Bg");
            n.hasImage = true;
            n.image = new ImageDescription { sprite = "bg_key", color = new Color(1f, 0.5f, 0.25f, 1f), imageType = 1, raycastTarget = false };
            d.nodes.Add(n);
            string asked = null;

            var img = Build(d, key => { asked = key; return sprite; })[0].GetComponent<Image>();

            Assert.AreEqual("bg_key", asked);
            Assert.AreSame(sprite, img.sprite);
            Assert.AreEqual(new Color(1f, 0.5f, 0.25f, 1f), img.color);
            Assert.AreEqual(Image.Type.Sliced, img.type);
            Assert.IsFalse(img.raycastTarget);
            UnityEngine.Object.DestroyImmediate(sprite);
            UnityEngine.Object.DestroyImmediate(tex);
        }

        [Test]
        public void Build_InactiveNodesAreDisabledButChildrenStillBuilt()
        {
            var d = new SceneDescription();
            d.nodes.Add(Node(0, -1, "Root"));
            var off = Node(1, 0, "Hidden");
            off.active = false;
            d.nodes.Add(off);
            d.nodes.Add(Node(2, 1, "Child"));

            var objs = Build(d);

            Assert.IsTrue(objs[0].activeSelf);
            Assert.IsFalse(objs[1].activeSelf);
            Assert.IsTrue(objs[2].activeSelf);
            Assert.IsFalse(objs[2].activeInHierarchy);
        }

        [Test]
        public void Build_ButtonClickRunsActionByObjectName()
        {
            var d = new SceneDescription();
            d.nodes.Add(Node(0, -1, "Root"));
            var n = Node(1, 0, "PlayButton");
            n.hasImage = true;
            n.image = new ImageDescription();
            n.hasButton = true;
            n.button = new ButtonDescription();
            d.nodes.Add(n);
            int clicks = 0;

            var btn = Build(d, null, new Dictionary<string, Action> { { "PlayButton", () => clicks++ } })[1].GetComponent<Button>();
            btn.onClick.Invoke();

            Assert.AreEqual(1, clicks);
            Assert.IsNotNull(btn.targetGraphic);
        }

        [Test]
        public void Build_ButtonFallsBackToMethodName()
        {
            var d = new SceneDescription();
            d.nodes.Add(Node(0, -1, "Root"));
            var n = Node(1, 0, "SomeButton");
            n.hasButton = true;
            n.button = new ButtonDescription();
            n.button.onClick.Add(new ClickCall { method = "OnShopClick", type = "X" });
            d.nodes.Add(n);
            int clicks = 0;

            var btn = Build(d, null, new Dictionary<string, Action> { { "OnShopClick", () => clicks++ } })[1].GetComponent<Button>();
            btn.onClick.Invoke();

            Assert.AreEqual(1, clicks);
        }

        [Test]
        public void Build_ParentReferencingFutureNodeThrows()
        {
            var d = new SceneDescription();
            d.nodes.Add(Node(0, 5, "Broken"));
            Assert.Throws<InvalidOperationException>(() => UiSceneBuilder.Build(d, null));
        }

        [Test]
        public void SceneDescription_RoundTripsThroughJsonUtility()
        {
            var d = new SceneDescription { name = "level3" };
            var n = Node(0, -1, "Canvas");
            n.isCanvas = true;
            n.anchorMax = Vector2.one;
            n.ignoredComponents.Add("AFCScaleToScreen");
            d.nodes.Add(n);

            var back = JsonUtility.FromJson<SceneDescription>(JsonUtility.ToJson(d));

            Assert.AreEqual("level3", back.name);
            Assert.IsTrue(back.nodes[0].isCanvas);
            Assert.AreEqual(Vector2.one, back.nodes[0].anchorMax);
            Assert.AreEqual("AFCScaleToScreen", back.nodes[0].ignoredComponents[0]);
        }
    }
}
