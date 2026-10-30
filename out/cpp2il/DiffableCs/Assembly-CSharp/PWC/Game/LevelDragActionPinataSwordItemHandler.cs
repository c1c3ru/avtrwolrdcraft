namespace PWC.Game;

public class LevelDragActionPinataSwordItemHandler : LevelDragActionItemHandlerBase
{
	[CompilerGenerated]
	private sealed class <LookAtPiniata>d__4 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelDragActionPinataSwordItemHandler <>4__this; //Field offset: 0x20

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
		public <LookAtPiniata>d__4(int <>1__state) { }

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

	private LevelPinataArea _currentPinata; //Field offset: 0xA0
	private Vector2 _piniataPos; //Field offset: 0xA8
	private bool _isInAreaOfPinata; //Field offset: 0xB0

	public LevelDragActionPinataSwordItemHandler() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	[IteratorStateMachine(typeof(<LookAtPiniata>d__4))]
	private IEnumerator LookAtPiniata() { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

	protected virtual void OnTargetExit(ILevelConsumer consumer, ExitReasonType exitReasonType) { }

	private void ResetSword() { }

}

