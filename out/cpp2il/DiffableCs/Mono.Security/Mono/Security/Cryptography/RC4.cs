namespace Mono.Security.Cryptography;

public abstract class RC4 : SymmetricAlgorithm
{
	private static KeySizes[] s_legalBlockSizes; //Field offset: 0x0
	private static KeySizes[] s_legalKeySizes; //Field offset: 0x8

	public virtual Byte[] IV
	{
		 get { } //Length: 68
		 set { } //Length: 4
	}

	private static RC4() { }

	public RC4() { }

	public static RC4 Create() { }

	public virtual Byte[] get_IV() { }

	public virtual void set_IV(Byte[] value) { }

}

