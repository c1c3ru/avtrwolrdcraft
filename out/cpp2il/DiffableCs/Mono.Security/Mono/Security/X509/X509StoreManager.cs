namespace Mono.Security.X509;

public sealed class X509StoreManager
{
	private static string _userPath; //Field offset: 0x0
	private static string _localMachinePath; //Field offset: 0x8
	private static X509Stores _userStore; //Field offset: 0x10
	private static X509Stores _machineStore; //Field offset: 0x18

	public static X509Stores CurrentUser
	{
		 get { } //Length: 180
	}

	internal static string CurrentUserPath
	{
		internal get { } //Length: 280
	}

	public static X509Stores LocalMachine
	{
		 get { } //Length: 180
	}

	internal static string LocalMachinePath
	{
		internal get { } //Length: 272
	}

	public static X509CertificateCollection TrustedRootCertificates
	{
		 get { } //Length: 156
	}

	public static X509Stores get_CurrentUser() { }

	internal static string get_CurrentUserPath() { }

	public static X509Stores get_LocalMachine() { }

	internal static string get_LocalMachinePath() { }

	public static X509CertificateCollection get_TrustedRootCertificates() { }

}

