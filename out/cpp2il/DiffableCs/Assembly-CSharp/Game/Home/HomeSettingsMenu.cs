namespace Game.Home;

public class HomeSettingsMenu : MonoBehaviour
{
	[SerializeField]
	private GameObject _mainPanel; //Field offset: 0x20
	[SerializeField]
	private GameObject _chatPanel; //Field offset: 0x28

	public HomeSettingsMenu() { }

	public void OnBackgroundClick() { }

	public void OnChatButtonClick() { }

	public void OnLangaugeButtonClick(string languageCode) { }

	public void Show() { }

}

