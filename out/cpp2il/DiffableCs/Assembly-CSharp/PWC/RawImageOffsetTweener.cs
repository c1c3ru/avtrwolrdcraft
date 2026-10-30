namespace PWC;

public class RawImageOffsetTweener : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <Animate>d__5 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public RawImageOffsetTweener <>4__this; //Field offset: 0x20

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
		public <Animate>d__5(int <>1__state) { }

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
	private RawImage _rawImage; //Field offset: 0x20
	[SerializeField]
	private Vector2 _speed; //Field offset: 0x28
	private Coroutine _coroutine; //Field offset: 0x30

	public RawImageOffsetTweener() { }

	[IteratorStateMachine(typeof(<Animate>d__5))]
	private IEnumerator Animate() { }

	private void OnDisable() { }

	private void OnEnable() { }

}

