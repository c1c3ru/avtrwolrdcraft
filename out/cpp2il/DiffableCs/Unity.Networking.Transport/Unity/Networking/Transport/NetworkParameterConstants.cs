namespace Unity.Networking.Transport;

public struct NetworkParameterConstants
{
	public const int InitialEventQueueSize = 100; //Field offset: 0x0
	public const int InvalidConnectionId = -1; //Field offset: 0x0
	public const int DriverDataStreamSize = 65536; //Field offset: 0x0
	public const int ConnectTimeoutMS = 1000; //Field offset: 0x0
	public const int MaxConnectAttempts = 60; //Field offset: 0x0
	public const int DisconnectTimeoutMS = 30000; //Field offset: 0x0
	public const int HeartbeatTimeoutMS = 500; //Field offset: 0x0
	public const int MaxMessageSize = 1400; //Field offset: 0x0
	public const int MTU = 1400; //Field offset: 0x0
	internal const int MaxPacketBufferSize = 1472; //Field offset: 0x0

}

