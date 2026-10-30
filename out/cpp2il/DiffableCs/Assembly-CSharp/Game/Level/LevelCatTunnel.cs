namespace Game.Level;

[RequireComponent(typeof(SkeletonAnimation), typeof(CShape), typeof(GameSoundPlayer))]
public class LevelCatTunnel : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<KeyValuePair`2<Side, LevelCat>, Boolean> <>9__11_0; //Field offset: 0x8
		public static Func<KeyValuePair`2<Side, LevelCat>, Boolean> <>9__14_0; //Field offset: 0x10
		public static Func<KeyValuePair`2<Side, LevelCat>, Boolean> <>9__15_0; //Field offset: 0x18

		private static <>c() { }

		public <>c() { }

		internal bool <OnItemBeginDrop>b__15_0(KeyValuePair<Side, LevelCat> pair) { }

		internal bool <OnItemPickUp>b__14_0(KeyValuePair<Side, LevelCat> pair) { }

		internal bool <OnLevelPostInit>b__11_0(KeyValuePair<Side, LevelCat> pair) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_0
	{
		public LevelCat thisCat; //Field offset: 0x10

		public <>c__DisplayClass12_0() { }

		internal void <LevelCatTunnel_OnBeginEnterTunnelHole>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_1
	{
		public KeyValuePair<Side, LevelCat> cat; //Field offset: 0x10

		public <>c__DisplayClass12_1() { }

		internal void <LevelCatTunnel_OnBeginEnterTunnelHole>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_0
	{
		public LevelDropArea dropArea; //Field offset: 0x10
		public LevelCatTunnel <>4__this; //Field offset: 0x18
		public LevelCat thisCat; //Field offset: 0x20
		public bool fight; //Field offset: 0x28
		public Side trySwitchToSide; //Field offset: 0x2C
		public Side currentSide; //Field offset: 0x30
		public Action <>9__8; //Field offset: 0x38
		public Action <>9__11; //Field offset: 0x40
		public TrackEntryDelegate <>9__12; //Field offset: 0x48
		public Action <>9__13; //Field offset: 0x50
		public Action <>9__14; //Field offset: 0x58
		public Action <>9__16; //Field offset: 0x60
		public Action <>9__7; //Field offset: 0x68

		public <>c__DisplayClass13_0() { }

		internal bool <LevelCatTunnel_OnEndEnterTunnelHole>b__0(KeyValuePair<Side, LevelDropArea> x) { }

		internal void <LevelCatTunnel_OnEndEnterTunnelHole>b__1(TrackEntry _) { }

		internal void <LevelCatTunnel_OnEndEnterTunnelHole>b__11() { }

		internal void <LevelCatTunnel_OnEndEnterTunnelHole>b__12(TrackEntry _) { }

		internal void <LevelCatTunnel_OnEndEnterTunnelHole>b__13() { }

		internal void <LevelCatTunnel_OnEndEnterTunnelHole>b__14() { }

		internal void <LevelCatTunnel_OnEndEnterTunnelHole>b__16() { }

		internal void <LevelCatTunnel_OnEndEnterTunnelHole>b__7() { }

		internal void <LevelCatTunnel_OnEndEnterTunnelHole>b__8() { }

		internal void <LevelCatTunnel_OnEndEnterTunnelHole>g__DropCatOnNewTunnelHole|3(LevelCat cat, Side fromSide, Side toSide, bool setAbandonedHole = true) { }

		internal void <LevelCatTunnel_OnEndEnterTunnelHole>g__EnableCatsCShapes|2() { }

		internal void <LevelCatTunnel_OnEndEnterTunnelHole>g__OnCompletePushBack|15(TrackEntry trackEntry) { }

		internal void <LevelCatTunnel_OnEndEnterTunnelHole>g__OnEventMoveOut|10(TrackEntry trackEntry, Event e) { }

		internal void <LevelCatTunnel_OnEndEnterTunnelHole>g__PopCat|4(LevelCat cat, Side side) { }

		internal void <LevelCatTunnel_OnEndEnterTunnelHole>g__SetTakePlaceAngryOnDropArea|5() { }

		internal void <LevelCatTunnel_OnEndEnterTunnelHole>g__SetTakePlaceNotAngryOnDropArea|6() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_1
	{
		public KeyValuePair<Side, LevelCat> cat; //Field offset: 0x10

		public <>c__DisplayClass13_1() { }

		internal void <LevelCatTunnel_OnEndEnterTunnelHole>b__9() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public KeyValuePair<Side, LevelDropArea> dropAreaWithSide; //Field offset: 0x10
		public LevelCatTunnel <>4__this; //Field offset: 0x20

		public <>c__DisplayClass9_0() { }

		internal void <Awake>b__0(LevelItem item) { }

		internal void <Awake>b__1(LevelItem item) { }

	}

	internal enum Side
	{
		Left = 0,
		Right = 1,
		Top = 2,
	}

	[SerializeField]
	private SerializableDictionaryBase<Side, LevelDropArea> _dropAreas; //Field offset: 0x20
	private readonly Dictionary<Side, Action`1<LevelItem>> _itemBeginDropActions; //Field offset: 0x28
	private readonly Dictionary<Side, Action`1<LevelItem>> _itemPickUpActions; //Field offset: 0x30
	private readonly Dictionary<Side, LevelCat> _tunnelHolesCats; //Field offset: 0x38
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x40
	private CShape _cShape; //Field offset: 0x48
	private bool _listenToPickUpEvent; //Field offset: 0x50
	private GameSoundPlayer _soundPlayer; //Field offset: 0x58

	public LevelCatTunnel() { }

	private void Awake() { }

	private void LevelCatTunnel_OnBeginEnterTunnelHole(LevelCat thisCat, bool fight) { }

	private void LevelCatTunnel_OnEndEnterTunnelHole(LevelCat thisCat, LevelDropArea dropArea, bool fight) { }

	private void OnDestroy() { }

	private void OnItemBeginDrop(Side side, LevelCat cat) { }

	private void OnItemPickUp(Side side, LevelItem _) { }

	private void OnLevelPostInit() { }

}

