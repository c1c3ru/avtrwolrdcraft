namespace PazuCore.EndSession;

public class EndSessionCanvas : SceneButtonsCanvasBase
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Boolean> <>9__8_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <Start>b__8_0() { }

	}

	[CompilerGenerated]
	private sealed class <Start>d__8 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public EndSessionCanvas <>4__this; //Field offset: 0x20

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
		public <Start>d__8(int <>1__state) { }

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
	private EndSessionCardsController <MyCardsController>k__BackingField; //Field offset: 0x30
	private GameObject _moreGamesButton; //Field offset: 0x38
	private GameObject _rateUsWidget; //Field offset: 0x40
	private bool _useNewEndSession; //Field offset: 0x48

	public private EndSessionCardsController MyCardsController
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public EndSessionCanvas() { }

	protected virtual void Awake() { }

	public void ClearBottomLeft() { }

	protected virtual void CreateDefaultButtons() { }

	[CompilerGenerated]
	public EndSessionCardsController get_MyCardsController() { }

	private void InstantiateCardsController() { }

	[CompilerGenerated]
	private void set_MyCardsController(EndSessionCardsController value) { }

	[IteratorStateMachine(typeof(<Start>d__8))]
	private IEnumerator Start() { }

}

