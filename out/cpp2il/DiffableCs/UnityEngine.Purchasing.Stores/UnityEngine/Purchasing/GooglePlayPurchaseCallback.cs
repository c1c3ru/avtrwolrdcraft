namespace UnityEngine.Purchasing;

[Nullable(0)]
[NullableContext(1)]
internal class GooglePlayPurchaseCallback : IGooglePurchaseCallback
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		[Nullable(0)]
		public GooglePlayPurchaseCallback <>4__this; //Field offset: 0x10
		[Nullable(0)]
		public IGooglePurchase purchase; //Field offset: 0x18
		[Nullable(0)]
		public string receipt; //Field offset: 0x20
		[Nullable(0)]
		public string purchaseToken; //Field offset: 0x28

		public <>c__DisplayClass8_0() { }

		internal void <NotifyDeferredPurchase>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		[Nullable(0)]
		public GooglePlayPurchaseCallback <>4__this; //Field offset: 0x10
		[Nullable(0)]
		public string sku; //Field offset: 0x18

		public <>c__DisplayClass9_0() { }

		internal void <NotifyDeferredProrationUpgradeDowngradeSubscription>b__0() { }

	}

	[Nullable(2)]
	private IStoreCallback m_StoreCallback; //Field offset: 0x10
	[Nullable(2)]
	private IGooglePlayConfigurationInternal m_GooglePlayConfigurationInternal; //Field offset: 0x18
	private readonly IUtil m_Util; //Field offset: 0x20

	public GooglePlayPurchaseCallback(IUtil util) { }

	public override void NotifyDeferredProrationUpgradeDowngradeSubscription(string sku) { }

	public override void NotifyDeferredPurchase(IGooglePurchase purchase, string receipt, string purchaseToken) { }

	public override void OnPurchaseFailed(PurchaseFailureDescription purchaseFailureDescription) { }

	public override void OnPurchaseSuccessful(IGooglePurchase purchase, string receipt, string purchaseToken) { }

	public override void SetStoreCallback(IStoreCallback storeCallback) { }

	public override void SetStoreConfiguration(IGooglePlayConfigurationInternal configuration) { }

}

