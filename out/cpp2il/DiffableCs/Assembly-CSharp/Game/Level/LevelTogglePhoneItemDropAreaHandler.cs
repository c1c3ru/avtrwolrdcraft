namespace Game.Level;

public class LevelTogglePhoneItemDropAreaHandler : MonoBehaviour, ILevelSpawnDuringGameplay
{
	private LevelSingleItemDropArea _dropArea; //Field offset: 0x20
	private bool _didOnReadyPostLoad; //Field offset: 0x28

	public LevelTogglePhoneItemDropAreaHandler() { }

	private void Awake() { }

	private void EnsureOnReadyPostLoad() { }

	private void OnDestroy() { }

	private void OnItemEndDrop(LevelItem levelItem) { }

	private void OnItemPickUp(LevelItem levelItem) { }

	private void OnLevelPostInit() { }

	private void OnReadyPostLoad() { }

	public override void OnSpawnDuringGameplay() { }

	private void SetPhoneToBack(LevelItem levelItem) { }

	private void SetPhoneToFront(LevelItem levelItem) { }

}

