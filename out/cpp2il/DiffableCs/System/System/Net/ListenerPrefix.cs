namespace System.Net;

internal sealed class ListenerPrefix
{
	private string original; //Field offset: 0x10
	private string host; //Field offset: 0x18
	private ushort port; //Field offset: 0x20
	private string path; //Field offset: 0x28
	private bool secure; //Field offset: 0x30
	public HttpListener Listener; //Field offset: 0x38

	public string Host
	{
		 get { } //Length: 8
	}

	public string Path
	{
		 get { } //Length: 8
	}

	public int Port
	{
		 get { } //Length: 8
	}

	public bool Secure
	{
		 get { } //Length: 8
	}

	public ListenerPrefix(string prefix) { }

	public static void CheckUri(string uri) { }

	public virtual bool Equals(object o) { }

	public string get_Host() { }

	public string get_Path() { }

	public int get_Port() { }

	public bool get_Secure() { }

	public virtual int GetHashCode() { }

	private void Parse(string uri) { }

	public virtual string ToString() { }

}

