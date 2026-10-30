namespace UnityEngine.Purchasing;

internal class WinRTStore : AbstractStore, IWindowsIAPCallback, IMicrosoftExtensions, IStoreExtension
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<ProductDefinition, Boolean> <>9__8_0; //Field offset: 0x8
		public static Func<ProductDefinition, WinProductDescription> <>9__8_1; //Field offset: 0x10
		public static Func<WinProductDescription, <>f__AnonymousType0`2<WinProductDescription, ProductMetadata>> <>9__15_1; //Field offset: 0x18
		public static Func<<>f__AnonymousType0`2<WinProductDescription, ProductMetadata>, ProductDescription> <>9__15_2; //Field offset: 0x20

		private static <>c() { }

		public <>c() { }

		internal <>f__AnonymousType0<WinProductDescription, ProductMetadata> <OnProductListReceived>b__15_1(WinProductDescription product) { }

		internal ProductDescription <OnProductListReceived>b__15_2(<>f__AnonymousType0<WinProductDescription, ProductMetadata> <>h__TransparentIdentifier0) { }

		internal bool <RetrieveProducts>b__8_0(ProductDefinition def) { }

		internal WinProductDescription <RetrieveProducts>b__8_1(ProductDefinition def) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass15_0
	{
		public WinProductDescription[] winProducts; //Field offset: 0x10
		public WinRTStore <>4__this; //Field offset: 0x18

		public <>c__DisplayClass15_0() { }

		internal void <OnProductListReceived>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass16_0
	{
		public WinRTStore <>4__this; //Field offset: 0x10
		public string message; //Field offset: 0x18

		public <>c__DisplayClass16_0() { }

		internal void <log>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass17_0
	{
		public WinRTStore <>4__this; //Field offset: 0x10
		public string productId; //Field offset: 0x18
		public string error; //Field offset: 0x20

		public <>c__DisplayClass17_0() { }

		internal void <OnPurchaseFailed>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass18_0
	{
		public WinRTStore <>4__this; //Field offset: 0x10
		public string productId; //Field offset: 0x18
		public string receipt; //Field offset: 0x20
		public string tranId; //Field offset: 0x28

		public <>c__DisplayClass18_0() { }

		internal void <OnPurchaseSucceeded>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass19_0
	{
		public string message; //Field offset: 0x10
		public WinRTStore <>4__this; //Field offset: 0x18

		public <>c__DisplayClass19_0() { }

		internal void <OnProductListError>b__0() { }

	}

	private IWindowsIAP win8; //Field offset: 0x10
	private IStoreCallback callback; //Field offset: 0x18
	private readonly IUtil util; //Field offset: 0x20
	private readonly ILogger logger; //Field offset: 0x28
	private bool m_CanReceivePurchases; //Field offset: 0x30

	public WinRTStore(IWindowsIAP win8, IUtil util, ILogger logger) { }

	public virtual void FinishTransaction(ProductDefinition product, string transactionId) { }

	private void init(int delay) { }

	public virtual void Initialize(IStoreCallback biller) { }

	public override void log(string message) { }

	public override void logError(string error) { }

	public override void OnProductListError(string message) { }

	public override void OnProductListReceived(WinProductDescription[] winProducts) { }

	public override void OnPurchaseFailed(string productId, string error) { }

	public override void OnPurchaseSucceeded(string productId, string receipt, string tranId) { }

	public virtual void Purchase(ProductDefinition product, string developerPayload) { }

	public void restoreTransactions(bool pausing) { }

	public override void RestoreTransactions() { }

	public virtual void RetrieveProducts(ReadOnlyCollection<ProductDefinition> productDefs) { }

	public void SetWindowsIAP(IWindowsIAP iap) { }

}

