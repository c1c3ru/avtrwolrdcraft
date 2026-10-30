namespace PazuCore;

public class PazuUnityPurchaser : MonoBehaviour, IDetailedStoreListener, IStoreListener
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<Response> <>9__40_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <RestoreAllProducts>b__40_0(Response response) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass21_0
	{
		public Product membership1; //Field offset: 0x10
		public Product membership1b; //Field offset: 0x18

		public <>c__DisplayClass21_0() { }

		internal bool <InitializePurchasing>b__0(Product p) { }

		internal bool <InitializePurchasing>b__1(Product p) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass29_0
	{
		public string productName; //Field offset: 0x10

		public <>c__DisplayClass29_0() { }

		internal bool <GetUnityProduct>b__0(Product x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass33_0
	{
		public string productName; //Field offset: 0x10

		public <>c__DisplayClass33_0() { }

		internal bool <BuyProduct>b__0(Product x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass37_0
	{
		public string transactionID; //Field offset: 0x10

		public <>c__DisplayClass37_0() { }

		internal bool <FinishTransactionIfExists>b__0(Product product) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass40_0
	{
		public List<Product> allReceiptsProducts; //Field offset: 0x10
		public PazuUnityPurchaser <>4__this; //Field offset: 0x18

		public <>c__DisplayClass40_0() { }

		internal void <RestoreAllProducts>b__1(Response response) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass44_0
	{
		public IAPResult cloudResult; //Field offset: 0x10
		public PazuUnityPurchaser <>4__this; //Field offset: 0x18
		public Product product; //Field offset: 0x20

		public <>c__DisplayClass44_0() { }

		internal void <ProcessPurchase>b__1(Response response) { }

		internal bool <ProcessPurchase>b__2(Item x) { }

		internal void <ProcessPurchase>g__OnPandingIAPEnded|0(IAPResult result) { }

	}

	[CompilerGenerated]
	private sealed class <RestoreAllProducts>d__40 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public PazuUnityPurchaser <>4__this; //Field offset: 0x20
		private <>c__DisplayClass40_0 <>8__1; //Field offset: 0x28

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <RestoreAllProducts>d__40(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <Start>d__19 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public PazuUnityPurchaser <>4__this; //Field offset: 0x20
		private WaitForSeconds <wait>5__2; //Field offset: 0x28
		private int <counter>5__3; //Field offset: 0x30

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <Start>d__19(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private static IStoreController m_StoreController; //Field offset: 0x0
	private static IExtensionProvider m_StoreExtensionProvider; //Field offset: 0x8
	public static PazuUnityPurchaser Instance; //Field offset: 0x10
	private StandardPurchasingModule m_module; //Field offset: 0x20
	[CompilerGenerated]
	private string <ProductIDNonConsumable>k__BackingField; //Field offset: 0x28
	private string kProductIDBlackFriday; //Field offset: 0x30
	private bool isUserInitiatePurchase; //Field offset: 0x38
	private bool isUserInitiateRestore; //Field offset: 0x39
	private bool productAlreadyPurchased; //Field offset: 0x3A
	private readonly HashSet<String> m_PendingProducts; //Field offset: 0x40
	private bool _haveFullGamePackOnStart; //Field offset: 0x48
	private List<Product> _productsOnStart; //Field offset: 0x50
	[CompilerGenerated]
	private Action<String> UpdatePandingPurchaseUIAction; //Field offset: 0x58

	public event Action<String> UpdatePandingPurchaseUIAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public private string ProductIDNonConsumable
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public PazuUnityPurchaser() { }

	[CompilerGenerated]
	public void add_UpdatePandingPurchaseUIAction(Action<String> value) { }

	private bool AddNonConsumableProductToUser(string productName, bool logErrorIfAlreadyExists) { }

	private void Awake() { }

	public void BuyBlackFriday() { }

	public void BuyFullversion() { }

	public void BuyProduct(string productName, string entitlements = null) { }

	private void BuyProductId(string productId) { }

	public bool FinishTransactionIfExists(string transactionID) { }

	private void GanarateBlackFridayProductID() { }

	[CompilerGenerated]
	public string get_ProductIDNonConsumable() { }

	public List<String> GetAllReceipts() { }

	public string GetAllReceiptsForCloudRequest() { }

	public AppStore GetAppStore() { }

	public string GetFirstPendingTransactionInQueueReceipt() { }

	public string GetProductIsoCurrencyCode(string productName, out string currencySymbol) { }

	public string GetProductLocalPrice(string productName) { }

	public float GetProductLocalPriceNumber(string productName) { }

	public string GetProductLocalPriceWithPriceOverride(string productName, float price) { }

	private string GetReceiptPayload(string receipt) { }

	private Product GetUnityProduct(string productName) { }

	public void InitializePurchasing() { }

	private bool IsInitialized() { }

	public bool IsPurchasedProductDeferred(string productId) { }

	private void OnBoughtProduct(Product product) { }

	private void OnDeferredPurchase(Product product) { }

	private void OnDestroy() { }

	public override void OnInitialized(IStoreController controller, IExtensionProvider extensions) { }

	public override void OnInitializeFailed(InitializationFailureReason error) { }

	public override void OnInitializeFailed(InitializationFailureReason error, string message) { }

	public override void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription) { }

	public override void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason) { }

	private void OnTransactionsRestored(bool result, string error) { }

	public override PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args) { }

	[CompilerGenerated]
	public void remove_UpdatePandingPurchaseUIAction(Action<String> value) { }

	[IteratorStateMachine(typeof(<RestoreAllProducts>d__40))]
	private IEnumerator RestoreAllProducts() { }

	public void RestorePurchases() { }

	[CompilerGenerated]
	private void set_ProductIDNonConsumable(string value) { }

	[IteratorStateMachine(typeof(<Start>d__19))]
	private IEnumerator Start() { }

	private void UnlockFullVersionProduct() { }

}

