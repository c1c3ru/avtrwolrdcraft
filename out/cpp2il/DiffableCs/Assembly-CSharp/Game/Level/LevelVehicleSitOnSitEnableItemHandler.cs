namespace Game.Level;

public class LevelVehicleSitOnSitEnableItemHandler : MonoBehaviour, ILevelSpawnDuringGameplay
{
	private LevelItem _levelItem; //Field offset: 0x20
	private bool _didOnReadyPostLoad; //Field offset: 0x28
	private LevelDropArea _detachedDropArea; //Field offset: 0x30
	private bool _isEnabledSitting; //Field offset: 0x38

	public LevelVehicleSitOnSitEnableItemHandler() { }

	[CompilerGenerated]
	private void <OverrideBasicDrop>b__11_0() { }

	private void Awake() { }

	private void EnsureOnReadyPostLoad() { }

	private void OnDestroy() { }

	private void OnItemDetachFromParent(LevelItem item, Transform parent) { }

	private void OnItemEndLand(LevelDropArea dropArea) { }

	private void OnLevelPostInit() { }

	private void OnReadyPostLoad() { }

	public override void OnSpawnDuringGameplay() { }

	private bool OverrideBasicDrop(LevelItem item, PointerEventData pointerEventData) { }

}

