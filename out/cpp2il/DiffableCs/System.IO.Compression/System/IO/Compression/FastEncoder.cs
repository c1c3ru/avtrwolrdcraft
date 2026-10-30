namespace System.IO.Compression;

internal sealed class FastEncoder
{
	private readonly FastEncoderWindow _inputWindow; //Field offset: 0x10
	private readonly Match _currentMatch; //Field offset: 0x18
	private double _lastCompressionRatio; //Field offset: 0x20

	internal int BytesInHistory
	{
		internal get { } //Length: 32
	}

	internal double LastCompressionRatio
	{
		internal get { } //Length: 8
	}

	internal DeflateInput UnprocessedInput
	{
		internal get { } //Length: 24
	}

	internal void FlushInput() { }

	internal int get_BytesInHistory() { }

	internal double get_LastCompressionRatio() { }

	internal DeflateInput get_UnprocessedInput() { }

	internal void GetBlock(DeflateInput input, OutputBuffer output, int maxBytesToCopy) { }

	internal void GetBlockFooter(OutputBuffer output) { }

	internal void GetBlockHeader(OutputBuffer output) { }

	internal void GetCompressedData(DeflateInput input, OutputBuffer output) { }

	private void GetCompressedOutput(DeflateInput input, OutputBuffer output, int maxBytesToCopy) { }

	private void GetCompressedOutput(OutputBuffer output) { }

	private bool InputAvailable(DeflateInput input) { }

	private bool SafeToWriteTo(OutputBuffer output) { }

	internal static void WriteChar(byte b, OutputBuffer output) { }

	internal static void WriteDeflatePreamble(OutputBuffer output) { }

	private void WriteEndOfBlock(OutputBuffer output) { }

	internal static void WriteMatch(int matchLen, int matchPos, OutputBuffer output) { }

}

