namespace Unity.Networking.Transport;

[BurstCompile]
public struct BaselibNetworkInterface : INetworkInterface, IDisposable
{
	public struct BaselibData
	{
		public Baselib_RegisteredNetwork_Socket_UDP m_Socket; //Field offset: 0x0
		public SocketStatus m_SocketStatus; //Field offset: 0x8
		public Payloads m_PayloadsTx; //Field offset: 0x10
		public NetworkInterfaceEndPoint m_LocalEndpoint; //Field offset: 0x68
		public long m_LastUpdateTime; //Field offset: 0xA8
		public long m_LastSocketRecreateTime; //Field offset: 0xB0
		public uint m_NumSocketRecreate; //Field offset: 0xB8

	}

	[BurstCompile]
	private struct FlushSendJob : IJob
	{
		public Payloads Tx; //Field offset: 0x0
		[NativeDisableContainerSafetyRestriction]
		public NativeArray<BaselibData> Baselib; //Field offset: 0x58

		public override void Execute() { }

	}

	public struct Payloads : IDisposable
	{
		public UnsafeAtomicFreeList m_Handles; //Field offset: 0x0
		public UnsafeBaselibNetworkArray m_PayloadArray; //Field offset: 0x10
		public UnsafeBaselibNetworkArray m_EndpointArray; //Field offset: 0x30
		private uint m_PayloadSize; //Field offset: 0x50

		public int Capacity
		{
			 get { } //Length: 8
		}

		public int InUse
		{
			 get { } //Length: 8
		}

		public bool IsCreated
		{
			 get { } //Length: 8
		}

		public Payloads(int capacity, uint maxPayloadSize) { }

		public int AcquireHandle() { }

		public override void Dispose() { }

		public int get_Capacity() { }

		public int get_InUse() { }

		public bool get_IsCreated() { }

		public Baselib_RegisteredNetwork_Request GetRequestFromHandle(int handle) { }

		public void ReleaseHandle(int handle) { }

	}

	[BurstCompile]
	private struct ReceiveJob : IJob
	{
		public NetworkPacketReceiver Receiver; //Field offset: 0x0
		public Payloads Rx; //Field offset: 0x2B0
		[NativeDisableContainerSafetyRestriction]
		public NativeArray<BaselibData> Baselib; //Field offset: 0x308

		public override void Execute() { }

	}

	public enum SocketStatus
	{
		SocketNormal = 0,
		SocketNeedsRecreate = 1,
		SocketFailed = 2,
	}

	public static BaselibNetworkParameter DefaultParameters; //Field offset: 0x0
	private const int k_defaultRxQueueSize = 64; //Field offset: 0x0
	private const int k_defaultTxQueueSize = 64; //Field offset: 0x0
	private const int k_defaultMaximumPayloadSize = 2000; //Field offset: 0x0
	private const uint k_MaxNumSocketRecreate = 1000; //Field offset: 0x0
	private const uint k_RequestsBatchSize = 64; //Field offset: 0x0
	private static TransportFunctionPointer<BeginSendMessageDelegate> BeginSendMessageFunctionPointer; //Field offset: 0x10
	private static TransportFunctionPointer<EndSendMessageDelegate> EndSendMessageFunctionPointer; //Field offset: 0x18
	private static TransportFunctionPointer<AbortSendMessageDelegate> AbortSendMessageFunctionPointer; //Field offset: 0x20
	private BaselibNetworkParameter configuration; //Field offset: 0x0
	[ReadOnly]
	internal NativeArray<BaselibData> m_Baselib; //Field offset: 0x10
	[NativeDisableContainerSafetyRestriction]
	private Payloads m_PayloadsRx; //Field offset: 0x20
	[NativeDisableContainerSafetyRestriction]
	private Payloads m_PayloadsTx; //Field offset: 0x78
	private UnsafeBaselibNetworkArray m_LocalAndTempEndpoint; //Field offset: 0xD0

	public bool IsCreated
	{
		 get { } //Length: 68
	}

	public override NetworkInterfaceEndPoint LocalEndPoint
	{
		 get { } //Length: 108
	}

	private static BaselibNetworkInterface() { }

	[BurstCompile(DisableDirectCall = True)]
	[MonoPInvokeCallback(typeof(AbortSendMessageDelegate))]
	private static void AbortSendMessage(ref NetworkInterfaceSendHandle handle, IntPtr userData) { }

	[BurstCompile(DisableDirectCall = True)]
	[MonoPInvokeCallback(typeof(BeginSendMessageDelegate))]
	private static int BeginSendMessage(out NetworkInterfaceSendHandle handle, IntPtr userData, int requiredPayloadSize) { }

	public override int Bind(NetworkInterfaceEndPoint endpoint) { }

	public override int CreateInterfaceEndPoint(NetworkEndPoint address, out NetworkInterfaceEndPoint endpoint) { }

	private int CreateInterfaceEndPoint(Baselib_NetworkAddress address, out NetworkInterfaceEndPoint endpoint) { }

	public override NetworkSendInterface CreateSendInterface() { }

	public override void Dispose() { }

	[BurstCompile(DisableDirectCall = True)]
	[MonoPInvokeCallback(typeof(EndSendMessageDelegate))]
	private static int EndSendMessage(ref NetworkInterfaceSendHandle handle, ref NetworkInterfaceEndPoint address, IntPtr userData, ref NetworkSendQueueHandle sendQueueHandle) { }

	public bool get_IsCreated() { }

	public override NetworkInterfaceEndPoint get_LocalEndPoint() { }

	public override NetworkEndPoint GetGenericEndPoint(NetworkInterfaceEndPoint endpoint) { }

	private NetworkInterfaceEndPoint GetLocalEndPoint(Baselib_RegisteredNetwork_Socket_UDP socket) { }

	public override int Initialize(NetworkSettings settings) { }

	public override int Listen() { }

	private static void MarkSocketAsNeedingRecreate(NativeArray<BaselibData> baselib) { }

	private void RecreateSocket(long updateTime) { }

	private static int ScheduleAllReceives(Baselib_RegisteredNetwork_Socket_UDP socket, ref Payloads PayloadsRx) { }

	public override JobHandle ScheduleReceive(NetworkPacketReceiver receiver, JobHandle dep) { }

	public override JobHandle ScheduleSend(NativeQueue<QueuedSendMessage> sendQueue, JobHandle dep) { }

	private bool TryExtractParameters(out BaselibNetworkParameter config, INetworkParameter[] param) { }

	private bool ValidateParameters(BaselibNetworkParameter param) { }

	private bool WouldBindFailWithoutAddressReuse(Baselib_NetworkAddress address) { }

}

