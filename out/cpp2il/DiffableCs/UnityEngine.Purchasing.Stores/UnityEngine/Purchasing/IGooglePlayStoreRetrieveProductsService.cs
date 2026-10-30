namespace UnityEngine.Purchasing;

internal interface IGooglePlayStoreRetrieveProductsService
{

	public bool HasInitiallyRetrievedProducts() { }

	public void ResumeConnection() { }

	public void RetrieveProducts(ReadOnlyCollection<ProductDefinition> products, bool wantPurchases) { }

	public void SetStoreCallback(IStoreCallback storeCallback) { }

}

