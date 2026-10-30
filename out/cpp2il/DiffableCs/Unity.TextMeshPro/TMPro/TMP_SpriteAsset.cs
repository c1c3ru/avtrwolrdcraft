namespace TMPro;

[ExcludeFromPreset]
public class TMP_SpriteAsset : TMP_Asset
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<TMP_SpriteGlyph, UInt32> <>9__40_0; //Field offset: 0x8
		public static Func<TMP_SpriteCharacter, UInt32> <>9__41_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal uint <SortCharacterTable>b__41_0(TMP_SpriteCharacter c) { }

		internal uint <SortGlyphTable>b__40_0(TMP_SpriteGlyph item) { }

	}

	private static HashSet<Int32> k_searchedSpriteAssets; //Field offset: 0x0
	internal Dictionary<Int32, Int32> m_NameLookup; //Field offset: 0x30
	internal Dictionary<UInt32, Int32> m_GlyphIndexLookup; //Field offset: 0x38
	[SerializeField]
	private string m_Version; //Field offset: 0x40
	[SerializeField]
	internal FaceInfo m_FaceInfo; //Field offset: 0x48
	public Texture spriteSheet; //Field offset: 0xA8
	[SerializeField]
	private List<TMP_SpriteCharacter> m_SpriteCharacterTable; //Field offset: 0xB0
	internal Dictionary<UInt32, TMP_SpriteCharacter> m_SpriteCharacterLookup; //Field offset: 0xB8
	[SerializeField]
	private List<TMP_SpriteGlyph> m_SpriteGlyphTable; //Field offset: 0xC0
	internal Dictionary<UInt32, TMP_SpriteGlyph> m_SpriteGlyphLookup; //Field offset: 0xC8
	public List<TMP_Sprite> spriteInfoList; //Field offset: 0xD0
	[SerializeField]
	public List<TMP_SpriteAsset> fallbackSpriteAssets; //Field offset: 0xD8
	internal bool m_IsSpriteAssetLookupTablesDirty; //Field offset: 0xE0

	public internal FaceInfo faceInfo
	{
		 get { } //Length: 16
		internal set { } //Length: 36
	}

	public internal Dictionary<UInt32, TMP_SpriteCharacter> spriteCharacterLookupTable
	{
		 get { } //Length: 36
		internal set { } //Length: 8
	}

	public internal List<TMP_SpriteCharacter> spriteCharacterTable
	{
		 get { } //Length: 36
		internal set { } //Length: 8
	}

	public internal List<TMP_SpriteGlyph> spriteGlyphTable
	{
		 get { } //Length: 8
		internal set { } //Length: 8
	}

	public internal string version
	{
		 get { } //Length: 8
		internal set { } //Length: 8
	}

	public TMP_SpriteAsset() { }

	private void Awake() { }

	public FaceInfo get_faceInfo() { }

	public Dictionary<UInt32, TMP_SpriteCharacter> get_spriteCharacterLookupTable() { }

	public List<TMP_SpriteCharacter> get_spriteCharacterTable() { }

	public List<TMP_SpriteGlyph> get_spriteGlyphTable() { }

	public string get_version() { }

	private Material GetDefaultSpriteMaterial() { }

	public int GetSpriteIndexFromHashcode(int hashCode) { }

	public int GetSpriteIndexFromName(string name) { }

	public int GetSpriteIndexFromUnicode(uint unicode) { }

	public static TMP_SpriteAsset SearchForSpriteByHashCode(TMP_SpriteAsset spriteAsset, int hashCode, bool includeFallbacks, out int spriteIndex) { }

	private static TMP_SpriteAsset SearchForSpriteByHashCodeInternal(TMP_SpriteAsset spriteAsset, int hashCode, bool searchFallbacks, out int spriteIndex) { }

	private static TMP_SpriteAsset SearchForSpriteByHashCodeInternal(List<TMP_SpriteAsset> spriteAssets, int hashCode, bool searchFallbacks, out int spriteIndex) { }

	public static TMP_SpriteAsset SearchForSpriteByUnicode(TMP_SpriteAsset spriteAsset, uint unicode, bool includeFallbacks, out int spriteIndex) { }

	private static TMP_SpriteAsset SearchForSpriteByUnicodeInternal(List<TMP_SpriteAsset> spriteAssets, uint unicode, bool includeFallbacks, out int spriteIndex) { }

	private static TMP_SpriteAsset SearchForSpriteByUnicodeInternal(TMP_SpriteAsset spriteAsset, uint unicode, bool includeFallbacks, out int spriteIndex) { }

	internal void set_faceInfo(FaceInfo value) { }

	internal void set_spriteCharacterLookupTable(Dictionary<UInt32, TMP_SpriteCharacter> value) { }

	internal void set_spriteCharacterTable(List<TMP_SpriteCharacter> value) { }

	internal void set_spriteGlyphTable(List<TMP_SpriteGlyph> value) { }

	internal void set_version(string value) { }

	internal void SortCharacterTable() { }

	internal void SortGlyphAndCharacterTables() { }

	public void SortGlyphTable() { }

	public void UpdateLookupTables() { }

	private void UpgradeSpriteAsset() { }

}

