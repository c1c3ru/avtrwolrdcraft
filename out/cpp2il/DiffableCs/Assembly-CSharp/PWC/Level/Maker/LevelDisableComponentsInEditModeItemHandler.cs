namespace PWC.Level.Maker;

public class LevelDisableComponentsInEditModeItemHandler : MonoBehaviour, ILevelSpawnDuringGameplay
{
	private ILevelMakerDisabledWhileInEditMode[] _componentsDisabledWhileInEditMode; //Field offset: 0x20
	private bool _isInMakerMode; //Field offset: 0x28
	private LevelItem _levelItem; //Field offset: 0x30

	public LevelDisableComponentsInEditModeItemHandler() { }

	private void Awake() { }

	private void LevelMakerManager_OnMakerModeChangedAction(bool state) { }

	private void OnDestroy() { }

	private void OnEnterMakerMode() { }

	private void OnExitMakerMode() { }

	private void OnLevelPostInit() { }

	protected override void OnReadyPostLoad() { }

	private override void PWC.Level.ILevelSpawnDuringGameplay.OnSpawnDuringGameplay() { }

	public void SetMakerMode(bool isMakerMode) { }

}

