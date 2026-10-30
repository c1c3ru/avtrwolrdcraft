namespace System.Security.Cryptography.X509Certificates;

internal abstract class X509Certificate2ImplUnix : X509Certificate2Impl
{
	private bool readCertData; //Field offset: 0x10
	private CertificateData certData; //Field offset: 0x18

	public virtual IEnumerable<X509Extension> Extensions
	{
		 get { } //Length: 24
	}

	public virtual string Issuer
	{
		 get { } //Length: 40
	}

	public virtual X500DistinguishedName IssuerName
	{
		 get { } //Length: 24
	}

	public virtual string KeyAlgorithm
	{
		 get { } //Length: 24
	}

	public virtual Byte[] KeyAlgorithmParameters
	{
		 get { } //Length: 24
	}

	public virtual DateTime NotAfter
	{
		 get { } //Length: 96
	}

	public virtual DateTime NotBefore
	{
		 get { } //Length: 96
	}

	public virtual Byte[] PublicKeyValue
	{
		 get { } //Length: 24
	}

	public virtual Byte[] RawData
	{
		 get { } //Length: 24
	}

	public virtual Byte[] SerialNumber
	{
		 get { } //Length: 24
	}

	public virtual string SignatureAlgorithm
	{
		 get { } //Length: 24
	}

	public virtual string Subject
	{
		 get { } //Length: 40
	}

	public virtual X500DistinguishedName SubjectName
	{
		 get { } //Length: 24
	}

	public virtual Byte[] Thumbprint
	{
		 get { } //Length: 400
	}

	public virtual int Version
	{
		 get { } //Length: 28
	}

	protected X509Certificate2ImplUnix() { }

	public virtual void AppendPrivateKeyInfo(StringBuilder sb) { }

	private void EnsureCertData() { }

	public virtual IEnumerable<X509Extension> get_Extensions() { }

	public virtual string get_Issuer() { }

	public virtual X500DistinguishedName get_IssuerName() { }

	public virtual string get_KeyAlgorithm() { }

	public virtual Byte[] get_KeyAlgorithmParameters() { }

	public virtual DateTime get_NotAfter() { }

	public virtual DateTime get_NotBefore() { }

	public virtual Byte[] get_PublicKeyValue() { }

	public virtual Byte[] get_RawData() { }

	public virtual Byte[] get_SerialNumber() { }

	public virtual string get_SignatureAlgorithm() { }

	public virtual string get_Subject() { }

	public virtual X500DistinguishedName get_SubjectName() { }

	public virtual Byte[] get_Thumbprint() { }

	public virtual int get_Version() { }

	public virtual string GetNameInfo(X509NameType nameType, bool forIssuer) { }

	protected abstract Byte[] GetRawCertData() { }

}

