namespace Unity.Networking.Transport;

internal struct NetworkProtocol
{
	[UnmanagedFunctionPointer(CallingConvention::Cdecl (2))]
	internal sealed class ComputePacketOverheadDelegate : MulticastDelegate
	{

		public ComputePacketOverheadDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(ref Connection connection, out int payloadOffset, AsyncCallback callback, object object) { }

		public override int EndInvoke(ref Connection connection, out int payloadOffset, IAsyncResult result) { }

		public override int Invoke(ref Connection connection, out int payloadOffset) { }

	}

	[UnmanagedFunctionPointer(CallingConvention::Cdecl (2))]
	internal sealed class ConnectDelegate : MulticastDelegate
	{

		public ConnectDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(ref Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData, AsyncCallback callback, object object) { }

		public override void EndInvoke(ref Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IAsyncResult result) { }

		public override void Invoke(ref Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData) { }

	}

	[UnmanagedFunctionPointer(CallingConvention::Cdecl (2))]
	internal sealed class DisconnectDelegate : MulticastDelegate
	{

		public DisconnectDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(ref Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData, AsyncCallback callback, object object) { }

		public override void EndInvoke(ref Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IAsyncResult result) { }

		public override void Invoke(ref Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData) { }

	}

	[UnmanagedFunctionPointer(CallingConvention::Cdecl (2))]
	internal sealed class ProcessReceiveDelegate : MulticastDelegate
	{

		public ProcessReceiveDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(IntPtr stream, ref NetworkInterfaceEndPoint address, int size, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData, ref ProcessPacketCommand command, AsyncCallback callback, object object) { }

		public override void EndInvoke(ref NetworkInterfaceEndPoint address, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, ref ProcessPacketCommand command, IAsyncResult result) { }

		public override void Invoke(IntPtr stream, ref NetworkInterfaceEndPoint address, int size, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData, ref ProcessPacketCommand command) { }

	}

	[UnmanagedFunctionPointer(CallingConvention::Cdecl (2))]
	internal sealed class ProcessSendConnectionAcceptDelegate : MulticastDelegate
	{

		public ProcessSendConnectionAcceptDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(ref Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData, AsyncCallback callback, object object) { }

		public override void EndInvoke(ref Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IAsyncResult result) { }

		public override void Invoke(ref Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData) { }

	}

	[UnmanagedFunctionPointer(CallingConvention::Cdecl (2))]
	internal sealed class ProcessSendDelegate : MulticastDelegate
	{

		public ProcessSendDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(ref Connection connection, bool hasPipeline, ref NetworkSendInterface sendInterface, ref NetworkInterfaceSendHandle sendHandle, ref NetworkSendQueueHandle queueHandle, IntPtr userData, AsyncCallback callback, object object) { }

		public override int EndInvoke(ref Connection connection, ref NetworkSendInterface sendInterface, ref NetworkInterfaceSendHandle sendHandle, ref NetworkSendQueueHandle queueHandle, IAsyncResult result) { }

		public override int Invoke(ref Connection connection, bool hasPipeline, ref NetworkSendInterface sendInterface, ref NetworkInterfaceSendHandle sendHandle, ref NetworkSendQueueHandle queueHandle, IntPtr userData) { }

	}

	[UnmanagedFunctionPointer(CallingConvention::Cdecl (2))]
	internal sealed class ProcessSendPingDelegate : MulticastDelegate
	{

		public ProcessSendPingDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(ref Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData, AsyncCallback callback, object object) { }

		public override void EndInvoke(ref Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IAsyncResult result) { }

		public override void Invoke(ref Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData) { }

	}

	[UnmanagedFunctionPointer(CallingConvention::Cdecl (2))]
	internal sealed class ProcessSendPongDelegate : MulticastDelegate
	{

		public ProcessSendPongDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(ref Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData, AsyncCallback callback, object object) { }

		public override void EndInvoke(ref Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IAsyncResult result) { }

		public override void Invoke(ref Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData) { }

	}

	[UnmanagedFunctionPointer(CallingConvention::Cdecl (2))]
	internal sealed class UpdateDelegate : MulticastDelegate
	{

		public UpdateDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(long updateTime, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData, AsyncCallback callback, object object) { }

		public override void EndInvoke(ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IAsyncResult result) { }

		public override void Invoke(long updateTime, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData) { }

	}

	public TransportFunctionPointer<ComputePacketOverheadDelegate> ComputePacketOverhead; //Field offset: 0x0
	public TransportFunctionPointer<ProcessReceiveDelegate> ProcessReceive; //Field offset: 0x8
	public TransportFunctionPointer<ProcessSendDelegate> ProcessSend; //Field offset: 0x10
	public TransportFunctionPointer<ProcessSendConnectionAcceptDelegate> ProcessSendConnectionAccept; //Field offset: 0x18
	public TransportFunctionPointer<ConnectDelegate> Connect; //Field offset: 0x20
	public TransportFunctionPointer<DisconnectDelegate> Disconnect; //Field offset: 0x28
	public TransportFunctionPointer<ProcessSendPingDelegate> ProcessSendPing; //Field offset: 0x30
	public TransportFunctionPointer<ProcessSendPongDelegate> ProcessSendPong; //Field offset: 0x38
	public TransportFunctionPointer<UpdateDelegate> Update; //Field offset: 0x40
	[NativeDisableUnsafePtrRestriction]
	public IntPtr UserData; //Field offset: 0x48
	public int MaxHeaderSize; //Field offset: 0x50
	public int MaxFooterSize; //Field offset: 0x54
	public bool NeedsUpdate; //Field offset: 0x58

	public int PaddingSize
	{
		 get { } //Length: 12
	}

	public NetworkProtocol(TransportFunctionPointer<ComputePacketOverheadDelegate> computePacketOverhead, TransportFunctionPointer<ProcessReceiveDelegate> processReceive, TransportFunctionPointer<ProcessSendDelegate> processSend, TransportFunctionPointer<ProcessSendConnectionAcceptDelegate> processSendConnectionAccept, TransportFunctionPointer<ConnectDelegate> connect, TransportFunctionPointer<DisconnectDelegate> disconnect, TransportFunctionPointer<ProcessSendPingDelegate> processSendPing, TransportFunctionPointer<ProcessSendPongDelegate> processSendPong, TransportFunctionPointer<UpdateDelegate> update, bool needsUpdate, IntPtr userData, int maxHeaderSize, int maxFooterSize) { }

	public int get_PaddingSize() { }

}

