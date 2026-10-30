namespace System.Net.Sockets;

public class TcpListener
{
	private IPEndPoint m_ServerSocketEP; //Field offset: 0x10
	private Socket m_ServerSocket; //Field offset: 0x18
	private bool m_Active; //Field offset: 0x20
	private bool m_ExclusiveAddressUse; //Field offset: 0x21

	public Socket Server
	{
		 get { } //Length: 8
	}

	public TcpListener(IPAddress localaddr, int port) { }

	public TcpClient AcceptTcpClient() { }

	public Socket get_Server() { }

	public void Start() { }

	public void Start(int backlog) { }

	public void Stop() { }

}

