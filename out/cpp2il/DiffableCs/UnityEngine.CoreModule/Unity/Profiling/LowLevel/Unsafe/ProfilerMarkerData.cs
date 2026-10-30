namespace Unity.Profiling.LowLevel.Unsafe;

public struct ProfilerMarkerData
{
	public byte Type; //Field offset: 0x0
	private readonly byte reserved0; //Field offset: 0x1
	private readonly ushort reserved1; //Field offset: 0x2
	public uint Size; //Field offset: 0x4
	public Void* Ptr; //Field offset: 0x8

}

