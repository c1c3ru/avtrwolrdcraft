namespace UnityEngine.Purchasing;

public class FakeGooglePlayStoreConfiguration : IGooglePlayConfiguration, IStoreConfiguration
{

	public FakeGooglePlayStoreConfiguration() { }

	public override void SetDeferredProrationUpgradeDowngradeSubscriptionListener(Action<Product> action) { }

	public override void SetDeferredPurchaseListener(Action<Product> action) { }

	public override void SetFetchPurchasesAtInitialize(bool enable) { }

	public override void SetFetchPurchasesExcludeDeferred(bool exclude) { }

	public override void SetMaxConnectionAttempts(int maxConnectionAttempts) { }

	public override void SetObfuscatedAccountId(string accountId) { }

	public override void SetObfuscatedProfileId(string profileId) { }

	public override void SetQueryProductDetailsFailedListener(Action<Int32> action) { }

	public override void SetServiceDisconnectAtInitializeListener(Action action) { }

}

