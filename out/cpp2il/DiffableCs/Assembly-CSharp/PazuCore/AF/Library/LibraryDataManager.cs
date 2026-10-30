namespace PazuCore.AF.Library;

public class LibraryDataManager : AddressablesFeatureBase
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<LibraryGame, Int32> <>9__42_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal int <DownloadGamesTexturesIfNeeded>b__42_0(LibraryGame x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass42_0
	{
		public LibrarySection section; //Field offset: 0x10

		public <>c__DisplayClass42_0() { }

		internal bool <DownloadGamesTexturesIfNeeded>b__1(LibraryGame game) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass44_0
	{
		public string op; //Field offset: 0x10
		public LibraryDataManager <>4__this; //Field offset: 0x18
		public string languageCode; //Field offset: 0x20
		public string countryCode; //Field offset: 0x28
		public bool isDone; //Field offset: 0x30

		public <>c__DisplayClass44_0() { }

		internal void <DownloadJson>b__0(string responseText) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass49_0
	{
		public LibraryDataManager <>4__this; //Field offset: 0x10
		public LibraryGame game; //Field offset: 0x18
		public Action<Boolean> onFinish; //Field offset: 0x20
		public bool calledFallback; //Field offset: 0x28

		public <>c__DisplayClass49_0() { }

		internal void <LaunchGame>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass51_0
	{
		public LibraryDataManager <>4__this; //Field offset: 0x10
		public LibraryGame game; //Field offset: 0x18
		public Action<Boolean> onFinish; //Field offset: 0x20

		public <>c__DisplayClass51_0() { }

		internal void <OpenGameInStore>b__2() { }

		internal void <OpenGameInStore>b__4() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass51_1
	{
		public string itunesLink; //Field offset: 0x10
		public <>c__DisplayClass51_0 CS$<>8__locals1; //Field offset: 0x18

		public <>c__DisplayClass51_1() { }

		internal void <OpenGameInStore>b__1() { }

		internal void <OpenGameInStore>g__OpenAppstore|0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass51_2
	{
		public string url; //Field offset: 0x10
		public string package; //Field offset: 0x18
		public string urlfallback; //Field offset: 0x20
		public <>c__DisplayClass51_0 CS$<>8__locals2; //Field offset: 0x28

		public <>c__DisplayClass51_2() { }

		internal void <OpenGameInStore>b__3() { }

	}

	[CompilerGenerated]
	private sealed class <DownloadEverythingIfNeeded>d__40 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LibraryDataManager <>4__this; //Field offset: 0x20
		private string <dateModifiedBeforeDownload>5__2; //Field offset: 0x28

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
		public <DownloadEverythingIfNeeded>d__40(int <>1__state) { }

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
	private sealed class <DownloadJson>d__44 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LibraryDataManager <>4__this; //Field offset: 0x20
		private <>c__DisplayClass44_0 <>8__1; //Field offset: 0x28

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
		public <DownloadJson>d__44(int <>1__state) { }

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
		public const string DATA = "PazuCore_Library_Data"; //Field offset: 0x0
		public const string LAST_LANGUAGE_REQUEST = "PazuCore_Library_LastLanguageCodeRequest"; //Field offset: 0x0
		public const string LAST_COUNTRY_REQUEST = "PazuCore_Library_LastCountryCodeRequest"; //Field offset: 0x0
		public const string LAST_BUILD_NUMBER = "PazuCore_Library_LastBuildNumber"; //Field offset: 0x0

	}

	private const float ALLOW_DOWNLOAD_EVENRYTHING_AGAIN_AFTER_DURATION = 1800; //Field offset: 0x0
	[CompilerGenerated]
	private static LibraryDataManager <Instance>k__BackingField; //Field offset: 0x0
	private readonly HashSet<String> _requiredTextureNames; //Field offset: 0x78
	[CompilerGenerated]
	private LibraryData <CurrentLibraryData>k__BackingField; //Field offset: 0x80
	[CompilerGenerated]
	private bool <IsReady>k__BackingField; //Field offset: 0x88
	private readonly Dictionary<Int32, Boolean> _cachedIsGameInstalled; //Field offset: 0x90
	private List<Int32> _cachedInstalledGames; //Field offset: 0x98
	private readonly Dictionary<Int32, Boolean> _cachedIsGameBundleInstalled; //Field offset: 0xA0
	private bool _isDownloadEverythingInProgress; //Field offset: 0xA8
	private float _lastDownloadEverythingCallTime; //Field offset: 0xAC
	private bool _isIOSDeviceWithSystemVersion15OrHeight; //Field offset: 0xB0
	[CompilerGenerated]
	private bool <IsAboutToLaunchOtherGame>k__BackingField; //Field offset: 0xB1

	public private LibraryData CurrentLibraryData
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private static LibraryDataManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public bool IsAboutToLaunchOtherGame
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public bool IsDownloadEverythingInProgress
	{
		 get { } //Length: 8
	}

	public bool IsFeatureLoaded
	{
		 get { } //Length: 224
	}

	public private bool IsReady
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public LibraryDataManager() { }

	[CompilerGenerated]
	private bool <IsGameBundleInstalled>b__46_0(int x) { }

	[CompilerGenerated]
	private void <OnGameResume>g__Download|53_0() { }

	protected virtual bool AllowNonGameScreenOrientation() { }

	protected virtual void Awake() { }

	private void ClearInstalledGamesCache() { }

	[IteratorStateMachine(typeof(<DownloadEverythingIfNeeded>d__40))]
	private IEnumerator DownloadEverythingIfNeeded() { }

	private void DownloadGamesTexturesIfNeeded(LibraryData libraryData) { }

	[IteratorStateMachine(typeof(<DownloadJson>d__44))]
	private IEnumerator DownloadJson() { }

	[CompilerGenerated]
	public LibraryData get_CurrentLibraryData() { }

	[CompilerGenerated]
	public static LibraryDataManager get_Instance() { }

	[CompilerGenerated]
	public bool get_IsAboutToLaunchOtherGame() { }

	public bool get_IsDownloadEverythingInProgress() { }

	public bool get_IsFeatureLoaded() { }

	[CompilerGenerated]
	public bool get_IsReady() { }

	public LibraryGame GetCurrentGame() { }

	protected virtual string GetFallbackResourcesPath() { }

	protected virtual string GetFeatureCloudResponseKey() { }

	protected virtual string GetFeatureKey() { }

	public virtual AddressablesFeatureType GetFeatureType() { }

	public List<Int32> GetInstalledGames() { }

	private static string GetKey(string key) { }

	public bool IsGameBundleInstalled(int gameBundleId) { }

	public bool IsGameInstalled(int gameId) { }

	private void LaunchGame(LibraryGame game, AppContentData addedConentDataToUrl = null, Action<Boolean> onFinish = null) { }

	private void LoadCachedOrDefaultData() { }

	private void MarkTextureAsRequired(string url) { }

	private void OnAndroidChangedSavingFilesAppsPackage() { }

	protected virtual void OnDestroy() { }

	public void OnGameResume() { }

	private void OnUserSync(SyncType syncType) { }

	public void OpenGame(int gameId, bool ifOpenStoreShowParentalGate = true, AppContentData addedConentDataToUrl = null, Action<Boolean> onFinish = null, string context = "") { }

	public void OpenGameInStore(LibraryGame game, bool showParentalGate = true, Action<Boolean> onFinish = null, string context = "") { }

	[CompilerGenerated]
	private void set_CurrentLibraryData(LibraryData value) { }

	[CompilerGenerated]
	private static void set_Instance(LibraryDataManager value) { }

	[CompilerGenerated]
	public void set_IsAboutToLaunchOtherGame(bool value) { }

	[CompilerGenerated]
	private void set_IsReady(bool value) { }

	private void Start() { }

	private void UpdateRemoteTexturesGC() { }

}

