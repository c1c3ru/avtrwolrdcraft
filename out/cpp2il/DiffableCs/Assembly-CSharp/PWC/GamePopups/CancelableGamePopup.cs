namespace PWC.GamePopups;

public class CancelableGamePopup : GamePopup
{
	[CompilerGenerated]
	private Action OnInstanceCancelAction; //Field offset: 0x48

	public event Action OnInstanceCancelAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public CancelableGamePopup() { }

	[CompilerGenerated]
	public void add_OnInstanceCancelAction(Action value) { }

	protected virtual bool OnAndroidBack() { }

	public void OnCancelButtonPress() { }

	[CompilerGenerated]
	public void remove_OnInstanceCancelAction(Action value) { }

}

