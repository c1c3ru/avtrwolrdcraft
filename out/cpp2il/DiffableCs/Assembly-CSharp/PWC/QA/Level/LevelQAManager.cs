namespace PWC.QA.Level;

public class LevelQAManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<LevelCharacter> <>9__7_0; //Field offset: 0x8
		public static Action<LevelItem> <>9__7_1; //Field offset: 0x10
		public static Func<Int32, Boolean> <>9__7_7; //Field offset: 0x18
		public static Action<LevelCharacter> <>9__7_5; //Field offset: 0x20

		private static <>c() { }

		public <>c() { }

		internal void <Init>b__7_0(LevelCharacter character) { }

		internal void <Init>b__7_1(LevelItem item) { }

		internal void <Init>b__7_5(LevelCharacter character) { }

		internal bool <Init>b__7_7(int x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_0
	{
		public HashSet<Type> passedTypes; //Field offset: 0x10
		public List<LevelCharacter> characters; //Field offset: 0x18
		public Dictionary<LevelCharacter, Int32> indexes; //Field offset: 0x20
		public LevelQAManager <>4__this; //Field offset: 0x28

		public <>c__DisplayClass7_0() { }

		internal bool <Init>b__2(PDPrefab item) { }

		internal void <Init>b__6(LevelCharacter character) { }

		internal void <Init>g__PlayAnimations|3() { }

		internal void <Init>g__RunOnCharacters|4(Action<LevelCharacter> action) { }

	}

	[CompilerGenerated]
	private struct <>c__DisplayClass7_1
	{
		public LevelItem levelItem; //Field offset: 0x0

	}

	[CompilerGenerated]
	private sealed class <Init>d__7 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelQAManager <>4__this; //Field offset: 0x20
		private <>c__DisplayClass7_0 <>8__1; //Field offset: 0x28
		private List<PDPrefab> <itemsPrefabs>5__2; //Field offset: 0x30
		private List<Int32> <babiesIds>5__3; //Field offset: 0x38
		private List<Int32> <ids>5__4; //Field offset: 0x40
		private Bounds <bounds>5__5; //Field offset: 0x48
		private int <charactersCount>5__6; //Field offset: 0x60
		private Dictionary<LevelCharacter, Vector2> <charactersPositions>5__7; //Field offset: 0x68
		private int <nextItemIndex>5__8; //Field offset: 0x70
		private int <i>5__9; //Field offset: 0x74
		private Enumerator<LevelCharacter> <>7__wrap9; //Field offset: 0x78
		private LevelCharacter <character>5__11; //Field offset: 0x90

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
		public <Init>d__7(int <>1__state) { }

		private void <>m__Finally1() { }

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
	private sealed class <Start>d__6 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelQAManager <>4__this; //Field offset: 0x20

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
		public <Start>d__6(int <>1__state) { }

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
	private static LevelQAManager <Instance>k__BackingField; //Field offset: 0x0

	public private static LevelQAManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public LevelQAManager() { }

	[CompilerGenerated]
	internal static void <Init>g__CallSpawnDuringGameplayIfPossible|7_8(ref <>c__DisplayClass7_1 unnamed_param_0) { }

	private void Awake() { }

	[CompilerGenerated]
	public static LevelQAManager get_Instance() { }

	[IteratorStateMachine(typeof(<Init>d__7))]
	private IEnumerator Init() { }

	private void OnDestroy() { }

	[CompilerGenerated]
	private static void set_Instance(LevelQAManager value) { }

	[IteratorStateMachine(typeof(<Start>d__6))]
	private IEnumerator Start() { }

	private void SwitchHands(LevelCharacter character) { }

	private bool TryPutInHand(LevelCharacter character, LevelItem levelItem, AvatarHandType handType) { }

}

