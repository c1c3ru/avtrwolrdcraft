namespace UnityEngine.Purchasing.Security;

internal class SignerInfo
{
	[CompilerGenerated]
	private int <Version>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private string <IssuerSerialNumber>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private Byte[] <EncryptedDigest>k__BackingField; //Field offset: 0x20

	public private Byte[] EncryptedDigest
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private string IssuerSerialNumber
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private int Version
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public SignerInfo(Asn1Node n) { }

	[CompilerGenerated]
	public Byte[] get_EncryptedDigest() { }

	[CompilerGenerated]
	public string get_IssuerSerialNumber() { }

	[CompilerGenerated]
	public int get_Version() { }

	[CompilerGenerated]
	private void set_EncryptedDigest(Byte[] value) { }

	[CompilerGenerated]
	private void set_IssuerSerialNumber(string value) { }

	[CompilerGenerated]
	private void set_Version(int value) { }

}

