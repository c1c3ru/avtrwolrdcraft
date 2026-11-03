using System;
using System.Collections.Generic;
using System.Linq;
using AvatarWorld.Core.Avatar;
using AvatarWorld.Core.Economy;
using Spine;
using Spine.Unity;
using UnityEngine;

namespace AvatarWorld.Runtime
{
    /// <summary>
    /// Validacao no Android dos Ciclos 1-3 (docs/AVATAR_GAMEPLAY_PLAN.md):
    /// Ciclo 1 - corpo/olhos/cabelo, provado no Editor por AvatarGpuProbe.cs, aqui pelo runtime real
    /// em build de player (sem UnityEditor), carregando os assets de Resources/AvatarSpine.
    /// Ciclo 2 - roupas reais via SUT: cada peca de roupa e um skin "Templates/X" ja existente no
    /// esqueleto, cuja pagina de atlas (mesmo nome, ex. "T_Torso_7.png") recebe a textura real do
    /// item extraida de resources.assets (sutsystem/skins/character/..., ver clothing-manifest.json).
    /// Botoes OnGUI (toque real no Android) trocam cada categoria independentemente no MESMO avatar -
    /// so mudam attachments/texturas, sem recriar o esqueleto nem a SkeletonAnimation.
    /// Ciclo 3 - a selecao atual fica em PlayerState.Appearance (Core/Avatar), gravada no MESMO
    /// SaveStore/arquivo que a Home usaria (AvatarCatalog e a fonte unica de IDs validos, tambem usada
    /// pela validacao fora da engine em PlayerStateTests). Cada toque salva imediatamente, provando
    /// que reabrir o app mantem a aparencia escolhida.
    /// Mantido fora da Home/HomeBootstrap de proposito - acesso pela Home e o Ciclo 4.
    /// </summary>
    public sealed class AvatarGpuRuntime : MonoBehaviour
    {
        [Serializable] class ManifestPiece { public string template; public string file; }
        [Serializable] class ManifestItem { public string id; public List<ManifestPiece> pieces; }
        [Serializable] class Manifest { public List<ManifestItem> items; }

        class Category { public string key; public string label; public string[] itemIds; }

        static readonly string[] BodyTextureNames = {
            "MultiPack__Body_Outline_31883", "MultiPack__Body_Shadow_87873", "MultiPack__Body_Solid_99707",
            "MultiPack__Ear_Shadow_76723", "Eyes_01_1_Color_21563", "Eyes_01_1_P_18738",
            "Hair_Front_01_Color_56300", "Hair_Front_02_Color_21315",
        };
        static readonly Dictionary<string, string> BodyPageToResource = new Dictionary<string, string> {
            { "MultiPack__Body_Outline", "MultiPack__Body_Outline_31883" },
            { "MultiPack__Body_Shadow", "MultiPack__Body_Shadow_87873" },
            { "MultiPack__Body_Solid", "MultiPack__Body_Solid_99707" },
            { "MultiPack__Ear_Shadow", "MultiPack__Ear_Shadow_76723" },
            { "Eyes_01_1_Color", "Eyes_01_1_Color_21563" },
            { "Eyes_01_1_P", "Eyes_01_1_P_18738" },
            { "Hair_Front_01_Color", "Hair_Front_01_Color_56300" },
            { "Hair_Front_02_Color", "Hair_Front_02_Color_21315" },
        };

        Dictionary<string, ManifestItem> _itemsById;
        Dictionary<string, Material> _materialByPage;
        readonly HashSet<string> _loadedClothingPages = new HashSet<string>();
        SkeletonAnimation _skeletonAnimation;
        SkeletonData _skeletonData;
        Shader _shader;

