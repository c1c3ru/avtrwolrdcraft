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
        WorldMapRuntime _worldMap;

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
            _homeActions.Initialize(objs, _save, _state, OpenWorldMap, OpenStarterPackChallenges, () => OpenStore());

            BackgroundMusic.Play("Audio/home_music");
        }

        /// <summary>"Pacote Inicial": desafios aleatorios do banco de 100, na dificuldade do valor do pacote.</summary>
        void OpenStarterPackChallenges(int packValue)
        {
            if (FindFirstObjectByType<LiteracyChallengeScreen>() != null) return;
            var screenGo = new GameObject("StarterPackChallenges");
            var screen = screenGo.AddComponent<LiteracyChallengeScreen>();
            screen.BeginRandom(_literacy, new ChallengeSelector(_state), packValue, "Pacote Inicial",
                () => _save.Save(_state), _homeActions.ReturnToHome);
        }

        /// <summary>Loja com a moldura do original. Sem moedas, os desafios (preco -> dificuldade) pagam moedas.</summary>
        void OpenStore(Action afterClose = null)
        {
            if (FindFirstObjectByType<StoreScreen>() != null) return;
            var host = new GameObject("Store");
            var store = host.AddComponent<StoreScreen>();
            store.Begin(_state, _save, () =>
            {
                Destroy(host);
                _save.Save(_state);
                if (afterClose != null) afterClose(); else _homeActions.ReturnFromGameplay();
            }, price =>
            {
                if (FindFirstObjectByType<LiteracyChallengeScreen>() != null) return;
                var screenGo = new GameObject("StoreChallenges");
                var screen = screenGo.AddComponent<LiteracyChallengeScreen>();
                screen.SortingOrder = 900;
                screen.BeginRandom(_literacy, new ChallengeSelector(_state), price, "Moedas AW",
                    () => { _save.Save(_state); store.RefreshCoins(); },
                    () => { store.RefreshCoins(); store.SelectCategory(store.Category); });
            });
        }

        /// <summary>Play abre o mapa World do original; a quadra de basquete e um predio dele.</summary>
        void OpenWorldMap()
        {
            if (FindFirstObjectByType<WorldMapRuntime>() != null) return;
            var host = new GameObject("WorldMap");
            _worldMap = host.AddComponent<WorldMapRuntime>();
            _worldMap.OnOpenLevel = OpenSceneSlice;
            LoadingScreen.Show();
            _worldMap.Begin(CloseWorldMap, OpenBasketballCourt, () => LoadingScreen.Hide(0.8f), OpenAvatarSlots);
        }

        /// <summary>Slots de avatar/pet/carro (AvatarMakerLobby): aberto pelo avatar+ do mapa; voltar retorna ao mapa.</summary>
        void OpenAvatarSlots()
        {
            if (FindFirstObjectByType<AvatarSlotsScreen>() != null) return;
            if (_worldMap != null) _worldMap.gameObject.SetActive(false);
            var host = new GameObject("AvatarSlots");
            var slots = host.AddComponent<AvatarSlotsScreen>();
            slots.Begin(_save, _state, () =>
            {
                _save.Save(_state);
                Destroy(host);
                if (_worldMap != null) _worldMap.gameObject.SetActive(true);
            }, () => OpenStore(() => { }));
        }

        void CloseWorldMap()
        {
            if (_worldMap != null) Destroy(_worldMap.gameObject);
            _worldMap = null;
            _save.Save(_state);
            _homeActions.ReturnFromGameplay();
        }

        /// <summary>Ambiente generico (arte e layout extraidos) aberto por um predio do mapa; voltar retorna ao mapa.</summary>
        void OpenSceneSlice(int levelType)
        {
            if (FindFirstObjectByType<SceneSliceRuntime>() != null) return;
            if (_worldMap != null) _worldMap.gameObject.SetActive(false);
            var host = new GameObject("SceneSlice");
            void Close()
            {
                Destroy(host);
                LoadingScreen.Show();
                if (_worldMap != null) _worldMap.gameObject.SetActive(true);
                LoadingScreen.Hide(0.5f);
            }
            if (!host.AddComponent<SceneSliceRuntime>().Begin(levelType, Close, () => LoadingScreen.Hide(0.7f))) Close();
        }

        void OpenBasketballCourt()
        {
            if (FindFirstObjectByType<BasketballCourtRuntime>() != null) return;
            // O mapa fica desativado (preserva a posicao da camera) enquanto a quadra esta aberta.
            if (_worldMap != null) _worldMap.gameObject.SetActive(false);
            var game = new GameObject("BasketballCourtGameplay");
            game.AddComponent<BasketballCourtRuntime>().Begin(_save, _state, () =>
            {
                _save.Save(_state);
                Destroy(game);
                LoadingScreen.Show();
                if (_worldMap != null) _worldMap.gameObject.SetActive(true);
                LoadingScreen.Hide(0.5f);
            });
            LoadingScreen.Hide(0.7f);
        }

        void OnApplicationPause(bool paused) { if (paused && _state != null) _save.Save(_state); }
        void OnApplicationQuit() { if (_state != null) _save.Save(_state); }
    }
}
