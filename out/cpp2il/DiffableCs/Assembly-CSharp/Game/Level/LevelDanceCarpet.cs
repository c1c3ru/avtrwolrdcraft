namespace Game.Level;

public class LevelDanceCarpet : LevelFoldableItem
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<GameObject> <>9__8_1; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <GameSetActive>b__8_1(GameObject light) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public bool value; //Field offset: 0x10

		public <>c__DisplayClass8_0() { }

		internal void <GameSetActive>b__0(GameObject x) { }

	}

	[CompilerGenerated]
	private sealed class <RandomLightsCoroutine>d__9 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelDanceCarpet <>4__this; //Field offset: 0x20
		private int <randomIndex>5__2; //Field offset: 0x28

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
		public <RandomLightsCoroutine>d__9(int <>1__state) { }

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
	private static Action<Boolean> OnGameSetActiveAction; //Field offset: 0x0
	[SerializeField]
	private Transform _danceCarpetArea; //Field offset: 0x390
	[SerializeField]
	private List<GameObject> _onGameObjects; //Field offset: 0x398
	[SerializeField]
	private List<GameObject> _randomLights; //Field offset: 0x3A0

	public static event Action<Boolean> OnGameSetActiveAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public LevelDanceCarpet() { }

	[CompilerGenerated]
	public static void add_OnGameSetActiveAction(Action<Boolean> value) { }

	public void GameSetActive(bool value) { }

	protected virtual void OnLevelPostInit() { }

	[IteratorStateMachine(typeof(<RandomLightsCoroutine>d__9))]
	private IEnumerator RandomLightsCoroutine() { }

	[CompilerGenerated]
	public static void remove_OnGameSetActiveAction(Action<Boolean> value) { }

	protected virtual void ToggleState() { }

}

