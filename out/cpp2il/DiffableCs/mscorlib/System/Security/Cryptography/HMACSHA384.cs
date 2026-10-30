namespace System.Security.Cryptography;

[ComVisible(True)]
public class HMACSHA384 : HMAC
{
	private bool m_useLegacyBlockSize; //Field offset: 0x61

	private int BlockSize
	{
		private get { } //Length: 24
	}

	public HMACSHA384() { }

	public HMACSHA384(Byte[] key) { }

	private int get_BlockSize() { }

}

