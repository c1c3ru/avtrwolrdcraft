namespace System.IO.Compression;

internal sealed class OutputBuffer
{
	[IsReadOnly]
	public struct BufferState
	{
		internal readonly int _pos; //Field offset: 0x0
		internal readonly uint _bitBuf; //Field offset: 0x4
		internal readonly int _bitCount; //Field offset: 0x8

		internal BufferState(int pos, uint bitBuf, int bitCount) { }

	}

	private Byte[] _byteBuffer; //Field offset: 0x10
	private int _pos; //Field offset: 0x18
	private uint _bitBuf; //Field offset: 0x1C
	private int _bitCount; //Field offset: 0x20

	internal int BitsInBuffer
	{
		internal get { } //Length: 28
	}

	internal int BytesWritten
	{
		internal get { } //Length: 8
	}

	internal int FreeBytes
	{
		internal get { } //Length: 36
	}

	internal BufferState DumpState() { }

	internal void FlushBits() { }

	internal int get_BitsInBuffer() { }

	internal int get_BytesWritten() { }

	internal int get_FreeBytes() { }

	internal void RestoreState(BufferState state) { }

	internal void UpdateBuffer(Byte[] output) { }

	internal void WriteBits(int n, uint bits) { }

	internal void WriteBytes(Byte[] byteArray, int offset, int count) { }

	private void WriteBytesUnaligned(Byte[] byteArray, int offset, int count) { }

	private void WriteByteUnaligned(byte b) { }

	internal void WriteUInt16(ushort value) { }

}

