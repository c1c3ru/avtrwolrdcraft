namespace System.Net;

internal class ChunkedInputStream : RequestStream
{
	private class ReadBufferState
	{
		public Byte[] Buffer; //Field offset: 0x10
		public int Offset; //Field offset: 0x18
		public int Count; //Field offset: 0x1C
		public int InitialCount; //Field offset: 0x20
		public HttpStreamAsyncResult Ares; //Field offset: 0x28

		public ReadBufferState(Byte[] buffer, int offset, int count, HttpStreamAsyncResult ares) { }

	}

	private bool disposed; //Field offset: 0x50
	private MonoChunkParser decoder; //Field offset: 0x58
	private HttpListenerContext context; //Field offset: 0x60
	private bool no_more_data; //Field offset: 0x68

	public ChunkedInputStream(HttpListenerContext context, Stream stream, Byte[] buffer, int offset, int length) { }

	public virtual IAsyncResult BeginRead(Byte[] buffer, int offset, int count, AsyncCallback cback, object state) { }

	public virtual void Close() { }

	public virtual int EndRead(IAsyncResult ares) { }

	private void OnRead(IAsyncResult base_ares) { }

	public virtual int Read(out Byte[] buffer, int offset, int count) { }

}

