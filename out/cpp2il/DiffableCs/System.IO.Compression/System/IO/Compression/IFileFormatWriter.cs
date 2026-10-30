namespace System.IO.Compression;

internal interface IFileFormatWriter
{

	public Byte[] GetFooter() { }

	public Byte[] GetHeader() { }

	public void UpdateWithBytesRead(Byte[] buffer, int offset, int bytesToCopy) { }

}

