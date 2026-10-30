namespace UnityEngine.Purchasing.Security;

public class CrossPlatformValidator
{
	private GooglePlayValidator google; //Field offset: 0x10
	private AppleValidator apple; //Field offset: 0x18
	private string googleBundleId; //Field offset: 0x20
	private string appleBundleId; //Field offset: 0x28

	public CrossPlatformValidator(Byte[] googlePublicKey, Byte[] appleRootCert, string appBundleId) { }

	public CrossPlatformValidator(Byte[] googlePublicKey, Byte[] appleRootCert, Byte[] unityChannelPublicKey_not_used, string appBundleId) { }

	public CrossPlatformValidator(Byte[] googlePublicKey, Byte[] appleRootCert, string googleBundleId, string appleBundleId) { }

	public CrossPlatformValidator(Byte[] googlePublicKey, Byte[] appleRootCert, Byte[] unityChannelPublicKey_not_used, string googleBundleId, string appleBundleId, string xiaomiBundleId_not_used) { }

	public IPurchaseReceipt[] Validate(string unityIAPReceipt) { }

}

