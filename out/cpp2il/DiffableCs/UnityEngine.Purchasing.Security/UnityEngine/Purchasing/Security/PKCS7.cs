namespace UnityEngine.Purchasing.Security;

internal class PKCS7
{
	private Asn1Node root; //Field offset: 0x10
	[CompilerGenerated]
	private Asn1Node <data>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private List<SignerInfo> <sinfos>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private List<X509Cert> <certChain>k__BackingField; //Field offset: 0x28
	private bool validStructure; //Field offset: 0x30

	public private List<X509Cert> certChain
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private Asn1Node data
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private List<SignerInfo> sinfos
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public PKCS7(Asn1Node node) { }

	private void CheckStructure() { }

	private X509Cert FindSignCert(SignerInfo sinfo) { }

	[CompilerGenerated]
	public List<X509Cert> get_certChain() { }

	[CompilerGenerated]
	public Asn1Node get_data() { }

	[CompilerGenerated]
	public List<SignerInfo> get_sinfos() { }

	private bool IsStoreKitSimulatorData() { }

	public static PKCS7 Load(Byte[] data) { }

	[CompilerGenerated]
	private void set_certChain(List<X509Cert> value) { }

	[CompilerGenerated]
	private void set_data(Asn1Node value) { }

	[CompilerGenerated]
	private void set_sinfos(List<SignerInfo> value) { }

	private bool ValidateChain(X509Cert root, X509Cert cert, DateTime certificateCreationTime) { }

	private static bool ValidateStoreKitSimulatorCertRoot(X509Cert root, X509Cert cert) { }

	public bool Verify(X509Cert cert, DateTime certificateCreationTime) { }

	private bool VerifyPublicKeyWithSha256OrSha1(X509Cert signCert, SignerInfo sinfo) { }

}

