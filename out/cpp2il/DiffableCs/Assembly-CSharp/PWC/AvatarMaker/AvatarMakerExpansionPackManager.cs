namespace PWC.AvatarMaker;

public class AvatarMakerExpansionPackManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass14_0
	{
		public InventorySkinsBuildData skinsBuildData; //Field offset: 0x10
		public List<InventoryFlagType> flagsWithCurrentSpineType; //Field offset: 0x18
		public List<InventoryFlagType> flagsWithoutCurrentSpineType; //Field offset: 0x20

		public <>c__DisplayClass14_0() { }

		internal bool <InitAvailableExpansionPacks>b__0(InventoryFlagType flag) { }

	}

	public static InventoryFlagType CurrentExpansionPackToPress; //Field offset: 0x0
	[SerializeField]
	private AvatarMakerExpansionPackCategory _expansionPackCategory; //Field offset: 0x20
	[SerializeField]
	private RectTransform _expansionPackCategoriesParent; //Field offset: 0x28
	[SerializeField]
	private RectTransform _expansionPackIndicator; //Field offset: 0x30
	[SerializeField]
	private RectTransform _expansionPackIndicatorForDefaultCategory; //Field offset: 0x38
	[SerializeField]
	private RectTransform _expansionPackArea; //Field offset: 0x40
	[SerializeField]
	private AvatarMakerExpansionPackCategory _defaultExpansionPackCategory; //Field offset: 0x48
	[SerializeField]
	private RectTransform _storeButtonUp; //Field offset: 0x50
	[SerializeField]
	private TooltipUIHandler _tooltipUIHandler; //Field offset: 0x58
	private List<AvatarMakerExpansionPackCategory> _availableExpansionPacks; //Field offset: 0x60

	public AvatarMakerExpansionPackManager() { }

	private AvatarMakerExpansionPackCategory AddExpansionPackCategory(InventoryFlagType flag) { }

	private void AnimateIndicators(AvatarMakerExpansionPackCategory category) { }

	public List<AvatarMakerExpansionPackCategory> GetAvailableExpansionPackCategories() { }

	public void Init() { }

	private AvatarMakerExpansionPackCategory InitAvailableExpansionPacks() { }

	private void OnDestroy() { }

	private void PressOnCurrentExpanisonPack(AvatarMakerExpansionPackCategory currentExpansionPack) { }

}

