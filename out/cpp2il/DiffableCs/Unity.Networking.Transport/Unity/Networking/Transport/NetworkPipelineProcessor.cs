namespace Unity.Networking.Transport;

internal struct NetworkPipelineProcessor : IDisposable
{
	internal struct Concurrent
	{
		[ReadOnly]
		internal NativeArray<NetworkPipelineStage> m_StageCollection; //Field offset: 0x0
		[ReadOnly]
		internal NativeArray<Byte> m_StaticInstanceBuffer; //Field offset: 0x10
		[ReadOnly]
		internal NativeList<PipelineImpl> m_Pipelines; //Field offset: 0x20
		[ReadOnly]
		internal NativeList<Int32> m_StageList; //Field offset: 0x30
		[ReadOnly]
		internal NativeList<Int32> m_AccumulatedHeaderCapacity; //Field offset: 0x40
		internal ParallelWriter<UpdatePipeline> m_SendStageNeedsUpdateWrite; //Field offset: 0x50
		[ReadOnly]
		internal NativeArray<Int32> sizePerConnection; //Field offset: 0x68
		[ReadOnly]
		internal NativeList<Byte> sharedBuffer; //Field offset: 0x78
		[ReadOnly]
		internal NativeList<Byte> sendBuffer; //Field offset: 0x88
		[ReadOnly]
		internal NativeArray<Int64> m_timestamp; //Field offset: 0x98

		public int PayloadCapacity(NetworkPipeline pipeline) { }

		internal int ProcessPipelineSend(Concurrent driver, int startStage, NetworkPipeline pipeline, NetworkConnection connection, NetworkInterfaceSendHandle sendHandle, int headerSize, NativeList<UpdatePipeline> currentUpdates) { }

		private int ProcessSendStage(int startStage, int internalBufferOffset, int internalSharedBufferOffset, PipelineImpl p, ref NativeList<Int32>& resumeQ, ref NetworkPipelineContext ctx, ref InboundSendBuffer inboundBuffer, ref Requests requests, int systemHeaderSize) { }

		public int Send(Concurrent driver, NetworkPipeline pipeline, NetworkConnection connection, NetworkInterfaceSendHandle sendHandle, int headerSize) { }

		public int SendHeaderCapacity(NetworkPipeline pipeline) { }

	}

	public struct PipelineImpl
	{
		public int FirstStageIndex; //Field offset: 0x0
		public int NumStages; //Field offset: 0x4
		public int receiveBufferOffset; //Field offset: 0x8
		public int sendBufferOffset; //Field offset: 0xC
		public int sharedBufferOffset; //Field offset: 0x10
		public int headerCapacity; //Field offset: 0x14
		public int payloadCapacity; //Field offset: 0x18

	}

	public struct UpdatePipeline
	{
		public NetworkPipeline pipeline; //Field offset: 0x0
		public int stage; //Field offset: 0x4
		public NetworkConnection connection; //Field offset: 0x8

	}

	public const int Alignment = 8; //Field offset: 0x0
	private const int SendSizeOffset = 0; //Field offset: 0x0
	private const int RecveiveSizeOffset = 1; //Field offset: 0x0
	private const int SharedSizeOffset = 2; //Field offset: 0x0
	public const int AlignmentMinusOne = 7; //Field offset: 0x0
	private NativeArray<NetworkPipelineStage> m_StageCollection; //Field offset: 0x0
	private NativeArray<Byte> m_StaticInstanceBuffer; //Field offset: 0x10
	private NativeList<Int32> m_StageList; //Field offset: 0x20
	private NativeList<Int32> m_AccumulatedHeaderCapacity; //Field offset: 0x30
	private NativeList<PipelineImpl> m_Pipelines; //Field offset: 0x40
	private NativeList<Byte> m_ReceiveBuffer; //Field offset: 0x50
	private NativeList<Byte> m_SendBuffer; //Field offset: 0x60
	private NativeList<Byte> m_SharedBuffer; //Field offset: 0x70
	private NativeList<UpdatePipeline> m_ReceiveStageNeedsUpdate; //Field offset: 0x80
	private NativeList<UpdatePipeline> m_SendStageNeedsUpdate; //Field offset: 0x90
	private NativeQueue<UpdatePipeline> m_SendStageNeedsUpdateRead; //Field offset: 0xA0
	private NativeArray<Int32> sizePerConnection; //Field offset: 0xB8
	private NativeArray<Int64> m_timestamp; //Field offset: 0xC8

	public internal long Timestamp
	{
		 get { } //Length: 12
		internal set { } //Length: 12
	}

	public NetworkPipelineProcessor(NetworkSettings settings) { }

	private static void AddSendUpdate(NetworkConnection connection, int stageId, NetworkPipeline pipelineId, NativeList<UpdatePipeline> currentUpdates) { }

	public NetworkPipeline CreatePipeline(Type[] stages) { }

	public override void Dispose() { }

	public long get_Timestamp() { }

	public void GetPipelineBuffers(NetworkPipeline pipelineId, NetworkPipelineStageId stageId, NetworkConnection connection, out NativeArray<Byte>& readProcessingBuffer, out NativeArray<Byte>& writeProcessingBuffer, out NativeArray<Byte>& sharedBuffer) { }

	public void initializeConnection(NetworkConnection con) { }

	private void InitializeStages(int networkId) { }

	public int PayloadCapacity(NetworkPipeline pipeline) { }

	private void ProcessReceiveStage(int stage, NetworkPipeline pipeline, int internalBufferOffset, int internalSharedBufferOffset, ref NetworkPipelineContext ctx, ref InboundRecvBuffer inboundBuffer, ref NativeList<Int32>& resumeQ, ref bool needsUpdate, ref bool needsSendUpdate, int systemHeadersSize) { }

	private void ProcessReceiveStagesFrom(NetworkDriver driver, int startStage, NetworkPipeline pipeline, NetworkConnection connection, InboundRecvBuffer buffer) { }

	public void Receive(NetworkDriver driver, NetworkConnection connection, NativeArray<Byte> buffer) { }

	internal void set_Timestamp(long value) { }

	public Concurrent ToConcurrent() { }

	public void UpdateReceive(NetworkDriver driver, out int updateCount) { }

	internal void UpdateSend(Concurrent driver, out int updateCount) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	public static void ValidateSendHandle(NetworkInterfaceSendHandle handle) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void ValidateStages(Type[] stages) { }

}

