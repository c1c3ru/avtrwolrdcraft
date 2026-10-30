namespace UnityEngine.Purchasing;

[Nullable(0)]
[NullableContext(1)]
internal class GooglePlayStoreService : IGooglePlayStoreService
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass21_0
	{
		[Nullable(0)]
		public GooglePlayStoreService <>4__this; //Field offset: 0x10
		[Nullable(0)]
		public Action ActionToRetry; //Field offset: 0x18

		public <>c__DisplayClass21_0() { }

		internal void <RetryConnection>b__0() { }

	}

	[CompilerGenerated]
	private struct <FetchPurchases>d__33 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
		[Nullable(0)]
		public GooglePlayStoreService <>4__this; //Field offset: 0x28
		[Nullable(new IL2CPP_TYPE_U1[] {0, 1, 1})]
		public Action<List`1<IGooglePurchase>> onQueryPurchaseSucceed; //Field offset: 0x30
		private TaskAwaiter <>u__1; //Field offset: 0x38

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <TryFetchPurchases>d__34 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		[Nullable(new IL2CPP_TYPE_U1[] {0, 1, 1})]
		public Action<List`1<IGooglePurchase>> onQueryPurchaseSucceed; //Field offset: 0x20
		[Nullable(0)]
		public GooglePlayStoreService <>4__this; //Field offset: 0x28
		[Nullable(new IL2CPP_TYPE_U1[] {0, 1, 1})]
		private TaskAwaiter<List`1<IGooglePurchase>> <>u__1; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	private int m_CurrentConnectionAttempts; //Field offset: 0x10
	private int m_MaxConnectionAttempts; //Field offset: 0x14
	private readonly IGoogleBillingClient m_BillingClient; //Field offset: 0x18
	private readonly IBillingClientStateListener m_BillingClientStateListener; //Field offset: 0x20
	private readonly IQueryProductDetailsService m_QueryProductDetailsService; //Field offset: 0x28
	private readonly ConcurrentQueue<ProductDescriptionQuery> m_ProductsToQuery; //Field offset: 0x30
	private readonly ConcurrentQueue<Action`1<List`1<IGooglePurchase>>> m_OnPurchaseSucceededQueue; //Field offset: 0x38
	private readonly IGooglePurchaseService m_GooglePurchaseService; //Field offset: 0x40
	private readonly IGoogleFinishTransactionService m_GoogleFinishTransactionService; //Field offset: 0x48
	private readonly IGoogleQueryPurchasesService m_GoogleQueryPurchasesService; //Field offset: 0x50
	private readonly IGoogleLastKnownProductService m_GoogleLastKnownProductService; //Field offset: 0x58
	private readonly ITelemetryDiagnostics m_TelemetryDiagnostics; //Field offset: 0x60
	private readonly ILogger m_Logger; //Field offset: 0x68
	private readonly IRetryPolicy m_RetryPolicy; //Field offset: 0x70
	private readonly IUtil m_Util; //Field offset: 0x78

	internal GooglePlayStoreService(IGoogleBillingClient billingClient, IQueryProductDetailsService queryProductDetailsService, IGooglePurchaseService purchaseService, IGoogleFinishTransactionService finishTransactionService, IGoogleQueryPurchasesService queryPurchasesService, IBillingClientStateListener billingClientStateListener, IGoogleLastKnownProductService lastKnownProductService, ITelemetryDiagnostics telemetryDiagnostics, ILogger logger, IRetryPolicy retryPolicy, IUtil util) { }

	[CompilerGenerated]
	private void <AttemptReconnection>b__19_0(Action retryAction) { }

	private bool AreConnectionAttemptsExhausted() { }

	private void AttemptReconnection() { }

	protected override void DequeueFetchPurchases() { }

	protected override void DequeueQueryProducts(GoogleBillingResponseCode googleBillingResponseCode) { }

	[AsyncStateMachine(typeof(<FetchPurchases>d__33))]
	public override void FetchPurchases(Action<List`1<IGooglePurchase>> onQueryPurchaseSucceed) { }

	public override void FinishTransaction(ProductDefinition product, string purchaseToken, Action<IGoogleBillingResult, IGooglePurchase> onTransactionFinished) { }

	public override IGooglePurchase GetPurchase(string purchaseToken, string skuType) { }

	private void HandleRetrieveProductsNotConnected(ReadOnlyCollection<ProductDefinition> products, Action<List`1<ProductDescription>, IGoogleBillingResult> onProductsReceived, Action<GoogleRetrieveProductsFailureReason, GoogleBillingResponseCode> onRetrieveProductsFailed) { }

	internal void InitConnectionWithGooglePlay() { }

	public override bool IsConnectionReady() { }

	private void OnConnected() { }

	private void OnDisconnected(GoogleBillingResponseCode googleBillingResponseCode) { }

	public override void Purchase(ProductDefinition product) { }

	public override void Purchase(ProductDefinition product, Product oldProduct, Nullable<GooglePlayReplacementMode> desiredReplacementMode) { }

	public override void ResumeConnection() { }

	public override void RetrieveProducts(ReadOnlyCollection<ProductDefinition> products, Action<List`1<ProductDescription>, IGoogleBillingResult> onProductsReceived, Action<GoogleRetrieveProductsFailureReason, GoogleBillingResponseCode> onRetrieveProductsFailed) { }

	private void RetryConnection(Action ActionToRetry) { }

	private void RetryConnectionAttempt(Action ActionToRetry) { }

	public override void SetMaxConnectionAttempts(int maxConnectionAttempts) { }

	public override void SetObfuscatedAccountId(string obfuscatedAccountId) { }

	public override void SetObfuscatedProfileId(string obfuscatedProfileId) { }

	private void StartConnection() { }

	[AsyncStateMachine(typeof(<TryFetchPurchases>d__34))]
	private Task TryFetchPurchases(Action<List`1<IGooglePurchase>> onQueryPurchaseSucceed) { }

}

