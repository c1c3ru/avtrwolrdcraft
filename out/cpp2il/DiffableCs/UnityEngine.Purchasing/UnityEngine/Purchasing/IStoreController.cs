namespace UnityEngine.Purchasing;

public interface IStoreController
{

	public ProductCollection products
	{
		 get { } //Length: 0
	}

	public void ConfirmPendingPurchase(Product product) { }

	[Obsolete]
	public void FetchAdditionalProducts(HashSet<ProductDefinition> additionalProducts, Action successCallback, Action<InitializationFailureReason> failCallback) { }

	public void FetchAdditionalProducts(HashSet<ProductDefinition> additionalProducts, Action successCallback, Action<InitializationFailureReason, String> failCallback) { }

	public ProductCollection get_products() { }

	public void InitiatePurchase(Product product, string payload) { }

	public void InitiatePurchase(string productId, string payload) { }

	public void InitiatePurchase(Product product) { }

	public void InitiatePurchase(string productId) { }

}

