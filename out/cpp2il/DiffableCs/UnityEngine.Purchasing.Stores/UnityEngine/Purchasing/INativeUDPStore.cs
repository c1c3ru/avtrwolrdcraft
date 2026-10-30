namespace UnityEngine.Purchasing;

internal interface INativeUDPStore : INativeStore
{

	public void FinishTransaction(ProductDefinition productDefinition, string transactionID) { }

	public void Initialize(Action<Boolean, String> callback) { }

	public void Purchase(string productId, Action<Boolean, String> callback, string developerPayload = null) { }

	public void RetrieveProducts(ReadOnlyCollection<ProductDefinition> products, Action<Boolean, String> callback) { }

}

