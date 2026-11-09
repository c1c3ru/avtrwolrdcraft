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
        [Serializable] class Option { public string id; public List<Piece> pieces; }
        [Serializable] class Breed { public string id; public List<Piece> body; public List<Piece> outline; public List<Option> patterns; public List<Option> eyebrows; }
        [Serializable] class EyeSet { public string id; public List<Piece> outline; public List<Piece> @base; public List<Piece> pupils; public List<Piece> gradient; }
        [Serializable] class PetFile
        {
            public string species; public string idle; public bool layered; public List<Piece> basePieces; public List<Variant> variants;
            public List<Breed> breeds; public List<EyeSet> eyes; public List<Option> mouths;
        }
        [Serializable] class PaletteColor { public float[] c; }
        [Serializable] class PaletteEntry { public float[] display; public List<PaletteColor> colors; }
        [Serializable] class PaletteList { public string name; public List<PaletteEntry> entries; }
        [Serializable] class PaletteFile { public List<PaletteList> lists; }
        static PaletteFile _palettes;

        // Cor de exibicao (ou a Colors[i]) da entrada da paleta do papel; branco se ausente.
        static Color PaletteColor_(string species, PetColorRole role, int index, int colorIndex = -1)
        {
            if (_palettes == null)
            {
                var text = Resources.Load<TextAsset>("AvatarSpine/pet-palettes");
                _palettes = text != null ? JsonUtility.FromJson<PaletteFile>(text.text) : new PaletteFile { lists = new List<PaletteList>() };
            }
            var name = PetCatalog.PaletteName(species, role);
            var list = _palettes.lists.Find(l => l.name == name);
            if (list == null || list.entries.Count == 0) return Color.white;
            var entry = list.entries[Mathf.Clamp(index, 0, list.entries.Count - 1)];
            var c = colorIndex >= 0 && colorIndex < entry.colors.Count ? entry.colors[colorIndex].c : entry.display;
            return new Color(c[0], c[1], c[2], 1f);
        }

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

        /// <summary>Cor de amostra (exibicao) da entrada da paleta do papel; branco se a especie nao tem esse papel.</summary>
        public static Color Swatch(string species, PetColorRole role, int index) => PaletteColor_(species, role, index);

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
            // Texturas: as da base e as do pet escolhido; as demais paginas ficam em branco.
            foreach (var texture in _textures) if (texture != null) Destroy(texture);
            _textures.Clear();
            if (_blank == null)
            {
                _blank = new Texture2D(1, 1, TextureFormat.RGBA32, false);
                _blank.SetPixel(0, 0, Color.clear);
                _blank.Apply(false, true);
            }
            foreach (var material in _materialByPage.Values) material.mainTexture = _blank;

            var skin = new Skin("pet-runtime-composite");
            var tints = new Dictionary<Attachment, Color>();
            var shown = new List<string>();
            var basic = _skeletonData.FindSkin("default");
            if (basic != null) skin.AddSkin(basic);
            foreach (var piece in _file.basePieces ?? new List<Piece>()) LoadPage(piece);

            if (!_file.layered)
            {
                var variant = _file.variants.FirstOrDefault(v => v.id == _pet.VariantId) ?? _file.variants[0];
                foreach (var piece in variant.pieces) LoadPage(piece);
                AddPieces(skin, tints, variant.pieces, Color.white, shown);
            }
            else BuildLayered(skin, tints, shown);

            _animation.skeleton.SetSkin(skin);
            _animation.skeleton.SetSlotsToSetupPose();
            // Camadas (padrao, sobrancelha, olhos, boca) podem nao ter anexo na pose inicial: liga o primeiro anexo que o proprio skin traz.
            if (_file.layered)
                foreach (var name in shown)
                {
                    var source = _skeletonData.FindSkin(name);
                    if (source == null) continue;
                    foreach (var entry in source.Attachments)
                    {
                        var slot = _animation.skeleton.Slots.Items[entry.SlotIndex];
                        if (slot.Attachment == null) slot.Attachment = entry.Attachment; // primeiro anexo do slot (os demais sao alternativas de pose)
                    }
                }
            foreach (var slot in _animation.skeleton.Slots)
                if (slot.Attachment != null && tints.TryGetValue(slot.Attachment, out var color)) { slot.R = color.r; slot.G = color.g; slot.B = color.b; }
            _animation.Update(0f);
            _animation.LateUpdate();
        }

        void BuildLayered(Skin skin, Dictionary<Attachment, Color> tints, List<string> shown)
        {
            string species = _pet.Species;
            var breed = _file.breeds.FirstOrDefault(b => b.id == _pet.BreedId) ?? _file.breeds[0];
            var eyes = _file.eyes.FirstOrDefault(e => e.id == _pet.EyesId) ?? _file.eyes[0];
            var mouth = _file.mouths.FirstOrDefault(m => m.id == _pet.MouthId) ?? _file.mouths[0];
            var pattern = string.IsNullOrEmpty(_pet.PatternId) ? null : breed.patterns.FirstOrDefault(o => o.id == _pet.PatternId);
            var eyebrow = string.IsNullOrEmpty(_pet.EyebrowId) ? null : breed.eyebrows.FirstOrDefault(o => o.id == _pet.EyebrowId);
            // Papeis de cor (AWSpineColorsList Dog_*/Cat_*): corpo, padrao e sobrancelha = cor de exibicao; olhos: Colors[0] na base e Colors[1] no gradiente.
            AddAndLoad(skin, tints, breed.body, PaletteColor_(species, PetColorRole.Body, _pet.BodyColor), shown);
            AddAndLoad(skin, tints, breed.outline, Color.white, shown);
            if (pattern != null) AddAndLoad(skin, tints, pattern.pieces, PaletteColor_(species, PetColorRole.Pattern, _pet.PatternColor), shown);
            if (eyebrow != null) AddAndLoad(skin, tints, eyebrow.pieces, PaletteColor_(species, PetColorRole.Eyebrows, _pet.EyebrowColor), shown);
            AddAndLoad(skin, tints, eyes.outline, Color.white, shown);
            AddAndLoad(skin, tints, eyes.@base, PaletteColor_(species, PetColorRole.Eyes, _pet.EyesColor, 0), shown);
            if (eyes.gradient != null && eyes.gradient.Count > 0) AddAndLoad(skin, tints, eyes.gradient, PaletteColor_(species, PetColorRole.Eyes, _pet.EyesColor, 1), shown);
            AddAndLoad(skin, tints, eyes.pupils, Color.white, shown);
            AddAndLoad(skin, tints, mouth.pieces, Color.white, shown);
        }

        void AddAndLoad(Skin skin, Dictionary<Attachment, Color> tints, List<Piece> pieces, Color tint, List<string> shown)
        {
            foreach (var piece in pieces) LoadPage(piece);
            AddPieces(skin, tints, pieces, tint, shown);
        }

        void AddPieces(Skin skin, Dictionary<Attachment, Color> tints, List<Piece> pieces, Color tint, List<string> shown)
        {
            foreach (var name in pieces.Select(p => p.skin).Distinct())
            {
                var source = _skeletonData.FindSkin(name);
                if (source == null) { Debug.LogError("PetGpuRuntime: skin ausente " + name); continue; }
                skin.AddSkin(source);
                foreach (var entry in source.Attachments) tints[entry.Attachment] = tint;
                shown.Add(name);
            }
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
