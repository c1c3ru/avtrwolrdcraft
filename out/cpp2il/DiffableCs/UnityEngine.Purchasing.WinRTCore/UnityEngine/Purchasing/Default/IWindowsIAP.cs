namespace UnityEngine.Purchasing.Default;

public interface IWindowsIAP
{

	public void BuildDummyProducts(List<WinProductDescription> products) { }

	public void FinaliseTransaction(string transactionId) { }

	public void Initialize(IWindowsIAPCallback callback) { }

	public void Purchase(string productId) { }

	public void RetrieveProducts(bool retryIfOffline) { }

}

