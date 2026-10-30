namespace Unity.Services.Authentication;

internal class CodeChallengeGenerator
{
	private const int k_CodeLength = 125; //Field offset: 0x0
	private const string k_CodeChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"; //Field offset: 0x0
	private readonly StringBuilder m_CodeBuilder; //Field offset: 0x10

	internal CodeChallengeGenerator() { }

	public string GenerateCode() { }

	public string GenerateStateString() { }

	public static string S256EncodeChallenge(string code) { }

}

