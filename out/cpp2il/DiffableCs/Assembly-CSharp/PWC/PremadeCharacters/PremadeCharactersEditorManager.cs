namespace PWC.PremadeCharacters;

public class PremadeCharactersEditorManager : AvatarMakerManager
{
	[SerializeField]
	private PremadeCharactersEditorConfigManager _configManager; //Field offset: 0xB0
	[SerializeField]
	private InputField _idInputField; //Field offset: 0xB8

	public PremadeCharactersEditorConfigManager ConfigManager
	{
		 get { } //Length: 8
	}

	public static PremadeCharactersEditorManager Instance
	{
		 get { } //Length: 156
	}

	public PremadeCharactersEditorManager() { }

	public PremadeCharactersEditorConfigManager get_ConfigManager() { }

	public static PremadeCharactersEditorManager get_Instance() { }

}

