using System;
using System.Collections.Generic;
using System.Linq;
using AvatarWorld.Core.Avatar;
using Spine;
using Spine.Unity;
using UnityEngine;

namespace AvatarWorld.Runtime
{
    /// <summary>
    /// Renderiza um pet simples (variante pronta): esqueleto/atlas da especie em Resources/AvatarSpine/Pets/&lt;Especie&gt;,
    /// skin composto "default" + skin da variante, texturas resolvidas em pet.json. Troca de especie/variante recria tudo.
    /// </summary>
    public sealed class PetGpuRuntime : MonoBehaviour
    {
        [Serializable] class Piece { public string template; public string file; public string skin; }
        [Serializable] class Variant { public string id; public List<Piece> pieces; }
        [Serializable] class PetFile { public string species; public string idle; public List<Piece> basePieces; public List<Variant> variants; }

        PetAppearance _pet;
        Vector3 _position;
        float _scale = 1f;
        PetFile _file;
        string _loadedSpecies;
        SkeletonDataAsset _dataAsset;
        SkeletonData _skeletonData;
        Dictionary<string, Material> _materialByPage;
        readonly List<Texture2D> _textures = new List<Texture2D>();
        Texture2D _blank;
        GameObject _avatarGo;
        SkeletonAnimation _animation;

        public bool IsReady => _animation != null && _animation.valid;
        public PetAppearance Pet => _pet;

        public void Configure(PetAppearance pet, Vector3 position, float scale)
        {
            _pet = pet ?? throw new ArgumentNullException(nameof(pet));
            _position = position;
            _scale = scale;
            Apply(pet);
        }

        /// <summary>Mostra a aparencia dada (troca de especie recria o esqueleto; troca de variante so refaz skin e texturas).</summary>
        public void Apply(PetAppearance pet)
        {
            _pet = pet.Clone();
            if (_loadedSpecies != _pet.Species && !LoadSpecies(_pet.Species)) return;
            BuildSkin();
        }

        bool LoadSpecies(string species)
        {
            Unload();
            string folder = "AvatarSpine/Pets/" + species;
            var atlasText = Resources.Load<TextAsset>(folder + "/Spine.atlas");
            var skeletonBinary = Resources.Load<TextAsset>(folder + "/Spine.skel");
            var json = Resources.Load<TextAsset>(folder + "/pet");
            var shader = Shader.Find("Spine/Skeleton");
            if (atlasText == null || skeletonBinary == null || json == null || shader == null)
            {
                Debug.LogError("PetGpuRuntime: recursos ausentes para " + species);
                return false;
            }
            _file = JsonUtility.FromJson<PetFile>(json.text);
            try
            {
                var atlasAsset = AvatarAtlasLoader.Create(atlasText, shader, null, out _materialByPage, -1);
                _dataAsset = SkeletonDataAsset.CreateRuntimeInstance(skeletonBinary, atlasAsset, true, 0.01f);
                _skeletonData = _dataAsset.GetSkeletonData(false);
            }
            catch (Exception e)
            {
                Debug.LogError("PetGpuRuntime: falha ao criar atlas de " + species + ": " + e);
                return false;
            }
            if (_skeletonData == null) return false;
            _avatarGo = new GameObject("Pet " + species);
            _avatarGo.transform.SetParent(transform, false);
            _avatarGo.transform.localPosition = _position;
            _avatarGo.transform.localScale = Vector3.one * _scale;
            _animation = SkeletonAnimation.AddToGameObject(_avatarGo, _dataAsset);
            _animation.Initialize(false);
            if (!_animation.valid) { Debug.LogError("PetGpuRuntime: SkeletonAnimation invalida para " + species); return false; }
            var renderer = _avatarGo.GetComponent<MeshRenderer>();
            if (renderer != null) renderer.sortingOrder = 4;
            string idle = _skeletonData.FindAnimation(_file.idle) != null ? _file.idle
                : _skeletonData.Animations.Count > 0 ? _skeletonData.Animations.Items[0].Name : null;
            if (idle != null) _animation.state.SetAnimation(0, idle, true);
            _loadedSpecies = species;
            return true;
        }

        void BuildSkin()
        {
            var variant = _file.variants.FirstOrDefault(v => v.id == _pet.VariantId) ?? _file.variants[0];
            // Texturas: as da base e as da variante escolhida; as demais paginas ficam em branco.
            foreach (var texture in _textures) if (texture != null) Destroy(texture);
            _textures.Clear();
            if (_blank == null)
            {
                _blank = new Texture2D(1, 1, TextureFormat.RGBA32, false);
                _blank.SetPixel(0, 0, Color.clear);
                _blank.Apply(false, true);
            }
            foreach (var material in _materialByPage.Values) material.mainTexture = _blank;
            foreach (var piece in (_file.basePieces ?? new List<Piece>()).Concat(variant.pieces)) LoadPage(piece);

            var skin = new Skin("pet-runtime-composite");
            var basic = _skeletonData.FindSkin("default");
            if (basic != null) skin.AddSkin(basic);
            var chosen = _skeletonData.FindSkin(variant.pieces[0].skin);
            if (chosen == null) { Debug.LogError("PetGpuRuntime: skin ausente " + variant.pieces[0].skin); return; }
            skin.AddSkin(chosen);
            _animation.skeleton.SetSkin(skin);
            _animation.skeleton.SetSlotsToSetupPose();
            _animation.Update(0f);
            _animation.LateUpdate();
        }

        void LoadPage(Piece piece)
        {
            string page = piece.template.Substring("Templates/".Length);
            if (!_materialByPage.TryGetValue(page, out var material)) return;
            var source = Resources.Load<Texture2D>("AvatarSpine/Clothing/" + System.IO.Path.GetFileNameWithoutExtension(piece.file));
            if (source == null) { Debug.LogError("PetGpuRuntime: textura ausente " + piece.file); return; }
            var pixels = source.GetPixels32();
            for (int i = 0; i < pixels.Length; i++)
            {
                var p = pixels[i];
                float a = p.a / 255f;
                pixels[i] = new Color32((byte)(p.r * a), (byte)(p.g * a), (byte)(p.b * a), p.a);
            }
            var copy = new Texture2D(source.width, source.height, TextureFormat.RGBA32, false);
            copy.SetPixels32(pixels);
            copy.Apply();
            copy.name = page;
            Resources.UnloadAsset(source);
            _textures.Add(copy);
            material.mainTexture = copy;
        }

        void Unload()
        {
            if (_avatarGo != null) Destroy(_avatarGo);
            _avatarGo = null;
            _animation = null;
            foreach (var texture in _textures) if (texture != null) Destroy(texture);
            _textures.Clear();
            _loadedSpecies = null;
        }

        void OnDestroy()
        {
            foreach (var texture in _textures) if (texture != null) Destroy(texture);
            if (_blank != null) Destroy(_blank);
        }
    }
}
