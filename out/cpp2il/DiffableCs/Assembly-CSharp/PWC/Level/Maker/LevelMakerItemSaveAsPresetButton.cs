namespace PWC.Level.Maker;

public class LevelMakerItemSaveAsPresetButton : GameUIElement, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private static Action<LevelMakerCustomizationObjectHandlerBase, HashSet`1<String>> OnClickAction; //Field offset: 0x0
	private LevelMakerCustomizationObjectHandlerBase _target; //Field offset: 0x28

	public static event Action<LevelMakerCustomizationObjectHandlerBase, HashSet`1<String>> OnClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public LevelMakerItemSaveAsPresetButton() { }

	[CompilerGenerated]
	public static void add_OnClickAction(Action<LevelMakerCustomizationObjectHandlerBase, HashSet`1<String>> value) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	[CompilerGenerated]
	public static void remove_OnClickAction(Action<LevelMakerCustomizationObjectHandlerBase, HashSet`1<String>> value) { }

	public void SetTargetItem(LevelMakerCustomizationObjectHandlerBase target) { }

}

