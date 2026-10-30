namespace TMPro;

[ExcludeFromPreset]
public class TMP_FontAsset : TMP_Asset
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<TMP_Character, UInt32> <>9__124_0; //Field offset: 0x8
		public static Func<Glyph, UInt32> <>9__125_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal uint <SortCharacterTable>b__124_0(TMP_Character c) { }

		internal uint <SortGlyphTable>b__125_0(Glyph c) { }

	}

	private static ProfilerMarker k_ReadFontAssetDefinitionMarker; //Field offset: 0x0
	private static ProfilerMarker k_AddSynthesizedCharactersMarker; //Field offset: 0x8
	private static ProfilerMarker k_TryAddCharacterMarker; //Field offset: 0x10
	private static ProfilerMarker k_TryAddCharactersMarker; //Field offset: 0x18
	private static ProfilerMarker k_UpdateGlyphAdjustmentRecordsMarker; //Field offset: 0x20
	private static ProfilerMarker k_ClearFontAssetDataMarker; //Field offset: 0x28
	private static ProfilerMarker k_UpdateFontAssetDataMarker; //Field offset: 0x30
	private static string s_DefaultMaterialSuffix; //Field offset: 0x38
	private static HashSet<Int32> k_SearchedFontAssetLookup; //Field offset: 0x40
	private static List<TMP_FontAsset> k_FontAssets_FontFeaturesUpdateQueue; //Field offset: 0x48
	private static HashSet<Int32> k_FontAssets_FontFeaturesUpdateQueueLookup; //Field offset: 0x50
	private static List<TMP_FontAsset> k_FontAssets_AtlasTexturesUpdateQueue; //Field offset: 0x58
	private static HashSet<Int32> k_FontAssets_AtlasTexturesUpdateQueueLookup; //Field offset: 0x60
	internal static UInt32[] k_GlyphIndexArray; //Field offset: 0x68
	[SerializeField]
	private string m_Version; //Field offset: 0x30
	[SerializeField]
	internal string m_SourceFontFileGUID; //Field offset: 0x38
	[SerializeField]
	private Font m_SourceFontFile; //Field offset: 0x40
	[SerializeField]
	private AtlasPopulationMode m_AtlasPopulationMode; //Field offset: 0x48
	[SerializeField]
	internal FaceInfo m_FaceInfo; //Field offset: 0x50
	[SerializeField]
	internal List<Glyph> m_GlyphTable; //Field offset: 0xB0
	internal Dictionary<UInt32, Glyph> m_GlyphLookupDictionary; //Field offset: 0xB8
	[SerializeField]
	internal List<TMP_Character> m_CharacterTable; //Field offset: 0xC0
	internal Dictionary<UInt32, TMP_Character> m_CharacterLookupDictionary; //Field offset: 0xC8
	internal Texture2D m_AtlasTexture; //Field offset: 0xD0
	[SerializeField]
	internal Texture2D[] m_AtlasTextures; //Field offset: 0xD8
	[SerializeField]
	internal int m_AtlasTextureIndex; //Field offset: 0xE0
	[SerializeField]
	private bool m_IsMultiAtlasTexturesEnabled; //Field offset: 0xE4
	[SerializeField]
	private bool m_ClearDynamicDataOnBuild; //Field offset: 0xE5
	[SerializeField]
	private List<GlyphRect> m_UsedGlyphRects; //Field offset: 0xE8
	[SerializeField]
	private List<GlyphRect> m_FreeGlyphRects; //Field offset: 0xF0
	[SerializeField]
	private FaceInfo_Legacy m_fontInfo; //Field offset: 0xF8
	[SerializeField]
	public Texture2D atlas; //Field offset: 0x100
	[SerializeField]
	internal int m_AtlasWidth; //Field offset: 0x108
	[SerializeField]
	internal int m_AtlasHeight; //Field offset: 0x10C
	[SerializeField]
	internal int m_AtlasPadding; //Field offset: 0x110
	[SerializeField]
	internal GlyphRenderMode m_AtlasRenderMode; //Field offset: 0x114
	[SerializeField]
	internal List<TMP_Glyph> m_glyphInfoList; //Field offset: 0x118
	[FormerlySerializedAs("m_kerningInfo")]
	[SerializeField]
	internal KerningTable m_KerningTable; //Field offset: 0x120
	[SerializeField]
	internal TMP_FontFeatureTable m_FontFeatureTable; //Field offset: 0x128
	[SerializeField]
	private List<TMP_FontAsset> fallbackFontAssets; //Field offset: 0x130
	[SerializeField]
	internal List<TMP_FontAsset> m_FallbackFontAssetTable; //Field offset: 0x138
	[SerializeField]
	internal FontAssetCreationSettings m_CreationSettings; //Field offset: 0x140
	[SerializeField]
	private TMP_FontWeightPair[] m_FontWeightTable; //Field offset: 0x198
	[SerializeField]
	private TMP_FontWeightPair[] fontWeights; //Field offset: 0x1A0
	public float normalStyle; //Field offset: 0x1A8
	public float normalSpacingOffset; //Field offset: 0x1AC
	public float boldStyle; //Field offset: 0x1B0
	public float boldSpacing; //Field offset: 0x1B4
	public byte italicStyle; //Field offset: 0x1B8
	public byte tabSize; //Field offset: 0x1B9
	internal bool IsFontAssetLookupTablesDirty; //Field offset: 0x1BA
	internal HashSet<Int32> FallbackSearchQueryLookup; //Field offset: 0x1C0
	private List<Glyph> m_GlyphsToRender; //Field offset: 0x1C8
	private List<Glyph> m_GlyphsRendered; //Field offset: 0x1D0
	private List<UInt32> m_GlyphIndexList; //Field offset: 0x1D8
	private List<UInt32> m_GlyphIndexListNewlyAdded; //Field offset: 0x1E0
	internal List<UInt32> m_GlyphsToAdd; //Field offset: 0x1E8
	internal HashSet<UInt32> m_GlyphsToAddLookup; //Field offset: 0x1F0
	internal List<TMP_Character> m_CharactersToAdd; //Field offset: 0x1F8
	internal HashSet<UInt32> m_CharactersToAddLookup; //Field offset: 0x200
	internal List<UInt32> s_MissingCharacterList; //Field offset: 0x208
	internal HashSet<UInt32> m_MissingUnicodesFromFontFile; //Field offset: 0x210

	public internal int atlasHeight
	{
		 get { } //Length: 8
		internal set { } //Length: 8
	}

	public internal int atlasPadding
	{
		 get { } //Length: 8
		internal set { } //Length: 8
	}

	public AtlasPopulationMode atlasPopulationMode
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public internal GlyphRenderMode atlasRenderMode
	{
		 get { } //Length: 8
		internal set { } //Length: 8
	}

	public Texture2D atlasTexture
	{
		 get { } //Length: 160
	}

	public int atlasTextureCount
	{
		 get { } //Length: 12
	}

	public Texture2D[] atlasTextures
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public internal int atlasWidth
	{
		 get { } //Length: 8
		internal set { } //Length: 8
	}

	public Dictionary<UInt32, TMP_Character> characterLookupTable
	{
		 get { } //Length: 36
	}

	public internal List<TMP_Character> characterTable
	{
		 get { } //Length: 8
		internal set { } //Length: 8
	}

	internal bool clearDynamicDataOnBuild
	{
		internal get { } //Length: 8
		internal set { } //Length: 12
	}

	public FontAssetCreationSettings creationSettings
	{
		 get { } //Length: 16
		 set { } //Length: 36
	}

	public FaceInfo faceInfo
	{
		 get { } //Length: 16
		 set { } //Length: 36
	}

	public List<TMP_FontAsset> fallbackFontAssetTable
	{
		 get { } //Length: 8
		 set { } //Length: 16
	}

	public internal TMP_FontFeatureTable fontFeatureTable
	{
		 get { } //Length: 8
		internal set { } //Length: 16
	}

	[Obsolete("The fontInfo property and underlying type is now obsolete. Please use the faceInfo property and FaceInfo type instead.")]
	public FaceInfo_Legacy fontInfo
	{
		 get { } //Length: 8
	}

	public internal TMP_FontWeightPair[] fontWeightTable
	{
		 get { } //Length: 8
		internal set { } //Length: 16
	}

	internal List<GlyphRect> freeGlyphRects
	{
		internal get { } //Length: 8
		internal set { } //Length: 8
	}

	public Dictionary<UInt32, Glyph> glyphLookupTable
	{
		 get { } //Length: 36
	}

	public internal List<Glyph> glyphTable
	{
		 get { } //Length: 8
		internal set { } //Length: 8
	}

	public bool isMultiAtlasTexturesEnabled
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public internal Font sourceFontFile
	{
		 get { } //Length: 8
		internal set { } //Length: 8
	}

	internal List<GlyphRect> usedGlyphRects
	{
		internal get { } //Length: 8
		internal set { } //Length: 8
	}

	public internal string version
	{
		 get { } //Length: 8
		internal set { } //Length: 8
	}

	private static TMP_FontAsset() { }

	public TMP_FontAsset() { }

	internal void AddCharacterToLookupCache(uint unicode, TMP_Character character) { }

	private void AddSynthesizedCharacter(uint unicode, bool isFontFaceLoaded, bool addImmediately = false) { }

	internal void AddSynthesizedCharactersAndFaceMetrics() { }

	private void Awake() { }

	internal void ClearAtlasTextures(bool setAtlasSizeToZero = false) { }

	public void ClearFontAssetData(bool setAtlasSizeToZero = false) { }

	internal void ClearFontAssetDataInternal() { }

	internal void ClearFontAssetTables() { }

	private void CopyListDataToArray(List<T> srcList, ref T[] dstArray) { }

	public static TMP_FontAsset CreateFontAsset(Font font) { }

	public static TMP_FontAsset CreateFontAsset(Font font, int samplingPointSize, int atlasPadding, GlyphRenderMode renderMode, int atlasWidth, int atlasHeight, AtlasPopulationMode atlasPopulationMode = 1, bool enableMultiAtlasSupport = true) { }

	public int get_atlasHeight() { }

	public int get_atlasPadding() { }

	public AtlasPopulationMode get_atlasPopulationMode() { }

	public GlyphRenderMode get_atlasRenderMode() { }

	public Texture2D get_atlasTexture() { }

	public int get_atlasTextureCount() { }

	public Texture2D[] get_atlasTextures() { }

	public int get_atlasWidth() { }

	public Dictionary<UInt32, TMP_Character> get_characterLookupTable() { }

	public List<TMP_Character> get_characterTable() { }

	internal bool get_clearDynamicDataOnBuild() { }

	public FontAssetCreationSettings get_creationSettings() { }

	public FaceInfo get_faceInfo() { }

	public List<TMP_FontAsset> get_fallbackFontAssetTable() { }

	public TMP_FontFeatureTable get_fontFeatureTable() { }

	public FaceInfo_Legacy get_fontInfo() { }

	public TMP_FontWeightPair[] get_fontWeightTable() { }

	internal List<GlyphRect> get_freeGlyphRects() { }

	public Dictionary<UInt32, Glyph> get_glyphLookupTable() { }

	public List<Glyph> get_glyphTable() { }

	public bool get_isMultiAtlasTexturesEnabled() { }

	public Font get_sourceFontFile() { }

	internal List<GlyphRect> get_usedGlyphRects() { }

	public string get_version() { }

	public static string GetCharacters(TMP_FontAsset fontAsset) { }

	public static Int32[] GetCharactersArray(TMP_FontAsset fontAsset) { }

	internal uint GetGlyphIndex(uint unicode) { }

	public bool HasCharacter(char character, bool searchFallbacks = false, bool tryAddCharacter = false) { }

	public bool HasCharacter(int character) { }

	private bool HasCharacter_Internal(uint character, bool searchFallbacks = false, bool tryAddCharacter = false) { }

	public bool HasCharacters(string text) { }

	public bool HasCharacters(string text, out UInt32[] missingCharacters, bool searchFallbacks = false, bool tryAddCharacter = false) { }

	public bool HasCharacters(string text, out List<Char>& missingCharacters) { }

	internal void InitializeCharacterLookupDictionary() { }

	internal void InitializeDictionaryLookupTables() { }

	internal void InitializeGlyphLookupDictionary() { }

	internal void InitializeGlyphPaidAdjustmentRecordsLookupDictionary() { }

	public void ReadFontAssetDefinition() { }

	internal static void RegisterFontAssetForAtlasTextureUpdate(TMP_FontAsset fontAsset) { }

	internal static void RegisterFontAssetForFontFeatureUpdate(TMP_FontAsset fontAsset) { }

	internal void set_atlasHeight(int value) { }

	internal void set_atlasPadding(int value) { }

	public void set_atlasPopulationMode(AtlasPopulationMode value) { }

	internal void set_atlasRenderMode(GlyphRenderMode value) { }

	public void set_atlasTextures(Texture2D[] value) { }

	internal void set_atlasWidth(int value) { }

	internal void set_characterTable(List<TMP_Character> value) { }

	internal void set_clearDynamicDataOnBuild(bool value) { }

	public void set_creationSettings(FontAssetCreationSettings value) { }

	public void set_faceInfo(FaceInfo value) { }

	public void set_fallbackFontAssetTable(List<TMP_FontAsset> value) { }

	internal void set_fontFeatureTable(TMP_FontFeatureTable value) { }

	internal void set_fontWeightTable(TMP_FontWeightPair[] value) { }

	internal void set_freeGlyphRects(List<GlyphRect> value) { }

	internal void set_glyphTable(List<Glyph> value) { }

	public void set_isMultiAtlasTexturesEnabled(bool value) { }

	internal void set_sourceFontFile(Font value) { }

	internal void set_usedGlyphRects(List<GlyphRect> value) { }

	internal void set_version(string value) { }

	private void SetupNewAtlasTexture() { }

	internal void SortAllTables() { }

	internal void SortCharacterTable() { }

	internal void SortFontFeatureTable() { }

	internal void SortGlyphTable() { }

	internal bool TryAddCharacterInternal(uint unicode, out TMP_Character character) { }

	public bool TryAddCharacters(string characters, bool includeFontFeatures = false) { }

	public bool TryAddCharacters(UInt32[] unicodes, out UInt32[] missingUnicodes, bool includeFontFeatures = false) { }

	public bool TryAddCharacters(string characters, out string missingCharacters, bool includeFontFeatures = false) { }

	public bool TryAddCharacters(UInt32[] unicodes, bool includeFontFeatures = false) { }

	internal void TryAddGlyphsToAtlasTextures() { }

	private bool TryAddGlyphsToNewAtlasTexture() { }

	internal bool TryGetCharacter_and_QueueRenderToTexture(uint unicode, out TMP_Character character) { }

	internal void UpdateAtlasTexture() { }

	internal static void UpdateAtlasTexturesForFontAssetsInQueue() { }

	internal void UpdateFontAssetData() { }

	internal static void UpdateFontFeaturesForFontAssetsInQueue() { }

	internal void UpdateGlyphAdjustmentRecords(UInt32[] glyphIndexes) { }

	internal void UpdateGlyphAdjustmentRecords(List<UInt32> glyphIndexes) { }

	internal void UpdateGlyphAdjustmentRecords(List<UInt32> newGlyphIndexes, List<UInt32> allGlyphIndexes) { }

	internal void UpdateGlyphAdjustmentRecords() { }

	internal void UpgradeFontAsset() { }

	private void UpgradeGlyphAdjustmentTableToFontFeatureTable() { }

}

