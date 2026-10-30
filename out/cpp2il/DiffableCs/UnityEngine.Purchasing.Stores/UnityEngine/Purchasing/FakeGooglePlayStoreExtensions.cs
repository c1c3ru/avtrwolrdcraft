namespace UnityEngine.Purchasing;

public class FakeGooglePlayStoreExtensions : IGooglePlayStoreExtensions, IStoreExtension
{

	public FakeGooglePlayStoreExtensions() { }

	public override void ConfirmSubscriptionPriceChange(string productId, Action<Boolean> callback) { }

	public override string GetObfuscatedAccountId(Product product) { }

	public override string GetObfuscatedProfileId(Product product) { }

	public override GooglePurchaseState GetPurchaseState(Product product) { }

	public override bool IsPurchasedProductDeferred(Product product) { }

	[Obsolete("RestoreTransactions(Action<bool> callback) is deprecated, please use RestoreTransactions(Action<bool, string> callback) instead.")]
	public override void RestoreTransactions(Action<Boolean> callback) { }

	public override void RestoreTransactions(Action<Boolean, String> callback) { }

	public override void UpgradeDowngradeSubscription(string oldSku, string newSku) { }

	public override void UpgradeDowngradeSubscription(string oldSku, string newSku, int desiredProrationMode) { }

	[Obsolete("Use UpgradeDowngradeSubscription(Product oldProduct, Product newProduct, GooglePlayReplacementMode desiredReplacementMode) instead.")]
	public override void UpgradeDowngradeSubscription(string oldSku, string newSku, GooglePlayProrationMode desiredProrationMode) { }

	public override void UpgradeDowngradeSubscription(string oldSku, string newSku, GooglePlayReplacementMode desiredReplacementMode) { }

}

