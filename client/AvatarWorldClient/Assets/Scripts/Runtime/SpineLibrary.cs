using System;
using System.Collections.Generic;
using AvatarWorld.Core.Spine;
using Spine.Unity;
using UnityEngine;

namespace AvatarWorld.Runtime
{
    /// <summary>
    /// Carrega esqueletos Spine do original por nome: Resources/Spine/&lt;nome&gt;/{&lt;nome&gt;.skel, &lt;nome&gt;.atlas, &lt;pagina&gt;.png}
    /// (tools/import_spine_original.py). Cada pagina do atlas ganha o Material da textura exata que o original liga a ela.
    /// As texturas do original nao sao pre-multiplicadas; o shader Spine/Skeleton recebe alpha direto (_StraightAlphaInput).
    /// </summary>
    public static class SpineLibrary
    {
        const string IndexPath = "Spine/spine-index";
        static SpineIndex _index;
        static readonly Dictionary<string, SkeletonDataAsset> _cache = new Dictionary<string, SkeletonDataAsset>(StringComparer.OrdinalIgnoreCase);

        public static SpineIndex Index
        {
            get
            {
                if (_index != null) return _index;
                var text = Resources.Load<TextAsset>(IndexPath);
                if (text == null) { Debug.LogError("SpineLibrary: " + IndexPath + " nao encontrado"); return null; }
                _index = new SpineIndex(JsonUtility.FromJson<SpineIndexData>(text.text));
                return _index;
            }
        }

        /// <summary>SkeletonDataAsset pelo nome; devolve nulo (com erro no log) se o esqueleto nao existir ou nao tiver atlas.</summary>
        public static SkeletonDataAsset Load(string name)
        {
            SkeletonDataAsset cached;
            if (_cache.TryGetValue(name, out cached)) return cached;
            var index = Index;
            SpineEntry entry;
            if (index == null || !index.TryGet(name, out entry)) { Debug.LogError("SpineLibrary: esqueleto desconhecido: " + name); return null; }
            if (!entry.renderable) { Debug.LogError("SpineLibrary: esqueleto sem atlas (so logica): " + name); return null; }

            string dir = "Spine/" + entry.folder + "/";
            var skel = Resources.Load<TextAsset>(dir + entry.folder + ".skel");
            var atlasText = Resources.Load<TextAsset>(dir + entry.folder + ".atlas");
            if (skel == null || atlasText == null) { Debug.LogError("SpineLibrary: arquivos ausentes para " + name); return null; }

            var shader = Shader.Find("Spine/Skeleton");
            if (shader == null) { Debug.LogError("SpineLibrary: shader Spine/Skeleton nao encontrado"); return null; }
            bool pma = atlasText.text.Contains("pma:true");
            var pages = AvatarAtlasLoader.ParsePageNames(atlasText.text);
            var materials = new Material[pages.Length];
            for (int i = 0; i < pages.Length; i++)
            {
                var texture = Resources.Load<Texture2D>(dir + pages[i]);
                if (texture == null)
                {
                    Debug.LogError("SpineLibrary: textura ausente " + dir + pages[i]);
                    texture = new Texture2D(1, 1, TextureFormat.RGBA32, false);
                    texture.SetPixel(0, 0, Color.clear);
                    texture.Apply(false, true);
                }
                texture.name = pages[i];         // o loader do Spine casa a pagina pelo nome da textura
                var material = new Material(shader) { name = pages[i], mainTexture = texture };
                if (!pma)
                {
                    material.SetFloat("_StraightAlphaInput", 1f);
                    material.EnableKeyword("_STRAIGHT_ALPHA_INPUT");
                }
                materials[i] = material;
            }
            var atlas = SpineAtlasAsset.CreateRuntimeInstance(atlasText, materials, true);
            var data = SkeletonDataAsset.CreateRuntimeInstance(skel, atlas, true, entry.scale > 0f ? entry.scale : 0.01f);
            if (entry.defaultMix > 0f) data.defaultMix = entry.defaultMix;
            _cache[name] = data;
            return data;
        }

        public static void Reset() { _index = null; _cache.Clear(); }
    }
}
