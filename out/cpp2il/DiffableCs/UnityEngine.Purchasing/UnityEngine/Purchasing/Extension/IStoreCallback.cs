namespace UnityEngine.Purchasing.Extension;

public interface IStoreCallback
{

	public ProductCollection products
	{
		 get { } //Length: 0
	}

	public bool useTransactionLog
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public ProductCollection get_products() { }

	public bool get_useTransactionLog() { }

	public void OnAllPurchasesRetrieved(List<Product> purchasedProducts) { }

	public void OnProductsRetrieved(List<ProductDescription> products) { }

	public void OnPurchaseFailed(PurchaseFailureDescription desc) { }

	public void OnPurchaseSucceeded(string storeSpecificId, string receipt, string transactionIdentifier) { }

	[Obsolete]
	public void OnSetupFailed(InitializationFailureReason reason) { }

	public void OnSetupFailed(InitializationFailureReason reason, string message) { }

	public void set_useTransactionLog(bool value) { }

}

