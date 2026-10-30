namespace UnityEngine.Purchasing;

internal interface IUnityCallback
{

	public void OnProductsRetrieved(string json) { }

	public void OnPurchaseFailed(string json) { }

	public void OnPurchaseSucceeded(string id, string receipt, string transactionID) { }

	public void OnSetupFailed(string json) { }

}

