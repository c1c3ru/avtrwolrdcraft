using System;
using System.Collections.Generic;
using UnityEngine;

namespace AvatarWorld.Runtime
{
    /// <summary>
    /// Monta a tela Home (level3 do original) ao iniciar. Dados em Resources/HomeSlice
    /// (level3.json e sprites/), gerados por tools/export_level.py.
    /// </summary>
    public sealed class HomeBootstrap : MonoBehaviour
    {
        const string SceneJson = "HomeSlice/level3";
        const string SpriteDir = "HomeSlice/sprites/";

        void Start()
        {
            var json = Resources.Load<TextAsset>(SceneJson);
            if (json == null) { Debug.LogError("Home: " + SceneJson + ".json nao encontrado em Resources"); return; }

            var desc = JsonUtility.FromJson<SceneDescription>(json.text);
            var actions = new Dictionary<string, Action>
            {
                { "PlayButton", () => Debug.Log("Home: Play (ainda nao implementado)") },
                { "ShopButton", () => Debug.Log("Home: Loja (ainda nao implementada)") },
            };

            UiSceneBuilder.EnsureEventSystem();
            UiSceneBuilder.Build(desc, key => Resources.Load<Sprite>(SpriteDir + key), actions);
        }
    }
}
