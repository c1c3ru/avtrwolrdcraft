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
            actions.Initialize(objects, saves, state, () => played = true, () => coins = true);
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

        [Test] public void PlayAndCoinChallengeAreSeparateActions()
        {
            actions.Open("AccountButton");
            Button("PlayButton").onClick.Invoke();
            Assert.IsTrue(played);
            Assert.IsFalse(coins, "Play não pode iniciar a atividade opcional que paga moedas.");
            Assert.IsNull(actions.CurrentPage);
            Assert.IsTrue(Array.Exists(objects.ToArray(), go =>
            {
                var canvas = go.GetComponent<Canvas>();
                return canvas != null && canvas.isRootCanvas && !canvas.enabled;
            }), "A Home precisa sair da frente ao entrar no jogo.");
            actions.ReturnFromGameplay();

            Button("Desafio: ganhar moedas").onClick.Invoke();
            Assert.IsTrue(coins, "A atividade opcional deve ter entrada própria.");
            Assert.IsTrue(played, "Abrir a atividade de moedas não deve substituir a navegação principal.");
        }

        [Test] public void AvatarEditorEntryOpensVisualRuntimeWithSharedState()
        {
            var entry = Button("Meu avatar");
            Assert.IsNotNull(entry, "A Home deve oferecer uma entrada visível para o editor visual.");
            entry.onClick.Invoke();

            var runtime = root.GetComponentInChildren<AvatarGpuRuntime>(true);
            Assert.IsNotNull(runtime, "A entrada deve criar o runtime Spine real, não um aviso textual.");
            Assert.IsTrue(Array.Exists(objects.ToArray(), go =>
            {
                var canvas = go.GetComponent<Canvas>();
                return canvas != null && canvas.isRootCanvas && !canvas.enabled;
            }), "A Home deve ceder a tela enquanto o editor está aberto.");
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

        [Test] public void SettingsSoundAndMusicCanBeToggledIndependently()
        {
            PlayerPrefs.SetInt("home.sfx.enabled", 1);
            PlayerPrefs.SetInt("home.music.enabled", 1);
            actions.Open("SettingsButton");
            Button("Efeitos sonoros: ligados").onClick.Invoke();
            Assert.AreEqual(0, PlayerPrefs.GetInt("home.sfx.enabled"));
            Assert.AreEqual(1, PlayerPrefs.GetInt("home.music.enabled"), "Mutar efeitos não deve silenciar a música.");
            Assert.IsTrue(UiSound.IsMuted);
            Assert.IsFalse(BackgroundMusic.IsMuted);
            Button("Efeitos sonoros: desligados").onClick.Invoke();
            Assert.AreEqual(1, PlayerPrefs.GetInt("home.sfx.enabled"));
            Assert.IsFalse(UiSound.IsMuted);
            Button("Música: ligada").onClick.Invoke();
            Assert.AreEqual(0, PlayerPrefs.GetInt("home.music.enabled"));
            Assert.AreEqual(1, PlayerPrefs.GetInt("home.sfx.enabled"), "Mutar música não deve silenciar os efeitos.");
            Assert.IsTrue(BackgroundMusic.IsMuted);
            Assert.IsFalse(UiSound.IsMuted);
            Button("Música: desligada").onClick.Invoke();
            Assert.AreEqual(1, PlayerPrefs.GetInt("home.music.enabled"));
            Assert.IsFalse(BackgroundMusic.IsMuted);
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
