namespace PazuCore;

public class Purchaser : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<Response> <>9__32_0; //Field offset: 0x8
		public static Action<Response> <>9__33_0; //Field offset: 0x10
		public static Func<Boolean> <>9__38_4; //Field offset: 0x18
		public static Action <>9__45_0; //Field offset: 0x20

		private static <>c() { }

		public <>c() { }

		internal bool <BuyProduct>b__38_4() { }

		internal void <RestorePurchases>b__45_0() { }

		internal void <VerifyReceiptAfterRestore>b__33_0(Response response) { }

		internal void <VerifyReceiptWithRestoreOp>b__32_0(Response response) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass26_0
	{
		public string productId; //Field offset: 0x10

		public <>c__DisplayClass26_0() { }

		internal void <OnPurchaseSucceeded>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass27_0
	{
		public string productId; //Field offset: 0x10

		public <>c__DisplayClass27_0() { }

		internal bool <GetProductInfoForAnalytics>b__0(Product x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass30_0
	{
		public string optionalProductId; //Field offset: 0x10

		public <>c__DisplayClass30_0() { }

		internal void <VerifyReceiptForReceiptDataWithBuyOp>b__0(Response response) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass38_0
	{
		public string productName; //Field offset: 0x10
		public string productId; //Field offset: 0x18
		public string entitlements; //Field offset: 0x20
		public Action <>9__5; //Field offset: 0x28

		public <>c__DisplayClass38_0() { }

		internal bool <BuyProduct>b__0(Product x) { }

		internal void <BuyProduct>b__1() { }

		internal void <BuyProduct>b__3() { }

		internal void <BuyProduct>b__5() { }

		internal void <BuyProduct>g__BuyNow|2() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass47_0
	{
		public Product extraProduct; //Field offset: 0x10

		public <>c__DisplayClass47_0() { }

		internal bool <InitIOSProducts>b__0(Product x) { }

	}

	private static List<Product> _iosProducts; //Field offset: 0x0
	public static string LastConsumableEntitlements; //Field offset: 0x8
	[CompilerGenerated]
	private static bool <IsInProgress>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private static Action<IAPResult> OnIAPEndedAction; //Field offset: 0x18
	[CompilerGenerated]
	private static Func<Boolean> OverrideCanListenToPurchaseSuccessAction; //Field offset: 0x20
	[CompilerGenerated]
	private static Purchaser <Instance>k__BackingField; //Field offset: 0x28
	private Coroutine _purchaseSuccessCoroutine; //Field offset: 0x20
	private Coroutine _restoreSuccessCoroutine; //Field offset: 0x28
	private bool _didCallFinishCompletedTransactionsIfNeededForIOS; //Field offset: 0x30

	public static event Action<IAPResult> OnIAPEndedAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public static event Func<Boolean> OverrideCanListenToPurchaseSuccessAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public private static Purchaser Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public private static bool IsInProgress
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public Purchaser() { }

	[CompilerGenerated]
	public static void add_OnIAPEndedAction(Action<IAPResult> value) { }

	[CompilerGenerated]
	public static void add_OverrideCanListenToPurchaseSuccessAction(Func<Boolean> value) { }

	private static void AddRestorePurchaseEndedEventToBatch(string result) { }

	private void Awake() { }

	public static void BuyNonConsumable() { }

	public static void BuyProduct(string productName, string entitlements = null) { }

	public static bool FinishTransaction(string transactionId) { }

	public static void ForceOnIAPEndedEvent(IAPResult result) { }

	[CompilerGenerated]
	public static Purchaser get_Instance() { }

	[CompilerGenerated]
	public static bool get_IsInProgress() { }

	public static List<Product> GetIOSProducts() { }

	public static string GetIOSSubscriptionProductName(bool withTrial) { }

	public static string GetLatestReceiptForCloud() { }

	public static void GetProductInfoForAnalytics(string productId, out string priceDisplay, out string currency, out string priceNumber) { }

	public static string GetProductLocalCurrencyCode(string productName) { }

	public static string GetProductLocalCurrencyCode(string productName, out string currencySymbol) { }

	public static string GetProductLocalPrice(string productName) { }

	public static float GetProductLocalPriceNumber(string productName) { }

	public static string GetProductLocalPriceWithPriceOverride(string productName, float price) { }

	public static String[] GetPurchasedNonConsumables() { }

	public static TrialPeriod GetTrialPeriodForProduct(string productName) { }

	private static void InitIOSProducts() { }

	private void OnDestroy() { }

	private static void OnIAPEnded(IAPResult result) { }

	private void OnPurchaseCanceled(string productId) { }

	private void OnPurchaseFailed(string productId, string reason) { }

	private void OnPurchaseSucceeded(string productId) { }

	private void OnRestoreFailed(string reason) { }

	private void OnRestoreSucceeded() { }

	private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode) { }

	[CompilerGenerated]
	public static void remove_OnIAPEndedAction(Action<IAPResult> value) { }

	[CompilerGenerated]
	public static void remove_OverrideCanListenToPurchaseSuccessAction(Func<Boolean> value) { }

	public static void RestorePurchases() { }

	[CompilerGenerated]
	private static void set_Instance(Purchaser value) { }

	[CompilerGenerated]
	private static void set_IsInProgress(bool value) { }

	private static void ShowIAPMessage(IAPResult result, bool wasPurchaseInProgress) { }

	private static void VerifyReceiptAfterPurchase(string productId) { }

	private static void VerifyReceiptAfterRestore() { }

	public static void VerifyReceiptForReceiptDataWithBuyOp(string receiptData, string optionalProductId = null) { }

	public static void VerifyReceiptWithRestoreOp(string latestReceipt = null) { }

}

