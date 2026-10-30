namespace System.Net.NetworkInformation;

internal abstract class CommonUnixIPGlobalProperties : IPGlobalProperties
{

	public virtual string DomainName
	{
		 get { } //Length: 396
	}

	protected CommonUnixIPGlobalProperties() { }

	public virtual string get_DomainName() { }

	private static int getdomainname(Byte[] name, int len) { }

}

