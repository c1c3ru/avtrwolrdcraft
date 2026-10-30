namespace PWC.QA.RTA;

public abstract class RTAPanelIndexesSettingsPageUI : RTAPanelSettingsPageUI
{
	[SerializeField]
	private InputField _startIndexInputField; //Field offset: 0x40
	[SerializeField]
	private InputField _endIndexInputField; //Field offset: 0x48
	protected int _currentStartIndex; //Field offset: 0x50
	protected int _currentEndIndex; //Field offset: 0x54

	protected RTAPanelIndexesSettingsPageUI() { }

	[CompilerGenerated]
	private void <ShowSetingsPage>b__6_0(string newValue) { }

	[CompilerGenerated]
	private void <ShowSetingsPage>b__6_1(string newValue) { }

	[CompilerGenerated]
	private void <ShowSetingsPage>g__OnNewValue|6_2(string newValue, int maxValue, int minValue, ref InputField inputField, ref int index) { }

	protected virtual string GetInformationText_Internal() { }

	public virtual void HideSetingsPage() { }

	protected abstract int MaxCount_Internal() { }

	public virtual void ShowSetingsPage() { }

}

