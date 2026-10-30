namespace Game.Level;

public class LevelStageTrigger : LevelStationaryItem, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private static Action<StageThemeType> OnStageTriggerClickAction; //Field offset: 0x0
	[SerializeField]
	private StageThemeType _stageTriggerType; //Field offset: 0x60
	private bool _isOn; //Field offset: 0x64
	private float _offYPosition; //Field offset: 0x68
	private bool _hasPersistentData; //Field offset: 0x6C
	private bool _isInteractable; //Field offset: 0x6D

	public static event Action<StageThemeType> OnStageTriggerClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public LevelStageTrigger() { }

	[CompilerGenerated]
	private void <TriggerSetActive>b__12_0() { }

	[CompilerGenerated]
	public static void add_OnStageTriggerClickAction(Action<StageThemeType> value) { }

	protected virtual void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnDestroy() { }

	private void OnLevelPostInit() { }

	public override void OnPointerClick(PointerEventData _) { }

	private void OnStageTriggerClick(StageThemeType stageTriggerType) { }

	[CompilerGenerated]
	public static void remove_OnStageTriggerClickAction(Action<StageThemeType> value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void TriggerSetActive() { }

}

