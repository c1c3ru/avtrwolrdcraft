namespace Unity.Collections;

internal struct NativeQueueBlockHeader
{
	public NativeQueueBlockHeader* m_NextBlock; //Field offset: 0x0
	public int m_NumItems; //Field offset: 0x8

}

