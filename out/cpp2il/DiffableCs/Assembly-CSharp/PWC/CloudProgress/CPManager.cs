namespace PWC.CloudProgress;

public class CPManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<String, Boolean> <>9__42_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <GetFiles>b__42_0(string x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass32_0
	{
		public string absoluteRootWithSlash; //Field offset: 0x10

		public <>c__DisplayClass32_0() { }

		internal string <TryCreateZipFromData>b__0(string x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass33_0
	{
		public Action<Boolean> onFinish; //Field offset: 0x10
		public CPTrackingData trackingData; //Field offset: 0x18
		public CPManager <>4__this; //Field offset: 0x20

		public <>c__DisplayClass33_0() { }

		internal void <UploadProgress>b__0(CPProfileMetadataCloudResponse response) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass33_1
	{
		public string zipFilePath; //Field offset: 0x10
		public Dictionary<String, String> filesToSave; //Field offset: 0x18
		public <>c__DisplayClass33_0 CS$<>8__locals1; //Field offset: 0x20
		public Action<Int64, Boolean> <>9__2; //Field offset: 0x28

		public <>c__DisplayClass33_1() { }

		internal void <UploadProgress>b__1() { }

		internal void <UploadProgress>b__2(long lastSaveDate, bool isSuccess) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass34_0
	{
		public string op; //Field offset: 0x10
		public Action<Int64, Byte[]> onFinish; //Field offset: 0x18
		public CPManager <>4__this; //Field offset: 0x20

		public <>c__DisplayClass34_0() { }

		internal void <Download>b__0(string responseText) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass35_0
	{
		public Action<Boolean, Boolean> onFinish; //Field offset: 0x10
		public CPManager <>4__this; //Field offset: 0x18

		public <>c__DisplayClass35_0() { }

		internal void <DownloadProgress>b__0(CPProfileMetadataCloudResponse response) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass35_1
	{
		public string absoluteRoot; //Field offset: 0x10
		public <>c__DisplayClass35_0 CS$<>8__locals1; //Field offset: 0x18
		public Action<Int64, Byte[]> <>9__2; //Field offset: 0x20

		public <>c__DisplayClass35_1() { }

		internal void <DownloadProgress>b__1() { }

		internal void <DownloadProgress>b__2(long lastSaveDate, Byte[] bytes) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass39_0
	{
		public string op; //Field offset: 0x10
		public Action<Int64, Boolean> onFinish; //Field offset: 0x18
		public CPManager <>4__this; //Field offset: 0x20
		public Byte[] zipFileBytes; //Field offset: 0x28

		public <>c__DisplayClass39_0() { }

		internal void <Upload>b__0(string responseText) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass47_0
	{
		public string op; //Field offset: 0x10
		public Action<CPProfileMetadataCloudResponse> onResponse; //Field offset: 0x18

		public <>c__DisplayClass47_0() { }

		internal void <GetCurrentProfileMetadataFromCloud>b__0(string responseText) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass48_0
	{
		public Action<Boolean, Boolean> onFinish; //Field offset: 0x10
		public CPManager <>4__this; //Field offset: 0x18
		public Action<Boolean> <>9__1; //Field offset: 0x20

		public <>c__DisplayClass48_0() { }

		internal void <InitSignedUserForAvatarId>b__0(AWCloudUserAvatarIdInitCloudResponse response) { }

		internal void <InitSignedUserForAvatarId>b__1(bool isSuccess) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass50_0
	{
		public string op; //Field offset: 0x10
		public Action<AWCloudUserAvatarIdInitCloudResponse> onResponse; //Field offset: 0x18

		public <>c__DisplayClass50_0() { }

		internal void <InitSignedUserForAvatarIdImplement>b__0(string responseText) { }

	}

	[CompilerGenerated]
	private sealed class <SendDownloadRequest>d__41 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public string url; //Field offset: 0x20
		public Action<Int64, Byte[]> onFinish; //Field offset: 0x28
		public long lastSaveDate; //Field offset: 0x30
		private UnityWebRequest <webRequest>5__2; //Field offset: 0x38

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
		public <SendDownloadRequest>d__41(int <>1__state) { }

		private void <>m__Finally1() { }

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
	private sealed class <SendUploadRequest>d__40 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Byte[] bytes; //Field offset: 0x20
		public string url; //Field offset: 0x28
		public Action<Int64, Boolean> onFinish; //Field offset: 0x30
		public long lastSaveDate; //Field offset: 0x38
		private UnityWebRequest <webRequest>5__2; //Field offset: 0x40

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
		public <SendUploadRequest>d__40(int <>1__state) { }

		private void <>m__Finally1() { }

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

	internal enum ZipErrorType
	{
		None = 0,
		NoData = 1,
		FiledToSerialize = 2,
		IOException = 3,
	}

	private const string CP_FILES_PATH = "__CPFilePaths.json"; //Field offset: 0x0
	private const string CP_LAST_SAVE_COPY_FOLDER = "CloudProgressLastSaveZipCopy"; //Field offset: 0x0
	private const string CP_LAST_SAVE_CACHE_TIMESTAMP_FILE = "CloudProgressLastSaveZipCopy/lastSaveTimestamp.txt"; //Field offset: 0x0
	private const string CP_LAST_SAVE_ZIP_FILE = "CloudProgressLastSaveZipCopy/LastSave.zip"; //Field offset: 0x0
	private const string CURRENT_PROFILE_KEY = "AWCurrentProfile"; //Field offset: 0x0
	private const string PNG_EXTENSION = ".png"; //Field offset: 0x0
	public static Action OnLastSaveDateChangedAction; //Field offset: 0x0
	public static Action OnPreGameProgressSaveToCloudAction; //Field offset: 0x8
	public static Action OnGameProgressLoadedFromCloudAction; //Field offset: 0x10
	[CompilerGenerated]
	private static CPManager <Instance>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private string <CurrentProfileID>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private long <LastSaveDate>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private Nullable<DateTimeOffset> <LastSaveDateAsDateTimeOffset>k__BackingField; //Field offset: 0x30

	public private string CurrentProfileID
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private static CPManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public private long LastSaveDate
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private Nullable<DateTimeOffset> LastSaveDateAsDateTimeOffset
	{
		[CompilerGenerated]
		 get { } //Length: 20
		[CompilerGenerated]
		private set { } //Length: 20
	}

	public CPManager() { }

	private void Awake() { }

	private static string CreateZipFile(string absoluteRoot, Dictionary<String, String> filesToSave, string overrideRelativeZipPath = null) { }

	private void Download(Action<Int64, Byte[]> onFinish) { }

	public void DownloadProgress(Action<Boolean, Boolean> onFinish = null) { }

	public void EnsureBackup() { }

	private void ExtractZipToData(string absoluteRoot, string zipFilePath, bool shouldSaveAsCopy, long lastSaveDate, bool shouldDeleteZipOnFinish) { }

	[CompilerGenerated]
	public string get_CurrentProfileID() { }

	[CompilerGenerated]
	public static CPManager get_Instance() { }

	[CompilerGenerated]
	public long get_LastSaveDate() { }

	[CompilerGenerated]
	public Nullable<DateTimeOffset> get_LastSaveDateAsDateTimeOffset() { }

	public void GetCurrentProfileMetadataFromCloud(Action<CPProfileMetadataCloudResponse> onResponse) { }

	private static List<String> GetFiles(string folderPath) { }

	private static Dictionary<String, String> GetFilesToSave(CPTrackingData trackingData, string absoluteRoot, List<String> filePaths) { }

	public bool HasCurrentProfileID() { }

	public void InitSignedUserForAvatarId(Action<Boolean, Boolean> onFinish) { }

	private void InitSignedUserForAvatarIdImplement(Action<AWCloudUserAvatarIdInitCloudResponse> onResponse) { }

	private void InvalidateLastSaveData() { }

	private void OnApplicationPause(bool pause) { }

	private void OnDestroy() { }

	private void OnUserSync(SyncType syncType) { }

	private void SaveLastSaveCopy(string absoluteRoot, string zipFilePath, long lastSaveDate) { }

	[IteratorStateMachine(typeof(<SendDownloadRequest>d__41))]
	private IEnumerator SendDownloadRequest(string url, long lastSaveDate, Action<Int64, Byte[]> onFinish) { }

	[IteratorStateMachine(typeof(<SendUploadRequest>d__40))]
	private IEnumerator SendUploadRequest(string url, Byte[] bytes, long lastSaveDate, Action<Int64, Boolean> onFinish) { }

	[CompilerGenerated]
	private void set_CurrentProfileID(string value) { }

	[CompilerGenerated]
	private static void set_Instance(CPManager value) { }

	[CompilerGenerated]
	private void set_LastSaveDate(long value) { }

	[CompilerGenerated]
	private void set_LastSaveDateAsDateTimeOffset(Nullable<DateTimeOffset> value) { }

	public void SetCurrentProfileData(List<ProfileData> profileDatas) { }

	private void SetCurrentProfileID(string profileId) { }

	private bool TryCreateZipFromData(CPTrackingData trackingData, out string zipFilePath, out ZipErrorType zipErrorType, out Dictionary<String, String>& filesToSave, string overrideRelativeZipPath = null) { }

	private bool TryLoadLastSaveCopy(string absoluteRoot, out string zipFilePath) { }

	private void Upload(string zipFilePath, Action<Int64, Boolean> onFinish) { }

	public void UploadProgress(Action<Boolean> onFinish = null) { }

}

