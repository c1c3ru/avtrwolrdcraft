namespace UnityEngine.Purchasing;

public interface IDetailedStoreListener : IStoreListener
{

	public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription) { }

}

