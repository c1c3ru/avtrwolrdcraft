namespace LipingShare.LCLib.Asn1Processor;

internal class Asn1Util
{
	private static Char[] hexDigits; //Field offset: 0x0
	private const string PemStartStr = "-----BEGIN"; //Field offset: 0x0
	private const string PemEndStr = "-----END"; //Field offset: 0x0

	private static Asn1Util() { }

	private Asn1Util() { }

	public static int BitPrecision(ulong ivalue) { }

	public static int BytePrecision(ulong value) { }

	public static long BytesToLong(Byte[] bytes) { }

	public static string BytesToPem(Byte[] data, string pemHeader) { }

	public static string BytesToPem(Byte[] data) { }

	public static string BytesToString(Byte[] bytes) { }

	public static long DerLengthDecode(Stream bt, ref bool isIndefiniteLength) { }

	public static int DERLengthEncode(Stream xdata, ulong length) { }

	public static string FormatString(string inStr, int lineLen, int groupLen) { }

	public static string GenStr(int len, char xch) { }

	public static byte GetHexDigitsVal(char ch) { }

	public static string GetPemFileHeader(string fileName) { }

	public static string GetPemHeader(string pemStr) { }

	public static string GetTagName(byte tag) { }

	public static Byte[] HexStrToBytes(string hexStr) { }

	public static bool IsAsn1EncodedHexStr(string dataStr) { }

	public static bool IsEqual(Byte[] source, Byte[] target) { }

	public static bool IsHexStr(string hexStr) { }

	public static bool IsPemFormated(string pemStr) { }

	public static bool IsPemFormatedFile(string fileName) { }

	public static bool IsValidHexDigits(char ch) { }

	public static Byte[] PemToBytes(string pemStr) { }

	public static Stream PemToStream(string pemStr) { }

	public static Byte[] StringToBytes(string msg) { }

	public static string ToHexString(Byte[] bytes) { }

}

