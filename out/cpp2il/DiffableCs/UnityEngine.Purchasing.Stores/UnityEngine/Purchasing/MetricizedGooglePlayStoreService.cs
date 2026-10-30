namespace UnityEngine.Purchasing;

[Nullable(0)]
[NullableContext(1)]
internal class MetricizedGooglePlayStoreService : GooglePlayStoreService
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass3_0
	{
		[Nullable(0)]
		public MetricizedGooglePlayStoreService <>4__this; //Field offset: 0x10
		public GoogleBillingResponseCode googleBillingResponseCode; //Field offset: 0x18

		public <>c__DisplayClass3_0() { }

		internal void <DequeueQueryProducts>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		[Nullable(0)]
		public MetricizedGooglePlayStoreService <>4__this; //Field offset: 0x10
		[Nullable(new IL2CPP_TYPE_U1[] {0, 1})]
		public ReadOnlyCollection<ProductDefinition> products; //Field offset: 0x18
		[Nullable(new IL2CPP_TYPE_U1[] {0, 1, 1, 1})]
		public Action<List`1<ProductDescription>, IGoogleBillingResult> onProductsReceived; //Field offset: 0x20
		[Nullable(0)]
		public Action<GoogleRetrieveProductsFailureReason, GoogleBillingResponseCode> onRetrieveProductsFailed; //Field offset: 0x28

		public <>c__DisplayClass5_0() { }

		internal void <RetrieveProducts>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		[Nullable(0)]
		public MetricizedGooglePlayStoreService <>4__this; //Field offset: 0x10
		[Nullable(0)]
		public ProductDefinition product; //Field offset: 0x18
		[Nullable(0)]
		public Product oldProduct; //Field offset: 0x20
		public Nullable<GooglePlayReplacementMode> desiredReplacementMode; //Field offset: 0x28

		public <>c__DisplayClass6_0() { }

		internal void <Purchase>b__0() { }

	}

	private readonly ITelemetryMetricsService m_TelemetryMetricsService; //Field offset: 0x80
	private readonly ITelemetryDiagnostics m_TelemetryDiagnostics; //Field offset: 0x88

	internal MetricizedGooglePlayStoreService(IGoogleBillingClient billingClient, IQueryProductDetailsService queryProductDetailsService, IGooglePurchaseService purchaseService, IGoogleFinishTransactionService finishTransactionService, IGoogleQueryPurchasesService queryPurchasesService, IBillingClientStateListener billingClientStateListener, IGoogleLastKnownProductService lastKnownProductService, ITelemetryDiagnostics telemetryDiagnostics, ITelemetryMetricsService telemetryMetricsService, ILogger logger, IRetryPolicy retryPolicy, IUtil util) { }

	[CompilerGenerated]
	[DebuggerHidden]
	private void <>n__0(GoogleBillingResponseCode googleBillingResponseCode) { }

	[CompilerGenerated]
	[DebuggerHidden]
	private void <>n__1(ReadOnlyCollection<ProductDefinition> products, Action<List`1<ProductDescription>, IGoogleBillingResult> onProductsReceived, Action<GoogleRetrieveProductsFailureReason, GoogleBillingResponseCode> onRetrieveProductsFailed) { }

	[CompilerGenerated]
	[DebuggerHidden]
	private void <>n__2(ProductDefinition product, Product oldProduct, Nullable<GooglePlayReplacementMode> desiredReplacementMode) { }

	protected virtual void DequeueFetchPurchases() { }

	protected virtual void DequeueQueryProducts(GoogleBillingResponseCode googleBillingResponseCode) { }

	public virtual void Purchase(ProductDefinition product, Product oldProduct, Nullable<GooglePlayReplacementMode> desiredReplacementMode) { }

	public virtual void RetrieveProducts(ReadOnlyCollection<ProductDefinition> products, Action<List`1<ProductDescription>, IGoogleBillingResult> onProductsReceived, Action<GoogleRetrieveProductsFailureReason, GoogleBillingResponseCode> onRetrieveProductsFailed) { }

}

