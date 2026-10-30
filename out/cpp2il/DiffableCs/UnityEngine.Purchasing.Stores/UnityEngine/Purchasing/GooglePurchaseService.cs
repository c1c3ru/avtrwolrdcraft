namespace UnityEngine.Purchasing;

[Nullable(0)]
[NullableContext(1)]
internal class GooglePurchaseService : IGooglePurchaseService
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass4_0
	{
		[Nullable(0)]
		public GooglePurchaseService <>4__this; //Field offset: 0x10
		[Nullable(0)]
		public ProductDefinition product; //Field offset: 0x18
		[Nullable(0)]
		public Product oldProduct; //Field offset: 0x20
		public Nullable<GooglePlayReplacementMode> desiredProrationMode; //Field offset: 0x28

		public <>c__DisplayClass4_0() { }

		[NullableContext(0)]
		internal void <Purchase>b__0(List<AndroidJavaObject> productDetailsList, IGoogleBillingResult _) { }

	}

	private readonly IGoogleBillingClient m_BillingClient; //Field offset: 0x10
	private readonly IGooglePurchaseCallback m_GooglePurchaseCallback; //Field offset: 0x18
	private readonly IQueryProductDetailsService m_QueryProductDetailsService; //Field offset: 0x20

	internal GooglePurchaseService(IGoogleBillingClient billingClient, IGooglePurchaseCallback googlePurchaseCallback, IQueryProductDetailsService queryProductDetailsService) { }

	private void HandleBillingFlowResult(IGoogleBillingResult billingResult, AndroidJavaObject sku) { }

	private void LaunchGoogleBillingFlow(AndroidJavaObject productToPurchase, Product oldProduct, Nullable<GooglePlayReplacementMode> desiredProrationMode) { }

	private void OnQueryProductDetailsResponse(List<AndroidJavaObject> productDetailsList, ProductDefinition productToBuy, Product oldProduct, Nullable<GooglePlayReplacementMode> desiredProrationMode) { }

	public override void Purchase(ProductDefinition product, Product oldProduct, Nullable<GooglePlayReplacementMode> desiredProrationMode) { }

	private void PurchaseFailedInvalidOldProduct(ProductDefinition productToBuy, Product oldProduct) { }

	private void PurchaseFailedSkuNotFound(ProductDefinition productToBuy) { }

	[NullableContext(2)]
	private bool ValidateOldProduct(Product oldProduct) { }

	private bool ValidateQueryProductDetailsResponseParams(List<AndroidJavaObject> skus, ProductDefinition productToBuy, Product oldProduct) { }

	private bool ValidateSkus(List<AndroidJavaObject> skus) { }

	private static void VerifyAndWarnIfMoreThanOneSku(List<AndroidJavaObject> skus) { }

}

