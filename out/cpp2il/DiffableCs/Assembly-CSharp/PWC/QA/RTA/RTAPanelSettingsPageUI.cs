namespace PWC.QA.RTA;

public abstract class RTAPanelSettingsPageUI : RTAMonoBehaviour
{
	[SerializeField]
	protected GameObject _contentParent; //Field offset: 0x20
	[SerializeField]
	private TMP_Text _label; //Field offset: 0x28
	[SerializeField]
	private TMP_Text _information; //Field offset: 0x30
	[SerializeField]
	private Button _startTestsButton; //Field offset: 0x38

	protected RTAPanelSettingsPageUI() { }

	[CompilerGenerated]
	private void <ShowSetingsPage>g__OnStartTestsButtonPressed|7_0() { }

	protected abstract string GetInformationText_Internal() { }

	protected abstract string GetLabelText_Internal() { }

	public override void HideSetingsPage() { }

	public override void ShowSetingsPage() { }

	public abstract void StartTests() { }

	protected void SyncSettingsPage() { }

}

