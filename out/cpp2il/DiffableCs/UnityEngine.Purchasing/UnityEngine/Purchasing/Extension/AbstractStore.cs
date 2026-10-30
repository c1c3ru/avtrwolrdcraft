namespace UnityEngine.Purchasing.Extension;

public abstract class AbstractStore : IStore
{

	protected AbstractStore() { }

	public abstract void FinishTransaction(ProductDefinition product, string transactionId) { }

	public abstract void Initialize(IStoreCallback callback) { }

	public abstract void Purchase(ProductDefinition product, string developerPayload) { }

	public abstract void RetrieveProducts(ReadOnlyCollection<ProductDefinition> products) { }

}

