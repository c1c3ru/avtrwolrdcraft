using System;
using System.Collections.Generic;
using System.IO;
using AvatarWorld.Core.Economy;
using AvatarWorld.Runtime;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace AvatarWorld.Core.Tests
{
    public class HomeActionsTests
    {
        GameObject root;
        HomeActions actions;
        List<GameObject> objects;
        string path;
        bool paused;
        int sound;
        bool hadSound;

        [SetUp]
        public void SetUp()
        {
            paused = AudioListener.pause;
            hadSound = PlayerPrefs.HasKey("home.sound.enabled");
            sound = PlayerPrefs.GetInt("home.sound.enabled", 1);
            path = Path.Combine(Path.GetTempPath(), "home-" + Guid.NewGuid() + ".json");
            new SaveStore(path).Save(PlayerState.CreateNew(75));
            root = new GameObject("TestHome");
            var description = JsonUtility.FromJson<SceneDescription>(Resources.Load<TextAsset>("HomeSlice/level3").text);
            objects = UiSceneBuilder.Build(description, null, parent: root.transform);
            HomeLayout.Apply(objects);
            actions = root.AddComponent<HomeActions>();
            actions.Initialize(objects, new SaveStore(path));
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(root);
            foreach (string suffix in new[] { "", ".tmp", ".corrupt" })
                if (File.Exists(path + suffix)) File.Delete(path + suffix);
            AudioListener.pause = paused;
            if (hadSound) PlayerPrefs.SetInt("home.sound.enabled", sound);
            else PlayerPrefs.DeleteKey("home.sound.enabled");
            PlayerPrefs.Save();
        }

        Button FindButton(string name) => Array.Find(root.GetComponentsInChildren<Button>(true), b => b.name == name);

        [TestCase("PlayButton", "Jogar")]
        [TestCase("ShopButton", "Loja")]
        [TestCase("SettingsButton", "Configurações")]
        [TestCase("AccountButton", "Perfil local")]
        [TestCase("MultiplayerButton", "Indisponível")]
        public void Click_OpensPageAndBackReturnsHome(string buttonName, string page)
        {
            // Executa o handler de pointer do Button, nao apenas onClick.Invoke.
            var eventObject = new GameObject("TestEvents", typeof(EventSystem));
            try
            {
                var data = new PointerEventData(eventObject.GetComponent<EventSystem>())
                    { button = PointerEventData.InputButton.Left };
                ExecuteEvents.Execute(FindButton(buttonName).gameObject, data, ExecuteEvents.pointerClickHandler);
                Assert.AreEqual(page, actions.CurrentPage);
                FindButton("Voltar à home").onClick.Invoke();
                Assert.IsNull(actions.CurrentPage);
            }
            finally { Object.DestroyImmediate(eventObject); }
        }

        [Test]
        public void EveryExportedButtonHasAHandlerAndRaycastSurface()
        {
            int count = 0;
            foreach (var go in objects)
            {
                var button = go.GetComponent<Button>();
                if (button == null) continue;
                count++;
                Assert.IsNotNull(button.targetGraphic, go.name);
                Assert.IsTrue(go.GetComponent<Graphic>().raycastTarget, go.name);
                button.onClick.Invoke();
                Assert.IsNotNull(actions.CurrentPage, go.name);
                actions.Close();
            }
            Assert.AreEqual(count, actions.BoundButtonCount);
            Assert.IsFalse(objects.Find(go => go.name == "MultiplayerCanvas").activeSelf);
        }

        [Test]
        public void ProfileSavePreservesExistingCurrency()
        {
            actions.Open("AccountButton");
            FindButton("Salvar progresso").onClick.Invoke();
            Assert.AreEqual(75, new SaveStore(path).LoadOrCreate(0).PazuCurrency);
        }

        [Test]
        public void SettingsToggleUpdatesAudioAndPersistsPreference()
        {
            PlayerPrefs.SetInt("home.sound.enabled", 1);
            actions.Open("SettingsButton");
            FindButton("Som: ligado").onClick.Invoke();
            Assert.AreEqual(0, PlayerPrefs.GetInt("home.sound.enabled"));
            Assert.IsTrue(AudioListener.pause);
            FindButton("Som: desligado").onClick.Invoke();
            Assert.AreEqual(1, PlayerPrefs.GetInt("home.sound.enabled"));
            Assert.IsFalse(AudioListener.pause);
        }
    }
}
