namespace UnityEngine.AddressableAssets;

internal class CheckCatalogsOperation : AsyncOperationBase<List`1<String>>
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<IResourceProvider, Boolean> <>9__5_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <Start>b__5_0(IResourceProvider rp) { }

	}

	private AddressablesImpl m_Addressables; //Field offset: 0x98
	private List<String> m_LocalHashes; //Field offset: 0xA0
	private List<ResourceLocatorInfo> m_LocatorInfos; //Field offset: 0xA8
	private AsyncOperationHandle<IList`1<AsyncOperationHandle>> m_DepOp; //Field offset: 0xB0

	public CheckCatalogsOperation(AddressablesImpl aa) { }

	protected virtual void Destroy() { }

	protected virtual void Execute() { }

	public virtual void GetDependencies(List<AsyncOperationHandle> dependencies) { }

	protected virtual bool InvokeWaitForCompletion() { }

	internal static List<String> ProcessDependentOpResults(IList<AsyncOperationHandle> results, List<ResourceLocatorInfo> locatorInfos, List<String> localHashes, out string errorString, out bool success) { }

	public AsyncOperationHandle<List`1<String>> Start(List<ResourceLocatorInfo> locatorInfos) { }

}

