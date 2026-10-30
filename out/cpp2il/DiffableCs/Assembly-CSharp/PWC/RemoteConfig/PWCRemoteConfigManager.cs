namespace PWC.RemoteConfig;

public class PWCRemoteConfigManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass18_0
	{
		public string op; //Field offset: 0x10
		public Dictionary<String, Object> data; //Field offset: 0x18
		public PWCRemoteConfigManager <>4__this; //Field offset: 0x20
		public Action<String> <>9__1; //Field offset: 0x28

		public <>c__DisplayClass18_0() { }

		internal void <Init>b__0() { }

		internal void <Init>b__1(string responseText) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass19_0
	{
		public ZoneBuildingItem buildingItem; //Field offset: 0x10
		public string url; //Field offset: 0x18

		public <>c__DisplayClass19_0() { }

		internal void <DownloadAssets>b__1(ResultType resultType) { }

	}

	[CompilerGenerated]
	private sealed class <Init>d__18 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public PWCRemoteConfigManager <>4__this; //Field offset: 0x20
		private <>c__DisplayClass18_0 <>8__1; //Field offset: 0x28

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
		public <Init>d__18(int <>1__state) { }

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
	private static Action<ZoneBuildingItem, String> OnTextureDownloadedAction; //Field offset: 0x0
	[CompilerGenerated]
	private static PWCRemoteConfigManager <Instance>k__BackingField; //Field offset: 0x8
	[CompilerGenerated]
	private ConfigData <Data>k__BackingField; //Field offset: 0x20
	private bool _isInProgress; //Field offset: 0x28

	public static event Action<ZoneBuildingItem, String> OnTextureDownloadedAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public private ConfigData Data
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private static PWCRemoteConfigManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public PWCRemoteConfigManager() { }

	[CompilerGenerated]
	internal static string <DownloadAssets>g__DownloadTexture|19_0(ZoneBuildingItem buildingItem, string url) { }

	[CompilerGenerated]
	public static void add_OnTextureDownloadedAction(Action<ZoneBuildingItem, String> value) { }

	private void Awake() { }

	private void DownloadAssets(ConfigData configData) { }

	[CompilerGenerated]
	public ConfigData get_Data() { }

	[CompilerGenerated]
	public static PWCRemoteConfigManager get_Instance() { }

	[IteratorStateMachine(typeof(<Init>d__18))]
	private IEnumerator Init() { }

	public static bool IsDataReady() { }

	private void OnDestroy() { }

	private void OnGameResume() { }

	public void RefreshData() { }

	[CompilerGenerated]
	public static void remove_OnTextureDownloadedAction(Action<ZoneBuildingItem, String> value) { }

	[CompilerGenerated]
	private void set_Data(ConfigData value) { }

	[CompilerGenerated]
	private static void set_Instance(PWCRemoteConfigManager value) { }

	private void Start() { }

}

