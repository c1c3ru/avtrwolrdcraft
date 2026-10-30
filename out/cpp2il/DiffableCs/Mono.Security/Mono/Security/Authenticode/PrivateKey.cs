namespace Mono.Security.Authenticode;

public class PrivateKey
{
	private bool encrypted; //Field offset: 0x10
	private RSA rsa; //Field offset: 0x18
	private bool weak; //Field offset: 0x20
	private int keyType; //Field offset: 0x24

	public RSA RSA
	{
		 get { } //Length: 8
	}

	public PrivateKey(Byte[] data, string password) { }

	public static PrivateKey CreateFromFile(string filename) { }

	public static PrivateKey CreateFromFile(string filename, string password) { }

	private bool Decode(Byte[] pvk, string password) { }

	private Byte[] DeriveKey(Byte[] salt, string password) { }

	public RSA get_RSA() { }

}

