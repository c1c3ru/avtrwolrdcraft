namespace UnityWebSocketSharp.Net;

internal class ChunkStream
{
	private int _chunkRead; //Field offset: 0x10
	private int _chunkSize; //Field offset: 0x14
	private List<Chunk> _chunks; //Field offset: 0x18
	private int _count; //Field offset: 0x20
	private Byte[] _endBuffer; //Field offset: 0x28
	private bool _gotIt; //Field offset: 0x30
	private WebHeaderCollection _headers; //Field offset: 0x38
	private int _offset; //Field offset: 0x40
	private StringBuilder _saved; //Field offset: 0x48
	private bool _sawCr; //Field offset: 0x50
	private InputChunkState _state; //Field offset: 0x54
	private int _trailerState; //Field offset: 0x58

	internal int Count
	{
		internal get { } //Length: 8
	}

	internal Byte[] EndBuffer
	{
		internal get { } //Length: 8
	}

	public WebHeaderCollection Headers
	{
		 get { } //Length: 8
	}

	internal int Offset
	{
		internal get { } //Length: 8
	}

	public bool WantsMore
	{
		 get { } //Length: 16
	}

	public ChunkStream(WebHeaderCollection headers) { }

	internal int get_Count() { }

	internal Byte[] get_EndBuffer() { }

	public WebHeaderCollection get_Headers() { }

	internal int get_Offset() { }

	public bool get_WantsMore() { }

	private int read(Byte[] buffer, int offset, int count) { }

	public int Read(Byte[] buffer, int offset, int count) { }

	internal void ResetChunkStore() { }

	private InputChunkState seekCrLf(Byte[] buffer, ref int offset, int length) { }

	private InputChunkState setChunkSize(Byte[] buffer, ref int offset, int length) { }

	private InputChunkState setTrailer(Byte[] buffer, ref int offset, int length) { }

	private static void throwProtocolViolation(string message) { }

	private void write(Byte[] buffer, int offset, int length) { }

	public void Write(Byte[] buffer, int offset, int count) { }

	private InputChunkState writeData(Byte[] buffer, ref int offset, int length) { }

}

