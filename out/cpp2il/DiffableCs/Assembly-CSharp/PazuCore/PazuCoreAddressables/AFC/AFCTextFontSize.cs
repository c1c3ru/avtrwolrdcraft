namespace PazuCore.PazuCoreAddressables.AFC;

[RequireComponent(typeof(AFCLocalizedText))]
public class AFCTextFontSize : MonoBehaviour
{
	[SerializeField]
	protected string _languageCode; //Field offset: 0x20
	[SerializeField]
	protected int _fontSize; //Field offset: 0x28
	private AFCLocalizedText _localizedText; //Field offset: 0x30
	[CompilerGenerated]
	private bool <ShouldUseLocalText>k__BackingField; //Field offset: 0x38

	public bool ShouldUseLocalText
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public AFCTextFontSize() { }

	private void Awake() { }

	[CompilerGenerated]
	public bool get_ShouldUseLocalText() { }

	[CompilerGenerated]
	public void set_ShouldUseLocalText(bool value) { }

	private void SetFontSize() { }

	private void Start() { }

}

