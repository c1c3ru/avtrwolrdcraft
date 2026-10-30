namespace UnityEngine.Purchasing.Interfaces;

internal interface IGooglePurchaseCallback
{

	public void NotifyDeferredProrationUpgradeDowngradeSubscription(string sku) { }

	public void NotifyDeferredPurchase(IGooglePurchase purchase, string receipt, string purchaseToken) { }

	public void OnPurchaseFailed(PurchaseFailureDescription purchaseFailureDescription) { }

	public void OnPurchaseSuccessful(IGooglePurchase purchase, string receipt, string purchaseToken) { }

	public void SetStoreCallback(IStoreCallback storeCallback) { }

	public void SetStoreConfiguration(IGooglePlayConfigurationInternal configuration) { }

}

