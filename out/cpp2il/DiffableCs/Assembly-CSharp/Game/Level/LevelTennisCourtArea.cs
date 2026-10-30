namespace Game.Level;

public class LevelTennisCourtArea : LevelCharactersOnlyDropArea
{
	[CompilerGenerated]
	private struct <>c__DisplayClass19_0
	{
		public LevelCharacter character; //Field offset: 0x0
		public LevelTennisCourtArea <>4__this; //Field offset: 0x8

	}

	[SerializeField]
	private CourtType _courtType; //Field offset: 0xDC
	[SerializeField]
	private bool _isNearNet; //Field offset: 0xE0
	[SerializeField]
	private List<LevelTennisCourtArea> _friendlyTennisCourtAreas; //Field offset: 0xE8
	[SerializeField]
	private List<LevelTennisCourtArea> _oppositeTennisCourtAreas; //Field offset: 0xF0
	[SerializeField]
	private List<Transform> _groundHitPoints; //Field offset: 0xF8
	[SerializeField]
	private List<Transform> _missHitPoints; //Field offset: 0x100
	[SerializeField]
	private string _requiredRacketLabel; //Field offset: 0x108
	private List<LevelCharacter> _charactersList; //Field offset: 0x110

	public List<LevelCharacter> CharactersList
	{
		 get { } //Length: 8
	}

	public List<Transform> GroundHitPoints
	{
		 get { } //Length: 8
	}

	public List<Transform> MissHitPoints
	{
		 get { } //Length: 8
	}

	public CourtType Type
	{
		 get { } //Length: 8
	}

	public LevelTennisCourtArea() { }

	[CompilerGenerated]
	private bool <IsCharacterHoldingRacket>g__IsHoldingRacket|19_0(AvatarHandType handType, ref <>c__DisplayClass19_0 unnamed_param_1) { }

	public List<LevelCharacter> get_CharactersList() { }

	public List<Transform> get_GroundHitPoints() { }

	public List<Transform> get_MissHitPoints() { }

	public CourtType get_Type() { }

	public List<LevelCharacter> GetAllFriendlyCharacters() { }

	public List<LevelCharacter> GetAllOpponentCharacters() { }

	public List<Transform> GetAllOpponentGroundHitPoints() { }

	public List<Transform> GetAllOpponentMissPoints() { }

	public List<LevelCharacter> GetAllRelevantCharacters() { }

	private bool IsCharacterHoldingRacket(LevelCharacter character) { }

	public virtual void OnItemEndDrop(LevelItem levelItem) { }

	public virtual void OnItemPickUp(LevelItem levelItem) { }

	protected virtual void OnLevelPostInit() { }

}

