namespace System.IO.Compression;

internal sealed class DeflaterManaged
{
	private enum DeflaterState
	{
		NotStarted = 0,
		SlowDownForIncompressible1 = 1,
		SlowDownForIncompressible2 = 2,
		StartingSmallData = 3,
		CompressThenCheck = 4,
		CheckingForIncompressible = 5,
		HandlingSmallData = 6,
	}

	private readonly FastEncoder _deflateEncoder; //Field offset: 0x10
	private readonly CopyEncoder _copyEncoder; //Field offset: 0x18
	private readonly DeflateInput _input; //Field offset: 0x20
	private readonly OutputBuffer _output; //Field offset: 0x28
	private DeflaterState _processingState; //Field offset: 0x30
	private DeflateInput _inputFromHistory; //Field offset: 0x38

	public override void Dispose() { }

	internal bool Finish(Byte[] outputBuffer, out int bytesRead) { }

	private void FlushInputWindows() { }

	internal int GetDeflateOutput(Byte[] outputBuffer) { }

	internal bool NeedsInput() { }

	internal void SetInput(Byte[] inputBuffer, int startIndex, int count) { }

	private bool UseCompressed(double ratio) { }

	private void WriteFinal() { }

}

