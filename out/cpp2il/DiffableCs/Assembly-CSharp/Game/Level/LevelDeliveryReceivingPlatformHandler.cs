namespace Game.Level;

public class LevelDeliveryReceivingPlatformHandler : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_0
	{
		public LevelDeliveryReceivingPlatformHandler <>4__this; //Field offset: 0x10
		public LevelItem item; //Field offset: 0x18

		public <>c__DisplayClass13_0() { }

		internal void <OnLevelPrePostInit>b__0() { }

	}

	[SerializeField]
	private LevelDropArea _nextDropArea; //Field offset: 0x20
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x28
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x30
	[SerializeField]
	private Transform _startTarget; //Field offset: 0x38
	[SerializeField]
	private Transform _endTarget; //Field offset: 0x40
	[SerializeField]
	protected string _conveyorMovmentSoundName; //Field offset: 0x48
	[SerializeField]
	private float _animationDelay; //Field offset: 0x50
	[SerializeField]
	private bool _haveMask; //Field offset: 0x54
	[SerializeField]
	private bool _haveTheSameSkeletonAnimation; //Field offset: 0x55
	private Queue<LevelItem> _allItems; //Field offset: 0x58

	public LevelDeliveryReceivingPlatformHandler() { }

	private void Awake() { }

	protected override string GetBulkDataKey(string sceneName) { }

	private void OnCompletMoveItemToEnd(object obj) { }

	private void OnCompletMoveItemX(object obj) { }

	private void OnDestroy() { }

	private void OnLevelPrePostInit() { }

	private void Start() { }

	private void StartMoveItem(LevelItem levelItem) { }

	public void StartReceivingPlatform() { }

}

