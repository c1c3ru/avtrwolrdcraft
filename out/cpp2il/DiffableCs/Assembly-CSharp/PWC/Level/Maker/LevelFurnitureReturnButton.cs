namespace PWC.Level.Maker;

public class LevelFurnitureReturnButton : GameUIElement, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private static Action OnItemClickAction; //Field offset: 0x0
	private LevelMakerFurnitureSpawnItemHandler _levelFurnitureSpawn; //Field offset: 0x28

	public static event Action OnItemClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 184
		[CompilerGenerated]
		 remove { } //Length: 184
	}

	public LevelFurnitureReturnButton() { }

	[CompilerGenerated]
	private void <OnPointerClick>b__4_0() { }

	[CompilerGenerated]
	public static void add_OnItemClickAction(Action value) { }

	public void ChangeTargetItem(LevelMakerFurnitureSpawnItemHandler newFurniture) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	[CompilerGenerated]
	public static void remove_OnItemClickAction(Action value) { }

}

