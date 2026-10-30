namespace System.IO.Compression;

internal struct ZipGenericExtraField
{
	private ushort _tag; //Field offset: 0x0
	private ushort _size; //Field offset: 0x2
	private Byte[] _data; //Field offset: 0x8

	public Byte[] Data
	{
		 get { } //Length: 8
	}

	public ushort Size
	{
		 get { } //Length: 8
	}

	public ushort Tag
	{
		 get { } //Length: 8
	}

	public Byte[] get_Data() { }

	public ushort get_Size() { }

	public ushort get_Tag() { }

	public static List<ZipGenericExtraField> ParseExtraField(Stream extraFieldData) { }

	public static int TotalSize(List<ZipGenericExtraField> fields) { }

	public static bool TryReadBlock(BinaryReader reader, long endExtraField, out ZipGenericExtraField field) { }

	public static void WriteAllBlocks(List<ZipGenericExtraField> fields, Stream stream) { }

	public void WriteBlock(Stream stream) { }

}

