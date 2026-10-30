namespace Game.Level;

public class LevelUnflipableChildOfMakerItemHandler : MonoBehaviour, ILevelSpawnDuringGameplay
{
	[SerializeField]
	private Transform childObject; //Field offset: 0x20
	private LevelMakerItem _levelMakerItem; //Field offset: 0x28
	private bool _didOnReadyPostLoad; //Field offset: 0x30
	private Vector3 childStartScale; //Field offset: 0x34

	public LevelUnflipableChildOfMakerItemHandler() { }

	private void Awake() { }

	private void EnsureOnReadyPostLoad() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void OnReadyPostLoad() { }

	public override void OnSpawnDuringGameplay() { }

	private void OnSyncIsFlippedState(LevelMakerItem levelItem, bool isFlipped) { }

}

