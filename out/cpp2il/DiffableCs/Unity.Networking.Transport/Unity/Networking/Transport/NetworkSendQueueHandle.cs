namespace Unity.Networking.Transport;

public struct NetworkSendQueueHandle
{
	private IntPtr handle; //Field offset: 0x0

	public ParallelWriter<QueuedSendMessage> FromHandle() { }

	internal static NetworkSendQueueHandle ToTempHandle(ParallelWriter<QueuedSendMessage> sendQueue) { }

}

