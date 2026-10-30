namespace System.Security.Cryptography.X509Certificates;

public sealed class PublicKey
{
	private static Byte[] Empty; //Field offset: 0x0
	private AsnEncodedData _keyValue; //Field offset: 0x10
	private AsnEncodedData _params; //Field offset: 0x18
	private Oid _oid; //Field offset: 0x20

	public AsnEncodedData EncodedKeyValue
	{
		 get { } //Length: 8
	}

	public AsnEncodedData EncodedParameters
	{
		 get { } //Length: 8
	}

	public AsymmetricAlgorithm Key
	{
		 get { } //Length: 420
	}

	public Oid Oid
	{
		 get { } //Length: 8
	}

	private static PublicKey() { }

	public PublicKey(Oid oid, AsnEncodedData parameters, AsnEncodedData keyValue) { }

	internal static DSA DecodeDSA(Byte[] rawPublicKey, Byte[] rawParameters) { }

	internal static RSA DecodeRSA(Byte[] rawPublicKey) { }

	public AsnEncodedData get_EncodedKeyValue() { }

	public AsnEncodedData get_EncodedParameters() { }

	public AsymmetricAlgorithm get_Key() { }

	public Oid get_Oid() { }

	private static Byte[] GetUnsignedBigInteger(Byte[] integer) { }

}

