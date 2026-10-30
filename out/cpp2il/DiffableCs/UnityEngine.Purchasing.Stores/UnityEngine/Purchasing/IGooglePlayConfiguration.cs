namespace UnityEngine.Purchasing;

public interface IGooglePlayConfiguration : IStoreConfiguration
{

	public void SetDeferredProrationUpgradeDowngradeSubscriptionListener(Action<Product> action) { }

	public void SetDeferredPurchaseListener(Action<Product> action) { }

	public void SetFetchPurchasesAtInitialize(bool enable) { }

	public void SetFetchPurchasesExcludeDeferred(bool exclude) { }

	public void SetMaxConnectionAttempts(int maxConnectionAttempts) { }

	public void SetObfuscatedAccountId(string accountId) { }

	public void SetObfuscatedProfileId(string profileId) { }

	public void SetQueryProductDetailsFailedListener(Action<Int32> action) { }

	public void SetServiceDisconnectAtInitializeListener(Action action) { }

}

