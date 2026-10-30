namespace System.Security.Principal;

[ComVisible(True)]
public class GenericPrincipal : ClaimsPrincipal
{
	private IIdentity m_identity; //Field offset: 0x28
	private String[] m_roles; //Field offset: 0x30

	public virtual IIdentity Identity
	{
		 get { } //Length: 8
	}

	public GenericPrincipal(IIdentity identity, String[] roles) { }

	public virtual IIdentity get_Identity() { }

}

