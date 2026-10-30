namespace Unity.Networking.Transport;

public struct DataStreamReader
{
	private struct Context
	{
		public int m_ReadByteIndex; //Field offset: 0x0
		public int m_BitIndex; //Field offset: 0x4
		public ulong m_BitBuffer; //Field offset: 0x8
		public int m_FailedReads; //Field offset: 0x10

	}

	[NativeDisableUnsafePtrRestriction]
	private Byte* m_bufferPtr; //Field offset: 0x0
	private Context m_Context; //Field offset: 0x8
	private int m_Length; //Field offset: 0x20

	public bool HasFailedReads
	{
		 get { } //Length: 16
	}

	public bool IsCreated
	{
		 get { } //Length: 16
	}

	public bool IsLittleEndian
	{
		 get { } //Length: 8
	}

	public int Length
	{
		 get { } //Length: 8
	}

	public DataStreamReader(NativeArray<Byte> array) { }

	public DataStreamReader(Byte* data, int length) { }

	private static int ByteSwap(int val) { }

	private static short ByteSwap(short val) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void CheckBits(int numbits) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckRead() { }

	private void FillBitBuffer() { }

	public bool get_HasFailedReads() { }

	public bool get_IsCreated() { }

	public bool get_IsLittleEndian() { }

	public int get_Length() { }

	public int GetBitsRead() { }

	public int GetBytesRead() { }

	public Void* GetUnsafeReadOnlyPtr() { }

	private static void Initialize(out DataStreamReader self, NativeArray<Byte> array) { }

	public byte ReadByte() { }

	public void ReadBytes(Byte* data, int length) { }

	public void ReadBytes(NativeArray<Byte> array) { }

	public ushort ReadFixedString(Byte* data, int maxLength) { }

	public FixedString128Bytes ReadFixedString128() { }

	public FixedString32Bytes ReadFixedString32() { }

	public FixedString4096Bytes ReadFixedString4096() { }

	public FixedString512Bytes ReadFixedString512() { }

	public FixedString64Bytes ReadFixedString64() { }

	public float ReadFloat() { }

	public int ReadInt() { }

	public int ReadIntNetworkByteOrder() { }

	public long ReadLong() { }

	public FixedString128Bytes ReadPackedFixedString128Delta(FixedString128Bytes baseline, NetworkCompressionModel model) { }

	public FixedString32Bytes ReadPackedFixedString32Delta(FixedString32Bytes baseline, NetworkCompressionModel model) { }

	public FixedString4096Bytes ReadPackedFixedString4096Delta(FixedString4096Bytes baseline, NetworkCompressionModel model) { }

	public FixedString512Bytes ReadPackedFixedString512Delta(FixedString512Bytes baseline, NetworkCompressionModel model) { }

	public FixedString64Bytes ReadPackedFixedString64Delta(FixedString64Bytes baseline, NetworkCompressionModel model) { }

	public ushort ReadPackedFixedStringDelta(Byte* data, int maxLength, Byte* baseData, ushort baseLength, NetworkCompressionModel model) { }

	public float ReadPackedFloat(NetworkCompressionModel model) { }

	public float ReadPackedFloatDelta(float baseline, NetworkCompressionModel model) { }

	public int ReadPackedInt(NetworkCompressionModel model) { }

	public int ReadPackedIntDelta(int baseline, NetworkCompressionModel model) { }

	public long ReadPackedLong(NetworkCompressionModel model) { }

	public long ReadPackedLongDelta(long baseline, NetworkCompressionModel model) { }

	public uint ReadPackedUInt(NetworkCompressionModel model) { }

	public uint ReadPackedUIntDelta(uint baseline, NetworkCompressionModel model) { }

	public ulong ReadPackedULong(NetworkCompressionModel model) { }

	public ulong ReadPackedULongDelta(ulong baseline, NetworkCompressionModel model) { }

	public uint ReadRawBits(int numbits) { }

	private uint ReadRawBitsInternal(int numbits) { }

	public short ReadShort() { }

	public short ReadShortNetworkByteOrder() { }

	public uint ReadUInt() { }

	public uint ReadUIntNetworkByteOrder() { }

	public ulong ReadULong() { }

	public ushort ReadUShort() { }

	public ushort ReadUShortNetworkByteOrder() { }

	public void SeekSet(int pos) { }

}

