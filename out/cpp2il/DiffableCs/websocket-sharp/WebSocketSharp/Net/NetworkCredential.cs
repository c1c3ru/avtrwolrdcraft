namespace WebSocketSharp.Net;

public class NetworkCredential
{
	private static readonly String[] _noRoles; //Field offset: 0x0
	private string _domain; //Field offset: 0x10
	private string _password; //Field offset: 0x18
	private String[] _roles; //Field offset: 0x20
	private string _username; //Field offset: 0x28

	public internal string Domain
	{
		 get { } //Length: 84
		internal set { } //Length: 8
	}

	public internal string Password
	{
		 get { } //Length: 84
		internal set { } //Length: 8
	}

	public internal String[] Roles
	{
		 get { } //Length: 100
		internal set { } //Length: 8
	}

	public internal string Username
	{
		 get { } //Length: 8
		internal set { } //Length: 8
	}

	private static NetworkCredential() { }

	public NetworkCredential(string username, string password) { }

	public NetworkCredential(string username, string password, string domain, String[] roles) { }

	public string get_Domain() { }

	public string get_Password() { }

	public String[] get_Roles() { }

	public string get_Username() { }

	internal void set_Domain(string value) { }

	internal void set_Password(string value) { }

	internal void set_Roles(String[] value) { }

	internal void set_Username(string value) { }

}

