namespace PWC.Level;

public class LevelCrossAllLevelSitArea : LevelSitArea, IHasCrossSceneObjectGuid
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public int avatarID; //Field offset: 0x10

		public <>c__DisplayClass5_0() { }

		internal bool <OnLevelPrePostInit>b__0(ILevelAvatar x) { }

	}

	private string _sceneGuid; //Field offset: 0x88
	private ILevelAvatar _avatar; //Field offset: 0x90

	public LevelCrossAllLevelSitArea() { }

	protected virtual void Awake() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

	protected override string GetBulkDataKey() { }

	protected virtual void OnDestroy() { }

	private void OnLevelPrePostInit() { }

	public void OnPreSaveProgress(Scene scene) { }

}

