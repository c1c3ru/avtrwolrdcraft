namespace Mono.Security.Cryptography;

internal sealed class CryptoConvert
{

	public static RSA FromCapiKeyBlob(Byte[] blob) { }

	public static RSA FromCapiKeyBlob(Byte[] blob, int offset) { }

	public static RSA FromCapiPrivateKeyBlob(Byte[] blob, int offset) { }

	public static RSA FromCapiPublicKeyBlob(Byte[] blob, int offset) { }

	private static RSAParameters GetParametersFromCapiPrivateKeyBlob(Byte[] blob, int offset) { }

	private static RSAParameters GetParametersFromCapiPublicKeyBlob(Byte[] blob, int offset) { }

	private static int ToInt32LE(Byte[] bytes, int offset) { }

	private static uint ToUInt32LE(Byte[] bytes, int offset) { }

	private static Byte[] Trim(Byte[] array) { }

}

