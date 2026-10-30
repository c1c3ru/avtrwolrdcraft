namespace PWC.Level;

public class LevelSpineDoorDynamicSortingHandler : MonoBehaviour
{
	internal enum ChangeType
	{
		None = 0,
		BeginAnimation = 1,
		EndAnimation = 2,
	}

	[SerializeField]
	private int _openedSortingOrder; //Field offset: 0x20
	[SerializeField]
	private int _closedSortingOrder; //Field offset: 0x24
	[SerializeField]
	private ChangeType _openChangeType; //Field offset: 0x28
	[SerializeField]
	private ChangeType _closeChangeType; //Field offset: 0x2C
	[SerializeField]
	private LevelSpineDoor _door; //Field offset: 0x30
	[SerializeField]
	private SortingGroup _sortingGroup; //Field offset: 0x38
	[SerializeField]
	private UnityEvent _onOpenChange; //Field offset: 0x40
	[SerializeField]
	private UnityEvent _onCloseChange; //Field offset: 0x48

	public LevelSpineDoorDynamicSortingHandler() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnDoorBeginAnimation(bool isOpening) { }

	private void OnDoorEndAnimation(bool isOpening) { }

	private void OnLevelPostInit() { }

	private void SyncState() { }

}

