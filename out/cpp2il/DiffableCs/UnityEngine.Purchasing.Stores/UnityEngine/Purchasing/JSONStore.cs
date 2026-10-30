namespace UnityEngine.Purchasing;

internal class JSONStore : AbstractStore, IUnityCallback, IStoreInternal, ITransactionHistoryExtensions, IStoreExtension
{
	private const string k_StoreSpecificErrorCodeKey = "storeSpecificErrorCode"; //Field offset: 0x0
	protected IStoreCallback unity; //Field offset: 0x10
	private INativeStore m_Store; //Field offset: 0x18
	private List<ProductDefinition> m_StoreCatalog; //Field offset: 0x20
	private bool m_IsRefreshing; //Field offset: 0x28
	private Action m_RefreshCallback; //Field offset: 0x30
	private StandardPurchasingModule m_Module; //Field offset: 0x38
	protected ILogger m_Logger; //Field offset: 0x40
	protected JsonProductDescriptionsDeserializer m_ProductDescriptionsDeserializer; //Field offset: 0x48
	protected PurchaseFailureDescription m_LastPurchaseFailureDescription; //Field offset: 0x50
	private StoreSpecificPurchaseErrorCode m_LastPurchaseErrorCode; //Field offset: 0x58

	public Product[] storeCatalog
	{
		 get { } //Length: 1040
	}

	public JSONStore() { }

	public virtual void FinishTransaction(ProductDefinition product, string transactionId) { }

	public Product[] get_storeCatalog() { }

	public override PurchaseFailureDescription GetLastPurchaseFailureDescription() { }

	public override StoreSpecificPurchaseErrorCode GetLastStoreSpecificPurchaseErrorCode() { }

	public virtual void Initialize(IStoreCallback callback) { }

	public override void OnProductsRetrieved(string json) { }

	public override void OnPurchaseFailed(string json) { }

	public void OnPurchaseFailed(PurchaseFailureDescription failure, string json = null) { }

	public override void OnPurchaseSucceeded(string id, string receipt, string transactionID) { }

	public override void OnSetupFailed(string reason) { }

	private StoreSpecificPurchaseErrorCode ParseStoreSpecificPurchaseErrorCode(string json) { }

	internal void ProcessManagedStoreResponse(List<ProductDefinition> storeProducts) { }

	public virtual void Purchase(ProductDefinition product, string developerPayload) { }

	public virtual void RetrieveProducts(ReadOnlyCollection<ProductDefinition> products) { }

	public void SetNativeStore(INativeStore native) { }

	private override void UnityEngine.Purchasing.IStoreInternal.SetModule(StandardPurchasingModule module) { }

}

