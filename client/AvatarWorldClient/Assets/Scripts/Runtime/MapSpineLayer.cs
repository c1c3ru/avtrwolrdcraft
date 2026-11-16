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

        /// <summary>
        /// Material do atlas. As texturas do original nao sao pre-multiplicadas: sem _StraightAlphaInput o Spine/Skeleton trata os
        /// pixels transparentes (RGB branco) como cor e o sol aparecia como um retangulo claro no canto do mapa.
        /// </summary>
        public static Material CreateMaterial(Shader shader, Texture2D texture, string name)
        {
            var material = new Material(shader) { name = name, mainTexture = texture };
            material.SetFloat("_StraightAlphaInput", 1f);
            material.EnableKeyword("_STRAIGHT_ALPHA_INPUT");
            return material;
        }

        /// <summary>
        /// Textura de uma pagina do atlas: a pasta MapSpine so guarda a primeira pagina; as demais (Pendolum2/3, C_Scissors_2..20...)
        /// ficam em Resources/Spine/&lt;esqueleto&gt;/. Null se nao existir em nenhuma.
        /// </summary>
        public static Texture2D LoadPageTexture(string skeleton, string page)
        {
            var texture = Resources.Load<Texture2D>("MapSpine/" + skeleton + "/" + page);
            return texture != null ? texture : Resources.Load<Texture2D>("Spine/" + skeleton + "/" + page);
        }

        /// <summary>
        /// Um Material por pagina do atlas, na ordem do arquivo. O Spine liga cada pagina ao material cujo mainTexture tem o nome da
        /// pagina; com um material so, as paginas extras geravam "Material with texture name ... not found for atlas asset".
        /// Pagina sem textura vira um pixel transparente (com aviso) para o resto do esqueleto ainda desenhar.
        /// </summary>
        public static Material[] CreateMaterials(Shader shader, string skeleton, string atlasText)
        {
            var pages = AvatarAtlasLoader.ParsePageNames(atlasText);
            var materials = new Material[pages.Length];
            for (int i = 0; i < pages.Length; i++)
            {
                var texture = LoadPageTexture(skeleton, pages[i]);
                if (texture == null)
                {
                    Debug.LogWarning("MapSpine: pagina ausente " + skeleton + "/" + pages[i]);
                    texture = new Texture2D(1, 1, TextureFormat.RGBA32, false) { name = pages[i] };
                    texture.SetPixel(0, 0, Color.clear);
                    texture.Apply(false, true);
                }
                materials[i] = CreateMaterial(shader, texture, pages[i]);
            }
            return materials;
        }

        public static MapSpineLayer Create(Transform parent, WorldSpineData data, Camera camera)
        {
            var shader = Shader.Find("Spine/Skeleton");
            string root = "MapSpine/" + data.skeleton + "/" + data.skeleton;
            var skeleton = Resources.Load<TextAsset>(root + ".skel");
            var atlasText = Resources.Load<TextAsset>(root + ".atlas");
            if (shader == null || skeleton == null || atlasText == null)
            {
                Debug.LogWarning("MapSpine: recursos ausentes para " + data.skeleton);
                return null;
            }
            try
            {
                var atlas = SpineAtlasAsset.CreateRuntimeInstance(atlasText, CreateMaterials(shader, data.skeleton, atlasText.text), true);
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
