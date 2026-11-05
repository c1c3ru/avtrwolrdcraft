using System.IO;
using System.Linq;
using AvatarWorld.Core.Audio;
using NUnit.Framework;
using UnityEngine;

namespace AvatarWorld.Core.Tests
{
    /// <summary>Registro de sons exportado por tools/import_audio_original.py (Resources/Sound/sound-registry.json).</summary>
    public class SoundRegistryTests
    {
        static SoundRegistry _registry;
        static string ResourcesDir { get { return Path.Combine(Application.dataPath, "Resources"); } }

        static SoundRegistry Registry
        {
            get
            {
                if (_registry == null)
                {
                    string path = Path.Combine(ResourcesDir, "Sound/sound-registry.json");
                    Assert.IsTrue(File.Exists(path), path);
                    _registry = new SoundRegistry(JsonUtility.FromJson<SoundRegistryData>(File.ReadAllText(path)));
                }
                return _registry;
            }
        }

        [Test]
        public void RegistryHasEveryOriginalSound()
        {
            Assert.AreEqual(2781, Registry.Count);
        }

        [Test]
        public void EveryEntryHasItsAudioFileOnDisk()
        {
            foreach (var e in Registry.All)
            {
                string ext = e.format == "flac-of-decoded-pcm" ? ".flac" : ".ogg";
                string file = Path.Combine(ResourcesDir, e.resourcePath + ext);
                Assert.IsTrue(File.Exists(file), e.name + " -> " + file);
                Assert.Greater(new FileInfo(file).Length, 0L, e.name);
            }
        }

        [Test]
        public void FormatCountsMatchTheImport()
        {
            Assert.AreEqual(2654, Registry.All.Count(e => e.format == "original-vorbis"));
            Assert.AreEqual(127, Registry.All.Count(e => e.format == "flac-of-decoded-pcm"));
        }

        [Test]
        public void CategoriesMatchTheOriginalRegistryFolders()
        {
            Assert.AreEqual(2514, Registry.All.Count(e => e.path.StartsWith("Sound/SFX/")));
            Assert.AreEqual(174, Registry.All.Count(e => e.path.StartsWith("Sound/Music/")));
            Assert.AreEqual(80, Registry.All.Count(e => e.path.StartsWith("Sound/Ambience/")));
            Assert.AreEqual(13, Registry.All.Count(e => e.path.StartsWith("PazuCore/Sound/")));
        }

        [Test]
        public void LookupIsCaseInsensitive()
        {
            SoundEntry e;
            Assert.IsTrue(Registry.TryGet("hotel_helipad_loop", out e));
            Assert.AreEqual("Hotel_Helipad_Loop", e.name);
        }

        [Test]
        public void ApostropheNameIsKeptAsInTheOriginal()
        {
            SoundEntry e;
            Assert.IsTrue(Registry.TryGet("Avatar_Doesn't_Fit_And_Drop", out e));
            Assert.IsFalse(e.resourcePath.Contains("'"));
        }

        [Test]
        public void HandlerNamesWithPairsExtensionsAndFoldersResolve()
        {
            var tokens = SoundRegistry.Tokens("Candle_On_2^Candle_Off_2").ToArray();
            CollectionAssert.AreEqual(new[] { "Candle_On_2", "Candle_Off_2" }, tokens);
            CollectionAssert.AreEqual(new[] { "Ball_Hit_Net" }, SoundRegistry.Tokens("Ball_Hit_Net.wav").ToArray());
            CollectionAssert.AreEqual(new[] { "Avatar_Tire_Inflator_Inflating_Loop" },
                SoundRegistry.Tokens("Cars_Garage/Avatar_Tire_Inflator_Inflating_Loop.wav").ToArray());
            Assert.AreEqual(2, Registry.Resolve("Candle_On_2^Candle_Off_2").Count());
            Assert.AreEqual(1, Registry.Resolve("Ball_Hit_Net.wav").Count());
        }

        [Test]
        public void UnknownAndEmptyNamesResolveToNothing()
        {
            Assert.AreEqual(0, Registry.Resolve("DoesNotExist").Count());
            Assert.AreEqual(0, Registry.Resolve("").Count());
            Assert.AreEqual(0, Registry.Resolve(null).Count());
        }
    }
}
