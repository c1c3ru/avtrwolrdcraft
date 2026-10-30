namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCLocalizedTextMeshPro : MonoBehaviour
{
	[SerializeField]
	protected string _key; //Field offset: 0x20
	[SerializeField]
	protected UnityEventString _onTextSetEvent; //Field offset: 0x28
	protected string _localizedText; //Field offset: 0x30
	[CompilerGenerated]
	private string <LanguageCode>k__BackingField; //Field offset: 0x38
	[CompilerGenerated]
	private TextMeshProUGUI <Text>k__BackingField; //Field offset: 0x40
	[CompilerGenerated]
	private bool <ShouldUseLocalText>k__BackingField; //Field offset: 0x48

	public private string LanguageCode
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public bool ShouldUseLocalText
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public private TextMeshProUGUI Text
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public AFCLocalizedTextMeshPro() { }

	private void Awake() { }

	protected void FitTextComponentToLanguageCode(string languageCode) { }

	[CompilerGenerated]
	public string get_LanguageCode() { }

	[CompilerGenerated]
	public bool get_ShouldUseLocalText() { }

	[CompilerGenerated]
	public TextMeshProUGUI get_Text() { }

	public void GetLocalizedText() { }

	protected override void GetLocalizedTextInternal() { }

	protected override void OnGetLocalizedText() { }

	[CompilerGenerated]
	private void set_LanguageCode(string value) { }

	[CompilerGenerated]
	public void set_ShouldUseLocalText(bool value) { }

	[CompilerGenerated]
	private void set_Text(TextMeshProUGUI value) { }

	public void SetKey(string key) { }

	protected override void SetLocalizedText() { }

}

