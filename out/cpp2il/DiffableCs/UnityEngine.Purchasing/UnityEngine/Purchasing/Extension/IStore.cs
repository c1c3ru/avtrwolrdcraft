namespace UnityEngine.Purchasing.Extension;

public interface IStore
{

	public void FinishTransaction(ProductDefinition product, string transactionId) { }

	public void Initialize(IStoreCallback callback) { }

	public void Purchase(ProductDefinition product, string developerPayload) { }

	public void RetrieveProducts(ReadOnlyCollection<ProductDefinition> products) { }

}

