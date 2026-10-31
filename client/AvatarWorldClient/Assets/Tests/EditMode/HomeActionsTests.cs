using System;
using System.Collections.Generic;
using System.IO;
using AvatarWorld.Core.Economy;
using AvatarWorld.Runtime;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace AvatarWorld.Core.Tests
{
    public class HomeActionsTests
    {
        GameObject root;
        HomeActions actions;
        PlayerState state;
        SaveStore saves;
        string path;
        bool played, paused, hadSound;
        int sound;
        List<GameObject> objects;

        [SetUp] public void Setup()
        {
            paused = AudioListener.pause;
            hadSound = PlayerPrefs.HasKey("home.sound.enabled");
            sound = PlayerPrefs.GetInt("home.sound.enabled", 1);
            path = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".json");
            saves = new SaveStore(path);
            state = PlayerState.CreateNew(75);
            root = new GameObject("TestHome");
            var desc = JsonUtility.FromJson<SceneDescription>(Resources.Load<TextAsset>("HomeSlice/level3").text);
            objects = UiSceneBuilder.Build(desc, null, parent: root.transform);
            actions = root.AddComponent<HomeActions>();
            actions.Initialize(objects, saves, state, () => played = true);
        }

        [TearDown] public void Cleanup()
        {
            Object.DestroyImmediate(root);
            if (File.Exists(path)) File.Delete(path);
            AudioListener.pause = paused;
            if (hadSound) PlayerPrefs.SetInt("home.sound.enabled", sound);
            else PlayerPrefs.DeleteKey("home.sound.enabled");
            PlayerPrefs.Save();
        }

        Button Button(string name) => Array.Find(root.GetComponentsInChildren<Button>(true), b => b.name == name && b.gameObject.activeInHierarchy);

        [Test] public void PlayUsesExistingGameplayAndClosesPanel()
        {
            actions.Open("AccountButton");
            Button("PlayButton").onClick.Invoke();
            Assert.IsTrue(played);
            Assert.IsNull(actions.CurrentPage);
        }

        [Test] public void ProfileSavesLiveGameplayStateInsteadOfStaleCopy()
        {
            new LocalStoreService(state).Earn(10, "test gameplay");
            actions.Open("AccountButton");
            Button("Salvar progresso").onClick.Invoke();
            Assert.AreEqual(85, saves.LoadOrCreate(0).PazuCurrency);
            Assert.AreEqual(1, saves.LoadOrCreate(0).Ledger.Count);
        }

        [Test] public void UnsupportedFeaturesRemainDisabledAndPending()
        {
            Assert.AreEqual(4, actions.BoundButtonCount);
            Assert.AreEqual(35, actions.PendingButtons.Count);
            Assert.IsFalse(Button("ShopButton").interactable);
            Assert.IsFalse(objects.Find(o => o.name == "MultiplayerCanvas").activeSelf);
            actions.Open("ShopButton");
            Assert.IsNull(actions.CurrentPage);
        }

        [Test] public void SettingsMutePersistsAndCanBeReversed()
        {
            PlayerPrefs.SetInt("home.sound.enabled", 1);
            actions.Open("SettingsButton");
            Button("Som: ligado").onClick.Invoke();
            Assert.IsTrue(AudioListener.pause);
            Assert.AreEqual(0, PlayerPrefs.GetInt("home.sound.enabled"));
            Button("Som: desligado").onClick.Invoke();
            Assert.IsFalse(AudioListener.pause);
            Assert.AreEqual(1, PlayerPrefs.GetInt("home.sound.enabled"));
        }

        [Test] public void ProgressReadsCompletedChallengesFromSharedState()
        {
            state.CompletedChallenges.Add("letter-a");
            actions.Open("AchievementsAppWidget");
            Assert.IsTrue(Array.Exists(root.GetComponentsInChildren<Text>(), t => t.text == "letter-a"));
            Button("Voltar à home").onClick.Invoke();
            Assert.IsNull(actions.CurrentPage);
        }
    }
}
