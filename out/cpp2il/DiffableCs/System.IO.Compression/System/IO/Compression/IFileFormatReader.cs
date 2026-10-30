namespace System.IO.Compression;

internal interface IFileFormatReader
{

	public bool ReadFooter(InputBuffer input) { }

	public bool ReadHeader(InputBuffer input) { }

	public void UpdateWithBytesRead(Byte[] buffer, int offset, int bytesToCopy) { }

	public void Validate() { }

}

