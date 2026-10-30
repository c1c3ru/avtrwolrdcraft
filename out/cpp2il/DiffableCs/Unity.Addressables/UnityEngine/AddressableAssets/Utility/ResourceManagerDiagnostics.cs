namespace UnityEngine.AddressableAssets.Utility;

internal class ResourceManagerDiagnostics : IDisposable
{
	private const int k_NumberOfCompletedOpResultEntriesToShow = 4; //Field offset: 0x0
	private const int k_MaximumCompletedOpResultEntryLength = 30; //Field offset: 0x0
	private ResourceManager m_ResourceManager; //Field offset: 0x10
	private Dictionary<Int32, DiagnosticInfo> m_cachedDiagnosticInfo; //Field offset: 0x18

	public ResourceManagerDiagnostics(ResourceManager resourceManager) { }

	internal int CalculateCompletedOperationHashcode(AsyncOperationHandle handle) { }

	internal int CalculateHashCode(AsyncOperationHandle handle) { }

	public override void Dispose() { }

	internal string GenerateCompletedOperationDisplayName(AsyncOperationHandle handle) { }

	private void OnResourceManagerDiagnosticEvent(DiagnosticEventContext eventContext) { }

	internal int SumDependencyNameHashCodes(AsyncOperationHandle handle) { }

}

