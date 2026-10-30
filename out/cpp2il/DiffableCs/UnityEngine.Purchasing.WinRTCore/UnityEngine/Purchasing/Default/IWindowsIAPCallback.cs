namespace UnityEngine.Purchasing.Default;

public interface IWindowsIAPCallback
{

	public void log(string message) { }

	public void logError(string error) { }

	public void OnProductListError(string message) { }

	public void OnProductListReceived(WinProductDescription[] winProducts) { }

	public void OnPurchaseFailed(string productId, string error) { }

	public void OnPurchaseSucceeded(string productId, string receipt, string transactionId) { }

}

