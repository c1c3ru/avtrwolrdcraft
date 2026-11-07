using System;
using System.Collections.Generic;
using AvatarWorld.Core.World;
using Spine.Unity;
using UnityEngine;

namespace AvatarWorld.Runtime
{
    /// <summary>
    /// Camada Spine de um mapa/interior (Sun_Moon = ceu, Water_Reflections = brilhos na agua), de
    /// Resources/MapSpine/&lt;nome&gt;/. No original os dois sao filhos da WorldCamera: aqui acompanham a camera pelo
    /// deslocamento exportado. Falha de carga so registra aviso (a cena segue sem a camada).
    /// </summary>
    public sealed class MapSpineLayer : MonoBehaviour
    {
        Camera _camera;
        Vector2 _offset;
        bool _follow;

        public static MapSpineLayer Create(Transform parent, WorldSpineData data, Camera camera)
        {
            var shader = Shader.Find("Spine/Skeleton");
            string root = "MapSpine/" + data.skeleton + "/" + data.skeleton;
            var skeleton = Resources.Load<TextAsset>(root + ".skel");
            var atlasText = Resources.Load<TextAsset>(root + ".atlas");
            var texture = Resources.Load<Texture2D>(root);
            if (shader == null || skeleton == null || atlasText == null || texture == null)
            {
                Debug.LogWarning("MapSpine: recursos ausentes para " + data.skeleton);
                return null;
            }
            try
            {
                var material = new Material(shader) { name = data.skeleton, mainTexture = texture };
                var atlas = SpineAtlasAsset.CreateRuntimeInstance(atlasText, new[] { material }, true);
                var dataAsset = SkeletonDataAsset.CreateRuntimeInstance(skeleton, atlas, true, 0.01f);
                var go = new GameObject("Spine_" + data.skeleton);
                go.transform.SetParent(parent, false);
                go.transform.position = new Vector3(data.x, data.y, 0f);
                go.transform.localScale = new Vector3(data.sx, data.sy, 1f);
                var animation = SkeletonAnimation.AddToGameObject(go, dataAsset);
                animation.Initialize(false);
                if (!animation.valid) { Destroy(go); return null; }

                var names = new List<string>();
                var animations = animation.Skeleton.Data.Animations;
                for (int i = 0; i < animations.Count; i++) names.Add(animations.Items[i].Name);
                string chosen = SpineAnimationPicker.Pick(names, data.skeleton, data.animation, DateTime.Now.Hour);
                if (chosen != null) animation.state.SetAnimation(0, chosen, data.loop);
                Debug.Log("MapSpine: " + data.skeleton + " animacao=" + chosen + " de [" + string.Join(", ", names) + "]");
                var meshRenderer = go.GetComponent<MeshRenderer>();
                if (meshRenderer != null) meshRenderer.sortingOrder = data.rank;

                var layer = go.AddComponent<MapSpineLayer>();
                layer._camera = camera;
                layer._offset = new Vector2(data.offsetX, data.offsetY);
                layer._follow = data.followCamera;
                return layer;
            }
            catch (Exception e)
            {
                Debug.LogWarning("MapSpine: falha ao criar " + data.skeleton + ": " + e.Message);
                return null;
            }
        }

        /// <summary>Cor do esqueleto inteiro (tonalidade por hora do dia / transparencia dos brilhos da agua).</summary>
        public void SetColor(Color color)
        {
            var animation = GetComponent<SkeletonAnimation>();
            if (animation == null || animation.Skeleton == null) return;
            animation.Skeleton.R = color.r; animation.Skeleton.G = color.g; animation.Skeleton.B = color.b; animation.Skeleton.A = color.a;
        }

        void LateUpdate()
        {
            if (!_follow || _camera == null) return;
            var p = _camera.transform.position;
            transform.position = new Vector3(p.x + _offset.x, p.y + _offset.y, 0f);
        }
    }
}
