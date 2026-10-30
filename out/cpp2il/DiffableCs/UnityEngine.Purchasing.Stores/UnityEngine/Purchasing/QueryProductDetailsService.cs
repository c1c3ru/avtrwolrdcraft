namespace UnityEngine.Purchasing;

[Nullable(0)]
[NullableContext(1)]
internal class QueryProductDetailsService : IQueryProductDetailsService
{
	[CompilerGenerated]
	private sealed class <>c
	{
		[Nullable(0)]
		public static readonly <>c <>9; //Field offset: 0x0
		[Nullable(0)]
		public static Func<Boolean, Boolean> <>9__14_0; //Field offset: 0x8
		[Nullable(0)]
		public static Func<ProductDefinition, Boolean> <>9__16_0; //Field offset: 0x10
		[Nullable(0)]
		public static Func<ProductDefinition, String> <>9__16_1; //Field offset: 0x18
		[Nullable(0)]
		public static Func<ProductDefinition, Boolean> <>9__17_0; //Field offset: 0x20
		[Nullable(0)]
		public static Func<ProductDefinition, String> <>9__17_1; //Field offset: 0x28

		private static <>c() { }

		public <>c() { }

		internal bool <AreAllProductDetailsCached>b__14_0(bool isCached) { }

		[NullableContext(0)]
		internal bool <QueryInAppsAsync>b__16_0(ProductDefinition product) { }

		[NullableContext(0)]
		internal string <QueryInAppsAsync>b__16_1(ProductDefinition product) { }

		[NullableContext(0)]
		internal bool <QuerySubsAsync>b__17_0(ProductDefinition product) { }

		[NullableContext(0)]
		internal string <QuerySubsAsync>b__17_1(ProductDefinition product) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		[Nullable(0)]
		public QueryProductDetailsService <>4__this; //Field offset: 0x10
		[Nullable(new IL2CPP_TYPE_U1[] {0, 1})]
		public ReadOnlyCollection<ProductDefinition> products; //Field offset: 0x18
		[Nullable(new IL2CPP_TYPE_U1[] {0, 1, 1, 1})]
		public Action<List`1<AndroidJavaObject>, IGoogleBillingResult> onProductDetailsResponse; //Field offset: 0x20
		public int retryCount; //Field offset: 0x28

		public <>c__DisplayClass10_0() { }

		internal void <QueryAsyncProduct>b__0(Action retryAction) { }

		internal void <QueryAsyncProduct>g__OnActionRetry|1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_0
	{
		[Nullable(0)]
		public QueryProductDetailsService <>4__this; //Field offset: 0x10
		[Nullable(new IL2CPP_TYPE_U1[] {0, 1})]
		public IReadOnlyCollection<ProductDefinition> products; //Field offset: 0x18
		[Nullable(0)]
		public Action retryQuery; //Field offset: 0x20
		[Nullable(new IL2CPP_TYPE_U1[] {0, 1, 1, 1})]
		public Action<List`1<AndroidJavaObject>, IGoogleBillingResult> onProductDetailsResponse; //Field offset: 0x28

		public <>c__DisplayClass12_0() { }

		[NullableContext(0)]
		internal void <TryQueryAsyncProductWithRetries>b__0(IProductDetailsQueryResponse productDetailsQueryResponse) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		[Nullable(new IL2CPP_TYPE_U1[] {0, 1, 1, 1})]
		public Action<List`1<ProductDescription>, IGoogleBillingResult> onProductDetailsResponse; //Field offset: 0x10
		[Nullable(0)]
		public QueryProductDetailsService <>4__this; //Field offset: 0x18

		public <>c__DisplayClass9_0() { }

		internal void <QueryAsyncProduct>b__0(List<AndroidJavaObject> productDetails, IGoogleBillingResult responseCode) { }

	}

	private readonly IGoogleBillingClient m_BillingClient; //Field offset: 0x10
	private readonly IGoogleCachedQueryProductDetailsService m_GoogleCachedQueryProductDetailsService; //Field offset: 0x18
	private readonly IProductDetailsConverter m_ProductDetailsConverter; //Field offset: 0x20
	private readonly IRetryPolicy m_RetryPolicy; //Field offset: 0x28
	private readonly IGoogleProductCallback m_GoogleProductCallback; //Field offset: 0x30
	private readonly IUtil m_Util; //Field offset: 0x38
	private readonly ITelemetryDiagnostics m_TelemetryDiagnostics; //Field offset: 0x40

	internal QueryProductDetailsService(IGoogleBillingClient billingClient, IGoogleCachedQueryProductDetailsService googleCachedQueryProductDetailsService, IProductDetailsConverter productDetailsConverter, IRetryPolicy retryPolicy, IGoogleProductCallback googleProductCallback, IUtil util, ITelemetryDiagnostics telemetryDiagnostics) { }

	private bool AreAllProductDetailsCached(IEnumerable<ProductDefinition> products) { }

	private IEnumerable<AndroidJavaObject> GetCachedProductDetails(IEnumerable<ProductDefinition> products) { }

	public override void QueryAsyncProduct(ProductDefinition product, Action<List`1<AndroidJavaObject>, IGoogleBillingResult> onProductDetailsResponse) { }

	public override void QueryAsyncProduct(ReadOnlyCollection<ProductDefinition> products, Action<List`1<ProductDescription>, IGoogleBillingResult> onProductDetailsResponse) { }

	public override void QueryAsyncProduct(ReadOnlyCollection<ProductDefinition> products, Action<List`1<AndroidJavaObject>, IGoogleBillingResult> onProductDetailsResponse) { }

	private void QueryAsyncProductWithRetries(IReadOnlyCollection<ProductDefinition> products, Action<List`1<AndroidJavaObject>, IGoogleBillingResult> onProductDetailsResponse, Action retryQuery) { }

	private void QueryInAppsAsync(IEnumerable<ProductDefinition> products, IProductDetailsResponseConsolidator consolidator) { }

	private void QueryProductDetails(List<String> productList, string type, IProductDetailsResponseConsolidator consolidator) { }

	private void QuerySubsAsync(IEnumerable<ProductDefinition> products, IProductDetailsResponseConsolidator consolidator) { }

	private bool ShouldRetryQuery(IEnumerable<ProductDefinition> requestedProducts, IProductDetailsQueryResponse queryResponse) { }

	private void TryQueryAsyncProductWithRetries(IReadOnlyCollection<ProductDefinition> products, Action<List`1<AndroidJavaObject>, IGoogleBillingResult> onProductDetailsResponse, Action retryQuery) { }

}

