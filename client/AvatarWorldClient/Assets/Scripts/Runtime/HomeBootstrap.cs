using System;
using System.Collections.Generic;
using System.Linq;
using AvatarWorld.Core.Economy;
using AvatarWorld.Core.Literacy;
using UnityEngine;

namespace AvatarWorld.Runtime
{
    /// <summary>
    /// Monta a tela Home (level3 do original) ao iniciar. Dados em Resources/HomeSlice
    /// (level3.json e sprites/), gerados por tools/export_level.py. Tambem carrega o save
    /// e liga o PlayButton aos desafios de alfabetizacao (moedas ganhas entram no mesmo saldo
    /// usado pela loja).
    /// </summary>
    public sealed class HomeBootstrap : MonoBehaviour
    {
        const string SceneJson = "HomeSlice/level3";
        const string SpriteDir = "HomeSlice/sprites/";
        const int StartingPazuCurrency = 50;

        SaveStore _save;
        PlayerState _state;
        LiteracyChallengeService _literacy;

        void Start()
        {
            // Builds de desenvolvimento por padrao nao logam stack trace completo de excecao no
            // Android; sem isso o logcat so mostra "NullReferenceException" sem dizer onde.
            Application.SetStackTraceLogType(LogType.Exception, StackTraceLogType.Full);

            _save = new SaveStore(SaveStore.DefaultPath);
            _state = _save.LoadOrCreate(StartingPazuCurrency);
            var economy = new LocalStoreService(_state, () => Guid.NewGuid().ToString("N"));
            _literacy = new LiteracyChallengeService(_state, economy);

            var json = Resources.Load<TextAsset>(SceneJson);
            if (json == null) { Debug.LogError("Home: " + SceneJson + ".json nao encontrado em Resources"); return; }

            var desc = JsonUtility.FromJson<SceneDescription>(json.text);
            var actions = new Dictionary<string, Action>
            {
                { "PlayButton", OpenLiteracyChallenges },
                { "ShopButton", () => Debug.Log("Home: Loja (ainda nao implementada)") },
            };

            UiSceneBuilder.EnsureEventSystem();
            var objs = UiSceneBuilder.Build(desc, key => Resources.Load<Sprite>(SpriteDir + key), actions);
            LogButtonScreenRect(objs, "PlayButton");
            LogButtonScreenRect(objs, "ShopButton");
        }

        /// <summary>Diagnostico temporario: imprime o retangulo em pixels de tela de um botao, pra
        /// calibrar toques via adb sem continuar advinhando coordenadas.</summary>
        static void LogButtonScreenRect(List<GameObject> objs, string name)
        {
            var go = objs.Find(o => o.name == name);
            if (go == null) { Debug.LogWarning("LogButtonScreenRect: '" + name + "' nao encontrado"); return; }
            var rt = (RectTransform)go.transform;
            var corners = new Vector3[4];
            rt.GetWorldCorners(corners);
            var bl = RectTransformUtility.WorldToScreenPoint(null, corners[0]);
            var tr = RectTransformUtility.WorldToScreenPoint(null, corners[2]);
            var center = (bl + tr) / 2f;
            Debug.Log("ButtonRect " + name + ": bottomLeft=" + bl + " topRight=" + tr + " center=" + center
                + " active=" + go.activeInHierarchy + " screen=" + Screen.width + "x" + Screen.height);
        }

        void OpenLiteracyChallenges()
        {
            Debug.Log("Home: PlayButton clicado");
            var queue = LiteracyContent.LetterRecognition()
                .Concat(LiteracyContent.SyllableBuilding())
                .Concat(LiteracyContent.ReadingComprehension())
                .ToList();

            var screenGo = new GameObject("LiteracyChallengeScreen");
            var screen = screenGo.AddComponent<LiteracyChallengeScreen>();
            screen.Begin(_literacy, queue, () => _save.Save(_state));
        }

        void OnApplicationPause(bool paused) { if (paused && _state != null) _save.Save(_state); }
        void OnApplicationQuit() { if (_state != null) _save.Save(_state); }
    }
}
