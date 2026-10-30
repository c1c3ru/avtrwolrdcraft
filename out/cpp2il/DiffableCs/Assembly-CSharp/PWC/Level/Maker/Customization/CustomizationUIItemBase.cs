namespace PWC.Level.Maker.Customization;

public abstract class CustomizationUIItemBase : GameUIElement, IPointerClickHandler, IEventSystemHandler
{
	protected const int INDEX_FOR_SELECTED_INIT_TEST = 0; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<CustomizationUIItemBase> OnItemClickAction; //Field offset: 0x0
	[SerializeField]
	protected Image _outline; //Field offset: 0x28
	protected LevelMakerCustomizationHandlerBase[] _handlers; //Field offset: 0x30
	protected LevelMakerCustomizationObjectHandlerBase _objectHandler; //Field offset: 0x38
	protected string _category; //Field offset: 0x40
	private readonly Color UNSELECTED_COLOR; //Field offset: 0x48
	private readonly Color SELECTED_COLOR; //Field offset: 0x58

	public static event Action<CustomizationUIItemBase> OnItemClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	protected CustomizationUIItemBase() { }

	[CompilerGenerated]
	public static void add_OnItemClickAction(Action<CustomizationUIItemBase> value) { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnItemClick(CustomizationUIItemBase item) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	[CompilerGenerated]
	public static void remove_OnItemClickAction(Action<CustomizationUIItemBase> value) { }

	protected override void SetSelected(bool value) { }

}

