using AvatarWorld.Core.Localization;
using AvatarWorld.Core.World;
using AvatarWorld.Runtime;
using NUnit.Framework;
using UnityEngine;

namespace AvatarWorld.Core.Tests
{
    public class HolidayModeTests
    {
        [Test] public void HolidayWorldsAreTheFourReadFromTheOriginalStaticArray()
        {
            CollectionAssert.AreEqual(new[] { 1, 3, 4, 6 }, HolidayMode.Worlds);
            Assert.IsTrue(HolidayMode.AppliesTo(HolidayMode.World));
            Assert.IsTrue(HolidayMode.AppliesTo(HolidayMode.StarDustCity));
            Assert.IsTrue(HolidayMode.AppliesTo(HolidayMode.Countryside));
            Assert.IsTrue(HolidayMode.AppliesTo(HolidayMode.College));
            Assert.IsFalse(HolidayMode.AppliesTo(HolidayMode.Vacation));
            Assert.IsFalse(HolidayMode.AppliesTo(HolidayMode.SnowyMountain));
        }

        [Test] public void HolidayForcesHalloweenOnlyInTheHolidayWorlds()
        {
            Assert.AreEqual(8, HolidayMode.HalloweenWeather);
            Assert.AreEqual(8, HolidayMode.WeatherFor(HolidayMode.College, WorldWeather.Rain, true));
            Assert.AreEqual(WorldWeather.Rain, HolidayMode.WeatherFor(HolidayMode.College, WorldWeather.Rain, false), "desligado: clima salvo");
            Assert.AreEqual(WorldWeather.Snow, HolidayMode.WeatherFor(HolidayMode.SnowyMountain, WorldWeather.Snow, true), "montanha nao participa");
            Assert.AreEqual(WorldWeather.Clear, HolidayMode.WeatherFor(HolidayMode.Vacation, WorldWeather.Clear, true), "resort nao participa");
        }

        [Test] public void HalloweenIsASupportedWeatherButXmasSnowIsNot()
        {
            Assert.IsTrue(WorldWeather.IsSupported(WorldWeather.Halloween));
            Assert.IsFalse(WorldWeather.IsSupported(7));
            Assert.AreEqual(HolidayMode.HalloweenWeather, WorldWeather.Halloween);
        }

        [Test] public void SkyHasAHalloweenConfigWithAllPhases()
        {
            var file = JsonUtility.FromJson<SkyFile>(Resources.Load<TextAsset>("WorldSlice/sky").text);
            Assert.IsNotNull(file.For(WorldWeather.Halloween), "sky.json precisa da config do clima 8 (tools/export_sky.py)");
            foreach (var weather in new[] { WorldWeather.Clear, WorldWeather.Rain, WorldWeather.Snow, WorldWeather.Halloween })
                Assert.IsNotNull(file.For(weather), "clima " + weather);
        }

        [Test] public void StoreDefaultsToOffAndRemembersTheChoice()
        {
            bool had = PlayerPrefs.HasKey(HolidayModeStore.PrefsKey);
            int old = PlayerPrefs.GetInt(HolidayModeStore.PrefsKey, 0);
            try
            {
                PlayerPrefs.DeleteKey(HolidayModeStore.PrefsKey);
                Assert.IsFalse(HolidayModeStore.IsOn);
                HolidayModeStore.IsOn = true;
                Assert.IsTrue(HolidayModeStore.IsOn);
                HolidayModeStore.IsOn = false;
                Assert.IsFalse(HolidayModeStore.IsOn);
            }
            finally
            {
                if (had) PlayerPrefs.SetInt(HolidayModeStore.PrefsKey, old); else PlayerPrefs.DeleteKey(HolidayModeStore.PrefsKey);
                PlayerPrefs.Save();
            }
        }

        [Test] public void HolidayTextsExistInEveryLanguage()
        {
            foreach (var key in new[] { "holiday.title", "holiday.on", "holiday.off" })
                foreach (Language l in System.Enum.GetValues(typeof(Language)))
                    Assert.IsFalse(string.IsNullOrWhiteSpace(Loc.Get(key, l)), key + " / " + l);
        }
    }
}
