namespace UnityEngine.Purchasing;

[Nullable(0)]
[NullableContext(1)]
internal class GooglePlayStoreFinishTransactionService : IGooglePlayStoreFinishTransactionService
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_0
	{
		[Nullable(0)]
		public GooglePlayStoreFinishTransactionService <>4__this; //Field offset: 0x10
		[Nullable(0)]
		public ProductDefinition product; //Field offset: 0x18

		public <>c__DisplayClass7_0() { }

		[NullableContext(0)]
		internal void <FinishTransaction>b__0(IGoogleBillingResult billingResult, IGooglePurchase googlePurchase) { }

	}

	private const int k_MaxRetryAttempts = 5; //Field offset: 0x0
	private readonly HashSet<String> m_ProcessedPurchaseToken; //Field offset: 0x10
	private readonly IGooglePlayStoreService m_GooglePlayStoreService; //Field offset: 0x18
	[Nullable(2)]
	private IStoreCallback m_StoreCallback; //Field offset: 0x20
	private int m_RetryCount; //Field offset: 0x28

	internal GooglePlayStoreFinishTransactionService(IGooglePlayStoreService googlePlayStoreService) { }

	private void CallPurchaseSucceededUpdateReceipt(IGooglePurchase googlePurchase) { }

	[NullableContext(2)]
	public override void FinishTransaction(ProductDefinition product, string purchaseToken) { }

	private void HandleFinishTransaction(ProductDefinition product, IGoogleBillingResult billingResult, IGooglePurchase purchase) { }

	private static bool IsResponseCodeInRecoverableState(IGoogleBillingResult billingResult) { }

	[NullableContext(2)]
	public override void SetStoreCallback(IStoreCallback storeCallback) { }

}

