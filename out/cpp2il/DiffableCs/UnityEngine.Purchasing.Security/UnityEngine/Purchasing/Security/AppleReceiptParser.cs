namespace UnityEngine.Purchasing.Security;

public class AppleReceiptParser
{
	private static Dictionary<String, Object> _mostRecentReceiptData; //Field offset: 0x0
	private const string k_AppleReceiptKey = "k_AppleReceiptKey"; //Field offset: 0x0
	private const string k_PKCS7Key = "k_PKCS7Key"; //Field offset: 0x0
	private const string k_ReceiptBytesKey = "k_ReceiptBytesKey"; //Field offset: 0x0

	private static AppleReceiptParser() { }

	public AppleReceiptParser() { }

	public static bool ArrayEquals(T[] a, T[] b) { }

	private Asn1Node GetSetNode(Asn1Node data) { }

	public AppleReceipt Parse(Byte[] receiptData) { }

	internal AppleReceipt Parse(Byte[] receiptData, out PKCS7 receipt) { }

	private AppleInAppPurchaseReceipt ParseInAppReceipt(Asn1Node inApp) { }

	private AppleReceipt ParseReceipt(Asn1Node data) { }

	private static void PopCultureOffThread(CultureInfo originalCulture) { }

	private static CultureInfo PushInvariantCultureOnThread() { }

	private static DateTime TryParseDateTimeNode(Asn1Node node) { }

}

