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
    /// e liga Play a uma sala jogavel; desafios de alfabetizacao sao atividade opcional de moedas.
    /// </summary>
    public sealed class HomeBootstrap : MonoBehaviour
    {
        const string SceneJson = "HomeSlice/level3";
        const string SpriteDir = "HomeSlice/sprites/";
        const int StartingPazuCurrency = 50;

        SaveStore _save;
        PlayerState _state;
        LiteracyChallengeService _literacy;
        HomeActions _homeActions;

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
            var objs = UiSceneBuilder.Build(desc, key => Resources.Load<Sprite>(SpriteDir + key));
            // A exportacao da level3 tambem contem EventSystem + StandaloneInputModule. Criar o
            // EventSystem antes de materializar esses objetos deixava dois sistemas competindo.
            UiSceneBuilder.EnsureEventSystem();

            // O original controla a visibilidade do multiplayer (menus de sair/entrar em sala,
            // "tem certeza que quer sair?") inteiramente por script em runtime; o estado "active"
            // capturado na exportacao estatica nao reflete isso. Sem essa logica, dialogos do
            // MultiplayerCanvas (ex.: AreaYouSureBubble, centralizado como o PlayButton) ficavam
            // ativos e invisiveis por cima da Home, interceptando todo clique na area. Multiplayer
            // esta fora do escopo deste cliente offline, entao desativa o ramo inteiro.
            var multiplayerCanvas = objs.Find(o => o.name == "MultiplayerCanvas");
            if (multiplayerCanvas != null) multiplayerCanvas.SetActive(false);

            HomeLayout.Apply(objs);
            _homeActions = gameObject.AddComponent<HomeActions>();
            _homeActions.Initialize(objs, _save, _state, OpenBasketballCourt, OpenLiteracyChallenges);

            BackgroundMusic.Play("Audio/home_music");
        }

        void OpenLiteracyChallenges()
        {
            if (FindFirstObjectByType<LiteracyChallengeScreen>() != null) return;
            var queue = LiteracyContent.LetterRecognition()
                .Concat(LiteracyContent.SyllableBuilding())
                .Concat(LiteracyContent.ReadingComprehension())
                .ToList();

            var screenGo = new GameObject("LiteracyChallengeScreen");
            var screen = screenGo.AddComponent<LiteracyChallengeScreen>();
            screen.Begin(_literacy, queue, () => _save.Save(_state), _homeActions.ReturnToHome);
        }

        void OpenBasketballCourt()
        {
            if (FindFirstObjectByType<BasketballCourtRuntime>() != null) return;
            var game = new GameObject("BasketballCourtGameplay");
            game.AddComponent<BasketballCourtRuntime>().Begin(_save, _state, () =>
            {
                _save.Save(_state);
                Destroy(game);
                _homeActions.ReturnFromGameplay();
            });
        }

        void OnApplicationPause(bool paused) { if (paused && _state != null) _save.Save(_state); }
        void OnApplicationQuit() { if (_state != null) _save.Save(_state); }
    }
}
