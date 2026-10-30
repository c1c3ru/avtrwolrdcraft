namespace PWC.AvatarSpine;

public class CharacterSpineSkinsManager : AvatarSpineSkinsManagerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_0
	{
		public CharacterSpineSkinsManager <>4__this; //Field offset: 0x10
		public Action<String> onRemoveAction; //Field offset: 0x18

		public <>c__DisplayClass12_0() { }

		internal void <PostRemoveSkinInternal>b__0(CharacterCategoryType categoryTypeToRemove) { }

		internal void <PostRemoveSkinInternal>b__1(CharacterCategoryType categoryTypeToRemove) { }

		internal void <PostRemoveSkinInternal>b__2(CharacterCategoryType categoryTypeToRemove) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public CharacterSpineSkinsManager <>4__this; //Field offset: 0x10
		public Action<String> onRemoveAction; //Field offset: 0x18

		public <>c__DisplayClass8_0() { }

		internal void <PreRemoveSkinInternal>b__0(CharacterCategoryType characterCategoryTypeToRemove) { }

	}

	private Dictionary<Int32, String> DEFAULT_SKIN_NAMES_BY_CATEGORY_TYPE; //Field offset: 0xB8
	private readonly HashSet<Int32> _requiredCategoryTypes; //Field offset: 0xC0

	public CharacterSpineSkinsManager() { }

	[CompilerGenerated]
	private bool <RemoveSkinChainEvent>g__HasBottom|11_2() { }

	[CompilerGenerated]
	private bool <RemoveSkinChainEvent>g__HasOnepiece|11_0() { }

	[CompilerGenerated]
	private bool <RemoveSkinChainEvent>g__HasShirt|11_1() { }

	protected virtual void GetMaterialConfig(string skinName, int categoryType, bool isColorable, out AvatarSpineColoringConfig coloringConfig) { }

	protected virtual int GetParentCategory(int categoryType) { }

	protected virtual int GetParentColorCategoryType(int categoryType) { }

	public virtual HashSet<Int32> GetRequiredCategoryTypes() { }

	protected virtual bool GetSkinsDataColorTest(int categoryType) { }

	protected virtual int GetSUTSystemCategoryKey(int categoryType) { }

	protected virtual Dictionary<Int32, String> InitDefaultSkinNamesByCategoryType() { }

	protected virtual void PerformSkinDataMigration(ref SkinData skinData) { }

	protected virtual void PostRemoveSkinInternal(int categoryType, Action<String> onRemoveAction) { }

	protected virtual void PreRemoveSkinInternal(int categoryType, Action<String> onRemoveAction) { }

	protected virtual void RemoveSkinChainEvent(int categoryType) { }

	protected virtual void RemoveSkinInternal(int categoryType, string skinName) { }

	protected virtual bool ShouldUseSUTSystem(int categoryType) { }

	protected virtual bool TryAddEyesSkinInternal(int categoryType, string skinName, AvatarSpineColoringConfig coloringConfig, Color[] colors, string previousEyesSkinName) { }

	protected virtual bool TryColorSkinInternal(int categoryType, string skinName, Color[] colors) { }

	protected virtual bool TryGetSkinInternal(int categoryType, string skinName, out Skin skin) { }

	protected virtual bool TrySUTColorSkinInternal(int categoryType, string skinName, Action<Material> initMaterial, List<Skin> addedSkins, List<Material> addedMaterials, Color[] colors) { }

}

