namespace PWC.AvatarSpine;

public class DogSpineSkinsManager : AvatarSpineSkinsManagerBase, IHasBreed
{
	[CompilerGenerated]
	private string <Breed>k__BackingField; //Field offset: 0xB8
	private Dictionary<Int32, String> DEFAULT_SKIN_NAMES_BY_CATEGORY_TYPE; //Field offset: 0xC0
	private readonly HashSet<Int32> _requiredCategoryTypes; //Field offset: 0xC8

	public override string Breed
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public DogSpineSkinsManager() { }

	[CompilerGenerated]
	public override string get_Breed() { }

	protected virtual SpineType GetDefaultSpineType() { }

	protected virtual void GetMaterialConfig(string skinName, int categoryType, bool isColorable, out AvatarSpineColoringConfig coloringConfig) { }

	protected virtual int GetParentCategory(int categoryType) { }

	protected virtual int GetParentColorCategoryType(int categoryType) { }

	public virtual HashSet<Int32> GetRequiredCategoryTypes() { }

	public virtual float GetSizeScaleFactor() { }

	protected virtual bool GetSkinsDataColorTest(int categoryType) { }

	protected virtual int GetSUTSystemCategoryKey(int categoryType) { }

	protected virtual Dictionary<Int32, String> InitDefaultSkinNamesByCategoryType() { }

	protected virtual void OnLoadInitialSkin(SkinData skinData) { }

	protected virtual void PerformSkinDataMigration(ref SkinData skinData) { }

	protected virtual void PostRemoveSkinInternal(int categoryType, Action<String> onRemoveAction) { }

	protected virtual void PreRemoveSkinInternal(int categoryType, Action<String> onRemoveAction) { }

	protected virtual void RemoveSkinChainEvent(int categoryType) { }

	protected virtual void RemoveSkinInternal(int categoryType, string skinName) { }

	[CompilerGenerated]
	public override void set_Breed(string value) { }

	protected virtual bool ShouldUseSUTSystem(int categoryType) { }

	protected virtual bool TryAddEyesSkinInternal(int categoryType, string skinName, AvatarSpineColoringConfig coloringConfig, Color[] colors, string previousEyesSkinName) { }

	protected virtual bool TryColorSkinInternal(int categoryType, string skinName, Color[] colors) { }

	protected virtual bool TryGetSkinInternal(int categoryType, string skinName, out Skin skin) { }

	protected virtual bool TryOverrideAddSkinParameters(ref int categoryType, ref string skinName) { }

	protected virtual bool TrySUTColorSkinInternal(int categoryType, string skinName, Action<Material> initMaterial, List<Skin> addedSkins, List<Material> addedMaterials, Color[] colors) { }

}

