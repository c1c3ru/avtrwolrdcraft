namespace PazuCore.AF.ActionBar;

public class LibraryButton : ToggleBase
{
	[CompilerGenerated]
	private static Action OnClickAction; //Field offset: 0x0

	public static event Action OnClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 184
		[CompilerGenerated]
		 remove { } //Length: 184
	}

	public LibraryButton() { }

	[CompilerGenerated]
	public static void add_OnClickAction(Action value) { }

	protected virtual void OnSelected(bool byUserInput) { }

	protected virtual void OnValueChangedOverride(bool value) { }

	[CompilerGenerated]
	public static void remove_OnClickAction(Action value) { }

}

