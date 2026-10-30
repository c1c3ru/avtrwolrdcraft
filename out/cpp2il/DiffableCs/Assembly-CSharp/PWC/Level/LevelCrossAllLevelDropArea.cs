namespace PWC.Level;

public class LevelCrossAllLevelDropArea : LevelDropArea, IHasCrossSceneObjectGuid, ICrossLevelsDrop
{
	[SerializeField]
	private bool _canConsumeAvatars; //Field offset: 0xD8
	[SerializeField]
	private bool _shouldZeroYForAllAvatar; //Field offset: 0xD9
	private string _sceneGuid; //Field offset: 0xE0

	public LevelCrossAllLevelDropArea() { }

	protected virtual void Awake() { }

	public virtual bool CanConsumeCharacters() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

	protected override string GetBulkDataKey() { }

	private void LoadFromBulkData(bool needToUpdateAvatars) { }

	protected virtual void OnDestroy() { }

	private void OnGameResume() { }

	private void OnLevelPrePostInit() { }

	public void OnPreSaveProgress(Scene scene) { }

}

