namespace Unity.Services.Authentication.PlayerAccounts;

internal class JwtDecoder : IJwtDecoder
{
	private static readonly DateTime k_UnixEpoch; //Field offset: 0x0
	private static readonly Char[] k_JwtSeparator; //Field offset: 0x8
	private readonly JsonSerializerSettings m_JsonSerializerSettings; //Field offset: 0x10
	private readonly IDateTimeWrapper m_DateTime; //Field offset: 0x18

	private static JwtDecoder() { }

	internal JwtDecoder(IDateTimeWrapper dateTime) { }

	private static Byte[] Base64UrlDecode(string input) { }

	public override T Decode(string token) { }

}

