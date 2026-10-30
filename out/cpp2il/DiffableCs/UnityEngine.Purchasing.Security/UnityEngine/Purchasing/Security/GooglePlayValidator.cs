namespace UnityEngine.Purchasing.Security;

internal class GooglePlayValidator
{
	private RSAKey key; //Field offset: 0x10

	public GooglePlayValidator(Byte[] rsaKey) { }

	public GooglePlayReceipt Validate(string receipt, string signature) { }

}

