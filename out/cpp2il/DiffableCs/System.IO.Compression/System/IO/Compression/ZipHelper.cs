namespace System.IO.Compression;

[Extension]
internal static class ZipHelper
{
	private static readonly DateTime s_invalidDateIndicator; //Field offset: 0x0

	private static ZipHelper() { }

	[Extension]
	internal static void AdvanceToPosition(Stream stream, long position) { }

	internal static uint DateTimeToDosTime(DateTime dateTime) { }

	internal static DateTime DosTimeToDateTime(uint dateTime) { }

	internal static void ReadBytes(Stream stream, Byte[] buffer, int bytesToRead) { }

	internal static bool RequiresUnicode(string test) { }

	private static bool SeekBackwardsAndRead(Stream stream, Byte[] buffer, out int bufferPointer) { }

	internal static bool SeekBackwardsToSignature(Stream stream, uint signatureToFind) { }

}

