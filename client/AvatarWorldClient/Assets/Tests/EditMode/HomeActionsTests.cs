using System;
using System.Collections.Generic;
using System.IO;
using AvatarWorld.Core.Economy;
using AvatarWorld.Core.Localization;
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
        bool hadSfx, hadMusic, hadLanguage;
        string language;
        Language locBefore;
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
            hadLanguage = PlayerPrefs.HasKey("home.language");
            language = PlayerPrefs.GetString("home.language", "");
            PlayerPrefs.DeleteKey("home.language");
            locBefore = Loc.Current;
            Loc.Current = Language.Pt;
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
            if (hadLanguage) PlayerPrefs.SetString("home.language", language);
            else PlayerPrefs.DeleteKey("home.language");
            Loc.Current = locBefore;
            UiSound.SetMuted(sfx == 0);
            BackgroundMusic.SetMuted(music == 0);
            PlayerPrefs.Save();
        }

        // O GameObject do botao do painel nasce com o texto da epoca; o que acompanha o idioma e o rotulo.
        Text Label(string text) => Array.Find(root.GetComponentsInChildren<Text>(true), t => t.text == text && t.gameObject.activeInHierarchy);

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
            Assert.AreEqual(12, actions.BoundButtonCount); // + WorldReset, ChatLanguage e as 4 bandeiras
            Assert.AreEqual(27, actions.PendingButtons.Count);
            Assert.IsFalse(Button("ShopButton").interactable);
            Assert.IsFalse(objects.Find(o => o.name == "MultiplayerCanvas").activeSelf);
            actions.Open("ShopButton");
            Assert.IsNull(actions.CurrentPage);
        }

        [Test] public void WorldReset_NeedsTwoConfirmationsAndKeepsABackup()
        {
            new LocalStoreService(state).Earn(10, "antes do reset");
            state.CompletedChallenges.Add("desafio-x");
            saves.Save(state);
            actions.Open("SettingsButton");
            Button("WorldResetButton").onClick.Invoke();
            Assert.AreEqual(Loc.Get("reset.title"), actions.CurrentPage);
            Assert.IsNull(Button(Loc.Get("reset.confirm.do")), "o botao final so aparece no segundo passo");
            Assert.AreEqual(85, state.PazuCurrency, "o aviso sozinho nao apaga nada");

            Button(Loc.Get("reset.continue")).onClick.Invoke();
            Assert.AreEqual(Loc.Get("reset.confirm.title"), actions.CurrentPage);
            Assert.AreEqual(85, state.PazuCurrency, "a confirmacao ainda nao apaga");

            Button(Loc.Get("reset.confirm.do")).onClick.Invoke();
            Assert.AreEqual(HomeBootstrap.StartingPazuCurrency, state.PazuCurrency);
            Assert.AreEqual(0, state.CompletedChallenges.Count);
            Assert.AreEqual(0, state.Ledger.Count);
            Assert.IsNotNull(state.Appearance);
            Assert.AreEqual(HomeBootstrap.StartingPazuCurrency, saves.LoadOrCreate(0).PazuCurrency, "o save em disco tambem volta ao inicio");
            Assert.IsTrue(File.Exists(path + ".before-reset"), "copia de seguranca do save anterior");
            Assert.AreEqual(85, new SaveStore(path + ".before-reset").LoadOrCreate(0).PazuCurrency);
            File.Delete(path + ".before-reset");
        }

        [Test] public void WorldReset_CanBeCancelledWithBack()
        {
            actions.Open("SettingsButton");
            Button("WorldResetButton").onClick.Invoke();
            Button(Loc.Get("back")).onClick.Invoke();
            Assert.IsNull(actions.CurrentPage);
            Assert.AreEqual(75, state.PazuCurrency);
        }

        [Test] public void LanguageButtons_SwitchInterfaceLanguageAndRememberIt()
        {
            actions.Open("SettingsButton");
            actions.Open("ChatLanguageButton");
            Button("enButton").onClick.Invoke();
            Assert.AreEqual(Language.En, Loc.Current);
            Assert.AreEqual("en", PlayerPrefs.GetString("home.language"));
            actions.Open("AccountButton");
            Assert.AreEqual("Local profile", actions.CurrentPage);
            Assert.IsNotNull(Button("Save progress"));
            Assert.IsNotNull(Label("Back"));

            actions.Close();
            actions.Open("SettingsButton");
            actions.Open("ChatLanguageButton");
            Button("esButton").onClick.Invoke();
            Assert.AreEqual(Language.Es, Loc.Current);
            actions.Open("AccountButton");
            Assert.IsNotNull(Label("Volver"), "o botao Voltar do painel acompanha o idioma");

            // Novo Home (proximo boot) le a preferencia gravada.
            Loc.Current = Language.Pt;
            var again = new GameObject("TestHome2");
            try
            {
                var desc = JsonUtility.FromJson<SceneDescription>(Resources.Load<TextAsset>("HomeSlice/level3").text);
                var objs = UiSceneBuilder.Build(desc, null, parent: again.transform);
                again.AddComponent<HomeActions>().Initialize(objs, saves, state, () => { });
                Assert.AreEqual(Language.Es, Loc.Current);
            }
            finally { Object.DestroyImmediate(again); }
        }

        [Test] public void ChatLanguageButton_TogglesThePanelAndFlagFollowsTheChoice()
        {
            var panel = Array.Find(root.GetComponentsInChildren<Transform>(true), t => t.name == "ChatLanguagesPanel").gameObject;
            Assert.IsFalse(panel.activeSelf);
            actions.Open("SettingsButton");
            actions.Open("ChatLanguageButton");
            Assert.IsTrue(panel.activeSelf);
            Button("idButton").onClick.Invoke();
            Assert.IsFalse(panel.activeSelf, "escolher fecha o painel");
            var flag = Array.Find(root.GetComponentsInChildren<Button>(true), b => b.name.Trim() == "ChatLanguageButton").transform.Find("Image").GetComponent<Image>();
            var idFlag = Array.Find(root.GetComponentsInChildren<Button>(true), b => b.name.Trim() == "idButton").transform.Find("Image").GetComponent<Image>();
            Assert.AreSame(idFlag.sprite, flag.sprite);
        }

        [Test] public void AvatarPassButtons_OpenThePassWhenProvided()
        {
            var passRoot = new GameObject("TestHomePass");
            try
            {
                var desc = JsonUtility.FromJson<SceneDescription>(Resources.Load<TextAsset>("HomeSlice/level3").text);
                var objs = UiSceneBuilder.Build(desc, null, parent: passRoot.transform);
                var withPass = passRoot.AddComponent<HomeActions>();
                int opened = 0;
                withPass.Initialize(objs, saves, state, () => { }, null, null, () => opened++);
                Assert.IsFalse(withPass.PendingButtons.Contains("AvatarPassButton"));
                Assert.IsFalse(withPass.PendingButtons.Contains("AvatarPassButton_Small"));
                Assert.AreEqual(actions.PendingButtons.Count - 2, withPass.PendingButtons.Count);
                withPass.Open("AvatarPassButton");
                Assert.AreEqual(1, opened);
            }
            finally { Object.DestroyImmediate(passRoot); }
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
