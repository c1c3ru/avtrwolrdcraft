namespace UnityEngine.Purchasing;

public interface IStoreListener
{

	public void OnInitialized(IStoreController controller, IExtensionProvider extensions) { }

	[Obsolete]
	public void OnInitializeFailed(InitializationFailureReason error) { }

	public void OnInitializeFailed(InitializationFailureReason error, string message) { }

	[Obsolete("Use IDetailedStoreListener.OnPurchaseFailed for more detailed callback.", False)]
	public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason) { }

	public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent) { }

}

