namespace Mono.Security.Cryptography;

public sealed class CryptoConvert
{

	public static RSA FromCapiPrivateKeyBlob(Byte[] blob) { }

	public static RSA FromCapiPrivateKeyBlob(Byte[] blob, int offset) { }

	private static RSAParameters GetParametersFromCapiPrivateKeyBlob(Byte[] blob, int offset) { }

	public static string ToHex(Byte[] input) { }

	private static int ToInt32LE(Byte[] bytes, int offset) { }

	private static uint ToUInt32LE(Byte[] bytes, int offset) { }

	private static Byte[] Trim(Byte[] array) { }

}

