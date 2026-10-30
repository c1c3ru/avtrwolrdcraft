namespace UnityEngine.ResourceManagement.Profiling;

internal struct BundleFrameData
{
	public int BundleCode; //Field offset: 0x0
	public int ReferenceCount; //Field offset: 0x4
	public float PercentComplete; //Field offset: 0x8
	public ContentStatus Status; //Field offset: 0xC
	public BundleSource Source; //Field offset: 0x10
	public BundleOptions LoadingOptions; //Field offset: 0x14

}

