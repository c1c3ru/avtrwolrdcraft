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
        // skin: nome do skin do esqueleto quando difere de template (cabelo da frente: Hair_Front/N_Color); template sempre da a pagina.
        [Serializable] class ManifestPiece { public string template; public string file; public string skin; }

        static string SkinOf(ManifestPiece piece) => string.IsNullOrEmpty(piece.skin) ? piece.template : piece.skin;
        [Serializable] class ManifestItem { public string id; public List<ManifestPiece> pieces; }
        [Serializable] class Manifest { public List<ManifestItem> items; }

        class Category { public string key; public string label; public string[] itemIds; }
        [Serializable] class PaletteColor { public float[] c; }
        [Serializable] class PaletteEntry { public float[] display; public List<PaletteColor> colors; }
        [Serializable] class Palettes { public List<PaletteEntry> skin; public List<PaletteEntry> eyes; public List<PaletteEntry> general; public int defaultSkin; public int defaultEyes; }
        Palettes _palettes;

        static Color ToColor(float[] c) => new Color(c[0], c[1], c[2], 1f);

        Color GeneralColor(int index) => ToColor(_palettes.general[Mathf.Clamp(index, 0, _palettes.general.Count - 1)].display);

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
        readonly Dictionary<string, string> _pageFileLoaded = new Dictionary<string, string>(); // pagina -> arquivo da textura atual
        readonly Dictionary<string, Texture2D> _pageTextures = new Dictionary<string, Texture2D>();
        readonly Dictionary<string, bool> _available = new Dictionary<string, bool>();
        Texture2D _blank;
        SkeletonAnimation _skeletonAnimation;
        SkeletonData _skeletonData;
        Shader _shader;

        readonly List<Category> _categories = new List<Category> {
            new Category { key = AvatarCatalog.CategoryHair, label = "Cabelo", itemIds = AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryHair] },
            new Category { key = AvatarCatalog.CategoryHairBack, label = "Cabelo atras", itemIds = AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryHairBack] },
            new Category { key = AvatarCatalog.CategoryShirt, label = "Camisa", itemIds = AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryShirt] },
            new Category { key = AvatarCatalog.CategoryJacket, label = "Jaqueta", itemIds = AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryJacket] },
            new Category { key = AvatarCatalog.CategoryBottom, label = "Calca", itemIds = AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryBottom] },
            new Category { key = AvatarCatalog.CategoryShoes, label = "Sapato", itemIds = AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryShoes] },
            new Category { key = AvatarCatalog.CategoryAccessory, label = "Acessorio", itemIds = AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryAccessory] },
            new Category { key = AvatarCatalog.CategoryHat, label = "Chapeu", itemIds = AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryHat] },
            new Category { key = AvatarCatalog.CategoryMouth, label = "Boca", itemIds = AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryMouth] },
            new Category { key = AvatarCatalog.CategoryEyebrows, label = "Sobrancelha", itemIds = AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryEyebrows] },
        };
        static readonly string[] HairOptions = AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryHair];

        SaveStore _saveStore;
        PlayerState _playerState;
        Action _onClose;
        bool _useSharedState;
        bool _embeddedWorldAvatar;
        Vector3 _worldPosition;
        int _worldSortingOrder = 4;
        float _worldScale = 1f;
        AvatarAppearance Appearance => _playerState.Appearance;

        public void Configure(SaveStore saveStore, PlayerState playerState, Action onClose)
        {
            _saveStore = saveStore ?? throw new ArgumentNullException(nameof(saveStore));
            _playerState = playerState ?? throw new ArgumentNullException(nameof(playerState));
            _onClose = onClose;
            _useSharedState = true;
        }

        public void ConfigureAsWorldAvatar(SaveStore saveStore, PlayerState playerState, Vector3 position, float scale, int sortingOrder = 4)
        {
            _worldSortingOrder = sortingOrder;
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

            var atlasText = Resources.Load<TextAsset>("AvatarSpine/Avatar_Spine.atlas");
            var skeletonBinary = Resources.Load<TextAsset>("AvatarSpine/Avatar_Spine.skel");
            if (atlasText == null || skeletonBinary == null)
            {
                Debug.LogError("AvatarGpuRuntime: atlas ou skeleton nao encontrados em Resources/AvatarSpine");
                return;
            }

            var manifestText = Resources.Load<TextAsset>("AvatarSpine/clothing-manifest");
            if (manifestText == null) { Debug.LogError("AvatarGpuRuntime: clothing-manifest.json nao encontrado"); return; }
            var manifest = JsonUtility.FromJson<Manifest>(manifestText.text);
            _itemsById = manifest.items.ToDictionary(i => i.id, i => i);
            var paletteText = Resources.Load<TextAsset>("AvatarSpine/palettes");
            if (paletteText == null) { Debug.LogError("AvatarGpuRuntime: palettes.json nao encontrado"); return; }
            _palettes = JsonUtility.FromJson<Palettes>(paletteText.text);

            var realTextures = new Dictionary<string, Texture2D>(StringComparer.Ordinal);

            foreach (var resourceName in BodyTextureNames)
            {
                var source = Resources.Load<Texture2D>("AvatarSpine/Textures/" + resourceName);
                if (source == null) { Debug.LogError("AvatarGpuRuntime: textura ausente " + resourceName); return; }
                var texture = PremultipliedCopy(source);
                var pageName = BodyPageToResource.First(p => p.Value == resourceName).Key;
                texture.name = pageName;
                realTextures[pageName] = texture;
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
            // O manifesto tem centenas de itens: so os selecionados agora carregam textura no Start; os demais
            // carregam sob demanda (LoadItemTextures) e sao descartados por ReleaseUnselected. Todas as 2172 paginas
            // ja tem Material no atlas (AvatarAtlasLoader), entao trocar o mainTexture depois funciona.
            var pageToFile = new Dictionary<string, string>();
            foreach (var selectedId in SelectedItemIds())
            {
                if (!_itemsById.TryGetValue(selectedId, out var selectedItem)) continue;
                foreach (var piece in selectedItem.pieces)
                {
                    var pageName = piece.template.Substring("Templates/".Length);
                    if (!pageToFile.ContainsKey(pageName)) pageToFile[pageName] = piece.file;
                }
            }

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
                _pageFileLoaded[pageName] = pair.Value;
                _pageTextures[pageName] = texture;
                realTextures[pageName] = texture;
                Resources.UnloadAsset(source);
            }

            SpineAtlasAsset atlasAsset;
            SkeletonDataAsset skeletonDataAsset;
            try
            {
                atlasAsset = AvatarAtlasLoader.Create(atlasText, _shader, realTextures, out _materialByPage);
                skeletonDataAsset = SkeletonDataAsset.CreateRuntimeInstance(skeletonBinary, atlasAsset, true, 0.01f);
                _skeletonData = skeletonDataAsset.GetSkeletonData(false);
            }
            catch (Exception exception)
            {
                Debug.LogError("AvatarGpuRuntime: falha ao criar atlas completo: " + exception);
                return;
            }
            Debug.Log("AvatarGpuRuntime: atlas completo, 2172/2172 paginas com Material");
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
            if (_embeddedWorldAvatar && avatarRenderer != null) avatarRenderer.sortingOrder = _worldSortingOrder;
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

        /// <summary>Esqueleto e skin prontos (Start concluiu); o editor visual espera isto antes de gerar miniaturas.</summary>
        /// <summary>
        /// Renderiza uma aparencia qualquer (NPC) numa textura transparente e devolve um sprite com o pivo nos pes. Troca a
        /// aparencia do avatar so durante a captura (mesmo quadro) e a restaura. Os ids do look nao precisam estar nas listas do
        /// editor, so no manifesto; "none" ou ids desconhecidos simplesmente nao desenham peca.
        /// </summary>
        public Sprite CaptureLook(AvatarAppearance look, int size = 256)
        {
            if (!IsReady || look == null) return null;
            var t = _skeletonAnimation.transform;
            var backup = Appearance.Clone();
            var position = t.position; var scale = t.localScale; float facing = _skeletonAnimation.Skeleton.ScaleX;
            var spot = new Vector3(0f, 500f, 0f);
            RenderTexture rt = null; GameObject camGo = null; Texture2D tex = null;
            try
            {
                CopyAppearance(look, Appearance);
                RebuildSkin();
                t.position = spot; t.localScale = Vector3.one; _skeletonAnimation.Skeleton.ScaleX = 1f;
                RefreshMesh();
                var mr = t.GetComponent<MeshRenderer>();
                var bounds = mr != null ? mr.bounds : new Bounds(spot + Vector3.up, Vector3.one * 2f);
                float ortho = Mathf.Max(bounds.extents.x, bounds.extents.y, 0.1f) * 1.05f;
                camGo = new GameObject("NpcCaptureCamera", typeof(Camera));
                var cam = camGo.GetComponent<Camera>();
                cam.orthographic = true; cam.orthographicSize = ortho; cam.enabled = false;
                cam.clearFlags = CameraClearFlags.SolidColor; cam.backgroundColor = new Color(0f, 0f, 0f, 0f);
                camGo.transform.position = new Vector3(bounds.center.x, bounds.center.y, -10f);
                rt = new RenderTexture(size, size, 16, RenderTextureFormat.ARGB32);
                cam.targetTexture = rt;
                cam.Render();
                RenderTexture.active = rt;
                tex = new Texture2D(size, size, TextureFormat.RGBA32, false);
                tex.ReadPixels(new Rect(0, 0, size, size), 0, 0);
                tex.Apply();
                var pivot = new Vector2((t.position.x - (bounds.center.x - ortho)) / (2f * ortho), (t.position.y - (bounds.center.y - ortho)) / (2f * ortho));
                return Sprite.Create(tex, new Rect(0, 0, size, size), pivot, size / (2f * ortho));
            }
            finally
            {
                RenderTexture.active = null;
                if (camGo != null) Destroy(camGo);
                if (rt != null) { rt.Release(); Destroy(rt); }
                CopyAppearance(backup, Appearance);
                RebuildSkin();
                t.position = position; t.localScale = scale; _skeletonAnimation.Skeleton.ScaleX = facing;
                RefreshMesh();
            }
        }

        // Copia todos os campos sem validar contra o catalogo (NPCs usam itens fora das listas do editor).
        static void CopyAppearance(AvatarAppearance from, AvatarAppearance to)
        {
            to.HairId = from.HairId; to.ShirtId = from.ShirtId; to.BottomId = from.BottomId; to.ShoesId = from.ShoesId;
            to.AccessoryId = from.AccessoryId; to.MouthId = from.MouthId; to.EyebrowsId = from.EyebrowsId;
            to.HairBackId = from.HairBackId; to.HatId = from.HatId; to.JacketId = from.JacketId;
            to.SkinIndex = from.SkinIndex; to.EyesIndex = from.EyesIndex;
            to.ItemColors = from.Clone().ItemColors;
        }

        /// <summary>Avatar embutido (mundo/interior): toca uma animacao do esqueleto se ela existir.</summary>
        public void PlayAnimation(string animationName, bool loop)
        {
            if (!IsReady || _skeletonAnimation.Skeleton.Data.FindAnimation(animationName) == null) return;
            _skeletonAnimation.state.SetAnimation(0, animationName, loop);
        }

        /// <summary>Espelha o avatar horizontalmente (true = olhando para a esquerda).</summary>
        public void SetFacing(bool left)
        {
            if (IsReady) _skeletonAnimation.Skeleton.ScaleX = left ? -1f : 1f;
        }

        /// <summary>Transform do avatar (posicao no mundo), ou null antes de ficar pronto.</summary>
        public Transform AvatarTransform => _skeletonAnimation != null ? _skeletonAnimation.transform : null;

        public bool IsReady => _skeletonAnimation != null && _skeletonAnimation.valid;

        /// <summary>Aparencia em edicao (a mesma de PlayerState; nada e gravado ate o editor salvar).</summary>
        public AvatarAppearance CurrentAppearance => _playerState.Appearance;

        IEnumerable<string> SelectedItemIds()
        {
            foreach (var category in _categories) yield return Appearance.Get(category.key);
        }

        /// <summary>O item existe no manifesto e todas as suas pecas tem skin "Templates/..." no esqueleto.</summary>
        public bool IsItemAvailable(string itemId)
        {
            if (!IsReady) return false;
            if (AvatarCatalog.IsBuiltIn(itemId)) return true;
            if (_available.TryGetValue(itemId, out var cached)) return cached;
            bool ok;
            if (_itemsById.TryGetValue(itemId, out var item))
            {
                ok = item.pieces.Count > 0;
                if (ok) foreach (var piece in item.pieces) if (_skeletonData.FindSkin(SkinOf(piece)) == null) { ok = false; break; }
            }
            else ok = false;
            _available[itemId] = ok;
            return ok;
        }

        /// <summary>Descarta as texturas de roupa que nenhuma categoria atual usa (miniaturas geram e descartam).</summary>
        public void ReleaseUnselected()
        {
            if (!IsReady) return;
            var needed = new HashSet<string>();
            foreach (var id in SelectedItemIds())
                if (_itemsById.TryGetValue(id, out var item))
                    foreach (var piece in item.pieces) needed.Add(piece.template.Substring("Templates/".Length));
            if (_blank == null)
            {
                _blank = new Texture2D(1, 1, TextureFormat.RGBA32, false);
                _blank.SetPixel(0, 0, Color.clear);
                _blank.Apply(false, true);
            }
            foreach (var page in new List<string>(_pageTextures.Keys))
            {
                if (needed.Contains(page)) continue;
                if (_pageTextures[page] != null) Destroy(_pageTextures[page]);
                _materialByPage[page].mainTexture = _blank;
                _pageTextures.Remove(page);
                _pageFileLoaded.Remove(page);
            }
        }

        /// <summary>Troca uma categoria no avatar ja montado (as texturas de todas as variantes foram carregadas na criacao). Nao grava.</summary>
        public void SelectOption(string category, string itemId)
        {
            if (!IsReady || !Appearance.TrySelect(category, itemId)) return;
            RebuildSkin();
            RefreshMesh();
        }

        /// <summary>Troca o indice de cor (pele/olhos) no avatar ja montado. Nao grava.</summary>
        public void SelectColor(string category, int index)
        {
            if (!IsReady || !Appearance.TrySelectColor(category, index)) return;
            RebuildSkin();
            RefreshMesh();
        }

        /// <summary>Troca a cor (paleta General) dos itens _color de uma categoria. Nao grava.</summary>
        public void SelectItemColor(string category, int index)
        {
            if (!IsReady || !Appearance.TrySelectItemColor(category, index)) return;
            RebuildSkin();
            RefreshMesh();
        }

        public int GeneralPaletteCount => _palettes != null ? _palettes.general.Count : 0;
        public Color GeneralSwatch(int index) => _palettes != null ? GeneralColor(index) : Color.white;

        /// <summary>Cor de exibicao (amostra do menu) da entrada da paleta; branco se fora do intervalo.</summary>
        public Color PaletteSwatch(string category, int index)
        {
            var list = category == AvatarCatalog.CategorySkin ? _palettes?.skin : category == AvatarCatalog.CategoryEyes ? _palettes?.eyes : null;
            return list != null && index >= 0 && index < list.Count ? ToColor(list[index].display) : Color.white;
        }

        /// <summary>Aplica uma aparencia inteira (desfazer/refazer/cancelar). Nao grava.</summary>
        public void ApplyAppearance(AvatarAppearance appearance)
        {
            if (!IsReady || appearance == null) return;
            foreach (var category in AvatarCatalog.OptionsByCategory.Keys) Appearance.TrySelect(category, appearance.Get(category));
            Appearance.TrySelectColor(AvatarCatalog.CategorySkin, appearance.SkinIndex);
            Appearance.TrySelectColor(AvatarCatalog.CategoryEyes, appearance.EyesIndex);
            Appearance.ItemColors = appearance.Clone().ItemColors;
            RebuildSkin();
            RefreshMesh();
        }

        // Atualiza a malha no mesmo quadro (necessario antes de Camera.Render para miniaturas).
        void RefreshMesh()
        {
            _skeletonAnimation.Update(0f);
            _skeletonAnimation.LateUpdate();
        }

        void LoadItemTextures(ManifestItem item)
        {
            foreach (var piece in item.pieces)
            {
                var pageName = piece.template.Substring("Templates/".Length);
                if (_pageFileLoaded.TryGetValue(pageName, out var loadedFile) && loadedFile == piece.file) continue;
                var resourceName = System.IO.Path.GetFileNameWithoutExtension(piece.file);
                var source = Resources.Load<Texture2D>("AvatarSpine/Clothing/" + resourceName);
                if (source == null) { Debug.LogError("AvatarGpuRuntime: textura de roupa ausente " + resourceName); continue; }
                var texture = PremultipliedCopy(source);
                Resources.UnloadAsset(source);
                texture.name = pageName;
                if (_pageTextures.TryGetValue(pageName, out var old) && old != null) Destroy(old);
                _materialByPage[pageName].mainTexture = texture;
                _pageTextures[pageName] = texture;
                _pageFileLoaded[pageName] = piece.file;
                _loadedClothingPages.Add(pageName);
            }
        }

        void RebuildSkin()
        {
            var skin = new Skin("avatar-runtime-composite");
            var tints = new Dictionary<Attachment, Color>();
            // Paletas oficiais (AWSpineColorsList): pele = DisplayColor na base e Colors nas sombras; olhos = Colors[0]/[1].
            var skinEntry = _palettes.skin[Mathf.Clamp(Appearance.SkinIndex, 0, _palettes.skin.Count - 1)];
            var eyeEntry = _palettes.eyes[Mathf.Clamp(Appearance.EyesIndex, 0, _palettes.eyes.Count - 1)];
            var skinBase = ToColor(skinEntry.display);
            var skinShadow = ToColor(skinEntry.colors[0].c);
            var earShadow = ToColor(skinEntry.colors[skinEntry.colors.Count > 1 ? 1 : 0].c);
            AddSkin(_skeletonData, skin, tints, "Body_Whites/Body_Whites", skinBase);
            AddSkin(_skeletonData, skin, tints, "Body_Shad/Body_Shad", skinShadow);
            AddSkin(_skeletonData, skin, tints, "Ear_Shad/Ear_Shad", earShadow);
            AddSkin(_skeletonData, skin, tints, "Body_Other/Body_Other", Color.white);
            AddSkin(_skeletonData, skin, tints, "Eyes/1_Color", ToColor(eyeEntry.colors[0].c));
            AddSkin(_skeletonData, skin, tints, "Eyes/1_Color-p", Color.white);

            foreach (var category in _categories)
            {
                if (!_itemsById.TryGetValue(Appearance.Get(category.key), out var item)) continue; // item embutido (boca padrao)
                LoadItemTextures(item);
                // Itens _color: tinta Multiply com a cor escolhida na paleta General (AvatarSpineSkinsColoringConfigs: Single/Multiply).
                var tint = AvatarCatalog.IsColorItem(item.id) ? GeneralColor(Appearance.GetItemColor(AvatarCatalog.ColorKey(category.key))) : Color.white;
                foreach (var piece in item.pieces)
                    AddSkin(_skeletonData, skin, tints, SkinOf(piece), tint);
            }

            _skeletonAnimation.skeleton.SetSkin(skin);
            _skeletonAnimation.skeleton.SetSlotsToSetupPose();
            // Boca: embutida no esqueleto por padrao; um item do SUT traz o proprio anexo "Mouths" (skin Templates/Mouth_N).
            _skeletonAnimation.skeleton.SetAttachment("Mouths", AvatarCatalog.IsBuiltIn(Appearance.MouthId) ? "Body_Outline/Mouth_Regular" : "Mouths");
            // Pecas cujo slot nao tem anexo na pose inicial (sobrancelhas): liga o anexo que o proprio skin do item traz.
            // Nao forca nomes fixos: itens podem ter so um lado, e SetAttachment lancaria excecao (pele ficaria sem tinta).
            foreach (var category in _categories)
            {
                if (AvatarCatalog.IsBuiltIn(Appearance.Get(category.key)) || !_itemsById.TryGetValue(Appearance.Get(category.key), out var placed)) continue;
                foreach (var piece in placed.pieces)
                {
                    var templateSkin = _skeletonData.FindSkin(SkinOf(piece));
                    if (templateSkin == null) continue;
                    foreach (var entry in templateSkin.Attachments)
                    {
                        var slot = _skeletonAnimation.skeleton.Slots.Items[entry.SlotIndex];
                        if (slot.Attachment == null) slot.Attachment = entry.Attachment;
                    }
                }
            }
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

            if (_onClose != null && GUI.Button(new Rect(Screen.width / scale - 230f, 10f, 220f, h), "Voltar"))
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
