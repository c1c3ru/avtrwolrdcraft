namespace WebSocketSharp.Net;

internal class ChunkedRequestStream : RequestStream
{
	private static readonly int _bufferLength; //Field offset: 0x0
	private HttpListenerContext _context; //Field offset: 0x50
	private ChunkStream _decoder; //Field offset: 0x58
	private bool _disposed; //Field offset: 0x60
	private bool _noMoreData; //Field offset: 0x61

	private static ChunkedRequestStream() { }

	internal ChunkedRequestStream(Stream stream, Byte[] buffer, int offset, int count, HttpListenerContext context) { }

	public virtual IAsyncResult BeginRead(Byte[] buffer, int offset, int count, AsyncCallback callback, object state) { }

	public virtual void Close() { }

	public virtual int EndRead(IAsyncResult asyncResult) { }

	private void onRead(IAsyncResult asyncResult) { }

	public virtual int Read(Byte[] buffer, int offset, int count) { }

}

