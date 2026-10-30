namespace Unity.Networking.Transport;

public struct DataStreamWriter
{
	private struct StreamData
	{
		public Byte* buffer; //Field offset: 0x0
		public int length; //Field offset: 0x8
		public int capacity; //Field offset: 0xC
		public ulong bitBuffer; //Field offset: 0x10
		public int bitIndex; //Field offset: 0x18
		public int failedWrites; //Field offset: 0x1C

	}

	[NativeDisableUnsafePtrRestriction]
	private StreamData m_Data; //Field offset: 0x0
	internal IntPtr m_SendHandleData; //Field offset: 0x20

	public int Capacity
	{
		 get { } //Length: 8
	}

	public bool HasFailedWrites
	{
		 get { } //Length: 16
	}

	public bool IsCreated
	{
		 get { } //Length: 16
	}

	public static bool IsLittleEndian
	{
		 get { } //Length: 8
	}

	public int Length
	{
		 get { } //Length: 80
	}

	public int LengthInBits
	{
		 get { } //Length: 76
	}

	public DataStreamWriter(int length, Allocator allocator) { }

	public DataStreamWriter(NativeArray<Byte> data) { }

	public DataStreamWriter(Byte* data, int length) { }

	public NativeArray<Byte> AsNativeArray() { }

	private static short ByteSwap(short val) { }

	private static int ByteSwap(int val) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void CheckAllocator(Allocator allocator) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void CheckBits(uint value, int numbits) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckRead() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckWrite() { }

	public void Clear() { }

	public void Flush() { }

	private void FlushBits() { }

	public int get_Capacity() { }

	public bool get_HasFailedWrites() { }

	public bool get_IsCreated() { }

	public static bool get_IsLittleEndian() { }

	public int get_Length() { }

	public int get_LengthInBits() { }

	private static void Initialize(out DataStreamWriter self, NativeArray<Byte> data) { }

	private void SyncBitData() { }

	public bool WriteByte(byte value) { }

	public bool WriteBytes(NativeArray<Byte> value) { }

	public bool WriteBytes(Byte* data, int bytes) { }

	public bool WriteFixedString128(FixedString128Bytes str) { }

	public bool WriteFixedString32(FixedString32Bytes str) { }

	public bool WriteFixedString4096(FixedString4096Bytes str) { }

	public bool WriteFixedString512(FixedString512Bytes str) { }

	public bool WriteFixedString64(FixedString64Bytes str) { }

	public bool WriteFloat(float value) { }

	public bool WriteInt(int value) { }

	public bool WriteIntNetworkByteOrder(int value) { }

	public bool WriteLong(long value) { }

	public bool WritePackedFixedString128Delta(FixedString128Bytes str, FixedString128Bytes baseline, NetworkCompressionModel model) { }

	public bool WritePackedFixedString32Delta(FixedString32Bytes str, FixedString32Bytes baseline, NetworkCompressionModel model) { }

	public bool WritePackedFixedString4096Delta(FixedString4096Bytes str, FixedString4096Bytes baseline, NetworkCompressionModel model) { }

	public bool WritePackedFixedString512Delta(FixedString512Bytes str, FixedString512Bytes baseline, NetworkCompressionModel model) { }

	public bool WritePackedFixedString64Delta(FixedString64Bytes str, FixedString64Bytes baseline, NetworkCompressionModel model) { }

	private bool WritePackedFixedStringDelta(Byte* data, uint length, Byte* baseData, uint baseLength, NetworkCompressionModel model) { }

	public bool WritePackedFloat(float value, NetworkCompressionModel model) { }

	public bool WritePackedFloatDelta(float value, float baseline, NetworkCompressionModel model) { }

	public bool WritePackedInt(int value, NetworkCompressionModel model) { }

	public bool WritePackedIntDelta(int value, int baseline, NetworkCompressionModel model) { }

	public bool WritePackedLong(long value, NetworkCompressionModel model) { }

	public bool WritePackedLongDelta(long value, long baseline, NetworkCompressionModel model) { }

	public bool WritePackedUInt(uint value, NetworkCompressionModel model) { }

	public bool WritePackedUIntDelta(uint value, uint baseline, NetworkCompressionModel model) { }

	public bool WritePackedULong(ulong value, NetworkCompressionModel model) { }

	public bool WritePackedULongDelta(ulong value, ulong baseline, NetworkCompressionModel model) { }

	public bool WriteRawBits(uint value, int numbits) { }

	private void WriteRawBitsInternal(uint value, int numbits) { }

	public bool WriteShort(short value) { }

	public bool WriteShortNetworkByteOrder(short value) { }

	public bool WriteUInt(uint value) { }

	public bool WriteUIntNetworkByteOrder(uint value) { }

	public bool WriteULong(ulong value) { }

	public bool WriteUShort(ushort value) { }

	public bool WriteUShortNetworkByteOrder(ushort value) { }

}

