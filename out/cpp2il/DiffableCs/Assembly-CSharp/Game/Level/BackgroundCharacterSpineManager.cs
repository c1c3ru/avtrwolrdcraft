namespace Game.Level;

public class BackgroundCharacterSpineManager : CharacterSpineSkinsManager
{
	[SerializeField]
	private int _backgroundCharacterID; //Field offset: 0xC8
	[SerializeField]
	private List<String> _additionalSkinNames; //Field offset: 0xD0
	[SerializeField]
	private List<CharacterCategoryType> _categoryTypes; //Field offset: 0xD8
	private string _defaultIdleAnimation; //Field offset: 0xE0

	public BackgroundCharacterSpineManager() { }

	public void SetAnimation(string newAnimation) { }

	private void Start() { }

}

