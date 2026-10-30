namespace System.Security.Cryptography.X509Certificates;

public class X509Certificate2 : X509Certificate
{
	private Byte[] lazyRawData; //Field offset: 0x60
	private Oid lazySignatureAlgorithm; //Field offset: 0x68
	private int lazyVersion; //Field offset: 0x70
	private X500DistinguishedName lazySubjectName; //Field offset: 0x78
	private X500DistinguishedName lazyIssuerName; //Field offset: 0x80
	private PublicKey lazyPublicKey; //Field offset: 0x88
	private AsymmetricAlgorithm lazyPrivateKey; //Field offset: 0x90
	private X509ExtensionCollection lazyExtensions; //Field offset: 0x98

	public X509ExtensionCollection Extensions
	{
		 get { } //Length: 980
	}

	public bool HasPrivateKey
	{
		 get { } //Length: 52
	}

	internal X509Certificate2Impl Impl
	{
		internal get { } //Length: 140
	}

	public X500DistinguishedName IssuerName
	{
		 get { } //Length: 108
	}

	public DateTime NotAfter
	{
		 get { } //Length: 8
	}

	public DateTime NotBefore
	{
		 get { } //Length: 8
	}

	public AsymmetricAlgorithm PrivateKey
	{
		 get { } //Length: 356
		 set { } //Length: 56
	}

	public PublicKey PublicKey
	{
		 get { } //Length: 344
	}

	public Byte[] RawData
	{
		 get { } //Length: 108
	}

	public string SerialNumber
	{
		 get { } //Length: 16
	}

	public Oid SignatureAlgorithm
	{
		 get { } //Length: 116
	}

	public X500DistinguishedName SubjectName
	{
		 get { } //Length: 108
	}

	public string Thumbprint
	{
		 get { } //Length: 28
	}

	public int Version
	{
		 get { } //Length: 92
	}

	public X509Certificate2() { }

	public X509Certificate2(Byte[] rawData) { }

	internal X509Certificate2(X509Certificate2Impl impl) { }

	public X509Certificate2(string fileName) { }

	public X509Certificate2(X509Certificate certificate) { }

	protected X509Certificate2(SerializationInfo info, StreamingContext context) { }

	private static X509Extension CreateCustomExtensionIfAny(Oid oid) { }

	public X509ExtensionCollection get_Extensions() { }

	public bool get_HasPrivateKey() { }

	internal X509Certificate2Impl get_Impl() { }

	public X500DistinguishedName get_IssuerName() { }

	public DateTime get_NotAfter() { }

	public DateTime get_NotBefore() { }

	public AsymmetricAlgorithm get_PrivateKey() { }

	public PublicKey get_PublicKey() { }

	public Byte[] get_RawData() { }

	public string get_SerialNumber() { }

	public Oid get_SignatureAlgorithm() { }

	public X500DistinguishedName get_SubjectName() { }

	public string get_Thumbprint() { }

	public int get_Version() { }

	public static X509ContentType GetCertContentType(Byte[] rawData) { }

	public string GetNameInfo(X509NameType nameType, bool forIssuer) { }

	public virtual void Reset() { }

	public void set_PrivateKey(AsymmetricAlgorithm value) { }

	public virtual string ToString() { }

	public virtual string ToString(bool verbose) { }

	public bool Verify() { }

}

