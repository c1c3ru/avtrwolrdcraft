namespace PWC.Level;

public class LevelDragActionPaintItemHandler : LevelDragActionItemHandlerBase
{
	[CompilerGenerated]
	private sealed class <Paint>d__12 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelDragActionPaintItemHandler <>4__this; //Field offset: 0x20

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
		public <Paint>d__12(int <>1__state) { }

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
	private Color _color; //Field offset: 0xA0
	[SerializeField]
	private SpriteRenderer _brushSpriteRenderer; //Field offset: 0xB0
	private readonly List<ILevelPaintableTarget> _currentTargets; //Field offset: 0xB8
	private Coroutine _paintingCoroutine; //Field offset: 0xC0
	private LTexture _brush; //Field offset: 0xC8

	public LevelDragActionPaintItemHandler() { }

	protected virtual void Awake() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	protected virtual bool IsStrictInteractionTest() { }

	protected virtual bool Multiplayer_ShouldSendEnterAndExitEvents() { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

	protected virtual void OnTargetExit(ILevelConsumer consumer, ExitReasonType exitReasonType) { }

	[IteratorStateMachine(typeof(<Paint>d__12))]
	private IEnumerator Paint() { }

	public void SetColor(Color color) { }

}

