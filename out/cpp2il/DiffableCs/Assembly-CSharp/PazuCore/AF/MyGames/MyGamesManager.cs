namespace PazuCore.AF.MyGames;

public class MyGamesManager : AddressablesFeatureBase
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Boolean> <>9__18_0; //Field offset: 0x8
		public static Func<Boolean> <>9__18_1; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal bool <LoadCachedOrDefaultData>b__18_0() { }

		internal bool <LoadCachedOrDefaultData>b__18_1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass26_0
	{
		public MyGamesManager <>4__this; //Field offset: 0x10
		public string op; //Field offset: 0x18
		public Action<MyGamesSuggestionsResponse> onResponse; //Field offset: 0x20

		public <>c__DisplayClass26_0() { }

		internal void <GetSuggestionsFromCloud>b__0(string responseText) { }

	}

	[CompilerGenerated]
	private sealed class <GetSuggestionsIfNeededCoroutine>d__25 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public MyGamesManager <>4__this; //Field offset: 0x20
		public List<Int32> gameList; //Field offset: 0x28

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
		public <GetSuggestionsIfNeededCoroutine>d__25(int <>1__state) { }

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
	private sealed class <LoadCachedOrDefaultData>d__18 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public MyGamesManager <>4__this; //Field offset: 0x20
		private string <dataString>5__2; //Field offset: 0x28

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
		public <LoadCachedOrDefaultData>d__18(int <>1__state) { }

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

	private static class Keys
	{
		public const string DATA = "PazuCore_MyGames_Data"; //Field offset: 0x0
		public const string LAST_BUILD_NUMBER = "PazuCore_MyGames_LastBuildNumber"; //Field offset: 0x0

	}

	public const string MY_LATEST_GAME_KEY = "PazuCore_MyLatestGame"; //Field offset: 0x0
	[CompilerGenerated]
	private static MyGamesManager <Instance>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private MyGamesSuggestionsData <CurrentSuggestionsData>k__BackingField; //Field offset: 0x78
	private bool _isGettingSuggestionsDataFromServer; //Field offset: 0x80
	private MyGamesSuggestionsData _backupSuggestionsData; //Field offset: 0x88
	private string _backupSuggestionsJson; //Field offset: 0x90
	private bool _isBackupData; //Field offset: 0x98

	public private MyGamesSuggestionsData CurrentSuggestionsData
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private static MyGamesManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public bool IsFeatureLoaded
	{
		 get { } //Length: 224
	}

	public MyGamesManager() { }

	[CompilerGenerated]
	private void <GetSuggestionsIfNeededCoroutine>b__25_0(MyGamesSuggestionsResponse response) { }

	protected virtual bool AllowNonGameScreenOrientation() { }

	protected virtual void Awake() { }

	[CompilerGenerated]
	public MyGamesSuggestionsData get_CurrentSuggestionsData() { }

	[CompilerGenerated]
	public static MyGamesManager get_Instance() { }

	public bool get_IsFeatureLoaded() { }

	protected virtual string GetFallbackResourcesPath() { }

	protected virtual string GetFeatureCloudResponseKey() { }

	protected virtual string GetFeatureKey() { }

	public virtual AddressablesFeatureType GetFeatureType() { }

	private void GetSuggestionsFromCloud(List<Int32> gameIds, Action<MyGamesSuggestionsResponse> onResponse) { }

	public void GetSuggestionsIfNeeded(List<Int32> gameList) { }

	[IteratorStateMachine(typeof(<GetSuggestionsIfNeededCoroutine>d__25))]
	private IEnumerator GetSuggestionsIfNeededCoroutine(List<Int32> gameList) { }

	public virtual void Init(bool didChangeVersion) { }

	[IteratorStateMachine(typeof(<LoadCachedOrDefaultData>d__18))]
	private IEnumerator LoadCachedOrDefaultData() { }

	protected virtual void OnDestroy() { }

	[CompilerGenerated]
	private void set_CurrentSuggestionsData(MyGamesSuggestionsData value) { }

	[CompilerGenerated]
	private static void set_Instance(MyGamesManager value) { }

}

