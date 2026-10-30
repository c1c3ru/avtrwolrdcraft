namespace UnityEngine.Purchasing;

public interface IGooglePlayStoreExtensions : IStoreExtension
{

	[Obsolete("No longer functional. This calls launchPriceChangeConfirmationFlow which was removed from Google Play Billing Library 6.0.0")]
	public void ConfirmSubscriptionPriceChange(string productId, Action<Boolean> callback) { }

	public string GetObfuscatedAccountId(Product product) { }

	public string GetObfuscatedProfileId(Product product) { }

	public GooglePurchaseState GetPurchaseState(Product product) { }

	public bool IsPurchasedProductDeferred(Product product) { }

	[Obsolete("RestoreTransactions(Action<bool> callback) is deprecated, please use RestoreTransactions(Action<bool, string> callback) instead.")]
	public void RestoreTransactions(Action<Boolean> callback) { }

	public void RestoreTransactions(Action<Boolean, String> callback) { }

	public void UpgradeDowngradeSubscription(string oldSku, string newSku) { }

	public void UpgradeDowngradeSubscription(string oldSku, string newSku, int desiredProrationMode) { }

	[Obsolete("Use UpgradeDowngradeSubscription(Product oldProduct, Product newProduct, GooglePlayReplacementMode desiredReplacementMode) instead.")]
	public void UpgradeDowngradeSubscription(string oldSku, string newSku, GooglePlayProrationMode desiredProrationMode) { }

	public void UpgradeDowngradeSubscription(string oldSku, string newSku, GooglePlayReplacementMode desiredReplacementMode) { }

}

