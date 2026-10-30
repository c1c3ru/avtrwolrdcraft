namespace UnityEngine.ResourceManagement.Profiling;

internal struct AssetFrameData
{
	public int AssetCode; //Field offset: 0x0
	public int BundleCode; //Field offset: 0x4
	public int ReferenceCount; //Field offset: 0x8
	public float PercentComplete; //Field offset: 0xC
	public ContentStatus Status; //Field offset: 0x10

	public virtual bool Equals(object obj) { }

	public virtual int GetHashCode() { }

}

