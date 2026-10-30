namespace UnityEngine.Purchasing.Security;

public class AppleValidator
{
	private X509Cert cert; //Field offset: 0x10
	private AppleReceiptParser parser; //Field offset: 0x18

	public AppleValidator(Byte[] appleRootCertificate) { }

	public AppleReceipt Validate(Byte[] receiptData) { }

}

