namespace System.IO.Compression;

internal sealed class HuffmanTree
{
	[CompilerGenerated]
	private static readonly HuffmanTree <StaticLiteralLengthTree>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private static readonly HuffmanTree <StaticDistanceTree>k__BackingField; //Field offset: 0x8
	private readonly int _tableBits; //Field offset: 0x10
	private readonly Int16[] _table; //Field offset: 0x18
	private readonly Int16[] _left; //Field offset: 0x20
	private readonly Int16[] _right; //Field offset: 0x28
	private readonly Byte[] _codeLengthArray; //Field offset: 0x30
	private readonly int _tableMask; //Field offset: 0x38

	public static HuffmanTree StaticDistanceTree
	{
		[CompilerGenerated]
		 get { } //Length: 88
	}

	public static HuffmanTree StaticLiteralLengthTree
	{
		[CompilerGenerated]
		 get { } //Length: 88
	}

	private static HuffmanTree() { }

	public HuffmanTree(Byte[] codeLengths) { }

	private UInt32[] CalculateHuffmanCode() { }

	private void CreateTable() { }

	[CompilerGenerated]
	public static HuffmanTree get_StaticDistanceTree() { }

	[CompilerGenerated]
	public static HuffmanTree get_StaticLiteralLengthTree() { }

	public int GetNextSymbol(InputBuffer input) { }

	private static Byte[] GetStaticDistanceTreeLength() { }

	private static Byte[] GetStaticLiteralTreeLength() { }

}

