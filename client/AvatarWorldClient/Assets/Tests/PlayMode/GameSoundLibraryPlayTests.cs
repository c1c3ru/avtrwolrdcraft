using System.Collections;
using System.Linq;
using AvatarWorld.Core.Audio;
using AvatarWorld.Runtime;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace AvatarWorld.PlayModeTests
{
    /// <summary>Sons reais do original carregados pelo Unity pelo caminho do registro.</summary>
    public class GameSoundLibraryPlayTests
    {
        [UnityTest]
        public IEnumerator SampledClipsLoadWithTheOriginalDuration()
        {
            yield return null;
            var registry = GameSoundLibrary.Registry;
            Assert.IsNotNull(registry);
            var all = registry.All.OrderBy(e => e.name, System.StringComparer.OrdinalIgnoreCase).ToList();
            var sample = all.Where((e, i) => i % 12 == 0).Concat(all.Where(e => e.format == "flac-of-decoded-pcm").Take(20)).Distinct().ToList();
            Assert.Greater(sample.Count, 200);
            int checkedClips = 0;
            foreach (var e in sample)
            {
                var clip = Resources.Load<AudioClip>(e.resourcePath);
                Assert.IsNotNull(clip, e.resourcePath);
                Assert.AreEqual(e.length, clip.length, 0.1f, e.name + " duracao");
                Assert.AreEqual(e.channels, clip.channels, e.name + " canais");
                checkedClips++;
                Resources.UnloadAsset(clip);
                if (checkedClips % 40 == 0) yield return null;
            }
        }

        [UnityTest]
        public IEnumerator HandlerNamesResolveToClips()
        {
            yield return null;
            Assert.IsNotNull(GameSoundLibrary.GetClip("Ball_Hit_Net.wav"));
            Assert.IsNotNull(GameSoundLibrary.GetClip("Candle_On_2^Candle_Off_2"));
            Assert.IsNotNull(GameSoundLibrary.GetClip("Cars_Garage/Avatar_Tire_Inflator_Inflating_Loop.wav"));
            Assert.IsNull(GameSoundLibrary.GetClip("DoesNotExist"));
        }

        [UnityTest]
        public IEnumerator MusicIsStreamedAndFlacIsPcm()
        {
            yield return null;
            var music = GameSoundLibrary.Registry.All.First(e => e.path.StartsWith("Sound/Music/"));
            var musicClip = Resources.Load<AudioClip>(music.resourcePath);
            Assert.IsNotNull(musicClip);
            Assert.AreEqual(AudioClipLoadType.Streaming, musicClip.loadType, music.name);
            var flac = GameSoundLibrary.Registry.All.First(e => e.format == "flac-of-decoded-pcm");
            var flacClip = Resources.Load<AudioClip>(flac.resourcePath);
            Assert.IsNotNull(flacClip, flac.resourcePath);
            Assert.AreEqual(flac.channels, flacClip.channels);
        }
    }
}
