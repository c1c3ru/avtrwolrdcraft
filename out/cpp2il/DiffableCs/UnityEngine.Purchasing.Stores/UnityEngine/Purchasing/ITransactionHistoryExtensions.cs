namespace UnityEngine.Purchasing;

public interface ITransactionHistoryExtensions : IStoreExtension
{

	public PurchaseFailureDescription GetLastPurchaseFailureDescription() { }

	public StoreSpecificPurchaseErrorCode GetLastStoreSpecificPurchaseErrorCode() { }

}

