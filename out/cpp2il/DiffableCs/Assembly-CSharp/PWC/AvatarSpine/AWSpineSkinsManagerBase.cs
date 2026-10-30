namespace PWC.AvatarSpine;

public abstract class AWSpineSkinsManagerBase : AvatarSpineMaterialsManager
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<KeyValuePair`2<Material, Material>, Boolean> <>9__13_3; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <AddSkin>b__13_3(KeyValuePair<Material, Material> matsPair) { }

	}

	protected Dictionary<Int32, String> _defaultSkinNamesByCategoryType; //Field offset: 0x58
	protected readonly Dictionary<Int32, String> _skinNameByCategoryType; //Field offset: 0x60
	protected readonly Dictionary<Int32, Color[]> _skinColorsByCategoryType; //Field offset: 0x68
	private readonly Dictionary<Int32, String> _skinNameForStoredColorsByCategoryType; //Field offset: 0x70
	private readonly Dictionary<Int32, List`1<Skin>> _sutSystemSkins; //Field offset: 0x78
	protected readonly Dictionary<Int32, List`1<Material>> _sutSystemMaterials; //Field offset: 0x80
	private Action<Material> _sutInitGradientMaterial; //Field offset: 0x88
	private Action<Material> _sutInitSingleColortMaterial; //Field offset: 0x90
	private Action<Material> _sutInitMultiColortMaterial; //Field offset: 0x98
	[CompilerGenerated]
	private SpineType <SpineType>k__BackingField; //Field offset: 0xA0

	public SpineType SpineType
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	protected AWSpineSkinsManagerBase() { }

	[CompilerGenerated]
	private void <AddSkin>b__13_0(Material material) { }

	[CompilerGenerated]
	private void <AddSkin>b__13_1(Material material) { }

	[CompilerGenerated]
	private void <AddSkin>b__13_2(Material material) { }

	[CompilerGenerated]
	private void <RemoveAllSkins>b__31_0(int categoryType) { }

	public override bool AddSkin(int categoryType, string skinName, Action<String> onSkinRemoveAction = null, bool isRecursiveCall = false) { }

	protected void ClearStoredColorsOfSkin(int categoryType, string skinName) { }

	public override void ColorSkin(int categoryType, Color[] colors) { }

	public void ForceSkinNameForCategoryType(int categoryType, string skinName) { }

	public void ForgetSkinColors(int categoryType) { }

	[CompilerGenerated]
	public SpineType get_SpineType() { }

	protected Color[] GetDefaultColors(int categoryType) { }

	public IReadOnlyDictionary<Int32, String> GetDefaultSkinNamesByCategoryType() { }

	protected abstract void GetMaterialConfig(string skinName, int categoryType, bool isColorable, out AvatarSpineColoringConfig coloringConfig) { }

	protected abstract int GetParentCategory(int categoryType) { }

	protected abstract int GetParentColorCategoryType(int categoryType) { }

	public IReadOnlyDictionary<Int32, String> GetSkinNameByCategoryType() { }

	protected List<SkinData> GetSkinsData() { }

	protected abstract bool GetSkinsDataColorTest(int categoryType) { }

	protected abstract int GetSUTSystemCategoryKey(int categoryType) { }

	protected abstract Dictionary<Int32, String> InitDefaultSkinNamesByCategoryType() { }

	protected bool IsCategoryTypeActive(int categoryType) { }

	public bool IsColorable(string skinName) { }

	public override bool IsColorable(int categoryType) { }

	public bool IsSkinActive(int categoryType, string skinName) { }

	protected bool IsStoredColorsBelongToSkin(int categoryType, string skinName) { }

	protected override void PerformSkinDataMigration(ref SkinData skinData) { }

	protected abstract void PostRemoveSkinInternal(int categoryType, Action<String> onRemoveAction) { }

	protected abstract void PreRemoveSkinInternal(int categoryType, Action<String> onRemoveAction) { }

	public void RemoveAllSkins() { }

	public override bool RemoveSkin(int categoryType, bool initiateChainEvent, Action<String> onRemoveAction = null) { }

	protected abstract void RemoveSkinChainEvent(int categoryType) { }

	protected abstract void RemoveSkinInternal(int categoryType, string skinName) { }

	[CompilerGenerated]
	protected void set_SpineType(SpineType value) { }

	protected abstract bool ShouldUseSUTSystem(int categoryType) { }

	public void SkinSetTransparent(int categoryType, bool value) { }

	protected void StoreSkinColors(int categoryType, string skinName, Color[] colors) { }

	protected abstract bool TryAddEyesSkinInternal(int categoryType, string skinName, AvatarSpineColoringConfig coloringConfig, Color[] colors, string previousEyesSkinName) { }

	protected abstract bool TryColorSkinInternal(int categoryType, string skinName, Color[] colors) { }

	public bool TryGetDefaultSkin(int categoryType, out int defaultCategoryType, out string defaultSkinName) { }

	protected override HashSet<String> TryGetExcludedSkins(string skinName) { }

	public bool TryGetSkin(string skinName, out Skin skin) { }

	public bool TryGetSkinColor(int categoryType, out Color[] colors) { }

	protected abstract bool TryGetSkinInternal(int categoryType, string skinName, out Skin skin) { }

	public bool TryGetSkinName(int categoryType, out string skinName) { }

	protected override bool TryOverrideAddSkinParameters(ref int categoryType, ref string skinName) { }

	protected abstract bool TrySUTColorSkinInternal(int categoryType, string skinName, Action<Material> initMaterial, List<Skin> addedSkins, List<Material> addedMaterials, Color[] colors) { }

}

