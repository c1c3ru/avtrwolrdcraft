namespace PWC.AvatarMaker;

public class AvatarMakerExpansionPackCategory : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private static Action<AvatarMakerExpansionPackCategory> <OnExpansionPackCategoryButtonClickAction>k__BackingField; //Field offset: 0x0
	private const string TOOLTIP_CHARACTER = "grown-up "; //Field offset: 0x0
	private const string TOOLTIP_BABY = "baby "; //Field offset: 0x0
	private const string TOOLTIP_TODDLER = "toddler "; //Field offset: 0x0
	private const string TOOLTIP_PREFIX = "Only for "; //Field offset: 0x0
	private const string THUMB_DEFAULT_PATH = "Default"; //Field offset: 0x0
	private const string THUMB_PATH_SUFIX = "_Thumb"; //Field offset: 0x0
	private const string THUMB_PATH_CAR_PREFIX = "PackCategories/CarMaker_"; //Field offset: 0x0
	private const string THUMB_PATH_AVATAR_PREFIX = "PackCategories/AvatarMaker_"; //Field offset: 0x0
	private const string TOOLTIP_AND = "and "; //Field offset: 0x0
	private const string TOOLTIP_SUFFIX = "avatar"; //Field offset: 0x0
	[CompilerGenerated]
	private static AvatarMakerExpansionPackCategory <CurrentExpansionPack>k__BackingField; //Field offset: 0x8
	[CompilerGenerated]
	private static AvatarMakerExpansionPackCategory <DefaultExpasnionPack>k__BackingField; //Field offset: 0x10
	[SerializeField]
	protected Image _image; //Field offset: 0x20
	[SerializeField]
	private string _soundName; //Field offset: 0x28
	[CompilerGenerated]
	private InventoryFlagType <FlagType>k__BackingField; //Field offset: 0x30
	public bool IsExpansionPackDefault; //Field offset: 0x34
	protected RectTransform _indicator; //Field offset: 0x38
	private bool _isClickable; //Field offset: 0x40
	private TooltipUIHandler _tooltipUIHandler; //Field offset: 0x48
	private string _tooltipText; //Field offset: 0x50

	public private static AvatarMakerExpansionPackCategory CurrentExpansionPack
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public private static AvatarMakerExpansionPackCategory DefaultExpasnionPack
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public private InventoryFlagType FlagType
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public static Action<AvatarMakerExpansionPackCategory> OnExpansionPackCategoryButtonClickAction
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		 set { } //Length: 88
	}

	public AvatarMakerExpansionPackCategory() { }

	private void AnimateIndicator() { }

	public void ForceClick() { }

	[CompilerGenerated]
	public static AvatarMakerExpansionPackCategory get_CurrentExpansionPack() { }

	[CompilerGenerated]
	public static AvatarMakerExpansionPackCategory get_DefaultExpasnionPack() { }

	[CompilerGenerated]
	public InventoryFlagType get_FlagType() { }

	[CompilerGenerated]
	public static Action<AvatarMakerExpansionPackCategory> get_OnExpansionPackCategoryButtonClickAction() { }

	public static Sprite GetSpriteFromInventoryFlag(InventoryFlagType inventoryFlagType) { }

	private static string GetThumbPrefix(InventoryFlagType inventoryFlagType) { }

	public void Init(InventoryFlagType inventoryFlagType, RectTransform indicator, bool isExpansionPackDefault, TooltipUIHandler tooltipUIHandler) { }

	private string InitLocalizedTooltipText(InventoryFlagType flagType) { }

	private string InitTooltipText(InventoryFlagType flagType) { }

	public static bool IsCarPack(InventoryFlagType inventoryFlagType) { }

	private void OnDestroy() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private void OnPointerClickInternal() { }

	[CompilerGenerated]
	private static void set_CurrentExpansionPack(AvatarMakerExpansionPackCategory value) { }

	[CompilerGenerated]
	private static void set_DefaultExpasnionPack(AvatarMakerExpansionPackCategory value) { }

	[CompilerGenerated]
	private void set_FlagType(InventoryFlagType value) { }

	[CompilerGenerated]
	public static void set_OnExpansionPackCategoryButtonClickAction(Action<AvatarMakerExpansionPackCategory> value) { }

	private void SetActiveAccordingToCurrentSpineType(InventoryFlagType inventoryFlagType) { }

	public bool TryGetRelevantCategoryInCurrentExpansion(int categoryType, out List<Int32>& relevantCategories, out bool hasMoreThanOneCategoryType) { }

}

