namespace PWC.PremadeCharacters;

public class PremadeCharactersEditorConfigManager : MonoBehaviour
{
	[SerializeField]
	private GameObject _togglePrefab; //Field offset: 0x20
	[SerializeField]
	private GameObject _seperatorPrefab; //Field offset: 0x28
	private AvatarSpineConfig _currentConfig; //Field offset: 0x30

	public PremadeCharactersEditorConfigManager() { }

}

