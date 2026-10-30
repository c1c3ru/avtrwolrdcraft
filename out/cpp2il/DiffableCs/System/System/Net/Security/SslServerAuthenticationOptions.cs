namespace System.Net.Security;

public class SslServerAuthenticationOptions
{
	private X509RevocationMode _checkCertificateRevocation; //Field offset: 0x10
	private SslProtocols _enabledSslProtocols; //Field offset: 0x14
	private EncryptionPolicy _encryptionPolicy; //Field offset: 0x18
	private bool _allowRenegotiation; //Field offset: 0x1C
	[CompilerGenerated]
	private bool <ClientCertificateRequired>k__BackingField; //Field offset: 0x1D
	[CompilerGenerated]
	private X509Certificate <ServerCertificate>k__BackingField; //Field offset: 0x20

	public X509RevocationMode CertificateRevocationCheckMode
	{
		 set { } //Length: 156
	}

	public bool ClientCertificateRequired
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public SslProtocols EnabledSslProtocols
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public EncryptionPolicy EncryptionPolicy
	{
		 set { } //Length: 156
	}

	public X509Certificate ServerCertificate
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public SslServerAuthenticationOptions() { }

	[CompilerGenerated]
	public bool get_ClientCertificateRequired() { }

	public SslProtocols get_EnabledSslProtocols() { }

	[CompilerGenerated]
	public X509Certificate get_ServerCertificate() { }

	public void set_CertificateRevocationCheckMode(X509RevocationMode value) { }

	[CompilerGenerated]
	public void set_ClientCertificateRequired(bool value) { }

	public void set_EnabledSslProtocols(SslProtocols value) { }

	public void set_EncryptionPolicy(EncryptionPolicy value) { }

	[CompilerGenerated]
	public void set_ServerCertificate(X509Certificate value) { }

}

