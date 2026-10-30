namespace UnityEngine.Purchasing;

internal class GooglePlayStore : AbstractStore
{
	private readonly IGooglePlayStoreRetrieveProductsService m_RetrieveProductsService; //Field offset: 0x10
	private readonly IGooglePlayStorePurchaseService m_StorePurchaseService; //Field offset: 0x18
	private readonly IGoogleFetchPurchases m_FetchPurchases; //Field offset: 0x20
	private readonly IGooglePlayStoreFinishTransactionService m_FinishTransactionService; //Field offset: 0x28
	private readonly IGooglePurchaseCallback m_GooglePurchaseCallback; //Field offset: 0x30
	private readonly IGooglePlayStoreExtensionsInternal m_GooglePlayStoreExtensions; //Field offset: 0x38
	private readonly IGooglePlayConfigurationInternal m_GooglePlayConfigurationInternal; //Field offset: 0x40
	private readonly IUtil m_Util; //Field offset: 0x48

	public GooglePlayStore(IGooglePlayStoreRetrieveProductsService retrieveProductsService, IGooglePlayStorePurchaseService storePurchaseService, IGoogleFetchPurchases fetchPurchases, IGooglePlayStoreFinishTransactionService transactionService, IGooglePurchaseCallback googlePurchaseCallback, IGooglePlayConfigurationInternal googlePlayConfigurationInternal, IGooglePlayStoreExtensionsInternal googlePlayStoreExtensions, IUtil util) { }

	public virtual void FinishTransaction(ProductDefinition product, string transactionId) { }

	private bool HasInitiallyRetrievedProducts() { }

	public virtual void Initialize(IStoreCallback callback) { }

	public void OnPause(bool isPaused) { }

	public virtual void Purchase(ProductDefinition product, string dummy) { }

	public virtual void RetrieveProducts(ReadOnlyCollection<ProductDefinition> products) { }

	private bool ShouldFetchPurchasesNext() { }

}

