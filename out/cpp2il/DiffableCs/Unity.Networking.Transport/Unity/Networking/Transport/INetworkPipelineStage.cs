namespace Unity.Networking.Transport;

public interface INetworkPipelineStage
{

	public int StaticSize
	{
		 get { } //Length: 0
	}

	public int get_StaticSize() { }

	public NetworkPipelineStage StaticInitialize(Byte* staticInstanceBuffer, int staticInstanceBufferLength, NetworkSettings settings) { }

}

