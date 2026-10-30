namespace UnityEngine.Purchasing;

[Nullable(0)]
[NullableContext(1)]
internal class PurchasingManager : IStoreCallback, IStoreController
{
	[CompilerGenerated]
	private sealed class <>c
	{
		[Nullable(0)]
		public static readonly <>c <>9; //Field offset: 0x0
		[Nullable(0)]
		public static Func<ProductDefinition, Product> <>9__38_0; //Field offset: 0x8
		[Nullable(0)]
		public static Func<ProductDefinition, Product> <>9__39_0; //Field offset: 0x10
		[Nullable(0)]
		public static Func<ProductDefinition, Product> <>9__45_0; //Field offset: 0x18

		private static <>c() { }

		public <>c() { }

		[NullableContext(0)]
		internal Product <FetchAdditionalProducts>b__38_0(ProductDefinition x) { }

		[NullableContext(0)]
		internal Product <FetchAdditionalProducts>b__39_0(ProductDefinition x) { }

		[NullableContext(0)]
		internal Product <Initialize>b__45_0(ProductDefinition x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass27_0
	{
		[Nullable(0)]
		public Product product; //Field offset: 0x10

		public <>c__DisplayClass27_0() { }

		[NullableContext(0)]
		internal bool <OnAllPurchasesRetrieved>b__0(Product firstPurchasedProduct) { }

	}

	private readonly IStore m_Store; //Field offset: 0x10
	[Nullable(2)]
	private IInternalStoreListener m_Listener; //Field offset: 0x18
	private readonly ILogger m_Logger; //Field offset: 0x20
	private readonly TransactionLog m_TransactionLog; //Field offset: 0x28
	private readonly string m_StoreName; //Field offset: 0x30
	private readonly bool m_logUnavailableProducts; //Field offset: 0x38
	private readonly IUnityServicesInitializationChecker m_UnityServicesInitializationChecker; //Field offset: 0x40
	[Nullable(2)]
	private Action m_AdditionalProductsCallback; //Field offset: 0x48
	[Nullable(2)]
	private Action<InitializationFailureReason> m_AdditionalProductsFailCallback; //Field offset: 0x50
	[Nullable(2)]
	private Action<InitializationFailureReason, String> m_AdditionalProductsDetailedFailCallback; //Field offset: 0x58
	private readonly HashSet<String> purchasesProcessedInSession; //Field offset: 0x60
	[CompilerGenerated]
	private bool <useTransactionLog>k__BackingField; //Field offset: 0x68
	[CompilerGenerated]
	private ProductCollection <products>k__BackingField; //Field offset: 0x70
	private bool initialized; //Field offset: 0x78

	public private override ProductCollection products
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public override bool useTransactionLog
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	internal PurchasingManager(TransactionLog tDb, ILogger logger, IStore store, string storeName, IUnityServicesInitializationChecker unityServicesInitializationChecker, bool logUnavailableProducts) { }

	private void CheckForInitialization(int productCount) { }

	private static void ClearProductReceipt(Product product) { }

	public override void ConfirmPendingPurchase(Product product) { }

	private string CreateUnifiedReceipt(string rawReceipt, string transactionId) { }

	public override void FetchAdditionalProducts(HashSet<ProductDefinition> additionalProducts, Action successCallback, Action<InitializationFailureReason, String> failCallback) { }

	[Obsolete]
	public override void FetchAdditionalProducts(HashSet<ProductDefinition> additionalProducts, Action successCallback, Action<InitializationFailureReason> failCallback) { }

	[CompilerGenerated]
	public override ProductCollection get_products() { }

	[CompilerGenerated]
	public override bool get_useTransactionLog() { }

	private void HandlePurchaseRetrieved(Product product, Product purchasedProduct) { }

	private bool HasAvailableProductsToPurchase() { }

	private bool HasRecordedTransaction(string transactionId) { }

	public void Initialize(IInternalStoreListener listener, HashSet<ProductDefinition> products) { }

	public override void InitiatePurchase(Product product) { }

	public override void InitiatePurchase(string purchasableId, string developerPayload) { }

	[NullableContext(2)]
	public override void InitiatePurchase(string productId) { }

	public override void InitiatePurchase(Product product, string developerPayload) { }

	public override void OnAllPurchasesRetrieved(List<Product> purchasedProducts) { }

	internal static void OnEntitlementRevoked(Product revokedProduct) { }

	public override void OnProductsRetrieved(List<ProductDescription> products) { }

	public override void OnPurchaseFailed(PurchaseFailureDescription description) { }

	public override void OnPurchaseSucceeded(string id, string receipt, string transactionId) { }

	[NullableContext(2)]
	public override void OnSetupFailed(InitializationFailureReason reason, string message) { }

	[Obsolete]
	public override void OnSetupFailed(InitializationFailureReason reason) { }

	private void ProcessPurchaseIfNew(Product product) { }

	private void ProcessPurchaseOnStart() { }

	[CompilerGenerated]
	private void set_products(ProductCollection value) { }

	[CompilerGenerated]
	public override void set_useTransactionLog(bool value) { }

	private void UpdateProductReceiptAndTransactionID(Product product, string receipt, string transactionId) { }

	private bool WasPurchaseAlreadyProcessed(string transactionId) { }

}

