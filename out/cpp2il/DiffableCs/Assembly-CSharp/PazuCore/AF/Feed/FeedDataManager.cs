namespace PazuCore.AF.Feed;

public class FeedDataManager : AddressablesFeatureBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass37_0
	{
		public string op; //Field offset: 0x10
		public Nullable<Int32> lastFeedId; //Field offset: 0x18
		public FeedDataManager <>4__this; //Field offset: 0x20
		public string languageCode; //Field offset: 0x28
		public bool isDone; //Field offset: 0x30

		public <>c__DisplayClass37_0() { }

		internal void <DownloadJson>b__0(string responseText) { }

	}

	[CompilerGenerated]
	private sealed class <DownloadDataFromServerIfNeeded>d__33 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public FeedDataManager <>4__this; //Field offset: 0x20
		public Nullable<Int32> lastFeedId; //Field offset: 0x28

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
		public <DownloadDataFromServerIfNeeded>d__33(int <>1__state) { }

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
	private sealed class <DownloadJson>d__37 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Nullable<Int32> lastFeedId; //Field offset: 0x20
		public FeedDataManager <>4__this; //Field offset: 0x28
		private <>c__DisplayClass37_0 <>8__1; //Field offset: 0x30

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
		public <DownloadJson>d__37(int <>1__state) { }

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
		public const string DATA = "PazuCore_Feed_Data"; //Field offset: 0x0
		public const string LAST_LANGUAGE_REQUEST = "PazuCore_Feed_LastLanguageCodeRequest"; //Field offset: 0x0
		public const string LAST_BUILD_NUMBER = "PazuCore_Feed_LastBuildNumber"; //Field offset: 0x0
		public const string USER_HAS_NOT_SEEN_NEW_CONTENT = "PazuCore_Feed_UserHasNotSeenNewContent"; //Field offset: 0x0

	}

	private const int FEED_VERSION = 1; //Field offset: 0x0
	[CompilerGenerated]
	private static FeedDataManager <Instance>k__BackingField; //Field offset: 0x0
	private const float ALLOW_GETTING_DATA_AGAIN_AFTER_DURATION = 60; //Field offset: 0x0
	[CompilerGenerated]
	private bool <IsReady>k__BackingField; //Field offset: 0x75
	private FeedData _currentFeedData; //Field offset: 0x78
	private readonly HashSet<String> _requiredTextureNames; //Field offset: 0x80
	[CompilerGenerated]
	private bool <IsGettingDataFromServer>k__BackingField; //Field offset: 0x88
	private float _lastGettingDataFromServerCallTime; //Field offset: 0x8C
	private HashSet<Int32> lastFeedItemsTriedDownload; //Field offset: 0x90

	public FeedData CurrentFeedData
	{
		 get { } //Length: 8
	}

	public private static FeedDataManager Instance
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

	public private bool IsGettingDataFromServer
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public private bool IsReady
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public FeedDataManager() { }

	private void AddTorequiredTextureIfNeeded(string url, bool isRequired = true) { }

	private void AddTorequiredTexturesIfNeeded(List<FeedItemData> feedData) { }

	protected virtual bool AllowNonGameScreenOrientation() { }

	protected virtual void Awake() { }

	[IteratorStateMachine(typeof(<DownloadDataFromServerIfNeeded>d__33))]
	private IEnumerator DownloadDataFromServerIfNeeded(Nullable<Int32> lastFeedId = null) { }

	[IteratorStateMachine(typeof(<DownloadJson>d__37))]
	private IEnumerator DownloadJson(Nullable<Int32> lastFeedId) { }

	public FeedData get_CurrentFeedData() { }

	[CompilerGenerated]
	public static FeedDataManager get_Instance() { }

	public bool get_IsFeatureLoaded() { }

	[CompilerGenerated]
	public bool get_IsGettingDataFromServer() { }

	[CompilerGenerated]
	public bool get_IsReady() { }

	protected virtual string GetFallbackResourcesPath() { }

	protected virtual string GetFeatureCloudResponseKey() { }

	protected virtual string GetFeatureKey() { }

	public virtual AddressablesFeatureType GetFeatureType() { }

	public bool GetNewDataFromServer(Nullable<Int32> lastFeedId = null) { }

	public virtual void Init(bool didChangeVersion) { }

	private void LoadCachedData() { }

	public void MarkNewContentAsSeen() { }

	protected virtual void OnDestroy() { }

	[CompilerGenerated]
	private static void set_Instance(FeedDataManager value) { }

	[CompilerGenerated]
	private void set_IsGettingDataFromServer(bool value) { }

	[CompilerGenerated]
	private void set_IsReady(bool value) { }

	public bool ShouldUserSeeNewContent() { }

	private void UpdateRemoteTexturesGC() { }

}

