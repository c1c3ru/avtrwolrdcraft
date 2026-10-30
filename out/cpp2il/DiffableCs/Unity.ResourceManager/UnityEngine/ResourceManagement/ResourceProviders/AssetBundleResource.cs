namespace UnityEngine.ResourceManagement.ResourceProviders;

public class AssetBundleResource : IAssetBundleResource, IUpdateReceiver
{
	public enum CacheStatus
	{
		Unknown = 0,
		Cached = 1,
		NotCached = 2,
	}

	internal enum LoadType
	{
		None = 0,
		Local = 1,
		Web = 2,
	}

	private const int k_WaitForWebRequestMainThreadSleep = 1; //Field offset: 0x0
	private AssetBundle m_AssetBundle; //Field offset: 0x10
	private AsyncOperation m_RequestOperation; //Field offset: 0x18
	internal WebRequestQueueOperation m_WebRequestQueueOperation; //Field offset: 0x20
	internal ProvideHandle m_ProvideHandle; //Field offset: 0x28
	internal AssetBundleRequestOptions m_Options; //Field offset: 0x40
	internal CacheStatus cacheStatus; //Field offset: 0x48
	private bool m_RequestCompletedCallbackCalled; //Field offset: 0x4C
	private int m_Retries; //Field offset: 0x50
	private BundleSource m_Source; //Field offset: 0x54
	private long m_BytesToDownload; //Field offset: 0x58
	private long m_DownloadedBytes; //Field offset: 0x60
	private bool m_Completed; //Field offset: 0x68
	private AssetBundleUnloadOperation m_UnloadOperation; //Field offset: 0x70
	private string m_TransformedInternalId; //Field offset: 0x78
	private AssetBundleRequest m_PreloadRequest; //Field offset: 0x80
	private bool m_PreloadCompleted; //Field offset: 0x88
	private ulong m_LastDownloadedByteCount; //Field offset: 0x90
	private float m_TimeoutTimer; //Field offset: 0x98
	private int m_TimeoutOverFrames; //Field offset: 0x9C
	private int m_LastFrameCount; //Field offset: 0xA0
	private float m_TimeSecSinceLastUpdate; //Field offset: 0xA4

	internal long BytesToDownload
	{
		internal get { } //Length: 112
	}

	private bool HasTimedOut
	{
		private get { } //Length: 64
	}

	public AssetBundleResource() { }

	[CompilerGenerated]
	private void <AddBeginWebRequestHandler>b__46_0(UnityWebRequestAsyncOperation asyncOp) { }

	[CompilerGenerated]
	private void <GetAssetPreloadRequest>b__31_0(AsyncOperation operation) { }

	internal void AddBeginWebRequestHandler(WebRequestQueueOperation webRequestQueueOperation) { }

	private void AddBundleToProfiler(ContentStatus status, BundleSource source) { }

	private void AddCallbackInvokeIfDone(AsyncOperation operation, Action<AsyncOperation> callback) { }

	private void BeginOperation() { }

	private void BeginWebRequestOperation(AsyncOperation asyncOp) { }

	private void CompleteBundleLoad(AssetBundle bundle) { }

	internal UnityWebRequest CreateWebRequest(string url) { }

	internal UnityWebRequest CreateWebRequest(IResourceLocation loc) { }

	internal WebRequestQueueOperation EnqueueWebRequest(string internalId) { }

	internal long get_BytesToDownload() { }

	private bool get_HasTimedOut() { }

	public override AssetBundle GetAssetBundle() { }

	public AssetBundleRequest GetAssetPreloadRequest() { }

	private DownloadStatus GetDownloadStatus() { }

	public static void GetLoadInfo(ProvideHandle handle, out LoadType loadType, out string path) { }

	internal static void GetLoadInfo(IResourceLocation location, ResourceManager resourceManager, out LoadType loadType, out string path) { }

	internal bool IsCached() { }

	private void LoadLocalBundle() { }

	private void LocalRequestOperationCompleted(AsyncOperation op) { }

	private void OnUnloadOperationComplete(AsyncOperation op) { }

	private float PercentComplete() { }

	private void RemoveBundleFromProfiler() { }

	public void Start(ProvideHandle provideHandle, AssetBundleUnloadOperation unloadOp) { }

	public bool Unload(out AssetBundleUnloadOperation unloadOp) { }

	public override void Update(float unscaledDeltaTime) { }

	private bool WaitForCompletionHandler() { }

	private void WebRequestOperationCompleted(AsyncOperation op) { }

}

