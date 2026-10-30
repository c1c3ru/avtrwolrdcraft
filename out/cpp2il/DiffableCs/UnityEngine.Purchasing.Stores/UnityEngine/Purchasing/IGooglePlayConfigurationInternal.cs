namespace UnityEngine.Purchasing;

[NullableContext(1)]
internal interface IGooglePlayConfigurationInternal
{

	public bool DoesRetrievePurchasesExcludeDeferred() { }

	public bool IsFetchPurchasesAtInitializeSkipped() { }

	public void NotifyDeferredProrationUpgradeDowngradeSubscription(IStoreCallback storeCallback, string productId) { }

	public void NotifyDeferredPurchase(IStoreCallback storeCallback, IGooglePurchase purchase, string receipt, string transactionId) { }

	public void NotifyInitializationConnectionFailed() { }

	public void NotifyQueryProductDetailsFailed(int retryCount) { }

}

