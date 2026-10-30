namespace Mono.Security.Cryptography;

public sealed class PKCS8
{
	internal class EncryptedPrivateKeyInfo
	{
		private string _algorithm; //Field offset: 0x10
		private Byte[] _salt; //Field offset: 0x18
		private int _iterations; //Field offset: 0x20
		private Byte[] _data; //Field offset: 0x28

		public string Algorithm
		{
			 get { } //Length: 8
		}

		public Byte[] EncryptedData
		{
			 get { } //Length: 116
		}

		public int IterationCount
		{
			 get { } //Length: 8
		}

		public Byte[] Salt
		{
			 get { } //Length: 192
		}

		public EncryptedPrivateKeyInfo() { }

		public EncryptedPrivateKeyInfo(Byte[] data) { }

		private void Decode(Byte[] data) { }

		public string get_Algorithm() { }

		public Byte[] get_EncryptedData() { }

		public int get_IterationCount() { }

		public Byte[] get_Salt() { }

	}

	internal class PrivateKeyInfo
	{
		private int _version; //Field offset: 0x10
		private string _algorithm; //Field offset: 0x18
		private Byte[] _key; //Field offset: 0x20
		private ArrayList _list; //Field offset: 0x28

		public string Algorithm
		{
			 get { } //Length: 8
		}

		public Byte[] PrivateKey
		{
			 get { } //Length: 116
		}

		public PrivateKeyInfo() { }

		public PrivateKeyInfo(Byte[] data) { }

		private void Decode(Byte[] data) { }

		public static DSA DecodeDSA(Byte[] privateKey, DSAParameters dsaParameters) { }

		public static RSA DecodeRSA(Byte[] keypair) { }

		public static Byte[] Encode(RSA rsa) { }

		public static Byte[] Encode(DSA dsa) { }

		public static Byte[] Encode(AsymmetricAlgorithm aa) { }

		public string get_Algorithm() { }

		public Byte[] get_PrivateKey() { }

		private static Byte[] Normalize(Byte[] bigInt, int length) { }

		private static Byte[] RemoveLeadingZero(Byte[] bigInt) { }

	}


}

