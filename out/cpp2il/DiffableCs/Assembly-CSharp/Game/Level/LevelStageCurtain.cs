namespace Game.Level;

public class LevelStageCurtain : LevelSpineCurtain
{
	[CompilerGenerated]
	private static Action<StageThemeType> OnStageCurtainClosedAction; //Field offset: 0x0
	private bool _triggerEventOnEndAnimation; //Field offset: 0xD0
	private StageThemeType _currentStageTriggerType; //Field offset: 0xD4

	public static event Action<StageThemeType> OnStageCurtainClosedAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public LevelStageCurtain() { }

	[CompilerGenerated]
	public static void add_OnStageCurtainClosedAction(Action<StageThemeType> value) { }

	protected virtual void Awake() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnDestroy() { }

	protected virtual void OnEndAnimation() { }

	private void OnStageTriggerClick(StageThemeType stageTriggerType) { }

	[CompilerGenerated]
	public static void remove_OnStageCurtainClosedAction(Action<StageThemeType> value) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

