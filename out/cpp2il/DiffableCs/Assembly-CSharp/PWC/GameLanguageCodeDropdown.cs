namespace PWC;

public class GameLanguageCodeDropdown : MonoBehaviour
{
	[SerializeField]
	private Dropdown _dropdown; //Field offset: 0x20
	private List<String> _optionsTexts; //Field offset: 0x28
	private List<String> _optionsValues; //Field offset: 0x30

	public GameLanguageCodeDropdown() { }

	private void Awake() { }

	private void OnValueChanged(int index) { }

}

