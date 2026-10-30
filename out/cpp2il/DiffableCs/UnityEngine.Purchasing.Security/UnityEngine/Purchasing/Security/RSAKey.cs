namespace UnityEngine.Purchasing.Security;

internal class RSAKey
{
	[CompilerGenerated]
	private RSACryptoServiceProvider <rsa>k__BackingField; //Field offset: 0x10

	public private RSACryptoServiceProvider rsa
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public RSAKey(Asn1Node n) { }

	public RSAKey(Byte[] data) { }

	[CompilerGenerated]
	public RSACryptoServiceProvider get_rsa() { }

	private RSACryptoServiceProvider ParseNode(Asn1Node n) { }

	[CompilerGenerated]
	private void set_rsa(RSACryptoServiceProvider value) { }

	private string ToXML(string modulus, string exponent) { }

	public bool VerifySha1(Byte[] message, Byte[] signature) { }

	public bool VerifySha256(Byte[] message, Byte[] signature) { }

}

