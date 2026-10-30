namespace Game.Level;

public class LevelDeliverySendingPlatformHandler : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass16_0
	{
		public LevelDeliverySendingPlatformHandler <>4__this; //Field offset: 0x10
		public LevelItem levelItem; //Field offset: 0x18
		public Vector3 bottomTarget; //Field offset: 0x20
		public Action <>9__1; //Field offset: 0x30

		public <>c__DisplayClass16_0() { }

		internal void <OnItemEndDrop>b__0() { }

		internal void <OnItemEndDrop>b__1() { }

	}

	internal enum DeliveryType
	{
		Furniture = 0,
		Suitcase = 1,
	}

	[SerializeField]
	protected LevelDropArea _levelDropArea; //Field offset: 0x20
	[SerializeField]
	private SortingGroup _sortingGroup; //Field offset: 0x28
	[SerializeField]
	private DeliveryType _deliveryType; //Field offset: 0x30
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x38
	[SerializeField]
	private Transform _topTarget; //Field offset: 0x40
	[SerializeField]
	private Transform _bottomTarget; //Field offset: 0x48
	[SerializeField]
	protected GameSoundPlayer _soundPlayer; //Field offset: 0x50
	[SerializeField]
	private int _limitNumberOfItems; //Field offset: 0x58
	[SerializeField]
	private LevelDropArea _levelDropAreaWhenCanNotAccept; //Field offset: 0x60
	[SerializeField]
	private bool _haveMask; //Field offset: 0x68
	private int _numberOfItemsOnPlatform; //Field offset: 0x6C
	private string _key; //Field offset: 0x70

	public LevelDeliverySendingPlatformHandler() { }

	private void Awake() { }

	protected override string GetBulkDataKey(DeliveryType deliveryType) { }

	private string GlobalSpawnerGUID() { }

	private void OnDestroy() { }

	private void OnItemEndDrop(LevelItem levelItem) { }

	private void OnLevelPostInit() { }

	private void SendDelivery(TrackEntry trackEntry) { }

}

