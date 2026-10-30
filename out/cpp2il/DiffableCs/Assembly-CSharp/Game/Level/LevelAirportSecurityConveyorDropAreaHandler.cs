namespace Game.Level;

public class LevelAirportSecurityConveyorDropAreaHandler : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass23_0
	{
		public LevelAirportSecurityConveyorDropAreaHandler <>4__this; //Field offset: 0x10
		public LevelItem levelItem; //Field offset: 0x18

		public <>c__DisplayClass23_0() { }

		internal void <MoveItemBeforeScan>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass24_0
	{
		public LevelAirportSecurityConveyorDropAreaHandler <>4__this; //Field offset: 0x10
		public LevelItem levelItem; //Field offset: 0x18
		public Action <>9__1; //Field offset: 0x20

		public <>c__DisplayClass24_0() { }

		internal void <ScanItem>b__0() { }

		internal void <ScanItem>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass25_0
	{
		public LevelAirportSecurityConveyorDropAreaHandler <>4__this; //Field offset: 0x10
		public LevelItem levelItem; //Field offset: 0x18

		public <>c__DisplayClass25_0() { }

		internal void <MoveItemAfterScan>b__0() { }

	}

	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x20
	[SerializeField]
	private float _xRayStartXPosition; //Field offset: 0x28
	[SerializeField]
	private float _endXPosition; //Field offset: 0x2C
	[SerializeField]
	private LevelDropArea _endDropArea; //Field offset: 0x30
	[SerializeField]
	private GameObject _xRay; //Field offset: 0x38
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x40
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x48
	[SerializeField]
	private float _speed; //Field offset: 0x50
	[SerializeField]
	protected string _ConveyorMovmentSoundName; //Field offset: 0x58
	[SerializeField]
	protected string _startScanSoundName; //Field offset: 0x60
	[SerializeField]
	protected string _scanLoopSoundName; //Field offset: 0x68
	[SerializeField]
	protected string _endScanSoundName; //Field offset: 0x70
	[SerializeField]
	protected LevelSitArea _sitArea; //Field offset: 0x78
	[SerializeField]
	protected LevelCADropAreaHandlerWithData _levelCADropAreaHandlerWithData; //Field offset: 0x80
	private List<LevelItem> _itemsOnConveryorBeforeScan; //Field offset: 0x88
	private List<LevelItem> _itemsOnConveryorAfterScan; //Field offset: 0x90
	private bool _isScanning; //Field offset: 0x98
	private string securityGuardShirt; //Field offset: 0xA0

	public LevelAirportSecurityConveyorDropAreaHandler() { }

	private void Awake() { }

	private void MoveItemAfterScan(LevelItem levelItem) { }

	private void MoveItemBeforeScan(LevelItem levelItem) { }

	private void OnDestroy() { }

	private void OnItemEndDrop(LevelItem levelItem) { }

	private void OnItemPickUp(LevelItem levelItem) { }

	private void OnLevelPostInit() { }

	private void ScanItem(LevelItem levelItem) { }

}

