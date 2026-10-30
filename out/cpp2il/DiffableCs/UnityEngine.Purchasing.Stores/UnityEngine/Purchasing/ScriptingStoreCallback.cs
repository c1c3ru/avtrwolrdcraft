namespace UnityEngine.Purchasing;

[Nullable(0)]
[NullableContext(1)]
internal class ScriptingStoreCallback : IStoreCallback
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		[Nullable(0)]
		public ScriptingStoreCallback <>4__this; //Field offset: 0x10
		[Nullable(0)]
		public PurchaseFailureDescription desc; //Field offset: 0x18

		public <>c__DisplayClass10_0() { }

		internal void <OnPurchaseFailed>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		[Nullable(0)]
		public ScriptingStoreCallback <>4__this; //Field offset: 0x10
		public InitializationFailureReason reason; //Field offset: 0x18

		public <>c__DisplayClass5_0() { }

		internal void <OnSetupFailed>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		[Nullable(0)]
		public ScriptingStoreCallback <>4__this; //Field offset: 0x10
		public InitializationFailureReason reason; //Field offset: 0x18
		[Nullable(0)]
		public string message; //Field offset: 0x20

		public <>c__DisplayClass6_0() { }

		internal void <OnSetupFailed>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_0
	{
		[Nullable(0)]
		public ScriptingStoreCallback <>4__this; //Field offset: 0x10
		[Nullable(new IL2CPP_TYPE_U1[] {0, 1})]
		public List<ProductDescription> products; //Field offset: 0x18

		public <>c__DisplayClass7_0() { }

		internal void <OnProductsRetrieved>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		[Nullable(0)]
		public ScriptingStoreCallback <>4__this; //Field offset: 0x10
		[Nullable(0)]
		public string id; //Field offset: 0x18
		[Nullable(0)]
		public string receipt; //Field offset: 0x20
		[Nullable(0)]
		public string transactionID; //Field offset: 0x28

		public <>c__DisplayClass8_0() { }

		internal void <OnPurchaseSucceeded>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		[Nullable(0)]
		public ScriptingStoreCallback <>4__this; //Field offset: 0x10
		[Nullable(new IL2CPP_TYPE_U1[] {0, 1})]
		public List<Product> purchasedProducts; //Field offset: 0x18

		public <>c__DisplayClass9_0() { }

		internal void <OnAllPurchasesRetrieved>b__0() { }

	}

	private readonly IStoreCallback m_ForwardTo; //Field offset: 0x10
	private readonly IUtil m_Util; //Field offset: 0x18
	[CompilerGenerated]
	private bool <useTransactionLog>k__BackingField; //Field offset: 0x20

	public override ProductCollection products
	{
		 get { } //Length: 160
	}

	public override bool useTransactionLog
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public ScriptingStoreCallback(IStoreCallback forwardTo, IUtil util) { }

	public override ProductCollection get_products() { }

	[CompilerGenerated]
	public override bool get_useTransactionLog() { }

	public override void OnAllPurchasesRetrieved(List<Product> purchasedProducts) { }

	public override void OnProductsRetrieved(List<ProductDescription> products) { }

	public override void OnPurchaseFailed(PurchaseFailureDescription desc) { }

	public override void OnPurchaseSucceeded(string id, string receipt, string transactionID) { }

	[Obsolete]
	public override void OnSetupFailed(InitializationFailureReason reason) { }

	[NullableContext(2)]
	public override void OnSetupFailed(InitializationFailureReason reason, string message) { }

	[CompilerGenerated]
	public override void set_useTransactionLog(bool value) { }

}

