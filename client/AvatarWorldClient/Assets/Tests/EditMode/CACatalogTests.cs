using System.IO;
using AvatarWorld.Core.Avatar;
using NUnit.Framework;
using UnityEngine;

namespace AvatarWorld.Core.Tests
{
    /// <summary>Catalogo exportado por tools/export_ca_catalog.py (Resources/ContextualAnimations/ca-catalog.json).</summary>
    public class CACatalogTests
    {
        static CACatalog _catalog;

        static CACatalog Catalog
        {
            get
            {
                if (_catalog == null)
                {
                    string path = Path.Combine(Application.dataPath, "Resources/ContextualAnimations/ca-catalog.json");
                    Assert.IsTrue(File.Exists(path), path);
                    _catalog = new CACatalog(JsonUtility.FromJson<CACatalogData>(File.ReadAllText(path)));
                }
                return _catalog;
            }
        }

        [Test]
        public void CatalogHasTheExportedCounts()
        {
            Assert.AreEqual(974, Catalog.HandlerCount);
            Assert.AreEqual(3150, Catalog.ConfigCount);
        }

        [Test]
        public void KnownHandlerResolvesToTheOriginalAnimationName()
        {
            var h = Catalog.Find("BrokenWallWithBrush", 1);
            Assert.IsNotNull(h);
            Assert.AreEqual("Paint_Brush", h.folderName);
            Assert.AreEqual("CA/Paint_Brush/Paint_Strokes", h.AnimationName(0));
        }

        [Test]
        public void PetHandlersResolveWithoutTheCAPrefix()
        {
            int pets = 0;
            foreach (var spine in new[] { 3, 4, 14 })
                foreach (var h in Catalog.ForSpineType(spine))
                    for (int i = 0; i < h.configs.Length; i++)
                    {
                        pets++;
                        if (!h.configs[i].isNameFullAnimationName) Assert.IsFalse(h.AnimationName(i).StartsWith("CA/"), h.name);
                    }
            Assert.Greater(pets, 0);
        }

        [Test]
        public void HumanHandlersResolveWithTheCAPrefixUnlessTheNameIsFull()
        {
            foreach (var spine in new[] { 1, 2, 13 })
                foreach (var h in Catalog.ForSpineType(spine))
                    for (int i = 0; i < h.configs.Length; i++)
                        if (!h.configs[i].isNameFullAnimationName)
                            Assert.IsTrue(h.AnimationName(i).StartsWith("CA/"), h.name);
        }

        [Test]
        public void UnknownHandlerIsNull()
        {
            Assert.IsNull(Catalog.Find("DoesNotExist", 1));
        }

        [Test]
        public void SameNameInAnotherSpineTypeIsAnotherEntry()
        {
            Assert.IsNull(Catalog.Find("BrokenWallWithBrush", 4));
        }
    }
}
