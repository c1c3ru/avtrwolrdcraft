namespace UnityEngine.Purchasing.Interfaces;

internal interface IGooglePlayStoreService
{

	public void FetchPurchases(Action<List`1<IGooglePurchase>> onQueryPurchaseSucceed) { }

	public void FinishTransaction(ProductDefinition product, string purchaseToken, Action<IGoogleBillingResult, IGooglePurchase> onTransactionFinished) { }

	public IGooglePurchase GetPurchase(string purchaseToken, string skuType) { }

	public bool IsConnectionReady() { }

	public void Purchase(ProductDefinition product) { }

	public void Purchase(ProductDefinition product, Product oldProduct, Nullable<GooglePlayReplacementMode> desiredReplacementMode) { }

	public void ResumeConnection() { }

	public void RetrieveProducts(ReadOnlyCollection<ProductDefinition> products, Action<List`1<ProductDescription>, IGoogleBillingResult> onProductsReceived, Action<GoogleRetrieveProductsFailureReason, GoogleBillingResponseCode> onRetrieveProductFailed) { }

	public void SetMaxConnectionAttempts(int maxConnectionAttempts) { }

	public void SetObfuscatedAccountId(string obfuscatedAccountId) { }

	public void SetObfuscatedProfileId(string obfuscatedProfileId) { }

}

