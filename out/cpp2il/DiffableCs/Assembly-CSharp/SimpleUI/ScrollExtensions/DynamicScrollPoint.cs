namespace SimpleUI.ScrollExtensions;

public class DynamicScrollPoint : ScrollPoint
{
	[CompilerGenerated]
	private sealed class <UpdateDistanceDelay>d__3 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public DynamicScrollPoint <>4__this; //Field offset: 0x20

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
		public <UpdateDistanceDelay>d__3(int <>1__state) { }

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

	public BoundFloat OnFocusDistanceChanged; //Field offset: 0x58

	public DynamicScrollPoint() { }

	protected virtual void Awake() { }

	protected virtual void Start() { }

	private void UpdateDistance(Vector2 normalizedPosition) { }

	[IteratorStateMachine(typeof(<UpdateDistanceDelay>d__3))]
	private IEnumerator UpdateDistanceDelay() { }

}