        readonly List<Category> _categories = new List<Category> {
            new Category { key = AvatarCatalog.CategoryShirt, label = "Camisa", itemIds = AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryShirt] },
            new Category { key = AvatarCatalog.CategoryBottom, label = "Calca", itemIds = AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryBottom] },
            new Category { key = AvatarCatalog.CategoryShoes, label = "Sapato", itemIds = AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryShoes] },
            new Category { key = AvatarCatalog.CategoryAccessory, label = "Acessorio", itemIds = AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryAccessory] },
        };
        static readonly string[] HairOptions = AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryHair];

        SaveStore _saveStore;
        PlayerState _playerState;
        Action _onClose;
        bool _useSharedState;
        bool _embeddedWorldAvatar;
        Vector3 _worldPosition;
        float _worldScale = 1f;
        AvatarAppearance Appearance => _playerState.Appearance;

        public void Configure(SaveStore saveStore, PlayerState playerState, Action onClose)
        {
            _saveStore = saveStore ?? throw new ArgumentNullException(nameof(saveStore));
            _playerState = playerState ?? throw new ArgumentNullException(nameof(playerState));
            _onClose = onClose;
            _useSharedState = true;
        }

        public void ConfigureAsWorldAvatar(SaveStore saveStore, PlayerState playerState, Vector3 position, float scale)
        {
            Configure(saveStore, playerState, null);
            _embeddedWorldAvatar = true;
            _worldPosition = position;
            _worldScale = scale;
        }

        void Start()
        {
            Application.SetStackTraceLogType(LogType.Exception, StackTraceLogType.Full);

            // Mesmo arquivo/formato que a Home usaria (ver SaveStore.DefaultPath) - app com package id
            // proprio (com.c1c3ru.avatarvalidation), entao o save fica isolado do da Home de verdade
            // pelo proprio sandbox do Android, sem risco de misturar os dois.
            if (!_useSharedState)
            {
                _saveStore = new SaveStore(SaveStore.DefaultPath);
                _playerState = _saveStore.LoadOrCreate(0);
            }
            Debug.Log("AvatarGpuRuntime: aparencia carregada do save - " + Appearance.HairId + "/" + Appearance.ShirtId + "/" + Appearance.BottomId + "/" + Appearance.ShoesId + "/" + Appearance.AccessoryId);

            _shader = Shader.Find("Spine/Skeleton");
            if (_shader == null) { Debug.LogError("AvatarGpuRuntime: shader Spine/Skeleton nao encontrado"); return; }

            var manifestText = Resources.Load<TextAsset>("AvatarSpine/clothing-manifest");
            if (manifestText == null) { Debug.LogError("AvatarGpuRuntime: clothing-manifest.json nao encontrado"); return; }
            var manifest = JsonUtility.FromJson<Manifest>(manifestText.text);
            _itemsById = manifest.items.ToDictionary(i => i.id, i => i);

            var dummyTexture = new Texture2D(2, 2, TextureFormat.RGBA32, false) { name = "__avatar_runtime_unused__" };
            var dummyMaterial = new Material(_shader) { mainTexture = dummyTexture };
            var materials = new List<Material> { dummyMaterial };

            foreach (var resourceName in BodyTextureNames)
            {
                var source = Resources.Load<Texture2D>("AvatarSpine/Textures/" + resourceName);
                if (source == null) { Debug.LogError("AvatarGpuRuntime: textura ausente " + resourceName); return; }
                var texture = PremultipliedCopy(source);
                texture.name = BodyPageToResource.First(p => p.Value == resourceName).Key;
                materials.Add(new Material(_shader) { mainTexture = texture });
            }

            // Um Material por pagina de template unica usada por QUALQUER variante de QUALQUER
            // categoria (ex.: "B_Pelvis" e compartilhado por bottom_special_1 e bottom_special_10) -
            // trocar de item so reatribui o mainTexture desse Material (SetTextures real do SUT),
            // nunca cria um Material novo por item. A textura real da selecao inicial (indice 0 de
            // cada categoria) e carregada JA NA CRIACAO do Material, nao depois: GetAtlas() parseia
            // e amarra AtlasRegion->Material no momento do CreateRuntimeInstance - mutar so' o
            // mainTexture de um Material DEPOIS so funciona se aquele Material ja foi o escolhido
            // nesse parse (ligado por nome da textura == nome da pagina). Uma pagina cujo Material
            // tinha a dummy (nome nao-casante) na hora da criacao do atlas fica com
            // page.rendererObject nulo PRA SEMPRE - trocar o mainTexture dela depois nao conserta
            // (achado em teste no Android: a 2a opcao de cada categoria, nao carregada no Start,
            // continuava em magenta - material de erro do Unity - mesmo apos o toque trocar
            // corretamente a textura do Material). Por isso as texturas de TODAS as variantes
            // conhecidas (nao so a selecao inicial) sao carregadas com o nome certo ja aqui.
            var pageToFile = new Dictionary<string, string>();
            foreach (var item in manifest.items)
                foreach (var piece in item.pieces)
                {
                    var pageName = piece.template.Substring("Templates/".Length);
                    if (!pageToFile.ContainsKey(pageName)) pageToFile[pageName] = piece.file;
                }

            _materialByPage = new Dictionary<string, Material>();
            foreach (var pair in pageToFile)
            {
                var pageName = pair.Key;
                var resourceName = System.IO.Path.GetFileNameWithoutExtension(pair.Value);
                var source = Resources.Load<Texture2D>("AvatarSpine/Clothing/" + resourceName);
                if (source == null) { Debug.LogError("AvatarGpuRuntime: textura de roupa ausente " + resourceName); continue; }
                var texture = PremultipliedCopy(source);
                // MaterialsTextureLoader casa cada pagina do atlas pelo NOME DA TEXTURA (nao do
                // Material) - achado em diagnostico: sem isso toda peca de roupa fica com
                // page.rendererObject nulo e renderiza com o material de erro (magenta) do Unity.
                texture.name = pageName;
                _loadedClothingPages.Add(pageName);
                var mat = new Material(_shader) { mainTexture = texture, name = pageName };
                _materialByPage[pageName] = mat;
                materials.Add(mat);
            }

            var atlasText = Resources.Load<TextAsset>("AvatarSpine/Avatar_Spine.atlas");
            var skeletonBinary = Resources.Load<TextAsset>("AvatarSpine/Avatar_Spine.skel");
            if (atlasText == null || skeletonBinary == null)
            {
                Debug.LogError("AvatarGpuRuntime: atlas ou skeleton nao encontrados em Resources/AvatarSpine");
                return;
            }

            var atlasAsset = SpineAtlasAsset.CreateRuntimeInstance(atlasText, materials.ToArray(), true);
            var skeletonDataAsset = SkeletonDataAsset.CreateRuntimeInstance(skeletonBinary, atlasAsset, true, 0.01f);
            _skeletonData = skeletonDataAsset.GetSkeletonData(false);
            if (_skeletonData == null) { Debug.LogError("AvatarGpuRuntime: SkeletonData nao carregou"); return; }

            var avatarGo = new GameObject("Avatar");
            avatarGo.transform.SetParent(transform, false);
            if (_embeddedWorldAvatar)
            {
                avatarGo.transform.localPosition = _worldPosition;
                avatarGo.transform.localScale = Vector3.one * _worldScale;
            }
            _skeletonAnimation = SkeletonAnimation.AddToGameObject(avatarGo, skeletonDataAsset);
            _skeletonAnimation.Initialize(false);
            if (!_skeletonAnimation.valid) { Debug.LogError("AvatarGpuRuntime: SkeletonAnimation.valid == false"); return; }

            // Texturas das selecoes iniciais ja foram carregadas na criacao dos Materials acima.
            RebuildSkin();

            _skeletonAnimation.AnimationName = null;
            _skeletonAnimation.state.SetAnimation(0, "Idle_Stand_1", true);
            _skeletonAnimation.Update(0.1f);
            _skeletonAnimation.LateUpdate();

            var meshFilter = avatarGo.GetComponent<MeshFilter>();
            int tris = meshFilter != null && meshFilter.sharedMesh != null ? meshFilter.sharedMesh.triangles.Length / 3 : 0;
            var avatarRenderer = avatarGo.GetComponent<MeshRenderer>();
            if (_embeddedWorldAvatar && avatarRenderer != null) avatarRenderer.sortingOrder = 4;
            Debug.Log("AvatarGpuRuntime: avatar valido, " + tris + " triangulos reais, animacao Idle_Stand_1 tocando");


            if (!_embeddedWorldAvatar)
            {
                var cam = new GameObject("AvatarCamera", typeof(Camera));
                cam.transform.SetParent(transform, false);
                cam.tag = "MainCamera";
                var camera = cam.GetComponent<Camera>();
                camera.orthographic = true;
                camera.clearFlags = CameraClearFlags.SolidColor;
                camera.backgroundColor = new Color(0.922f, 0.914f, 0.953f, 1f);

                var meshRenderer = avatarGo.GetComponent<MeshRenderer>();
                Bounds bounds = meshRenderer != null ? meshRenderer.bounds : new Bounds(Vector3.zero, Vector3.one);
                float verticalHalf = bounds.extents.y * 1.15f;
                float horizontalHalf = bounds.extents.x * 1.15f / Mathf.Max(camera.aspect, 0.01f);
                camera.orthographicSize = Mathf.Max(verticalHalf, horizontalHalf, 0.01f);
                cam.transform.position = new Vector3(bounds.center.x, bounds.center.y, -10f);
            }
        }

        void LoadItemTextures(ManifestItem item)
        {
            foreach (var piece in item.pieces)
            {
                var pageName = piece.template.Substring("Templates/".Length);
                var resourceName = System.IO.Path.GetFileNameWithoutExtension(piece.file);
                var source = Resources.Load<Texture2D>("AvatarSpine/Clothing/" + resourceName);
                if (source == null) { Debug.LogError("AvatarGpuRuntime: textura de roupa ausente " + resourceName); continue; }
                var texture = PremultipliedCopy(source);
                texture.name = pageName;
                _materialByPage[pageName].mainTexture = texture;
                _loadedClothingPages.Add(pageName);
            }
        }

        void RebuildSkin()
        {
            var skin = new Skin("avatar-runtime-composite");
            var tints = new Dictionary<Attachment, Color>();
            AddSkin(_skeletonData, skin, tints, "Body_Whites/Body_Whites", new Color(1f, 0.824f, 0.675f));
            AddSkin(_skeletonData, skin, tints, "Body_Shad/Body_Shad", new Color(0.824f, 0.569f, 0.435f));
            AddSkin(_skeletonData, skin, tints, "Ear_Shad/Ear_Shad", new Color(0.667f, 0.376f, 0.271f));
            AddSkin(_skeletonData, skin, tints, "Body_Other/Body_Other", Color.white);
            AddSkin(_skeletonData, skin, tints, "Eyes/1_Color", new Color(0.22f, 0.44f, 0.57f));
            AddSkin(_skeletonData, skin, tints, "Eyes/1_Color-p", Color.white);
            AddSkin(_skeletonData, skin, tints, Appearance.HairId, new Color(0.31f, 0.16f, 0.12f));

            foreach (var category in _categories)
            {
                var item = _itemsById[Appearance.Get(category.key)];
                foreach (var piece in item.pieces)
                    AddSkin(_skeletonData, skin, tints, piece.template, Color.white);
            }

            _skeletonAnimation.skeleton.SetSkin(skin);
            _skeletonAnimation.skeleton.SetSlotsToSetupPose();
            _skeletonAnimation.skeleton.SetAttachment("Mouths", "Body_Outline/Mouth_Regular");
            foreach (var slot in _skeletonAnimation.skeleton.Slots)
                if (slot.Attachment != null && tints.TryGetValue(slot.Attachment, out var color))
                { slot.R = color.r; slot.G = color.g; slot.B = color.b; }
        }

        void OnGUI()
        {
            if (_embeddedWorldAvatar) return;
            if (_skeletonAnimation == null) return;
            float scale = Screen.width / 1280f;
            GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(scale, scale, 1f));
            float y = 10f;
            const float w = 220f, h = 60f;

            int hairIndex = Array.IndexOf(HairOptions, Appearance.HairId);
            if (GUI.Button(new Rect(10, y, w, h), "Cabelo: " + (hairIndex + 1) + "/" + HairOptions.Length))
            {
                var nextHair = HairOptions[(hairIndex + 1) % HairOptions.Length];
                Appearance.TrySelect(AvatarCatalog.CategoryHair, nextHair);
                _saveStore.Save(_playerState);
                RebuildSkin();
                Debug.Log("AvatarGpuRuntime: toque trocou cabelo para " + nextHair + " (salvo)");
            }
            y += h + 10f;

            foreach (var category in _categories)
            {
                int current = Array.IndexOf(category.itemIds, Appearance.Get(category.key));
                if (GUI.Button(new Rect(10, y, w, h), category.label + ": " + (current + 1) + "/" + category.itemIds.Length))
                {
                    var nextItemId = category.itemIds[(current + 1) % category.itemIds.Length];
                    Appearance.TrySelect(category.key, nextItemId);
                    _saveStore.Save(_playerState);
                    LoadItemTextures(_itemsById[nextItemId]);
                    RebuildSkin();
                    Debug.Log("AvatarGpuRuntime: toque trocou " + category.label + " para " + nextItemId + " (salvo)");
                }
                y += h + 10f;
            }

            if (_onClose != null && GUI.Button(new Rect(Screen.width / scale - 230f, 10f, 220f, h), "Voltar à Home"))
            {
                var close = _onClose;
                _onClose = null;
                close();
                Destroy(gameObject);
            }
        }

        static Texture2D PremultipliedCopy(Texture2D source)
        {
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
            return copy;
        }

        static void AddSkin(SkeletonData data, Skin composite, Dictionary<Attachment, Color> tints, string name, Color color)
        {
            var source = data.FindSkin(name);
            if (source == null) { Debug.LogError("AvatarGpuRuntime: skin ausente " + name); return; }
            composite.AddSkin(source);
            foreach (var item in source.Attachments) tints[item.Attachment] = color;
        }
    }
}
