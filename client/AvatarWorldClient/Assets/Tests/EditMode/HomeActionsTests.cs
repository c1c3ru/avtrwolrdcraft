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

            actions.Open("AchievementsAppWidget");
            Button("Desafio pedagógico: ganhar moedas").onClick.Invoke();
            Assert.IsTrue(coins, "A atividade opcional deve ter entrada própria.");
            Assert.IsTrue(played, "Abrir a atividade de moedas não deve substituir a navegação principal.");
        }

        [Test] public void AvatarEditorEntryOpensVisualRuntimeWithSharedState()
        {
            Button("NotSignedUserButton").onClick.Invoke();
            var entry = Button("Editar meu avatar");
            Assert.IsNotNull(entry, "Avatar ID deve abrir o perfil local, que oferece o editor visual.");
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
            Assert.AreEqual(28, actions.BoundButtonCount);
            Assert.AreEqual(12, actions.PendingButtons.Count);
            Assert.IsTrue(Button("ShopButton").interactable);
            Assert.IsFalse(objects.Find(o => o.name == "MultiplayerCanvas").activeSelf);
            actions.Open("MultiplayerButton");
            Assert.IsNull(actions.CurrentPage);
        }

        [Test] public void ShopPurchaseAppliesOutfitAndPersistsBalanceAndOwnership()
        {
            actions.Open("ShopButton");
            var visual = root.GetComponentInChildren<StoreVisualView>();
            Assert.IsNotNull(visual, "A loja deve abrir a interface gráfica com assets originais.");
            var preview = Array.Find(visual.GetComponentsInChildren<Image>(), i => i.name == "AvatarPreview");
            Assert.IsNotNull(preview.sprite, "O produto deve mostrar a composição real do avatar.");
            Assert.IsNotNull(Button("Passeio — 15 moedas").targetGraphic.GetComponent<Image>().sprite);
            Button("Passeio — 15 moedas").onClick.Invoke();
            Assert.AreEqual(60, state.PazuCurrency);
            Assert.AreEqual(1, state.GetClaimCount("offline.outfit.0"));
            var loaded = saves.LoadOrCreate(0);
            Assert.AreEqual(60, loaded.PazuCurrency);
            Assert.AreEqual(state.Appearance.HairId, loaded.Appearance.HairId);
            Button("Passeio — Aplicar (adquirido)").onClick.Invoke();
            Assert.AreEqual(60, state.PazuCurrency);
        }

        [Test] public void GiftButtonGrantsOneTimeRewardAndSavesIt()
        {
            Button("GiftBadge").onClick.Invoke();
            Button("Resgatar presente inicial: 25 moedas").onClick.Invoke();
            Assert.AreEqual(100, state.PazuCurrency);
            Assert.AreEqual(1, saves.LoadOrCreate(0).GetClaimCount("offline.starter"));
            actions.Open("NewUserGiftCurrency");
            Assert.IsFalse(Button("Presente inicial resgatado").interactable);
        }

        [Test] public void AllPassRewardsRemainVisibleAbovePlayButton()
        {
            actions.Open("AvatarPassButton");
            Button("Ativar passe: 60 moedas").onClick.Invoke();
            var reward = (RectTransform)Button("12 desafios: +25 moedas").transform;
            var playButton = (RectTransform)Button("Jogar desafios").transform;
            Assert.LessOrEqual(playButton.anchorMax.y, reward.anchorMin.y,
                "A ação de jogar não pode cobrir o terceiro prêmio.");
        }

        [Test] public void SettingsSoundAndMusicCanBeToggledIndependently()
        {
            PlayerPrefs.SetInt("home.sfx.enabled", 1);
            PlayerPrefs.SetInt("home.music.enabled", 1);
            actions.Open("SettingsButton");
            Button("SFX").onClick.Invoke();
            Assert.AreEqual(0, PlayerPrefs.GetInt("home.sfx.enabled"));
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

        [Test] public void SettingsBackdropRemainsClickableAndClosesMenu()
        {
            actions.Open("SettingsButton");
            var menu = objects.Find(o => o.name == "SettingsMenu");
            var backdrop = objects.Find(o => o.name == "Background" && o.transform.IsChildOf(menu.transform));
            var button = backdrop.GetComponent<Button>();
            Assert.IsTrue(menu.activeSelf);
            Assert.IsTrue(button.interactable);
            button.onClick.Invoke();
            Assert.IsFalse(menu.activeSelf);
        }

        [Test] public void AvatarEntryIsNotCoveredByComingSoonOverlay()
        {
            Assert.IsFalse(objects.Find(o => o.name == "ComingSoonButton").activeSelf);
            Assert.IsFalse(objects.Find(o => o.name == "NewUserGiftCurrency").activeSelf,
                "O presente sem arte não pode interceptar o Starter Pack.");
            Assert.IsTrue(Button("NotSignedUserButton").interactable);
            Button("NotSignedUserButton").onClick.Invoke();
            Button("Editar meu avatar").onClick.Invoke();
            Assert.IsNotNull(root.GetComponentInChildren<AvatarGpuRuntime>(true));
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
