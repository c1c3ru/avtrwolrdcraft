namespace UnityEngine.ResourceManagement.Util;

internal sealed class AsyncOpHandlesCacheKey : IOperationCacheKey, IEquatable<IOperationCacheKey>
{
	private readonly HashSet<AsyncOperationHandle> m_Handles; //Field offset: 0x10

	public AsyncOpHandlesCacheKey(IList<AsyncOperationHandle> handles) { }

	public virtual bool Equals(object obj) { }

	public override bool Equals(IOperationCacheKey other) { }

	private bool Equals(AsyncOpHandlesCacheKey other) { }

	public virtual int GetHashCode() { }

}

