namespace System.IO.Compression;

internal sealed class InputBuffer
{
	private Byte[] _buffer; //Field offset: 0x10
	private int _start; //Field offset: 0x18
	private int _end; //Field offset: 0x1C
	private uint _bitBuffer; //Field offset: 0x20
	private int _bitsInBuffer; //Field offset: 0x24

	public int AvailableBits
	{
		 get { } //Length: 8
	}

	public int AvailableBytes
	{
		 get { } //Length: 32
	}

	public InputBuffer() { }

	public int CopyTo(Byte[] output, int offset, int length) { }

	public bool EnsureBitsAvailable(int count) { }

	public int get_AvailableBits() { }

	public int get_AvailableBytes() { }

	private uint GetBitMask(int count) { }

	public int GetBits(int count) { }

	public bool NeedsInput() { }

	public void SetInput(Byte[] buffer, int offset, int length) { }

	public void SkipBits(int n) { }

	public void SkipToByteBoundary() { }

	public uint TryLoad16Bits() { }

}

