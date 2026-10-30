namespace System.IO.Compression;

internal sealed class FastEncoderWindow
{
	private Byte[] _window; //Field offset: 0x10
	private int _bufPos; //Field offset: 0x18
	private int _bufEnd; //Field offset: 0x1C
	private UInt16[] _prev; //Field offset: 0x20
	private UInt16[] _lookup; //Field offset: 0x28

	public int BytesAvailable
	{
		 get { } //Length: 12
	}

	public int FreeWindowSpace
	{
		 get { } //Length: 16
	}

	public DeflateInput UnprocessedInput
	{
		 get { } //Length: 132
	}

	public void CopyBytes(Byte[] inputBuffer, int startIndex, int count) { }

	private int FindMatch(int search, out int matchPos, int searchDepth, int niceLength) { }

	public void FlushWindow() { }

	public int get_BytesAvailable() { }

	public int get_FreeWindowSpace() { }

	public DeflateInput get_UnprocessedInput() { }

	internal bool GetNextSymbolOrMatch(Match match) { }

	private uint HashValue(uint hash, byte b) { }

	private uint InsertString(ref uint hash) { }

	private void InsertStrings(ref uint hash, int matchLen) { }

	public void MoveWindows() { }

	private void ResetWindow() { }

}

