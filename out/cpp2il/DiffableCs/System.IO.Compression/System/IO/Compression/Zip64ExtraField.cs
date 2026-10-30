namespace System.IO.Compression;

internal struct Zip64ExtraField
{
	private ushort _size; //Field offset: 0x0
	private Nullable<Int64> _uncompressedSize; //Field offset: 0x8
	private Nullable<Int64> _compressedSize; //Field offset: 0x18
	private Nullable<Int64> _localHeaderOffset; //Field offset: 0x28
	private Nullable<Int32> _startDiskNumber; //Field offset: 0x38

	public Nullable<Int64> CompressedSize
	{
		 get { } //Length: 12
		 set { } //Length: 8
	}

	public Nullable<Int64> LocalHeaderOffset
	{
		 get { } //Length: 12
		 set { } //Length: 8
	}

	public Nullable<Int32> StartDiskNumber
	{
		 get { } //Length: 8
	}

	public ushort TotalSize
	{
		 get { } //Length: 12
	}

	public Nullable<Int64> UncompressedSize
	{
		 get { } //Length: 12
		 set { } //Length: 8
	}

	public Nullable<Int64> get_CompressedSize() { }

	public Nullable<Int64> get_LocalHeaderOffset() { }

	public Nullable<Int32> get_StartDiskNumber() { }

	public ushort get_TotalSize() { }

	public Nullable<Int64> get_UncompressedSize() { }

	public static Zip64ExtraField GetAndRemoveZip64Block(List<ZipGenericExtraField> extraFields, bool readUncompressedSize, bool readCompressedSize, bool readLocalHeaderOffset, bool readStartDiskNumber) { }

	public static Zip64ExtraField GetJustZip64Block(Stream extraFieldStream, bool readUncompressedSize, bool readCompressedSize, bool readLocalHeaderOffset, bool readStartDiskNumber) { }

	public static void RemoveZip64Blocks(List<ZipGenericExtraField> extraFields) { }

	public void set_CompressedSize(Nullable<Int64> value) { }

	public void set_LocalHeaderOffset(Nullable<Int64> value) { }

	public void set_UncompressedSize(Nullable<Int64> value) { }

	private static bool TryGetZip64BlockFromGenericExtraField(ZipGenericExtraField extraField, bool readUncompressedSize, bool readCompressedSize, bool readLocalHeaderOffset, bool readStartDiskNumber, out Zip64ExtraField zip64Block) { }

	private void UpdateSize() { }

	public void WriteBlock(Stream stream) { }

}

