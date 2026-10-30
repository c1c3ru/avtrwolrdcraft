namespace PWC.Level;

public class LevelSwitchLevelDropArea : LevelDropArea
{
	[SerializeField]
	private LevelType _levelType; //Field offset: 0xD8

	public LevelSwitchLevelDropArea() { }

	protected virtual void Awake() { }

	protected override string GetBulkDataKey(string sceneName) { }

	protected virtual void OnDestroy() { }

	public virtual void OnItemEndDrop(LevelItem levelItem) { }

	protected override void OnItemSpawn(LevelItem levelItem) { }

	private void OnLevelPrePostInit() { }

	protected override void OnMovingItemToOtherLevel(LevelItem item) { }

}

