namespace System.Net.Sockets;

public class SocketAsyncEventArgs : EventArgs, IDisposable
{
	private bool disposed; //Field offset: 0x10
	internal int in_progress; //Field offset: 0x14
	private EndPoint remote_ep; //Field offset: 0x18
	private Socket current_socket; //Field offset: 0x20
	internal SocketAsyncResult socket_async_result; //Field offset: 0x28
	[CompilerGenerated]
	private Socket <AcceptSocket>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private int <BytesTransferred>k__BackingField; //Field offset: 0x38
	[CompilerGenerated]
	private SocketAsyncOperation <LastOperation>k__BackingField; //Field offset: 0x3C
	[CompilerGenerated]
	private int <SendPacketsSendSize>k__BackingField; //Field offset: 0x40
	[CompilerGenerated]
	private SocketError <SocketError>k__BackingField; //Field offset: 0x44
	[CompilerGenerated]
	private SocketFlags <SocketFlags>k__BackingField; //Field offset: 0x48
	[CompilerGenerated]
	private object <UserToken>k__BackingField; //Field offset: 0x50
	[CompilerGenerated]
	private EventHandler<SocketAsyncEventArgs> Completed; //Field offset: 0x58
	private Memory<Byte> _buffer; //Field offset: 0x60
	private int _offset; //Field offset: 0x70
	private int _count; //Field offset: 0x74
	private bool _bufferIsExplicitArray; //Field offset: 0x78
	private IList<ArraySegment`1<Byte>> _bufferList; //Field offset: 0x80

	public event EventHandler<SocketAsyncEventArgs> Completed
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public Socket AcceptSocket
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public IList<ArraySegment`1<Byte>> BufferList
	{
		 get { } //Length: 8
	}

	public private int BytesTransferred
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public int Count
	{
		 get { } //Length: 8
	}

	internal Socket CurrentSocket
	{
		internal get { } //Length: 8
	}

	private SocketAsyncOperation LastOperation
	{
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public Memory<Byte> MemoryBuffer
	{
		 get { } //Length: 12
	}

	public int Offset
	{
		 get { } //Length: 8
	}

	public EndPoint RemoteEndPoint
	{
		 set { } //Length: 8
	}

	[MonoTODO("unused property")]
	public int SendPacketsSendSize
	{
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public SocketError SocketError
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public SocketFlags SocketFlags
	{
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public object UserToken
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public SocketAsyncEventArgs() { }

	internal SocketAsyncEventArgs(bool flowExecutionContext) { }

	[CompilerGenerated]
	public void add_Completed(EventHandler<SocketAsyncEventArgs> value) { }

	internal void Complete_internal() { }

	public override void Dispose() { }

	private void Dispose(bool disposing) { }

	protected virtual void Finalize() { }

	[CompilerGenerated]
	public Socket get_AcceptSocket() { }

	public IList<ArraySegment`1<Byte>> get_BufferList() { }

	[CompilerGenerated]
	public int get_BytesTransferred() { }

	public int get_Count() { }

	internal Socket get_CurrentSocket() { }

	public Memory<Byte> get_MemoryBuffer() { }

	public int get_Offset() { }

	[CompilerGenerated]
	public SocketError get_SocketError() { }

	[CompilerGenerated]
	public object get_UserToken() { }

	protected override void OnCompleted(SocketAsyncEventArgs e) { }

	[CompilerGenerated]
	public void remove_Completed(EventHandler<SocketAsyncEventArgs> value) { }

	[CompilerGenerated]
	public void set_AcceptSocket(Socket value) { }

	[CompilerGenerated]
	private void set_BytesTransferred(int value) { }

	[CompilerGenerated]
	private void set_LastOperation(SocketAsyncOperation value) { }

	public void set_RemoteEndPoint(EndPoint value) { }

	[CompilerGenerated]
	public void set_SendPacketsSendSize(int value) { }

	[CompilerGenerated]
	public void set_SocketError(SocketError value) { }

	[CompilerGenerated]
	public void set_SocketFlags(SocketFlags value) { }

	[CompilerGenerated]
	public void set_UserToken(object value) { }

	public void SetBuffer(Memory<Byte> buffer) { }

	internal void SetBytesTransferred(int value) { }

	internal void SetCurrentSocket(Socket socket) { }

	internal void SetLastOperation(SocketAsyncOperation op) { }

}

