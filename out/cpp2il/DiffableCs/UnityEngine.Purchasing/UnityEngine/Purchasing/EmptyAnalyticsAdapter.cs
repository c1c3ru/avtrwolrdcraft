namespace UnityEngine.Purchasing;

internal class EmptyAnalyticsAdapter : IAnalyticsAdapter
{

	public EmptyAnalyticsAdapter() { }

	public override void SendTransactionEvent(Product product) { }

	public override void SendTransactionFailedEvent(Product product, PurchaseFailureDescription reason) { }

}

