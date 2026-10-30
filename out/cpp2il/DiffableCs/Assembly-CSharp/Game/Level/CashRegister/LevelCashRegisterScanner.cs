namespace Game.Level.CashRegister;

public class LevelCashRegisterScanner : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<LevelItem> <>9__8_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <Awake>b__8_0(LevelItem x) { }

	}

	[SerializeField]
	protected LevelCashRegisterMonitor _monitor; //Field offset: 0x20
	[SerializeField]
	protected LevelDragActionArea _dragActionArea; //Field offset: 0x28
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x30
	[SerializeField]
	private Sprite _onSprite; //Field offset: 0x38
	[SerializeField]
	private Sprite _offSprite; //Field offset: 0x40
	private float TIME_BETWEEN_SCANS; //Field offset: 0x48
	private int _bleepTweenID; //Field offset: 0x4C
	private float _lastScanTime; //Field offset: 0x50

	public LevelCashRegisterScanner() { }

	[CompilerGenerated]
	private void <ScanItem>b__11_0() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnItemEnter(LevelItem levelItem) { }

	private void OnItemExit(LevelItem levelItem, ExitReasonType exitReasonType) { }

	public void ScanItem(LevelItem levelItem) { }

}

