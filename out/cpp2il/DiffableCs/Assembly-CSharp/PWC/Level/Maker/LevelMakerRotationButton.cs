namespace PWC.Level.Maker;

public class LevelMakerRotationButton : GameUIElement, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private static Action OnItemClickAction; //Field offset: 0x0
	private ILevelMakerRotatableByUIItem _currentObjectHandler; //Field offset: 0x28

	public static event Action OnItemClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 184
		[CompilerGenerated]
		 remove { } //Length: 184
	}

	public LevelMakerRotationButton() { }

	[CompilerGenerated]
	public static void add_OnItemClickAction(Action value) { }

	private void Awake() { }

	private void OnDestroy() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private void OnRotatingItemByUIButton(ILevelMakerRotatableByUIItem target) { }

	[CompilerGenerated]
	public static void remove_OnItemClickAction(Action value) { }

	public void SetTargetItem(ILevelMakerRotatableByUIItem newRotating) { }

}

