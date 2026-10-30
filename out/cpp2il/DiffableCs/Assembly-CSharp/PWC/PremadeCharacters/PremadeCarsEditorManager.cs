namespace PWC.PremadeCharacters;

public class PremadeCarsEditorManager : CarMakerManager
{
	[SerializeField]
	private PremadeCharactersEditorConfigManager _configManager; //Field offset: 0xB0
	[SerializeField]
	private InputField _idInputField; //Field offset: 0xB8

	public PremadeCharactersEditorConfigManager ConfigManager
	{
		 get { } //Length: 8
	}

	public static PremadeCarsEditorManager Instance
	{
		 get { } //Length: 160
	}

	public PremadeCarsEditorManager() { }

	public PremadeCharactersEditorConfigManager get_ConfigManager() { }

	public static PremadeCarsEditorManager get_Instance() { }

}

