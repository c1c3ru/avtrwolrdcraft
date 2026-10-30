namespace UnityEngine.Purchasing;

[Nullable(0)]
[NullableContext(1)]
internal class GooglePlayStoreRetrieveProductsService : IGooglePlayStoreRetrieveProductsService
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		[Nullable(0)]
		public GooglePlayStoreRetrieveProductsService <>4__this; //Field offset: 0x10
		[Nullable(new IL2CPP_TYPE_U1[] {0, 1})]
		public List<ProductDescription> retrievedProducts; //Field offset: 0x18

		public <>c__DisplayClass10_0() { }

		[NullableContext(0)]
		internal void <OnProductsRetrievedWithPurchaseFetch>b__0(List<Product> purchaseProducts) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass14_0
	{
		[Nullable(0)]
		public Product purchaseProduct; //Field offset: 0x10

		public <>c__DisplayClass14_0() { }

		internal bool <MakePurchasesIntoProducts>b__0(ProductDescription product) { }

	}

	private readonly IGooglePlayStoreService m_GooglePlayStoreService; //Field offset: 0x10
	private readonly IGoogleFetchPurchases m_GoogleFetchPurchases; //Field offset: 0x18
	[Nullable(2)]
	private IStoreCallback m_StoreCallback; //Field offset: 0x20
	private readonly IGooglePlayConfigurationInternal m_GooglePlayConfigurationInternal; //Field offset: 0x28
	private readonly IGooglePlayStoreExtensions m_GooglePlayStoreExtensions; //Field offset: 0x30
	private bool m_HasInitiallyRetrievedProducts; //Field offset: 0x38
	private bool m_RetrieveProductsFailed; //Field offset: 0x39

	internal GooglePlayStoreRetrieveProductsService(IGooglePlayStoreService googlePlayStoreService, IGoogleFetchPurchases googleFetchPurchases, IGooglePlayConfigurationInternal googlePlayConfigurationInternal, IGooglePlayStoreExtensions googlePlayStoreExtensions) { }

	public override bool HasInitiallyRetrievedProducts() { }

	private bool IsPurchasedProductDeferred(Product product) { }

	private List<ProductDescription> MakePurchasesIntoProducts(List<ProductDescription> retrievedProducts, IEnumerable<Product> purchaseProducts) { }

	private void OnProductsRetrieved(List<ProductDescription> retrievedProducts, IGoogleBillingResult billingResult) { }

	private void OnProductsRetrievedWithPurchaseFetch(List<ProductDescription> retrievedProducts, IGoogleBillingResult billingResult) { }

	private void OnRetrieveProductsFailed(GoogleRetrieveProductsFailureReason reason, GoogleBillingResponseCode responseCode) { }

	public override void ResumeConnection() { }

	public override void RetrieveProducts(ReadOnlyCollection<ProductDefinition> products, bool wantPurchases = true) { }

	[NullableContext(2)]
	public override void SetStoreCallback(IStoreCallback storeCallback) { }

}

