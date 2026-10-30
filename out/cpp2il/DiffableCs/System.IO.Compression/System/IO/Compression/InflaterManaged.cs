namespace System.IO.Compression;

internal sealed class InflaterManaged
{
	private static readonly Byte[] s_extraLengthBits; //Field offset: 0x0
	private static readonly Int32[] s_lengthBase; //Field offset: 0x8
	private static readonly Int32[] s_distanceBasePosition; //Field offset: 0x10
	private static readonly Byte[] s_codeOrder; //Field offset: 0x18
	private static readonly Byte[] s_staticDistanceTreeTable; //Field offset: 0x20
	private readonly OutputWindow _output; //Field offset: 0x10
	private readonly InputBuffer _input; //Field offset: 0x18
	private HuffmanTree _literalLengthTree; //Field offset: 0x20
	private HuffmanTree _distanceTree; //Field offset: 0x28
	private InflaterState _state; //Field offset: 0x30
	private bool _hasFormatReader; //Field offset: 0x34
	private int _bfinal; //Field offset: 0x38
	private BlockType _blockType; //Field offset: 0x3C
	private readonly Byte[] _blockLengthBuffer; //Field offset: 0x40
	private int _blockLength; //Field offset: 0x48
	private int _length; //Field offset: 0x4C
	private int _distanceCode; //Field offset: 0x50
	private int _extraBits; //Field offset: 0x54
	private int _loopCounter; //Field offset: 0x58
	private int _literalLengthCodeCount; //Field offset: 0x5C
	private int _distanceCodeCount; //Field offset: 0x60
	private int _codeLengthCodeCount; //Field offset: 0x64
	private int _codeArraySize; //Field offset: 0x68
	private int _lengthCode; //Field offset: 0x6C
	private readonly Byte[] _codeList; //Field offset: 0x70
	private readonly Byte[] _codeLengthTreeCodeLength; //Field offset: 0x78
	private readonly bool _deflate64; //Field offset: 0x80
	private HuffmanTree _codeLengthTree; //Field offset: 0x88
	private IFileFormatReader _formatReader; //Field offset: 0x90

	private static InflaterManaged() { }

	internal InflaterManaged(IFileFormatReader reader, bool deflate64) { }

	private bool Decode() { }

	private bool DecodeBlock(out bool end_of_block_code_seen) { }

	private bool DecodeDynamicBlockHeader() { }

	private bool DecodeUncompressedBlock(out bool end_of_block) { }

	public void Dispose() { }

	public bool Finished() { }

	public int Inflate(Byte[] bytes, int offset, int length) { }

	private void Reset() { }

	public void SetInput(Byte[] inputBytes, int offset, int length) { }

}

