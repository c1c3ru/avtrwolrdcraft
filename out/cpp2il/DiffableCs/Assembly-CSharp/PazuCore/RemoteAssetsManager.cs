namespace PazuCore;

public class RemoteAssetsManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass15_0
	{
		public string assetName; //Field offset: 0x10

		public <>c__DisplayClass15_0() { }

		internal bool <PutOnTopOfTheDownloadRequestsQueueIfInQueue>b__0(AssetDownloadRequest x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass24_0
	{
		public RemoteAssetsManager <>4__this; //Field offset: 0x10
		public AssetDownloadRequest request; //Field offset: 0x18

		public <>c__DisplayClass24_0() { }

		internal void <DownloadTexture>b__0(string textureName_) { }

		internal void <DownloadTexture>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass25_0
	{
		public RemoteAssetsManager <>4__this; //Field offset: 0x10
		public AssetDownloadRequest request; //Field offset: 0x18

		public <>c__DisplayClass25_0() { }

		internal void <DownloadAudioClip>b__0(string assetName_) { }

		internal void <DownloadAudioClip>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <DownloadRequestsInQueue>d__22 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public RemoteAssetsManager <>4__this; //Field offset: 0x20

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
		public <DownloadRequestsInQueue>d__22(int <>1__state) { }

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
	private sealed class <WaitForAsset>d__35 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public RemoteAssetsManager <>4__this; //Field offset: 0x20
		public string assetName; //Field offset: 0x28
		public Action<String> assign; //Field offset: 0x30
		public Action onFailure; //Field offset: 0x38
		private AssetDownloadRequest <assetDownloadRequest>5__2; //Field offset: 0x40

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
		public <WaitForAsset>d__35(int <>1__state) { }

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

	internal class AssetDownloadRequest
	{
		internal enum Type
		{
			None = 0,
			Texture = 1,
			AudioClip = 2,
		}

		public readonly Type type; //Field offset: 0x10
		public readonly string assetName; //Field offset: 0x18
		public readonly string url; //Field offset: 0x20
		public readonly Action<ResultType> onFinishAction; //Field offset: 0x28
		public readonly bool isSharedAsset; //Field offset: 0x30
		public bool isDone; //Field offset: 0x31
		public bool isSuccess; //Field offset: 0x32

		public AssetDownloadRequest(Type type, string assetName, string url, Action<ResultType> onFinishAction, bool isSharedAsset) { }

	}

	internal enum ResultType
	{
		Success = 0,
		Failure = 1,
		AlreadyInProgress = 2,
	}

	private const int MAX_PARALLEL_DOWNLOADS = 10; //Field offset: 0x0
	public static bool AllowDownloads; //Field offset: 0x0
	[CompilerGenerated]
	private static RemoteAssetsManager <Instance>k__BackingField; //Field offset: 0x8
	private List<AssetDownloadRequest> _assetDownloadRequestsQueue; //Field offset: 0x20
	private readonly Dictionary<String, AssetDownloadRequest> _assetDownloadsInProgress; //Field offset: 0x28
	private readonly HashSet<String> _assetNamesSucceeded; //Field offset: 0x30
	private bool _isDownloadRequestsInQueueInProgress; //Field offset: 0x38
	private readonly Dictionary<String, String> _cachedAssetNames; //Field offset: 0x40
	private int _currentParallelDownloadsCount; //Field offset: 0x48

	public private static RemoteAssetsManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		private set { } //Length: 96
	}

	private static RemoteAssetsManager() { }

	public RemoteAssetsManager() { }

	private void Awake() { }

	private void DownloadAsset(AssetDownloadRequest request) { }

	public string DownloadAssetIfNeeded(Type type, string url, Action<ResultType> onFinish = null, bool isSharedAsset = true) { }

	private void DownloadAssetIfNeededInternal(Type type, string assetName, string url, Action<ResultType> onFinish, bool isSharedAsset) { }

	private void DownloadAudioClip(AssetDownloadRequest request) { }

	public string DownloadAudioClipIfNeeded(string url, Action<ResultType> onFinish = null) { }

	[IteratorStateMachine(typeof(<DownloadRequestsInQueue>d__22))]
	private IEnumerator DownloadRequestsInQueue() { }

	private void DownloadTexture(AssetDownloadRequest request) { }

	public string DownloadTextureIfNeeded(string url, Action<ResultType> onFinish = null, bool isSharedAsset = true) { }

	[CompilerGenerated]
	public static RemoteAssetsManager get_Instance() { }

	public string GetAssetNameForUrl(Type type, string url) { }

	public string GetAudioClipNameForUrl(string url) { }

	public string GetTextureNameForUrl(string url) { }

	private void OnAssetDownloadComplete(AssetDownloadRequest request) { }

	private void OnAssetDownloadFailed(AssetDownloadRequest request) { }

	public void PutOnTopOfTheDownloadRequestsQueueIfInQueue(string assetName) { }

	public void RemoveAssetNameFromSuccededCollection(string assetName) { }

	public string RequestAsset(Type type, string url, Action<String> assign, Action onFailure = null) { }

	public string RequestAudioClip(string url, Action<String> assign, Action onFailure = null) { }

	public string RequestTexture(string url, Action<String> assign, Action onFailure = null) { }

	[CompilerGenerated]
	private static void set_Instance(RemoteAssetsManager value) { }

	public void StopAndDiscardAllDownloads() { }

	public bool TryGetAssetDownloadRequestnProgress(string assetName, out AssetDownloadRequest request) { }

	[IteratorStateMachine(typeof(<WaitForAsset>d__35))]
	private IEnumerator WaitForAsset(string assetName, Action<String> assign, Action onFailure = null) { }

}

