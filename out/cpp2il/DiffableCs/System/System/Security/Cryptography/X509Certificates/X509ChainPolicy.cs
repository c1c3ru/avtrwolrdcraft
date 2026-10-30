namespace System.Security.Cryptography.X509Certificates;

public sealed class X509ChainPolicy
{
	private OidCollection apps; //Field offset: 0x10
	private OidCollection cert; //Field offset: 0x18
	private X509CertificateCollection store; //Field offset: 0x20
	private X509Certificate2Collection store2; //Field offset: 0x28
	private X509RevocationFlag rflag; //Field offset: 0x30
	private X509RevocationMode mode; //Field offset: 0x34
	private TimeSpan timeout; //Field offset: 0x38
	private X509VerificationFlags vflags; //Field offset: 0x40
	private DateTime vtime; //Field offset: 0x48

	public X509Certificate2Collection ExtraStore
	{
		 get { } //Length: 624
	}

	public X509RevocationFlag RevocationFlag
	{
		 get { } //Length: 8
	}

	public X509RevocationMode RevocationMode
	{
		 get { } //Length: 8
		 set { } //Length: 96
	}

	public X509VerificationFlags VerificationFlags
	{
		 get { } //Length: 8
		 set { } //Length: 96
	}

	public DateTime VerificationTime
	{
		 get { } //Length: 8
	}

	public X509ChainPolicy() { }

	public X509Certificate2Collection get_ExtraStore() { }

	public X509RevocationFlag get_RevocationFlag() { }

	public X509RevocationMode get_RevocationMode() { }

	public X509VerificationFlags get_VerificationFlags() { }

	public DateTime get_VerificationTime() { }

	public void Reset() { }

	public void set_RevocationMode(X509RevocationMode value) { }

	public void set_VerificationFlags(X509VerificationFlags value) { }

}

