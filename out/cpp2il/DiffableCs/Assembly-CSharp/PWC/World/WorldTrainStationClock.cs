namespace PWC.World;

public class WorldTrainStationClock : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <SetTime>d__7 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public WorldTrainStationClock <>4__this; //Field offset: 0x20

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
		public <SetTime>d__7(int <>1__state) { }

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

	private const float _hoursToDegrees = 30; //Field offset: 0x0
	private const float _minutesToDegrees = 6; //Field offset: 0x0
	[SerializeField]
	private Transform _hours; //Field offset: 0x20
	[SerializeField]
	private Transform _hoursLight; //Field offset: 0x28
	[SerializeField]
	private Transform _minutes; //Field offset: 0x30
	[SerializeField]
	private Transform _minutesLight; //Field offset: 0x38

	public WorldTrainStationClock() { }

	private void Awake() { }

	[IteratorStateMachine(typeof(<SetTime>d__7))]
	private IEnumerator SetTime() { }

}

