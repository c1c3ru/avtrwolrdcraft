namespace UnityEngine.Purchasing.Extension;

[AddComponentMenu(null)]
[HideInInspector]
internal class UnityUtil : MonoBehaviour, IUtil
{
	[CompilerGenerated]
	private sealed class <DelayedCoroutine>d__48 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public int delay; //Field offset: 0x20
		public UnityUtil <>4__this; //Field offset: 0x28
		public IEnumerator coroutine; //Field offset: 0x30

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
		public <DelayedCoroutine>d__48(int <>1__state) { }

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

	private static readonly List<Action> s_Callbacks; //Field offset: 0x0
	private static bool s_CallbacksPending; //Field offset: 0x8
	private static readonly List<RuntimePlatform> s_PcControlledPlatforms; //Field offset: 0x10
	private readonly List<Action`1<Boolean>> pauseListeners; //Field offset: 0x20

	public override string cloudProjectId
	{
		 get { } //Length: 80
	}

	public override DateTime currentTime
	{
		 get { } //Length: 80
	}

	public override string deviceModel
	{
		 get { } //Length: 8
	}

	public override string deviceName
	{
		 get { } //Length: 8
	}

	public override DeviceType deviceType
	{
		 get { } //Length: 8
	}

	public override string deviceUniqueIdentifier
	{
		 get { } //Length: 8
	}

	public override string gameVersion
	{
		 get { } //Length: 80
	}

	public override bool isEditor
	{
		 get { } //Length: 80
	}

	public override string operatingSystem
	{
		 get { } //Length: 8
	}

	public override string persistentDataPath
	{
		 get { } //Length: 80
	}

	public override RuntimePlatform platform
	{
		 get { } //Length: 80
	}

	public override float screenDpi
	{
		 get { } //Length: 8
	}

	public override int screenHeight
	{
		 get { } //Length: 8
	}

	public override string screenOrientation
	{
		 get { } //Length: 104
	}

	public override int screenWidth
	{
		 get { } //Length: 8
	}

	public override ulong sessionId
	{
		 get { } //Length: 100
	}

	public override string unityVersion
	{
		 get { } //Length: 80
	}

	public override string userId
	{
		 get { } //Length: 100
	}

	private static UnityUtil() { }

	public UnityUtil() { }

	public override void AddPauseListener(Action<Boolean> runnable) { }

	[IteratorStateMachine(typeof(<DelayedCoroutine>d__48))]
	private IEnumerator DelayedCoroutine(IEnumerator coroutine, int delay) { }

	public static T FindInstanceOfType() { }

	public override string get_cloudProjectId() { }

	public override DateTime get_currentTime() { }

	public override string get_deviceModel() { }

	public override string get_deviceName() { }

	public override DeviceType get_deviceType() { }

	public override string get_deviceUniqueIdentifier() { }

	public override string get_gameVersion() { }

	public override bool get_isEditor() { }

	public override string get_operatingSystem() { }

	public override string get_persistentDataPath() { }

	public override RuntimePlatform get_platform() { }

	public override float get_screenDpi() { }

	public override int get_screenHeight() { }

	public override string get_screenOrientation() { }

	public override int get_screenWidth() { }

	public override ulong get_sessionId() { }

	public override string get_unityVersion() { }

	public override string get_userId() { }

	public override T[] GetAnyComponentsOfType() { }

	public override object GetWaitForSeconds(int seconds) { }

	public override bool IsClassOrSubclass(Type potentialBase, Type potentialDescendant) { }

	public static T LoadResourceInstanceOfType() { }

	public void OnApplicationPause(bool paused) { }

	public static bool PcPlatform() { }

	public override void RunOnMainThread(Action runnable) { }

	private void Start() { }

	private override object Uniject.IUtil.InitiateCoroutine(IEnumerator start) { }

	private override void Uniject.IUtil.InitiateCoroutine(IEnumerator start, int delay) { }

	private void Update() { }

}

