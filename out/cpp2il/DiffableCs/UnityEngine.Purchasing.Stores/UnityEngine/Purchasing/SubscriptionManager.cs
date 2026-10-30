namespace UnityEngine.Purchasing;

public class SubscriptionManager
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Comparison<AppleInAppPurchaseReceipt> <>9__11_0; //Field offset: 0x8
		public static Func<Object, String> <>9__12_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal int <findMostRecentReceipt>b__11_0(AppleInAppPurchaseReceipt b, AppleInAppPurchaseReceipt a) { }

		internal string <getGooglePlayStoreSubInfo>b__12_0(object obj) { }

	}

	private readonly string receipt; //Field offset: 0x10
	private readonly string productId; //Field offset: 0x18
	private readonly string intro_json; //Field offset: 0x20

	public SubscriptionManager(Product product, string intro_json) { }

	public SubscriptionManager(string receipt, string id, string intro_json) { }

	private AppleInAppPurchaseReceipt findMostRecentReceipt(List<AppleInAppPurchaseReceipt> receipts) { }

	private SubscriptionInfo getAmazonAppStoreSubInfo(string productId) { }

	private SubscriptionInfo getAppleAppStoreSubInfo(string payload, string productId) { }

	private SubscriptionInfo getGooglePlayStoreSubInfo(string payload) { }

	public SubscriptionInfo getSubscriptionInfo() { }

	public static void UpdateSubscription(Product newProduct, Product oldProduct, string developerPayload, Action<Product, String> appleStore, Action<String, String> googleStore) { }

	public static void UpdateSubscriptionInAppleStore(Product newProduct, string developerPayload, Action<Product, String> appleStoreUpdateCallback) { }

	public static void UpdateSubscriptionInGooglePlayStore(Product oldProduct, Product newProduct, Action<String, String> googlePlayUpdateCallback) { }

}

