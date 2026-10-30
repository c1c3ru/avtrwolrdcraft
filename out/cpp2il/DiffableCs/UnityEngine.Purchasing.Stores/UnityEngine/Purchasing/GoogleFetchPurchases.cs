namespace UnityEngine.Purchasing;

internal class GoogleFetchPurchases : IGoogleFetchPurchases
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<IGooglePurchase, Boolean> <>9__11_0; //Field offset: 0x8
		public static Func<IGooglePurchase, Boolean> <>9__12_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal bool <PurchaseIsPending>b__12_0(IGooglePurchase purchase) { }

		internal bool <PurchaseIsPurchased>b__11_0(IGooglePurchase purchase) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		public GoogleFetchPurchases <>4__this; //Field offset: 0x10
		public List<IGooglePurchase> deferredPurchases; //Field offset: 0x18

		public <>c__DisplayClass10_0() { }

		internal void <OnFetchedPurchase>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public Action<List`1<Product>> onQueryPurchaseSucceed; //Field offset: 0x10
		public GoogleFetchPurchases <>4__this; //Field offset: 0x18

		public <>c__DisplayClass6_0() { }

		internal void <FetchPurchases>b__0(List<IGooglePurchase> googlePurchases) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public GoogleFetchPurchases <>4__this; //Field offset: 0x10
		public IGooglePurchase purchase; //Field offset: 0x18

		public <>c__DisplayClass8_0() { }

		internal Product <BuildProductsFromPurchase>b__0(string sku) { }

		internal Product <BuildProductsFromPurchase>b__1(Product product) { }

	}

	private readonly IGooglePlayStoreService m_GooglePlayStoreService; //Field offset: 0x10
	private IStoreCallback m_StoreCallback; //Field offset: 0x18
	private IUtil m_Util; //Field offset: 0x20

	internal GoogleFetchPurchases(IGooglePlayStoreService googlePlayStoreService, IUtil util) { }

	private IEnumerable<Product> BuildProductsFromPurchase(IGooglePurchase purchase) { }

	private static Product CompleteProductInfoWithPurchase(Product product, IGooglePurchase purchase) { }

	public override void FetchPurchases() { }

	public override void FetchPurchases(Action<List`1<Product>> onQueryPurchaseSucceed) { }

	private List<Product> FillProductsWithPurchases(IEnumerable<IGooglePurchase> purchases) { }

	private void OnFetchedPurchase(List<IGooglePurchase> purchases) { }

	private static Func<IGooglePurchase, Boolean> PurchaseIsPending() { }

	private static Func<IGooglePurchase, Boolean> PurchaseIsPurchased() { }

	public override void SetStoreCallback(IStoreCallback storeCallback) { }

	private void UpdateDeferredProduct(IGooglePurchase deferredPurchase, string sku) { }

	private void UpdateDeferredProductsByPurchase(IGooglePurchase deferredPurchase) { }

	private void UpdateDeferredProductsByPurchases(List<IGooglePurchase> deferredPurchases) { }

}

