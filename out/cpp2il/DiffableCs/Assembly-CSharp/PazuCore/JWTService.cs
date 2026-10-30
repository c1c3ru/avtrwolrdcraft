namespace PazuCore;

public static class JWTService
{
	internal class Header
	{
		public string typ; //Field offset: 0x10
		public string alg; //Field offset: 0x18

		public Header() { }

	}


	private static Byte[] Base64Decode(string encoded) { }

	private static string Base64Encode(Byte[] source) { }

	public static string Decode(string token, string secret = null, bool verify = false) { }

	public static string GenerateToken(object payload, string secret) { }

	private static Byte[] HmacSHA256(Byte[] token, Byte[] secret) { }

}

