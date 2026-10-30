namespace System.IO.Compression;

internal sealed class OutputWindow
{
	private readonly Byte[] _window; //Field offset: 0x10
	private int _end; //Field offset: 0x18
	private int _bytesUsed; //Field offset: 0x1C

	public int AvailableBytes
	{
		 get { } //Length: 8
	}

	public int FreeBytes
	{
		 get { } //Length: 16
	}

	public OutputWindow() { }

	public int CopyFrom(InputBuffer input, int length) { }

	public int CopyTo(Byte[] output, int offset, int length) { }

	public int get_AvailableBytes() { }

	public int get_FreeBytes() { }

	public void Write(byte b) { }

	public void WriteLengthDistance(int length, int distance) { }

}

