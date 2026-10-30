namespace Unity.Services.Authentication;

internal class JwtDecoder : IJwtDecoder
{
	private static readonly Char[] k_JwtSeparator; //Field offset: 0x0

	private static JwtDecoder() { }

	public JwtDecoder() { }

	private Byte[] Base64UrlDecode(string input) { }

	public override T Decode(string token) { }

}

