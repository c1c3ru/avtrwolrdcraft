namespace Game.Level;

public class LevelAquariumContainer : LevelConsumerAreaBase
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<LevelItem, Boolean> <>9__11_0; //Field offset: 0x8
		public static Func<LevelItem, LevelFish> <>9__11_1; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal bool <OnLevelPostInit>b__11_0(LevelItem item) { }

		internal LevelFish <OnLevelPostInit>b__11_1(LevelItem item) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass16_0
	{
		public float fishBackTargetY; //Field offset: 0x10
		public LevelAquariumContainer <>4__this; //Field offset: 0x18

		public <>c__DisplayClass16_0() { }

		internal void <MakeFishEatFood>b__0(object obj) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass16_1
	{
		public LevelFish fish; //Field offset: 0x10
		public <>c__DisplayClass16_0 CS$<>8__locals1; //Field offset: 0x18

		public <>c__DisplayClass16_1() { }

		internal void <MakeFishEatFood>b__1(TrackEntry x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass17_0
	{
		public PDPrefab fishFoodInstance; //Field offset: 0x10

		public <>c__DisplayClass17_0() { }

		internal void <EmptyFishFood>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <Fill>d__14 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelAquariumContainer <>4__this; //Field offset: 0x20
		public Color color; //Field offset: 0x28

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <Fill>d__14(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <MakeFishEatFood>d__16 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelAquariumContainer <>4__this; //Field offset: 0x20

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <MakeFishEatFood>d__16(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[SerializeField]
	private PDPrefabReference _fishFoodPrefabRef; //Field offset: 0x58
	[SerializeField]
	private int _maxFilling; //Field offset: 0x60
	[SerializeField]
	private LevelDropArea _aquariumDropArea; //Field offset: 0x68
	private List<PDPrefab> _fishFoodInstances; //Field offset: 0x70
	private List<LevelFish> _fishInAquarium; //Field offset: 0x78
	private Dictionary<LevelFish, Int32> _fishInAquariumTweenId; //Field offset: 0x80
	private int _fishEatingCount; //Field offset: 0x88
	private bool _isFishEating; //Field offset: 0x8C
	private Random _random; //Field offset: 0x90

	public LevelAquariumContainer() { }

	[CompilerGenerated]
	private void <MakeFishEatFood>b__16_2() { }

	public void AddFishFood(Color color) { }

	protected virtual void Awake() { }

	private void EmptyFishFood() { }

	[IteratorStateMachine(typeof(<Fill>d__14))]
	public IEnumerator Fill(Color color) { }

	[IteratorStateMachine(typeof(<MakeFishEatFood>d__16))]
	private IEnumerator MakeFishEatFood() { }

	private void Multiplayer_OnRandomGeneratorInit(int seed, string guidPrefix) { }

	protected virtual void OnDestroy() { }

	private void OnItemEndDrop(LevelItem item) { }

	private void OnItemPickUp(LevelItem item) { }

	private void OnLevelPostInit() { }

}

