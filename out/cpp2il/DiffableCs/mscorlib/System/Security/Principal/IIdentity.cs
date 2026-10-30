namespace System.Security.Principal;

public interface IIdentity
{

	public string AuthenticationType
	{
		 get { } //Length: 0
	}

	public bool IsAuthenticated
	{
		 get { } //Length: 0
	}

	public string Name
	{
		 get { } //Length: 0
	}

	public string get_AuthenticationType() { }

	public bool get_IsAuthenticated() { }

	public string get_Name() { }

}

