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
        bool played, coins, paused, hadSound;
        int sound, sfx, music;
        bool hadSfx, hadMusic;
        List<GameObject> objects;

        [SetUp] public void Setup()
        {
            paused = AudioListener.pause;
            hadSound = PlayerPrefs.HasKey("home.sound.enabled");
            sound = PlayerPrefs.GetInt("home.sound.enabled", 1);
            hadSfx = PlayerPrefs.HasKey("home.sfx.enabled");
            sfx = PlayerPrefs.GetInt("home.sfx.enabled", 1);
            hadMusic = PlayerPrefs.HasKey("home.music.enabled");
            music = PlayerPrefs.GetInt("home.music.enabled", 1);
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
            if (hadSfx) PlayerPrefs.SetInt("home.sfx.enabled", sfx);
            else PlayerPrefs.DeleteKey("home.sfx.enabled");
            if (hadMusic) PlayerPrefs.SetInt("home.music.enabled", music);
            else PlayerPrefs.DeleteKey("home.music.enabled");
            UiSound.SetMuted(sfx == 0);
            BackgroundMusic.SetMuted(music == 0);
            PlayerPrefs.Save();
        }

        Button Button(string name) => Array.Find(root.GetComponentsInChildren<Button>(true), b => b.name == name && b.gameObject.activeInHierarchy);

        [Test] public void PlayOpensGameplayAndHidesHome()
        {
            actions.Open("AccountButton");
            Button("PlayButton").onClick.Invoke();
            Assert.IsTrue(played);
            Assert.IsNull(actions.CurrentPage);
            Assert.IsTrue(Array.Exists(objects.ToArray(), go =>
            {
                var canvas = go.GetComponent<Canvas>();
                return canvas != null && canvas.isRootCanvas && !canvas.enabled;
            }), "A Home precisa sair da frente ao entrar no jogo.");
            actions.ReturnFromGameplay();
            Assert.IsNull(Button("Desafio: ganhar moedas"), "Entradas improvisadas saíram da Home: desafios ficam na loja (Moedas AW).");
            Assert.IsNull(Button("Meu avatar"), "O editor de avatar abre pelo avatar+ do mapa (slots).");
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
            Assert.AreEqual(6, actions.BoundButtonCount);
            Assert.AreEqual(33, actions.PendingButtons.Count);
            Assert.IsFalse(Button("ShopButton").interactable);
            Assert.IsFalse(objects.Find(o => o.name == "MultiplayerCanvas").activeSelf);
            actions.Open("ShopButton");
            Assert.IsNull(actions.CurrentPage);
        }

        [Test] public void ShopButtonOpensTheStoreWhenProvided()
        {
            var shopRoot = new GameObject("TestHomeShop");
            try
            {
                var desc = JsonUtility.FromJson<SceneDescription>(Resources.Load<TextAsset>("HomeSlice/level3").text);
                var shopObjects = UiSceneBuilder.Build(desc, null, parent: shopRoot.transform);
                var shopActions = shopRoot.AddComponent<HomeActions>();
                bool opened = false;
                shopActions.Initialize(shopObjects, saves, state, () => { }, null, () => opened = true);
                var shop = Array.Find(shopRoot.GetComponentsInChildren<Button>(true), b => b.name == "ShopButton");
                Assert.IsTrue(shop.interactable, "Loja liberada quando a tela existe");
                shopActions.Open("ShopButton");
                Assert.IsTrue(opened);
                Assert.IsFalse(shopActions.PendingButtons.Contains("ShopButton"));
            }
            finally { Object.DestroyImmediate(shopRoot); }
        }

        [Test] public void SettingsSoundAndMusicCanBeToggledIndependently()
        {
            PlayerPrefs.SetInt("home.sfx.enabled", 1);
            PlayerPrefs.SetInt("home.music.enabled", 1);
            actions.Open("SettingsButton");
            Assert.AreEqual("Configurações", actions.CurrentPage);
            Assert.IsTrue(objects.Find(o => o.name == "SettingsMenu").activeSelf, "O menu original deve abrir, não um painel próprio.");
            Button("SFX").onClick.Invoke();
            Assert.AreEqual(0, PlayerPrefs.GetInt("home.sfx.enabled"));
            Assert.IsTrue(Button("SFX").transform.Find("Off").gameObject.activeSelf, "Ícone desligado do original");
            Assert.AreEqual(1, PlayerPrefs.GetInt("home.music.enabled"), "Mutar efeitos não deve silenciar a música.");
            Assert.IsTrue(UiSound.IsMuted);
            Assert.IsFalse(BackgroundMusic.IsMuted);
            Button("SFX").onClick.Invoke();
            Assert.AreEqual(1, PlayerPrefs.GetInt("home.sfx.enabled"));
            Assert.IsFalse(UiSound.IsMuted);
            Button("Music").onClick.Invoke();
            Assert.AreEqual(0, PlayerPrefs.GetInt("home.music.enabled"));
            Assert.AreEqual(1, PlayerPrefs.GetInt("home.sfx.enabled"), "Mutar música não deve silenciar os efeitos.");
            Assert.IsTrue(BackgroundMusic.IsMuted);
            Assert.IsFalse(UiSound.IsMuted);
            Button("Music").onClick.Invoke();
            Assert.AreEqual(1, PlayerPrefs.GetInt("home.music.enabled"));
            Assert.IsFalse(BackgroundMusic.IsMuted);
        }

        [Test] public void ProgressReadsCompletedChallengesFromSharedState()
        {
            state.CompletedChallenges.Add("letter-a");
            actions.Open("AchievementsAppWidget");
            Assert.IsTrue(Array.Exists(root.GetComponentsInChildren<Text>(), t => t.text == "letter-a"));
            Button("Voltar").onClick.Invoke();
            Assert.IsNull(actions.CurrentPage);
        }
    }
}
