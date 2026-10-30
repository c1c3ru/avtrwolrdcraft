namespace Unity.Networking.Transport;

[BurstCompile]
public struct SimulatorPipelineStage : INetworkPipelineStage
{
	private static TransportFunctionPointer<ReceiveDelegate> ReceiveFunctionPointer; //Field offset: 0x0
	private static TransportFunctionPointer<SendDelegate> SendFunctionPointer; //Field offset: 0x8
	private static TransportFunctionPointer<InitializeConnectionDelegate> InitializeConnectionFunctionPointer; //Field offset: 0x10

	public override int StaticSize
	{
		 get { } //Length: 48
	}

	private static SimulatorPipelineStage() { }

	public override int get_StaticSize() { }

	[BurstCompile(DisableDirectCall = True)]
	[MonoPInvokeCallback(typeof(InitializeConnectionDelegate))]
	private static void InitializeConnection(Byte* staticInstanceBuffer, int staticInstanceBufferLength, Byte* sendProcessBuffer, int sendProcessBufferLength, Byte* recvProcessBuffer, int recvProcessBufferLength, Byte* sharedProcessBuffer, int sharedProcessBufferLength) { }

	[BurstCompile(DisableDirectCall = True)]
	[MonoPInvokeCallback(typeof(ReceiveDelegate))]
	private static void Receive(ref NetworkPipelineContext ctx, ref InboundRecvBuffer inboundBuffer, ref Requests requests, int systemHeaderSize) { }

	[BurstCompile(DisableDirectCall = True)]
	[MonoPInvokeCallback(typeof(SendDelegate))]
	private static int Send(ref NetworkPipelineContext ctx, ref InboundSendBuffer inboundBuffer, ref Requests requests, int systemHeaderSize) { }

	public override NetworkPipelineStage StaticInitialize(Byte* staticInstanceBuffer, int staticInstanceBufferLength, NetworkSettings settings) { }

}

