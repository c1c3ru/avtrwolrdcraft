namespace UnityEngine.Purchasing.Security;

internal class X509Cert
{
	[CompilerGenerated]
	private string <SerialNumber>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private DateTime <ValidAfter>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private DateTime <ValidBefore>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private RSAKey <PubKey>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private bool <SelfSigned>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private DistinguishedName <Subject>k__BackingField; //Field offset: 0x38
	[CompilerGenerated]
	private DistinguishedName <Issuer>k__BackingField; //Field offset: 0x40
	private Asn1Node TbsCertificate; //Field offset: 0x48
	[CompilerGenerated]
	private Asn1Node <Signature>k__BackingField; //Field offset: 0x50
	public Byte[] rawTBSCertificate; //Field offset: 0x58

	public private DistinguishedName Issuer
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private RSAKey PubKey
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private bool SelfSigned
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public private string SerialNumber
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private Asn1Node Signature
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private DistinguishedName Subject
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private DateTime ValidAfter
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private DateTime ValidBefore
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public X509Cert(Byte[] data) { }

	public X509Cert(Asn1Node n) { }

	public bool CheckCertTime(DateTime time) { }

	public bool CheckSignature(X509Cert signer) { }

	public bool CheckSignatureSha256(X509Cert signer) { }

	[CompilerGenerated]
	public DistinguishedName get_Issuer() { }

	[CompilerGenerated]
	public RSAKey get_PubKey() { }

	[CompilerGenerated]
	public bool get_SelfSigned() { }

	[CompilerGenerated]
	public string get_SerialNumber() { }

	[CompilerGenerated]
	public Asn1Node get_Signature() { }

	[CompilerGenerated]
	public DistinguishedName get_Subject() { }

	[CompilerGenerated]
	public DateTime get_ValidAfter() { }

	[CompilerGenerated]
	public DateTime get_ValidBefore() { }

	private void ParseNode(Asn1Node root) { }

	private DateTime ParseTime(Asn1Node n) { }

	[CompilerGenerated]
	private void set_Issuer(DistinguishedName value) { }

	[CompilerGenerated]
	private void set_PubKey(RSAKey value) { }

	[CompilerGenerated]
	private void set_SelfSigned(bool value) { }

	[CompilerGenerated]
	private void set_SerialNumber(string value) { }

	[CompilerGenerated]
	private void set_Signature(Asn1Node value) { }

	[CompilerGenerated]
	private void set_Subject(DistinguishedName value) { }

	[CompilerGenerated]
	private void set_ValidAfter(DateTime value) { }

	[CompilerGenerated]
	private void set_ValidBefore(DateTime value) { }

	private bool VerifySignatureWithSha256OrSha1(X509Cert signer) { }

}

