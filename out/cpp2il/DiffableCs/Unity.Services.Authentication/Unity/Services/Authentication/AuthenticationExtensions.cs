namespace Unity.Services.Authentication;

[Extension]
public static class AuthenticationExtensions
{
	internal const string ProfileKey = "com.unity.services.authentication.profile"; //Field offset: 0x0
	private const string k_ProfileRegex = "^[a-zA-Z0-9_-]{1,30}$"; //Field offset: 0x0

	[Extension]
	public static InitializationOptions SetProfile(InitializationOptions options, string profile) { }

}

