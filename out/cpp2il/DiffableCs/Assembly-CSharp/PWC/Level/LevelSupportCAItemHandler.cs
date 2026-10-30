namespace PWC.Level;

public class LevelSupportCAItemHandler : MonoBehaviour, ILevelItemDetachFromParentListener, ILevelSpawnDuringGameplay
{
	private LevelItem _levelItem; //Field offset: 0x20
	private bool _didAddExistingCAHandlers; //Field offset: 0x28

	public LevelSupportCAItemHandler() { }

	private void AddExistingCADropAreasHandlers() { }

	private void Awake() { }

	private void OnBeforeDetachFromParent(LevelItem levelItem, Transform parent) { }

	private void OnDestroy() { }

	private void OnEndDropOnRestArea(LevelAvatarRestAreaBase restArea) { }

	private void OnEndLand(LevelDropArea dropArea) { }

	private void OnLevelPostInit() { }

	private override void PWC.Level.ILevelItemDetachFromParentListener.OnChildItemDetachUnderSelfHierarchy(LevelItem levelItem) { }

	private override void PWC.Level.ILevelSpawnDuringGameplay.OnSpawnDuringGameplay() { }

}

