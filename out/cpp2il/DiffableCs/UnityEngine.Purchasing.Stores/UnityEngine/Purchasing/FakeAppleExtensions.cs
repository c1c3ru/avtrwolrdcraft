namespace UnityEngine.Purchasing;

[Nullable(0)]
[NullableContext(1)]
internal class FakeAppleExtensions : IAppleExtensions, IStoreExtension
{
	private bool m_FailRefresh; //Field offset: 0x10
	[CompilerGenerated]
	private bool <simulateAskToBuy>k__BackingField; //Field offset: 0x11

	public override bool simulateAskToBuy
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public FakeAppleExtensions() { }

	public override void ContinuePromotionalPurchases() { }

	public override void FetchStorePromotionOrder(Action<List`1<Product>> successCallback, Action errorCallback) { }

	public override void FetchStorePromotionVisibility(Product product, Action<String, AppleStorePromotionVisibility> successCallback, Action errorCallback) { }

	[CompilerGenerated]
	public override bool get_simulateAskToBuy() { }

	public override Dictionary<String, String> GetIntroductoryPriceDictionary() { }

	public override Dictionary<String, String> GetProductDetails() { }

	public override string GetTransactionReceiptForProduct(Product product) { }

	public override void PresentCodeRedemptionSheet() { }

	public override void RefreshAppReceipt(Action<String> successCallback, Action<String> errorCallback) { }

	[Obsolete("RefreshAppReceipt(Action<string> successCallback, Action errorCallback) is deprecated, please use RefreshAppReceipt(Action<string> successCallback, Action<string> errorCallback) instead.")]
	public override void RefreshAppReceipt(Action<String> successCallback, Action errorCallback) { }

	public override void RegisterPurchaseDeferredListener(Action<Product> callback) { }

	[NullableContext(2)]
	public override void RestoreTransactions(Action<Boolean, String> callback) { }

	[NullableContext(2)]
	[Obsolete("RestoreTransactions(Action<bool> callback) is deprecated, please use RestoreTransactions(Action<bool, string> callback) instead.")]
	public override void RestoreTransactions(Action<Boolean> callback) { }

	[CompilerGenerated]
	public override void set_simulateAskToBuy(bool value) { }

	public override void SetApplicationUsername(string applicationUsername) { }

	public override void SetStorePromotionOrder(List<Product> products) { }

	public override void SetStorePromotionVisibility(Product product, AppleStorePromotionVisibility visible) { }

}

