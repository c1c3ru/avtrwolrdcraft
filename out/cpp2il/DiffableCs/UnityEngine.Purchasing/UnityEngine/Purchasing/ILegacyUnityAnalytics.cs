namespace UnityEngine.Purchasing;

internal interface ILegacyUnityAnalytics
{

	public void SendCustomEvent(string name, Dictionary<String, Object> data) { }

	public void SendTransactionEvent(string productId, decimal amount, string currency, string receiptPurchaseData, string signature) { }

}

