namespace UnityEngine.Purchasing;

internal interface IAnalyticsAdapter
{

	public void SendTransactionEvent(Product product) { }

	public void SendTransactionFailedEvent(Product product, PurchaseFailureDescription description) { }

}

