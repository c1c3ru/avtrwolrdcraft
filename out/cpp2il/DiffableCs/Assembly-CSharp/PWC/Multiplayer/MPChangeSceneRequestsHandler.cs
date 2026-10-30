namespace PWC.Multiplayer;

public class MPChangeSceneRequestsHandler
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		public MPData_SceneChangeRequest sceneChangeRequestData; //Field offset: 0x10

		public <>c__DisplayClass10_0() { }

		internal bool <ContinueWithSceneChangeRequest>b__0(int x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_0
	{
		public string requestGuid; //Field offset: 0x10

		public <>c__DisplayClass7_0() { }

		internal bool <SetChangeSceneData>b__0(MPChangeSceneCollectedData x) { }

	}

	[CompilerGenerated]
	private sealed class <HandleChangeSceneRequest>d__8 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public MPChangeSceneRequestsHandler <>4__this; //Field offset: 0x20
		private MPChangeSceneCollectedData <data>5__2; //Field offset: 0x28
		private float <innerTimer>5__3; //Field offset: 0x30

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
		public <HandleChangeSceneRequest>d__8(int <>1__state) { }

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

	private const float MAX_WAIT_FOR_DATA_TIME = 30; //Field offset: 0x0
	private const float MAX_WAIT_FOR_SCENE_LOAD_TIME = 10; //Field offset: 0x0
	private readonly List<MPChangeSceneCollectedData> _list; //Field offset: 0x10
	private bool _isRunning; //Field offset: 0x18
	public MonoBehaviour _monoBehaviour; //Field offset: 0x20

	public MPChangeSceneRequestsHandler(MonoBehaviour monoBehaviour) { }

	public void Add(MPChangeSceneCollectedData data) { }

	private bool ContinueWithSceneChangeRequest(MPData_SceneChangeRequest sceneChangeRequestData) { }

	[IteratorStateMachine(typeof(<HandleChangeSceneRequest>d__8))]
	private IEnumerator HandleChangeSceneRequest() { }

	public void SetChangeSceneData(string requestGuid, MPSceneData sceneData, bool shouldSendNowEvenIfHasNoData = false) { }

	private static void StartSceneForPlayer(string sceneName, string requestGuid, MPSceneData sceneData, int targetPlayerUID) { }

}

