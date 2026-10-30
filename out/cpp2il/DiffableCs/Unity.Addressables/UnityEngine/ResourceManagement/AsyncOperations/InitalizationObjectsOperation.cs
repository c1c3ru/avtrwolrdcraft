namespace UnityEngine.ResourceManagement.AsyncOperations;

internal class InitalizationObjectsOperation : AsyncOperationBase<Boolean>
{
	private AsyncOperationHandle<ResourceManagerRuntimeData> m_RtdOp; //Field offset: 0x98
	private AddressablesImpl m_Addressables; //Field offset: 0xB0
	private AsyncOperationHandle<IList`1<AsyncOperationHandle>> m_DepOp; //Field offset: 0xB8

	protected virtual string DebugName
	{
		 get { } //Length: 64
	}

	public InitalizationObjectsOperation() { }

	[CompilerGenerated]
	private void <Execute>b__8_0(AsyncOperationHandle<IList`1<AsyncOperationHandle>> obj) { }

	protected virtual void Execute() { }

	protected virtual string get_DebugName() { }

	public void Init(AsyncOperationHandle<ResourceManagerRuntimeData> rtdOp, AddressablesImpl addressables) { }

	protected virtual bool InvokeWaitForCompletion() { }

	internal bool LogRuntimeWarnings(string pathToBuildLogs) { }

}

