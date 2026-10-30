namespace UnityEngine.Purchasing;

[NullableContext(1)]
internal interface IInternalStoreListener
{

	public void OnInitialized(IStoreController controller) { }

	[NullableContext(2)]
	public void OnInitializeFailed(InitializationFailureReason error, string message = null) { }

	public void OnPurchaseFailed(Product i, PurchaseFailureDescription p) { }

	public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e) { }

	public void SendTransactionEvent(Product product) { }

}

