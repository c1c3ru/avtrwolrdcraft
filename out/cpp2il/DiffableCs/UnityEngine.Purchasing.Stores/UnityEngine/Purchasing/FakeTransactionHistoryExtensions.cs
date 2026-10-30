namespace UnityEngine.Purchasing;

internal class FakeTransactionHistoryExtensions : ITransactionHistoryExtensions, IStoreExtension
{

	public FakeTransactionHistoryExtensions() { }

	public override PurchaseFailureDescription GetLastPurchaseFailureDescription() { }

	public override StoreSpecificPurchaseErrorCode GetLastStoreSpecificPurchaseErrorCode() { }

}

