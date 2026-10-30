namespace Unity.Networking.Transport;

public struct NetworkCompressionModel : IDisposable
{
	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <bucketOffsets>e__FixedBuffer
	{
		public uint FixedElementField; //Field offset: 0x0

	}

	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <bucketSizes>e__FixedBuffer
	{
		public byte FixedElementField; //Field offset: 0x0

	}

	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <decodeTable>e__FixedBuffer
	{
		public ushort FixedElementField; //Field offset: 0x0

	}

	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <encodeTable>e__FixedBuffer
	{
		public ushort FixedElementField; //Field offset: 0x0

	}

	internal static readonly Byte[] k_BucketSizes; //Field offset: 0x0
	internal const int k_AlphabetSize = 16; //Field offset: 0x0
	internal const int k_MaxHuffmanSymbolLength = 6; //Field offset: 0x0
	internal const int k_MaxContexts = 1; //Field offset: 0x0
	internal static readonly UInt32[] k_BucketOffsets; //Field offset: 0x8
	internal static readonly Int32[] k_FirstBucketCandidate; //Field offset: 0x10
	internal static readonly Byte[] k_DefaultModelData; //Field offset: 0x18
	[FixedBuffer(typeof(ushort), 16)]
	internal <encodeTable>e__FixedBuffer encodeTable; //Field offset: 0x0
	[FixedBuffer(typeof(ushort), 64)]
	internal <decodeTable>e__FixedBuffer decodeTable; //Field offset: 0x20
	[FixedBuffer(typeof(byte), 16)]
	internal <bucketSizes>e__FixedBuffer bucketSizes; //Field offset: 0xA0
	[FixedBuffer(typeof(uint), 16)]
	internal <bucketOffsets>e__FixedBuffer bucketOffsets; //Field offset: 0xB0

	private static NetworkCompressionModel() { }

	public NetworkCompressionModel(Allocator allocator) { }

	public int CalculateBucket(uint value) { }

	public override void Dispose() { }

	private static void GenerateHuffmanCodes(Byte[] symboLCodes, int symbolCodesOffset, Byte[] symbolLengths, int symbolLengthsOffset, int alphabetSize, int maxCodeLength) { }

	private static void GenerateHuffmanDecodeTable(UInt16[] decodeTable, int decodeTableOffset, Byte[] symbolLengths, Byte[] symbolCodes, int alphabetSize, int maxCodeLength) { }

	private static uint ReverseBits(uint value, int num_bits) { }

}

