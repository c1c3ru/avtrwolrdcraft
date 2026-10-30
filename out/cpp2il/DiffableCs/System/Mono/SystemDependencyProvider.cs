namespace Mono;

internal class SystemDependencyProvider : ISystemDependencyProvider
{
	private static SystemDependencyProvider instance; //Field offset: 0x0
	private static object syncRoot; //Field offset: 0x8
	[CompilerGenerated]
	private readonly SystemCertificateProvider <CertificateProvider>k__BackingField; //Field offset: 0x10

	public SystemCertificateProvider CertificateProvider
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public static SystemDependencyProvider Instance
	{
		 get { } //Length: 92
	}

	private override ISystemCertificateProvider Mono.ISystemDependencyProvider.CertificateProvider
	{
		private get { } //Length: 8
	}

	public X509PalImpl X509Pal
	{
		 get { } //Length: 24
	}

	private static SystemDependencyProvider() { }

	private SystemDependencyProvider() { }

	[CompilerGenerated]
	public SystemCertificateProvider get_CertificateProvider() { }

	public static SystemDependencyProvider get_Instance() { }

	public X509PalImpl get_X509Pal() { }

	internal static void Initialize() { }

	private override ISystemCertificateProvider Mono.ISystemDependencyProvider.get_CertificateProvider() { }

}

