namespace PazuCore.Analytics.Internal;

public class AnalyticsAliveTracker : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public AnalyticsAliveTracker <>4__this; //Field offset: 0x10
		public string dataString; //Field offset: 0x18

		public <>c__DisplayClass5_0() { }

		internal void <SaveCurrentTime>b__0() { }

		internal void <SaveCurrentTime>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <TrackAlive>d__4 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public AnalyticsAliveTracker <>4__this; //Field offset: 0x20
		private WaitForSeconds <wait>5__2; //Field offset: 0x28

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
		public <TrackAlive>d__4(int <>1__state) { }

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

	private const string KEY = "PazuCore_Analytics_AliveTracker"; //Field offset: 0x0
	private Coroutine _coroutine; //Field offset: 0x20

	public AnalyticsAliveTracker() { }

	private string GetKey(string key) { }

	public GameTimestamp GetLastAliveSaveTime() { }

	public void ResetTimer() { }

	private void SaveCurrentTime() { }

	[IteratorStateMachine(typeof(<TrackAlive>d__4))]
	private IEnumerator TrackAlive() { }

}

