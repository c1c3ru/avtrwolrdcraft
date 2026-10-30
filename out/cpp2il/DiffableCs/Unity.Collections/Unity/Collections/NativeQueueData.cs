namespace Unity.Collections;

[BurstCompatible]
internal struct NativeQueueData
{
	public IntPtr m_FirstBlock; //Field offset: 0x0
	public IntPtr m_LastBlock; //Field offset: 0x8
	public int m_MaxItems; //Field offset: 0x10
	public int m_CurrentRead; //Field offset: 0x14
	public Byte* m_CurrentWriteBlockTLS; //Field offset: 0x18

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public static void AllocateQueue(AllocatorHandle label, out NativeQueueData* outBuf) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public static NativeQueueBlockHeader* AllocateWriteBlockMT(NativeQueueData* data, NativeQueueBlockPoolData* pool, int threadIndex) { }

	public static void DeallocateQueue(NativeQueueData* data, NativeQueueBlockPoolData* pool, AllocatorHandle allocation) { }

	internal NativeQueueBlockHeader* GetCurrentWriteBlockTLS(int threadIndex) { }

	internal void SetCurrentWriteBlockTLS(int threadIndex, NativeQueueBlockHeader* currentWriteBlock) { }

}

