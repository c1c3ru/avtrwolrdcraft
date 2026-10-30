namespace Game.Level;

public class LevelPackingMachine : MonoBehaviour
{
	[SerializeField]
	private LevelConveyorDropArea _conveyorDropArea; //Field offset: 0x20
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x28
	[SerializeField]
	private Transform _itemParent; //Field offset: 0x30
	[SerializeField]
	private LevelDropArea _targetDropArea; //Field offset: 0x38
	private LevelItem _currentLevelItem; //Field offset: 0x40
	private bool _isInProgress; //Field offset: 0x48
	private readonly List<LevelItem> _queue; //Field offset: 0x50

	public LevelPackingMachine() { }

	[CompilerGenerated]
	private void <HandleItem>b__13_0(TrackEntry trackEntry) { }

	private void Awake() { }

	private void DropCurrentItemIfExists() { }

	private void HandleItem(LevelItem levelItem) { }

	private void HandleSpineAnimationEvent(TrackEntry trackEntry, Event spineEvent) { }

	private void OnConveyorItemPickUp(LevelItem levelItem) { }

	private void OnConveyorItemStopMoving(LevelConveyorDropArea _, LevelItem levelItem) { }

	private void OnDestroy() { }

}

