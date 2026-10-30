namespace System.Net.NetworkInformation;

internal sealed class UnixNoLibCIPGlobalProperties : UnixIPGlobalProperties
{

	public virtual string DomainName
	{
		 get { } //Length: 72
	}

	public UnixNoLibCIPGlobalProperties() { }

	public virtual string get_DomainName() { }

}

