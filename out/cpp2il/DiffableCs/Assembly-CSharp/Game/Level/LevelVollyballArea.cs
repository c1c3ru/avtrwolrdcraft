namespace Game.Level;

public class LevelVollyballArea : LevelCharactersOnlyDropArea
{
	[SerializeField]
	private bool _isNearNet; //Field offset: 0xDA
	[SerializeField]
	private List<LevelVollyballArea> _friendlyVollyballAreas; //Field offset: 0xE0
	[SerializeField]
	private List<LevelVollyballArea> _oppositeVollyballAreas; //Field offset: 0xE8
	public List<LevelCharacter> _charactersList; //Field offset: 0xF0

	public List<LevelCharacter> CharactersList
	{
		 get { } //Length: 8
	}

	public LevelVollyballArea() { }

	public List<LevelCharacter> get_CharactersList() { }

	public List<LevelCharacter> GetAllFriendlyCharacters() { }

	public List<LevelCharacter> GetAllOpponentCharacters() { }

	public List<LevelCharacter> GetAllRelevantCharacters() { }

	public virtual void OnItemEndDrop(LevelItem levelItem) { }

	public virtual void OnItemPickUp(LevelItem levelItem) { }

	protected virtual void OnLevelPostInit() { }

}

