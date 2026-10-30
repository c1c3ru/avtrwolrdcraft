namespace UnityEngine.Purchasing;

public interface INativeStore
{

	public void FinishTransaction(string productJSON, string transactionID) { }

	public void Purchase(string productJSON, string developerPayload) { }

	public void RetrieveProducts(string json) { }

}

