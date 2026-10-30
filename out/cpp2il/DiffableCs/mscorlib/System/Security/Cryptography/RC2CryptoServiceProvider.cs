namespace System.Security.Cryptography;

[ComVisible(True)]
public sealed class RC2CryptoServiceProvider : RC2
{
	private static KeySizes[] s_legalKeySizes; //Field offset: 0x0
	private bool m_use40bitSalt; //Field offset: 0x48

	public virtual int EffectiveKeySize
	{
		 get { } //Length: 8
	}

	private static RC2CryptoServiceProvider() { }

	public RC2CryptoServiceProvider() { }

	public virtual ICryptoTransform CreateDecryptor(Byte[] rgbKey, Byte[] rgbIV) { }

	public virtual ICryptoTransform CreateEncryptor(Byte[] rgbKey, Byte[] rgbIV) { }

	public virtual void GenerateIV() { }

	public virtual void GenerateKey() { }

	public virtual int get_EffectiveKeySize() { }

}

