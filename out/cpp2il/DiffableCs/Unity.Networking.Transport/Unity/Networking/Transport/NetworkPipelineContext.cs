namespace Unity.Networking.Transport;

public struct NetworkPipelineContext
{
	public Byte* staticInstanceBuffer; //Field offset: 0x0
	public Byte* internalSharedProcessBuffer; //Field offset: 0x8
	public Byte* internalProcessBuffer; //Field offset: 0x10
	public DataStreamWriter header; //Field offset: 0x18
	public long timestamp; //Field offset: 0x40
	public int staticInstanceBufferLength; //Field offset: 0x48
	public int internalSharedProcessBufferLength; //Field offset: 0x4C
	public int internalProcessBufferLength; //Field offset: 0x50
	public int accumulatedHeaderCapacity; //Field offset: 0x54

}

