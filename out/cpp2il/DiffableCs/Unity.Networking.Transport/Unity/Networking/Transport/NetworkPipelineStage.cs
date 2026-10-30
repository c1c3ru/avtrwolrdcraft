namespace Unity.Networking.Transport;

public struct NetworkPipelineStage
{
	[UnmanagedFunctionPointer(CallingConvention::Cdecl (2))]
	internal sealed class InitializeConnectionDelegate : MulticastDelegate
	{

		public InitializeConnectionDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(Byte* staticInstanceBuffer, int staticInstanceBufferLength, Byte* sendProcessBuffer, int sendProcessBufferLength, Byte* recvProcessBuffer, int recvProcessBufferLength, Byte* sharedProcessBuffer, int sharedProcessBufferLength, AsyncCallback callback, object object) { }

		public override void EndInvoke(IAsyncResult result) { }

		public override void Invoke(Byte* staticInstanceBuffer, int staticInstanceBufferLength, Byte* sendProcessBuffer, int sendProcessBufferLength, Byte* recvProcessBuffer, int recvProcessBufferLength, Byte* sharedProcessBuffer, int sharedProcessBufferLength) { }

	}

	[UnmanagedFunctionPointer(CallingConvention::Cdecl (2))]
	internal sealed class ReceiveDelegate : MulticastDelegate
	{

		public ReceiveDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(ref NetworkPipelineContext ctx, ref InboundRecvBuffer inboundBuffer, ref Requests requests, int systemHeadersSize, AsyncCallback callback, object object) { }

		public override void EndInvoke(ref NetworkPipelineContext ctx, ref InboundRecvBuffer inboundBuffer, ref Requests requests, IAsyncResult result) { }

		public override void Invoke(ref NetworkPipelineContext ctx, ref InboundRecvBuffer inboundBuffer, ref Requests requests, int systemHeadersSize) { }

	}

	[Flags]
	internal enum Requests
	{
		None = 0,
		Resume = 1,
		Update = 2,
		SendUpdate = 4,
		Error = 8,
	}

	[UnmanagedFunctionPointer(CallingConvention::Cdecl (2))]
	internal sealed class SendDelegate : MulticastDelegate
	{

		public SendDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(ref NetworkPipelineContext ctx, ref InboundSendBuffer inboundBuffer, ref Requests requests, int systemHeadersSize, AsyncCallback callback, object object) { }

		public override int EndInvoke(ref NetworkPipelineContext ctx, ref InboundSendBuffer inboundBuffer, ref Requests requests, IAsyncResult result) { }

		public override int Invoke(ref NetworkPipelineContext ctx, ref InboundSendBuffer inboundBuffer, ref Requests requests, int systemHeadersSize) { }

	}

	public TransportFunctionPointer<ReceiveDelegate> Receive; //Field offset: 0x0
	public TransportFunctionPointer<SendDelegate> Send; //Field offset: 0x8
	public TransportFunctionPointer<InitializeConnectionDelegate> InitializeConnection; //Field offset: 0x10
	public readonly int ReceiveCapacity; //Field offset: 0x18
	public readonly int SendCapacity; //Field offset: 0x1C
	public readonly int HeaderCapacity; //Field offset: 0x20
	public readonly int SharedStateCapacity; //Field offset: 0x24
	public readonly int PayloadCapacity; //Field offset: 0x28
	internal int StaticStateStart; //Field offset: 0x2C
	internal int StaticStateCapcity; //Field offset: 0x30

	public NetworkPipelineStage(TransportFunctionPointer<ReceiveDelegate> Receive, TransportFunctionPointer<SendDelegate> Send, TransportFunctionPointer<InitializeConnectionDelegate> InitializeConnection, int ReceiveCapacity, int SendCapacity, int HeaderCapacity, int SharedStateCapacity, int PayloadCapacity = 0) { }

}

