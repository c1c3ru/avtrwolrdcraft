namespace Mono.Net.Security;

internal sealed class MonoSslServerAuthenticationOptions : MonoSslAuthenticationOptions
{
	[CompilerGenerated]
	private readonly SslServerAuthenticationOptions <Options>k__BackingField; //Field offset: 0x18

	public virtual X509RevocationMode CertificateRevocationCheckMode
	{
		 set { } //Length: 28
	}

	public virtual bool ClientCertificateRequired
	{
		 get { } //Length: 28
		 set { } //Length: 32
	}

	public virtual X509CertificateCollection ClientCertificates
	{
		 get { } //Length: 56
		 set { } //Length: 56
	}

	public virtual SslProtocols EnabledSslProtocols
	{
		 get { } //Length: 28
		 set { } //Length: 28
	}

	public virtual EncryptionPolicy EncryptionPolicy
	{
		 set { } //Length: 28
	}

	public SslServerAuthenticationOptions Options
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public virtual X509Certificate ServerCertificate
	{
		 get { } //Length: 28
		 set { } //Length: 28
	}

	public virtual bool ServerMode
	{
		 get { } //Length: 8
	}

	public virtual string TargetHost
	{
		 get { } //Length: 56
		 set { } //Length: 56
	}

	public MonoSslServerAuthenticationOptions() { }

	public virtual bool get_ClientCertificateRequired() { }

	public virtual X509CertificateCollection get_ClientCertificates() { }

	public virtual SslProtocols get_EnabledSslProtocols() { }

	[CompilerGenerated]
	public SslServerAuthenticationOptions get_Options() { }

	public virtual X509Certificate get_ServerCertificate() { }

	public virtual bool get_ServerMode() { }

	public virtual string get_TargetHost() { }

	public virtual void set_CertificateRevocationCheckMode(X509RevocationMode value) { }

	public virtual void set_ClientCertificateRequired(bool value) { }

	public virtual void set_ClientCertificates(X509CertificateCollection value) { }

	public virtual void set_EnabledSslProtocols(SslProtocols value) { }

	public virtual void set_EncryptionPolicy(EncryptionPolicy value) { }

	public virtual void set_ServerCertificate(X509Certificate value) { }

	public virtual void set_TargetHost(string value) { }

}

