namespace UnityEngine.Purchasing;

internal interface IGoogleFetchPurchases
{

	public void FetchPurchases() { }

	public void FetchPurchases(Action<List`1<Product>> onQueryPurchaseSucceed) { }

	public void SetStoreCallback(IStoreCallback storeCallback) { }

}

