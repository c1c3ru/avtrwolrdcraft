namespace Unity.Networking.Transport;

public struct NetworkSendInterface
{
	[UnmanagedFunctionPointer(CallingConvention::Cdecl (2))]
	internal sealed class AbortSendMessageDelegate : MulticastDelegate
	{

		public AbortSendMessageDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(ref NetworkInterfaceSendHandle handle, IntPtr userData, AsyncCallback callback, object object) { }

		public override void EndInvoke(ref NetworkInterfaceSendHandle handle, IAsyncResult result) { }

		public override void Invoke(ref NetworkInterfaceSendHandle handle, IntPtr userData) { }

	}

	[UnmanagedFunctionPointer(CallingConvention::Cdecl (2))]
	internal sealed class BeginSendMessageDelegate : MulticastDelegate
	{

		public BeginSendMessageDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(out NetworkInterfaceSendHandle handle, IntPtr userData, int requiredPayloadSize, AsyncCallback callback, object object) { }

		public override int EndInvoke(out NetworkInterfaceSendHandle handle, IAsyncResult result) { }

		public override int Invoke(out NetworkInterfaceSendHandle handle, IntPtr userData, int requiredPayloadSize) { }

	}

	[UnmanagedFunctionPointer(CallingConvention::Cdecl (2))]
	internal sealed class EndSendMessageDelegate : MulticastDelegate
	{

		public EndSendMessageDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(ref NetworkInterfaceSendHandle handle, ref NetworkInterfaceEndPoint address, IntPtr userData, ref NetworkSendQueueHandle sendQueue, AsyncCallback callback, object object) { }

		public override int EndInvoke(ref NetworkInterfaceSendHandle handle, ref NetworkInterfaceEndPoint address, ref NetworkSendQueueHandle sendQueue, IAsyncResult result) { }

		public override int Invoke(ref NetworkInterfaceSendHandle handle, ref NetworkInterfaceEndPoint address, IntPtr userData, ref NetworkSendQueueHandle sendQueue) { }

	}

	public TransportFunctionPointer<BeginSendMessageDelegate> BeginSendMessage; //Field offset: 0x0
	public TransportFunctionPointer<EndSendMessageDelegate> EndSendMessage; //Field offset: 0x8
	public TransportFunctionPointer<AbortSendMessageDelegate> AbortSendMessage; //Field offset: 0x10
	[NativeDisableUnsafePtrRestriction]
	public IntPtr UserData; //Field offset: 0x18

}

