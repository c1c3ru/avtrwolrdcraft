namespace Unity.Networking.Transport;

public interface INetworkInterface : IDisposable
{

	public NetworkInterfaceEndPoint LocalEndPoint
	{
		 get { } //Length: 0
	}

	public int Bind(NetworkInterfaceEndPoint endpoint) { }

	public int CreateInterfaceEndPoint(NetworkEndPoint address, out NetworkInterfaceEndPoint endpoint) { }

	public NetworkSendInterface CreateSendInterface() { }

	public NetworkInterfaceEndPoint get_LocalEndPoint() { }

	public NetworkEndPoint GetGenericEndPoint(NetworkInterfaceEndPoint endpoint) { }

	public int Initialize(NetworkSettings settings) { }

	public int Listen() { }

	public JobHandle ScheduleReceive(NetworkPacketReceiver receiver, JobHandle dep) { }

	public JobHandle ScheduleSend(NativeQueue<QueuedSendMessage> sendQueue, JobHandle dep) { }

}

