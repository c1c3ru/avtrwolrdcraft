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
            UiSceneBuilder.EnsureEventSystem();
            var objects = UiSceneBuilder.Build(desc, key => Resources.Load<Sprite>(SpriteDir + key));
            HomeLayout.Apply(objects);
            gameObject.AddComponent<HomeActions>().Initialize(objects, new SaveStore(SaveStore.DefaultPath));
        }
    }
}
