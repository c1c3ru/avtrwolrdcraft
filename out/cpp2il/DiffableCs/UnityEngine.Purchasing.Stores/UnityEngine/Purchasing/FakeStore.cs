namespace UnityEngine.Purchasing;

internal class FakeStore : JSONStore, IFakeExtensions, IStoreExtension, INativeStore
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_0
	{
		public FakeStore <>4__this; //Field offset: 0x10
		public List<ProductDescription> products; //Field offset: 0x18

		public <>c__DisplayClass13_0() { }

		internal void <StoreRetrieveProducts>g__handleAllowInitializeOrRetrieveProducts|0(bool allow, InitializationFailureReason failureReason) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass15_0
	{
		public FakeStore <>4__this; //Field offset: 0x10
		public ProductDefinition product; //Field offset: 0x18

		public <>c__DisplayClass15_0() { }

		internal void <FakePurchase>g__handleAllowPurchase|0(bool allow, PurchaseFailureReason failureReason) { }

	}

	internal enum DialogType
	{
		Purchase = 0,
		RetrieveProducts = 1,
	}

	public const string Name = "fake"; //Field offset: 0x0
	private IStoreCallback m_Biller; //Field offset: 0x60
	private readonly List<String> m_PurchasedProducts; //Field offset: 0x68
	public bool purchaseCalled; //Field offset: 0x70
	public bool restoreCalled; //Field offset: 0x71
	[CompilerGenerated]
	private string <unavailableProductId>k__BackingField; //Field offset: 0x78
	public FakeStoreUIMode UIMode; //Field offset: 0x80

	public override string unavailableProductId
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public FakeStore() { }

	[CompilerGenerated]
	[DebuggerHidden]
	private void <>n__0(string id, string receipt, string transactionID) { }

	private void FakePurchase(ProductDefinition product, string developerPayload) { }

	public override void FinishTransaction(string productJSON, string transactionID) { }

	public virtual void FinishTransaction(ProductDefinition product, string transactionId) { }

	[CompilerGenerated]
	public override string get_unavailableProductId() { }

	public virtual void Initialize(IStoreCallback biller) { }

	public override void Purchase(string productJSON, string developerPayload) { }

	public void RegisterPurchaseForRestore(string productId) { }

	public void RestoreTransactions(Action<Boolean, String> callback) { }

	public override void RetrieveProducts(string json) { }

	[CompilerGenerated]
	public override void set_unavailableProductId(string value) { }

	protected override bool StartUI(object model, DialogType dialogType, Action<Boolean, T> callback) { }

	public void StoreRetrieveProducts(ReadOnlyCollection<ProductDefinition> productDefinitions) { }

}

