namespace PWC.Level;

public class LevelCrossLevelDropArea : LevelDropArea, IHasCrossSceneObjectGuid, ICrossLevelsDrop
{
	private const string TRANSPORTER = "transporter"; //Field offset: 0x0
	private const int NO_LEVEL_INDEX = -10; //Field offset: 0x0
	[SerializeField]
	private LevelType[] _levelType; //Field offset: 0xD8
	[SerializeField]
	private bool _canConsumeNonAvatars; //Field offset: 0xE0
	private bool _isTransporter; //Field offset: 0xE1
	private string _sceneGuid; //Field offset: 0xE8
	private bool _isMovingToNextLevel; //Field offset: 0xF0
	private int _nextLevelIndex; //Field offset: 0xF4

	public LevelType[] LevelType
	{
		 get { } //Length: 8
	}

	public LevelCrossLevelDropArea() { }

	protected virtual void Awake() { }

	public virtual bool CanConsumeCharacters() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

	public LevelType[] get_LevelType() { }

	protected override string GetBulkDataKey(string sceneName) { }

	public bool GetIsTransporter() { }

	protected virtual void OnDestroy() { }

	private void OnLevelPrePostInit() { }

	private void OnPreSaveProgress(Scene scene) { }

	public void SetNextFloor(int index) { }

}

