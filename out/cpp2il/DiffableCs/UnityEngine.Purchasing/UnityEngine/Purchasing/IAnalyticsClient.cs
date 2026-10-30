namespace UnityEngine.Purchasing;

internal interface IAnalyticsClient
{

	public void OnPurchaseFailed(Product product, PurchaseFailureDescription purchaseFailureDescription) { }

	public void OnPurchaseSucceeded(Product product) { }

}

