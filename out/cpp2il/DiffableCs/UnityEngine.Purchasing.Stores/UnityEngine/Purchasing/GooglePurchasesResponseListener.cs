namespace UnityEngine.Purchasing;

internal class GooglePurchasesResponseListener : AndroidJavaProxy
{
	private const string k_AndroidPurchasesResponseListenerClassName = "com.android.billingclient.api.PurchasesResponseListener"; //Field offset: 0x0
	private readonly Action<IGoogleBillingResult, IEnumerable`1<AndroidJavaObject>> m_OnQueryPurchasesResponse; //Field offset: 0x20

	internal GooglePurchasesResponseListener(Action<IGoogleBillingResult, IEnumerable`1<AndroidJavaObject>> onQueryPurchasesResponse) { }

	[Preserve]
	public void onQueryPurchasesResponse(AndroidJavaObject billingResult, AndroidJavaObject purchases) { }

}

