namespace PWC.World;

public class WorldTrain : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <Start>d__5 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public WorldTrain <>4__this; //Field offset: 0x20

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
		public <Start>d__5(int <>1__state) { }

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
	private Transform _startPos; //Field offset: 0x20
	[SerializeField]
	private Transform _goToPos; //Field offset: 0x28
	[SerializeField]
	private float _goToInitialPosTime; //Field offset: 0x30
	[SerializeField]
	private float _goToGoToPosTime; //Field offset: 0x34
	private Vector3 _initialLocalPosition; //Field offset: 0x38

	public WorldTrain() { }

	[CompilerGenerated]
	private void <Animate>b__6_0() { }

	[CompilerGenerated]
	private void <Animate>b__6_1() { }

	private void Animate() { }

	[IteratorStateMachine(typeof(<Start>d__5))]
	private IEnumerator Start() { }

}

