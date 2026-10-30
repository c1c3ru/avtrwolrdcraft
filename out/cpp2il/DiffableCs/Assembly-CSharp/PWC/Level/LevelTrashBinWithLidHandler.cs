namespace PWC.Level;

public class LevelTrashBinWithLidHandler : MonoBehaviour
{
	[SerializeField]
	private LevelSpineDoor _door; //Field offset: 0x20
	[SerializeField]
	private GameObject _killArea; //Field offset: 0x28
	[SerializeField]
	private LevelDropArea _doorDropArea; //Field offset: 0x30
	[FormerlySerializedAs("openedLidSortingOrder")]
	[SerializeField]
	private int _openedLidSortingOrder; //Field offset: 0x38
	[FormerlySerializedAs("closedLidSortingOrder")]
	[SerializeField]
	private int _closedLidSortingOrder; //Field offset: 0x3C
	private SortingGroup _doorSortingGroup; //Field offset: 0x40

	public LevelTrashBinWithLidHandler() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnDoorBeginAnimation(bool isOpening) { }

	private void OnDoorEndAnimation(bool isOpening) { }

	private void OnLevelPostInit() { }

	private void Start() { }

	private void SyncState() { }

}

