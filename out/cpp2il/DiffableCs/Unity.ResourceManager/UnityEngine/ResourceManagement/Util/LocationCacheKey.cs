namespace UnityEngine.ResourceManagement.Util;

internal sealed class LocationCacheKey : IOperationCacheKey, IEquatable<IOperationCacheKey>
{
	private readonly IResourceLocation m_Location; //Field offset: 0x10
	private readonly Type m_DesiredType; //Field offset: 0x18

	public LocationCacheKey(IResourceLocation location, Type desiredType) { }

	public virtual bool Equals(object obj) { }

	public override bool Equals(IOperationCacheKey other) { }

	private bool Equals(LocationCacheKey other) { }

	public virtual int GetHashCode() { }

}

