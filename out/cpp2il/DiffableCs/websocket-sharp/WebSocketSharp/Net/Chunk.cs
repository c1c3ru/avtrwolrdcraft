namespace WebSocketSharp.Net;

internal class Chunk
{
	private Byte[] _data; //Field offset: 0x10
	private int _offset; //Field offset: 0x18

	public int ReadLeft
	{
		 get { } //Length: 36
	}

	public Chunk(Byte[] data) { }

	public int get_ReadLeft() { }

	public int Read(Byte[] buffer, int offset, int count) { }

}

