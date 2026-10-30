namespace System.Security.Principal;

public interface IPrincipal
{

	public IIdentity Identity
	{
		 get { } //Length: 0
	}

	public IIdentity get_Identity() { }

}

