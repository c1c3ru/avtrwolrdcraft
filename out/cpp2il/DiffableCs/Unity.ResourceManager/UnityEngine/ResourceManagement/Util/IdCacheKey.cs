namespace UnityEngine.ResourceManagement.Util;

internal sealed class IdCacheKey : IOperationCacheKey, IEquatable<IOperationCacheKey>
{
	public string ID; //Field offset: 0x10
	public Type locationType; //Field offset: 0x18

	public IdCacheKey(Type locType, string id) { }

	private bool Equals(IdCacheKey other) { }

	public virtual bool Equals(object obj) { }

	public override bool Equals(IOperationCacheKey other) { }

	public virtual int GetHashCode() { }

}

