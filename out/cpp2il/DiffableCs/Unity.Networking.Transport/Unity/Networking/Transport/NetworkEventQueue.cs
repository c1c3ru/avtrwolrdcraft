namespace Unity.Networking.Transport;

internal struct NetworkEventQueue : IDisposable
{
	internal struct Concurrent
	{
		[NativeContainer]
		[NativeContainerIsAtomicWriteOnly]
		public struct ConcurrentConnectionQueue
		{
			[NativeDisableUnsafePtrRestriction]
			private UnsafeList<Int32>* m_ConnectionEventHeadTail; //Field offset: 0x0

			public int Length
			{
				 get { } //Length: 72
			}

			public ConcurrentConnectionQueue(NativeList<Int32> queue) { }

			public int Dequeue(int connectionId) { }

			public int get_Length() { }

		}

		[ReadOnly]
		internal NativeList<NetworkEvent> m_ConnectionEventQ; //Field offset: 0x0
		internal ConcurrentConnectionQueue m_ConnectionEventHeadTail; //Field offset: 0x10

		private int MaxEvents
		{
			private get { } //Length: 104
		}

		private int get_MaxEvents() { }

		public Type PopEventForConnection(int connectionId, out int offset, out int size) { }

		public Type PopEventForConnection(int connectionId, out int offset, out int size, out int pipelineId) { }

	}

	private struct SubQueueItem
	{
		public int connection; //Field offset: 0x0
		public int idx; //Field offset: 0x4

	}

	private NativeQueue<SubQueueItem> m_MasterEventQ; //Field offset: 0x0
	private NativeList<NetworkEvent> m_ConnectionEventQ; //Field offset: 0x18
	private NativeList<Int32> m_ConnectionEventHeadTail; //Field offset: 0x28

	private int MaxEvents
	{
		private get { } //Length: 136
	}

	public NetworkEventQueue(int queueSizePerConnection) { }

	internal void Clear() { }

	public override void Dispose() { }

	private int get_MaxEvents() { }

	public int GetCountForConnection(int connectionId) { }

	public Type PopEvent(out int id, out int offset, out int size) { }

	public Type PopEvent(out int id, out int offset, out int size, out int pipelineId) { }

	public Type PopEventForConnection(int connectionId, out int offset, out int size) { }

	public Type PopEventForConnection(int connectionId, out int offset, out int size, out int pipelineId) { }

	public void PushEvent(NetworkEvent ev) { }

	public Concurrent ToConcurrent() { }

}

