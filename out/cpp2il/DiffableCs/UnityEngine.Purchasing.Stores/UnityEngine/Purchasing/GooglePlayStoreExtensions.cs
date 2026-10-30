namespace UnityEngine.Purchasing;

[Nullable(0)]
[NullableContext(1)]
internal class GooglePlayStoreExtensions : IGooglePlayStoreExtensions, IStoreExtension, IGooglePlayStoreExtensionsInternal
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_0
	{
		[Nullable(0)]
		public Action<Boolean> callback; //Field offset: 0x10

		public <>c__DisplayClass12_0() { }

		[NullableContext(0)]
		internal void <RestoreTransactions>b__0(List<IGooglePurchase> _) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_0
	{
		[Nullable(new IL2CPP_TYPE_U1[] {0, 2})]
		public Action<Boolean, String> callback; //Field offset: 0x10

		public <>c__DisplayClass13_0() { }

		[NullableContext(0)]
		internal void <RestoreTransactions>b__0(List<IGooglePurchase> _) { }

	}

	private readonly IGooglePlayStoreService m_GooglePlayStoreService; //Field offset: 0x10
	private readonly IGooglePurchaseStateEnumProvider m_GooglePurchaseStateEnumProvider; //Field offset: 0x18
	private readonly ITelemetryDiagnostics m_TelemetryDiagnostics; //Field offset: 0x20
	private readonly ILogger m_Logger; //Field offset: 0x28
	[Nullable(2)]
	private IStoreCallback m_StoreCallback; //Field offset: 0x30
	[Nullable(new IL2CPP_TYPE_U1[] {2, 1})]
	private readonly Action<Product> m_DeferredPurchaseAction; //Field offset: 0x38
	[Nullable(new IL2CPP_TYPE_U1[] {2, 1})]
	private readonly Action<Product> m_DeferredProrationUpgradeDowngradeSubscriptionAction; //Field offset: 0x40

	internal GooglePlayStoreExtensions(IGooglePlayStoreService googlePlayStoreService, IGooglePurchaseStateEnumProvider googlePurchaseStateEnumProvider, ILogger logger, ITelemetryDiagnostics telemetryDiagnostics) { }

	public override void ConfirmSubscriptionPriceChange(string productId, Action<Boolean> callback) { }

	public override string GetObfuscatedAccountId(Product product) { }

	public override string GetObfuscatedProfileId(Product product) { }

	public override GooglePurchaseState GetPurchaseState(Product product) { }

	private IGooglePurchase GooglePurchaseFromProduct(Product product) { }

	public override bool IsPurchasedProductDeferred(Product product) { }

	[NullableContext(2)]
	[Obsolete("RestoreTransactions(Action<bool> callback) is deprecated, please use RestoreTransactions(Action<bool, string> callback) instead.")]
	public override void RestoreTransactions(Action<Boolean> callback) { }

	[NullableContext(2)]
	public override void RestoreTransactions(Action<Boolean, String> callback) { }

	public override void SetStoreCallback(IStoreCallback storeCallback) { }

	private bool TryIsPurchasedProductDeferred(Product product) { }

	public override void UpgradeDowngradeSubscription(string oldSku, string newSku) { }

	public override void UpgradeDowngradeSubscription(string oldSku, string newSku, int desiredProrationMode) { }

	public override void UpgradeDowngradeSubscription(string oldSku, string newSku, GooglePlayProrationMode desiredProrationMode) { }

	public override void UpgradeDowngradeSubscription(string oldSku, string newSku, GooglePlayReplacementMode desiredReplacementMode) { }

}

