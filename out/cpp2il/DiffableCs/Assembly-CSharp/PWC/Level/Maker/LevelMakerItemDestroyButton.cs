namespace PWC.Level.Maker;

public class LevelMakerItemDestroyButton : GameUIElement
{
	[CompilerGenerated]
	private static Action<ILevelMakerDeletableByUIItem> OnClickAction; //Field offset: 0x0
	[SerializeField]
	private UGCDeleteItemMessage _ugcDeleteItemMessage; //Field offset: 0x28
	private ILevelMakerDeletableByUIItem _target; //Field offset: 0x30

	public static event Action<ILevelMakerDeletableByUIItem> OnClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public LevelMakerItemDestroyButton() { }

	[CompilerGenerated]
	public static void add_OnClickAction(Action<ILevelMakerDeletableByUIItem> value) { }

	public void OnButtonClick() { }

	protected virtual void OnDisable() { }

	private void PerformClick() { }

	[CompilerGenerated]
	public static void remove_OnClickAction(Action<ILevelMakerDeletableByUIItem> value) { }

	public void SetTargetItem(ILevelMakerDeletableByUIItem target) { }

}

