namespace PWC.Multiplayer;

public class MPMoveAvatarRequestsHandler
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public string moveAvatarGuid; //Field offset: 0x10

		public <>c__DisplayClass6_0() { }

		internal bool <SetMoveAvatarData>b__0(MPMoveAvatarCollectedData x) { }

	}

	[CompilerGenerated]
	private sealed class <HandleMoveAvatarRequest>d__7 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public MPMoveAvatarRequestsHandler <>4__this; //Field offset: 0x20

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
		public <HandleMoveAvatarRequest>d__7(int <>1__state) { }

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

	private const float WAIT_TIME = 3; //Field offset: 0x0
	private readonly List<MPMoveAvatarCollectedData> _list; //Field offset: 0x10
	private bool _isRunning; //Field offset: 0x18
	public MonoBehaviour _monoBehaviour; //Field offset: 0x20

	public MPMoveAvatarRequestsHandler(MonoBehaviour monoBehaviour) { }

	public void Add(MPMoveAvatarCollectedData data) { }

	[IteratorStateMachine(typeof(<HandleMoveAvatarRequest>d__7))]
	private IEnumerator HandleMoveAvatarRequest() { }

	public void SetMoveAvatarData(string moveAvatarGuid, MPAvatarData avatarData) { }

}

