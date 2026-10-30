namespace UnityEngine.ResourceManagement.Util;

internal sealed class DependenciesCacheKey : IOperationCacheKey, IEquatable<IOperationCacheKey>
{
	private readonly IList<IResourceLocation> m_Dependencies; //Field offset: 0x10
	private readonly int m_DependenciesHash; //Field offset: 0x18

	public DependenciesCacheKey(IList<IResourceLocation> dependencies, int dependenciesHash) { }

	public virtual bool Equals(object obj) { }

	public override bool Equals(IOperationCacheKey other) { }

	private bool Equals(DependenciesCacheKey other) { }

	public virtual int GetHashCode() { }

}

