namespace PazuCore.PazuCloud;

public class PazuCloudOfflineManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_0
	{
		public PazuCloudOfflineManager <>4__this; //Field offset: 0x10
		public Action<Response> onFinish; //Field offset: 0x18

		public <>c__DisplayClass12_0() { }

		internal void <GetClientState>b__0(ClientStateResponse response) { }

	}

	[CompilerGenerated]
	private sealed class <OfflineTimer>d__10 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public PazuCloudOfflineManager <>4__this; //Field offset: 0x20
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
		public <OfflineTimer>d__10(int <>1__state) { }

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
	private sealed class <Start>d__6 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public PazuCloudOfflineManager <>4__this; //Field offset: 0x20

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
		public <Start>d__6(int <>1__state) { }

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

	private static float _offlineTimer; //Field offset: 0x0
	private const float OFFLINE_DURATION_LIMIT = 43200; //Field offset: 0x0
	private const float TIMER_INTERVAL = 60; //Field offset: 0x0
	private bool _didInit; //Field offset: 0x20
	private bool _isTryingToGetClientState; //Field offset: 0x21

	public PazuCloudOfflineManager() { }

	[CompilerGenerated]
	private void <CheckOffline>b__11_0(Response response) { }

	[CompilerGenerated]
	private void <ShowOfflineMessage>b__13_0() { }

	[CompilerGenerated]
	private void <ShowOfflineMessage>b__13_1(Response response) { }

	public static float AddToOfflineTimer(float seconds) { }

	private void Awake() { }

	private void CheckOffline() { }

	private void GetClientState(Action<Response> onFinish) { }

	private void Init() { }

	public static bool IsOfflineAndReachedLimit() { }

	public static void LoadOfflineTimer() { }

	[IteratorStateMachine(typeof(<OfflineTimer>d__10))]
	private IEnumerator OfflineTimer() { }

	private void OnDestroy() { }

	public void OnGamePause() { }

	public void OnGameResume() { }

	private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode) { }

	public static void ResetTimer() { }

	public static void SaveOfflineTimer() { }

	private void ShowOfflineMessage() { }

	[IteratorStateMachine(typeof(<Start>d__6))]
	private IEnumerator Start() { }

}

