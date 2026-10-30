namespace UnityEngine.Purchasing;

internal class GooglePurchaseUpdatedListener : AndroidJavaProxy, IGooglePurchaseUpdatedListener
{
	[CompilerGenerated]
	private struct <HandleUserCancelledPurchaseFailure>d__14 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
		public GooglePurchaseUpdatedListener <>4__this; //Field offset: 0x28
		public IGoogleBillingResult billingResult; //Field offset: 0x30
		[Nullable(new IL2CPP_TYPE_U1[] {0, 1, 1})]
		private TaskAwaiter<List`1<IGooglePurchase>> <>u__1; //Field offset: 0x38

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	private const string k_AndroidPurchaseListenerClassName = "com.android.billingclient.api.PurchasesUpdatedListener"; //Field offset: 0x0
	private readonly IGoogleLastKnownProductService m_LastKnownProductService; //Field offset: 0x20
	private readonly IGooglePurchaseCallback m_GooglePurchaseCallback; //Field offset: 0x28
	private readonly IGooglePurchaseBuilder m_PurchaseBuilder; //Field offset: 0x30
	private readonly IGoogleCachedQueryProductDetailsService m_GoogleCachedQueryProductDetailsService; //Field offset: 0x38
	private readonly IGooglePurchaseStateEnumProvider m_GooglePurchaseStateEnumProvider; //Field offset: 0x40
	private IGoogleQueryPurchasesService m_GoogleQueryPurchasesService; //Field offset: 0x48

	internal GooglePurchaseUpdatedListener(IGoogleLastKnownProductService googleLastKnownProductService, IGooglePurchaseCallback googlePurchaseCallback, IGooglePurchaseBuilder purchaseBuilder, IGoogleCachedQueryProductDetailsService googleCachedQueryProductDetailsService, IGooglePurchaseStateEnumProvider googlePurchaseStateEnumProvider, IGoogleQueryPurchasesService googleQueryPurchasesService = null) { }

	[CompilerGenerated]
	private bool <HandleUserCancelledPurchaseFailure>b__15_0(IGooglePurchase purchase) { }

	private void ApplyOnPurchases(IEnumerable<IGooglePurchase> purchases, IGoogleBillingResult billingResult, Action<IGooglePurchase, String> action) { }

	private void ApplyOnPurchases(List<IGooglePurchase> purchases, Action<IGooglePurchase> action) { }

	private void HandleErrorCases(IGoogleBillingResult billingResult, List<IGooglePurchase> purchases) { }

	private void HandleErrorGoogleBillingResult(IGoogleBillingResult billingResult) { }

	private void HandlePurchasedProduct(IGooglePurchase googlePurchase) { }

	private void HandleResultOkCases(IGoogleBillingResult result, List<IGooglePurchase> purchases) { }

	[AsyncStateMachine(typeof(<HandleUserCancelledPurchaseFailure>d__14))]
	private void HandleUserCancelledPurchaseFailure(IGoogleBillingResult billingResult) { }

	private void HandleUserCancelledPurchaseFailure(IGoogleBillingResult billingResult, List<IGooglePurchase> googlePurchases) { }

	private bool IsDeferredSubscriptionChange(IGooglePurchase googlePurchase) { }

	private bool IsLastProrationModeDeferred() { }

	private void OnPurchaseAlreadyOwned(IGooglePurchase googlePurchase) { }

	private void OnPurchaseCancelled(IGoogleBillingResult billingResult) { }

	private void OnPurchaseCancelled(IGooglePurchase googlePurchase) { }

	private void OnPurchaseFailed(IGooglePurchase googlePurchase, string debugMessage) { }

	private void OnPurchaseOk(IGooglePurchase googlePurchase) { }

	[Preserve]
	public void onPurchasesUpdated(AndroidJavaObject billingResult, AndroidJavaObject javaPurchasesList) { }

	internal void OnPurchasesUpdated(IGoogleBillingResult result, List<IGooglePurchase> purchases) { }

	public void SetGoogleQueryPurchaseService(IGoogleQueryPurchasesService googleFetchPurchases) { }

}

