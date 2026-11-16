using AvatarWorld.Runtime;
using NUnit.Framework;
using UnityEngine;

namespace AvatarWorld.Core.Tests
{
    public class MapSpineLayerTests
    {
        [Test]
        public void MaterialUsesStraightAlphaInput_SoTransparentPixelsDoNotShowAsAWhiteRectangle()
        {
            var shader = Shader.Find("Spine/Skeleton");
            Assert.IsNotNull(shader, "shader Spine/Skeleton");
            var texture = new Texture2D(2, 2);
            var material = MapSpineLayer.CreateMaterial(shader, texture, "Sun_Moon");
            try
            {
                Assert.AreEqual("Sun_Moon", material.name);
                Assert.AreSame(texture, material.mainTexture);
                Assert.AreEqual(1f, material.GetFloat("_StraightAlphaInput"), "o atlas do original nao e pre-multiplicado");
                Assert.IsTrue(material.IsKeywordEnabled("_STRAIGHT_ALPHA_INPUT"));
            }
            finally
            {
                Object.DestroyImmediate(material);
                Object.DestroyImmediate(texture);
            }
        }
    }
}
