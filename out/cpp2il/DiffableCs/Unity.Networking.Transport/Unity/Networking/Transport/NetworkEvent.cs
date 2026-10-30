namespace Unity.Networking.Transport;

public struct NetworkEvent
{
	internal enum Type
	{
		Empty = 0,
		Data = 1,
		Connect = 2,
		Disconnect = 3,
	}

	internal Type type; //Field offset: 0x0
	internal short pipelineId; //Field offset: 0x2
	internal int connectionId; //Field offset: 0x4
	internal int status; //Field offset: 0x8
	internal int offset; //Field offset: 0x8
	internal int size; //Field offset: 0xC

}

