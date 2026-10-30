namespace UnityEngine.Purchasing;

public interface IAppleConfiguration : IStoreConfiguration
{

	public string appReceipt
	{
		 get { } //Length: 0
	}

	public bool canMakePayments
	{
		 get { } //Length: 0
	}

	public string get_appReceipt() { }

	public bool get_canMakePayments() { }

	public void SetApplePromotionalPurchaseInterceptorCallback(Action<Product> callback) { }

	public void SetEntitlementsRevokedListener(Action<List`1<Product>> callback) { }

}

