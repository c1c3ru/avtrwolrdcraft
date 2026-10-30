namespace Unity.Networking.Transport;

[BurstCompile]
public struct FragmentationPipelineStage : INetworkPipelineStage
{
	internal struct FragContext
	{
		public int startIndex; //Field offset: 0x0
		public int endIndex; //Field offset: 0x4
		public int sequence; //Field offset: 0x8
		public bool packetError; //Field offset: 0xC

	}

	[Flags]
	private enum FragFlags
	{
		First = 32768,
		Last = 16384,
		SeqMask = 16383,
	}

	public struct FragSharedContext
	{
		public int PayloadCapacity; //Field offset: 0x0
		public int MaxMessageSize; //Field offset: 0x4

	}

	private const int FragHeaderCapacity = 2; //Field offset: 0x0
	private static TransportFunctionPointer<ReceiveDelegate> ReceiveFunctionPointer; //Field offset: 0x0
	private static TransportFunctionPointer<SendDelegate> SendFunctionPointer; //Field offset: 0x8
	private static TransportFunctionPointer<InitializeConnectionDelegate> InitializeConnectionFunctionPointer; //Field offset: 0x10

	public override int StaticSize
	{
		 get { } //Length: 48
	}

	private static FragmentationPipelineStage() { }

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

