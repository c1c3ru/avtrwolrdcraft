namespace UnityEngine.Purchasing;

internal class GoogleAcknowledgePurchaseListener : AndroidJavaProxy
{
	private const string k_AndroidAcknowledgePurchaseResponseListenerClassName = "com.android.billingclient.api.AcknowledgePurchaseResponseListener"; //Field offset: 0x0
	private readonly Action<IGoogleBillingResult> m_OnAcknowledgePurchaseResponse; //Field offset: 0x20

	internal GoogleAcknowledgePurchaseListener(Action<IGoogleBillingResult> onAcknowledgePurchaseResponseAction) { }

	[Preserve]
	private void onAcknowledgePurchaseResponse(AndroidJavaObject billingResult) { }

}

