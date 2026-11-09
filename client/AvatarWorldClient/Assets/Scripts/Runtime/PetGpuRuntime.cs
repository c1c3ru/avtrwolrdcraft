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
            public List<Breed> breeds; public List<EyeSet> eyes; public List<Option> mouths; public List<Option> manes; public List<Option> tails;
            public List<Option> hats; public List<Option> outfits; public List<Option> shoes; public List<Option> accessories;
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

        // Medidas da pose inicial (unidades do esqueleto, escala 1; skin padrao + corpo): centro X, base Y, largura, altura.
        // Servem para ajustar cada animal a uma altura-alvo e apoia-lo no chao, ja que os esqueletos tem tamanhos muito diferentes.
        static readonly Dictionary<string, Vector4> Sizes = new Dictionary<string, Vector4>
        {
            { "Rabbit", new Vector4(1.5f, -1.0f, 89.9f, 146.4f) }, { "Hamster", new Vector4(-2.5f, 1.1f, 87.8f, 100.1f) },
            { "Bird", new Vector4(17.4f, 3.3f, 113.0f, 127.6f) }, { "Chicken", new Vector4(13.1f, 6.4f, 117.6f, 148.6f) },
            { "Turtle", new Vector4(-3.7f, 12.0f, 81.0f, 110.6f) }, { "Lizard", new Vector4(16.7f, 7.5f, 170.1f, 133.8f) },
            { "Snake", new Vector4(16.6f, 1.2f, 120.7f, 130.0f) }, { "Fish", new Vector4(12.4f, 6.8f, 125.9f, 106.0f) },
            { "Cow", new Vector4(-42.3f, 1.4f, 526.3f, 533.0f) }, { "Dog", new Vector4(-1.2f, -0.7f, 237.2f, 214.5f) },
            { "Cat", new Vector4(8.3f, -4.3f, 210.4f, 174.5f) }, { "Horse", new Vector4(-64.6f, -4.8f, 498.8f, 624.0f) },
        };
        const float SkeletonScale = 0.01f;

        PetAppearance _pet;
        Vector3 _position;     // ponto no chao (base, centro) onde o pet fica
        float _targetHeight, _maxWidth;
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

        /// <summary>position = base do pet; o animal e escalado para targetHeight de altura (sem passar de maxWidth de largura), em unidades do mundo.</summary>
        public void Configure(PetAppearance pet, Vector3 position, float targetHeight, float maxWidth)
        {
            _pet = pet ?? throw new ArgumentNullException(nameof(pet));
            _position = position;
            _targetHeight = targetHeight;
            _maxWidth = maxWidth;
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
            float scale = 1f;
            Vector3 position = _position;
            if (Sizes.TryGetValue(species, out var size))
            {
                // size = (centro X, base Y, largura, altura) em unidades do esqueleto; o mundo usa SkeletonScale por unidade.
                scale = Mathf.Min(_targetHeight / (size.w * SkeletonScale), _maxWidth / (size.z * SkeletonScale));
                position -= new Vector3(size.x * SkeletonScale * scale, size.y * SkeletonScale * scale, 0f);
            }
            _avatarGo.transform.localPosition = position;
            _avatarGo.transform.localScale = Vector3.one * scale;
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
            // Roupas e acessorios (SUT): so as pecas do item escolhido carregam textura; skins Templates/<pagina>, sem tinta.
            AddClothing(skin, tints, _file.outfits, _pet.OutfitId, shown);
            AddClothing(skin, tints, _file.shoes, _pet.ShoesId, shown);
            AddClothing(skin, tints, _file.accessories, _pet.AccessoryId, shown);
            AddClothing(skin, tints, _file.hats, _pet.HatId, shown);
            // Cavalo: crina (cabelo da frente + de tras) e cauda, cada um com a propria paleta.
            var mane = string.IsNullOrEmpty(_pet.ManeId) || _file.manes == null ? null : _file.manes.FirstOrDefault(o => o.id == _pet.ManeId);
            if (mane != null) AddAndLoad(skin, tints, mane.pieces, PaletteColor_(species, PetColorRole.Mane, _pet.ManeColor), shown);
            var tail = string.IsNullOrEmpty(_pet.TailId) || _file.tails == null ? null : _file.tails.FirstOrDefault(o => o.id == _pet.TailId);
            if (tail != null) AddAndLoad(skin, tints, tail.pieces, PaletteColor_(species, PetColorRole.Tail, _pet.TailColor), shown);
        }

        void AddClothing(Skin skin, Dictionary<Attachment, Color> tints, List<Option> list, string id, List<string> shown)
        {
            if (string.IsNullOrEmpty(id) || list == null) return;
            var item = list.FirstOrDefault(o => o.id == id);
            if (item != null) AddAndLoad(skin, tints, item.pieces, Color.white, shown);
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
