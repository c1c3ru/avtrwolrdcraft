namespace System.Security.Principal;

public class GenericIdentity : ClaimsIdentity
{
	private readonly string m_name; //Field offset: 0x78
	private readonly string m_type; //Field offset: 0x80

	public virtual string AuthenticationType
	{
		 get { } //Length: 8
	}

	public virtual IEnumerable<Claim> Claims
	{
		 get { } //Length: 4
	}

	public virtual bool IsAuthenticated
	{
		 get { } //Length: 96
	}

	public virtual string Name
	{
		 get { } //Length: 8
	}

	public GenericIdentity(string name, string type) { }

	private GenericIdentity() { }

	protected GenericIdentity(GenericIdentity identity) { }

	private void AddNameClaim() { }

	public virtual ClaimsIdentity Clone() { }

	public virtual string get_AuthenticationType() { }

	public virtual IEnumerable<Claim> get_Claims() { }

	public virtual bool get_IsAuthenticated() { }

	public virtual string get_Name() { }

}

