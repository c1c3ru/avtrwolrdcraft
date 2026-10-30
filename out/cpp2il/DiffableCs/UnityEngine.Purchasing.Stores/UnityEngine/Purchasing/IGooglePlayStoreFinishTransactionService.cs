namespace UnityEngine.Purchasing;

internal interface IGooglePlayStoreFinishTransactionService
{

	public void FinishTransaction(ProductDefinition product, string purchaseToken) { }

	public void SetStoreCallback(IStoreCallback storeCallback) { }

}

