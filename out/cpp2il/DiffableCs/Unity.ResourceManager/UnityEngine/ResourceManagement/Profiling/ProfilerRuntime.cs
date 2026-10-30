namespace UnityEngine.ResourceManagement.Profiling;

internal static class ProfilerRuntime
{
	internal static IProfilerEmitter m_profilerEmitter; //Field offset: 0x0
	public const int kCatalogTag = 0; //Field offset: 0x0
	public const int kBundleDataTag = 1; //Field offset: 0x0
	public const int kAssetDataTag = 2; //Field offset: 0x0
	public const int kSceneDataTag = 3; //Field offset: 0x0
	public static readonly Guid kResourceManagerProfilerGuid; //Field offset: 0x8
	private static ProfilerCounterValue<Int32> CatalogLoadCounter; //Field offset: 0x18
	private static ProfilerCounterValue<Int32> AssetBundleLoadCounter; //Field offset: 0x19
	private static ProfilerCounterValue<Int32> AssetLoadCounter; //Field offset: 0x1A
	private static ProfilerCounterValue<Int32> SceneLoadCounter; //Field offset: 0x1B
	private static ProfilerFrameData<Hash128, CatalogFrameData> m_CatalogData; //Field offset: 0x20
	private static ProfilerFrameData<IAsyncOperation, BundleFrameData> m_BundleData; //Field offset: 0x28
	private static ProfilerFrameData<IAsyncOperation, AssetFrameData> m_AssetData; //Field offset: 0x30
	private static ProfilerFrameData<IAsyncOperation, AssetFrameData> m_SceneData; //Field offset: 0x38
	private static Dictionary<String, IAsyncOperation> m_BundleNameToOperation; //Field offset: 0x40
	private static Dictionary<String, List`1<IAsyncOperation>> m_BundleNameToAssetOperations; //Field offset: 0x48
	private static Dictionary<IAsyncOperation, ValueTuple`2<Int32, Single>> m_DataChange; //Field offset: 0x50

	private static ProfilerRuntime() { }

	public static void AddAssetOperation(ProvideHandle handle, ContentStatus status) { }

	public static void AddBundleOperation(ProvideHandle handle, AssetBundleRequestOptions requestOptions, ContentStatus status, BundleSource source) { }

	public static void AddCatalog(Hash128 buildHash) { }

	public static void AddSceneOperation(AsyncOperationHandle<SceneInstance> handle, IResourceLocation location, ContentStatus status) { }

	public static void BundleReleased(string bundleName) { }

	private static string GetContainingBundleNameForLocation(IResourceLocation location) { }

	internal static int GetSceneLoadCounterValue() { }

	public static void Initialise() { }

	private static void InstanceOnOnLateUpdateDelegate(float deltaTime) { }

	internal static void PushToProfilerStream() { }

	private static void RefreshChangedReferenceCounts() { }

	public static void SceneReleased(AsyncOperationHandle<SceneInstance> handle) { }

	private static bool ShouldUpdateFrameDataWithOperationData(IAsyncOperation activeOperation, int frameReferenceCount, float framePercentComplete, out ValueTuple<Int32, Single>& newDataOut) { }

}

