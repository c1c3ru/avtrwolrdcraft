namespace UnityEngine.Purchasing;

[Nullable(0)]
[NullableContext(1)]
internal class MetricizedAppleStoreImpl : AppleStoreImpl
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		[Nullable(0)]
		public MetricizedAppleStoreImpl <>4__this; //Field offset: 0x10
		[Nullable(new IL2CPP_TYPE_U1[] {0, 1})]
		public ReadOnlyCollection<ProductDefinition> products; //Field offset: 0x18

		public <>c__DisplayClass10_0() { }

		internal void <RetrieveProducts>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass11_0
	{
		[Nullable(0)]
		public MetricizedAppleStoreImpl <>4__this; //Field offset: 0x10
		[Nullable(0)]
		public ProductDefinition product; //Field offset: 0x18
		[Nullable(0)]
		public string developerPayload; //Field offset: 0x20

		public <>c__DisplayClass11_0() { }

		internal void <Purchase>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass2_0
	{
		[Nullable(0)]
		public MetricizedAppleStoreImpl <>4__this; //Field offset: 0x10
		[Nullable(new IL2CPP_TYPE_U1[] {0, 1, 1})]
		public Action<List`1<Product>> successCallback; //Field offset: 0x18
		[Nullable(0)]
		public Action errorCallback; //Field offset: 0x20

		public <>c__DisplayClass2_0() { }

		internal void <FetchStorePromotionOrder>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass3_0
	{
		[Nullable(0)]
		public MetricizedAppleStoreImpl <>4__this; //Field offset: 0x10
		[Nullable(0)]
		public Product product; //Field offset: 0x18
		[Nullable(new IL2CPP_TYPE_U1[] {0, 1})]
		public Action<String, AppleStorePromotionVisibility> successCallback; //Field offset: 0x20
		[Nullable(0)]
		public Action errorCallback; //Field offset: 0x28

		public <>c__DisplayClass3_0() { }

		internal void <FetchStorePromotionVisibility>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass4_0
	{
		[Nullable(0)]
		public MetricizedAppleStoreImpl <>4__this; //Field offset: 0x10
		[Nullable(new IL2CPP_TYPE_U1[] {0, 1})]
		public List<Product> products; //Field offset: 0x18

		public <>c__DisplayClass4_0() { }

		internal void <SetStorePromotionOrder>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		[Nullable(0)]
		public MetricizedAppleStoreImpl <>4__this; //Field offset: 0x10
		[Nullable(0)]
		public Action<Boolean> callback; //Field offset: 0x18

		public <>c__DisplayClass5_0() { }

		internal void <RestoreTransactions>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		[Nullable(0)]
		public MetricizedAppleStoreImpl <>4__this; //Field offset: 0x10
		[Nullable(new IL2CPP_TYPE_U1[] {0, 2})]
		public Action<Boolean, String> callback; //Field offset: 0x18

		public <>c__DisplayClass6_0() { }

		internal void <RestoreTransactions>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_0
	{
		[Nullable(0)]
		public MetricizedAppleStoreImpl <>4__this; //Field offset: 0x10
		[Nullable(new IL2CPP_TYPE_U1[] {0, 1})]
		public Action<String> successCallback; //Field offset: 0x18
		[Nullable(new IL2CPP_TYPE_U1[] {0, 1})]
		public Action<String> errorCallback; //Field offset: 0x20

		public <>c__DisplayClass7_0() { }

		internal void <RefreshAppReceipt>b__0() { }

	}

	private readonly ITelemetryMetricsService m_TelemetryMetricsService; //Field offset: 0xE8

	public MetricizedAppleStoreImpl(IUtil util, ITelemetryDiagnostics telemetryDiagnostics, ITelemetryMetricsService telemetryMetricsService) { }

	[CompilerGenerated]
	[DebuggerHidden]
	private void <>n__0(Action<List`1<Product>> successCallback, Action errorCallback) { }

	[CompilerGenerated]
	[DebuggerHidden]
	private void <>n__1(Product product, Action<String, AppleStorePromotionVisibility> successCallback, Action errorCallback) { }

	[CompilerGenerated]
	[DebuggerHidden]
	private void <>n__2(List<Product> products) { }

	[CompilerGenerated]
	[DebuggerHidden]
	[NullableContext(2)]
	private void <>n__3(Action<Boolean> callback) { }

	[CompilerGenerated]
	[DebuggerHidden]
	[NullableContext(2)]
	private void <>n__4(Action<Boolean, String> callback) { }

	[CompilerGenerated]
	[DebuggerHidden]
	private void <>n__5(Action<String> successCallback, Action<String> errorCallback) { }

	[CompilerGenerated]
	[DebuggerHidden]
	[NullableContext(0)]
	private void <>n__6(ReadOnlyCollection<ProductDefinition> products) { }

	[CompilerGenerated]
	[DebuggerHidden]
	[NullableContext(0)]
	private void <>n__7(ProductDefinition product, string developerPayload) { }

	public virtual void ContinuePromotionalPurchases() { }

	public virtual void FetchStorePromotionOrder(Action<List`1<Product>> successCallback, Action errorCallback) { }

	public virtual void FetchStorePromotionVisibility(Product product, Action<String, AppleStorePromotionVisibility> successCallback, Action errorCallback) { }

	public virtual void PresentCodeRedemptionSheet() { }

	public virtual void Purchase(ProductDefinition product, string developerPayload) { }

	public virtual void RefreshAppReceipt(Action<String> successCallback, Action<String> errorCallback) { }

	[NullableContext(2)]
	public virtual void RestoreTransactions(Action<Boolean, String> callback) { }

	[NullableContext(2)]
	[Obsolete("RestoreTransactions(Action<bool> callback) is deprecated, please use RestoreTransactions(Action<bool, string> callback) instead.")]
	public virtual void RestoreTransactions(Action<Boolean> callback) { }

	public virtual void RetrieveProducts(ReadOnlyCollection<ProductDefinition> products) { }

	public virtual void SetStorePromotionOrder(List<Product> products) { }

}

