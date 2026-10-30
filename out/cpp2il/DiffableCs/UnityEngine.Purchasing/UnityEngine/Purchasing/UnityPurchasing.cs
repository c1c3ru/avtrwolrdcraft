namespace UnityEngine.Purchasing;

public abstract class UnityPurchasing
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public PurchasingManager manager; //Field offset: 0x10
		public StoreListenerProxy proxy; //Field offset: 0x18

		public <>c__DisplayClass5_0() { }

		internal void <Initialize>b__0(HashSet<ProductDefinition> response) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public HashSet<ProductDefinition> localProductSet; //Field offset: 0x10
		public Action<HashSet`1<ProductDefinition>> callback; //Field offset: 0x18

		public <>c__DisplayClass6_0() { }

		internal void <FetchAndMergeProducts>b__0(HashSet<ProductDefinition> cloudProducts) { }

	}


	protected UnityPurchasing() { }

	public static void ClearTransactionLog() { }

	internal static void FetchAndMergeProducts(bool useCatalog, HashSet<ProductDefinition> localProductSet, ICatalogProvider catalog, Action<HashSet`1<ProductDefinition>> callback) { }

	private static IAnalyticsAdapter GenerateLegacyUnityAnalytics() { }

	private static IAnalyticsAdapter GenerateUnityAnalytics(ILogger logger) { }

	[Obsolete("Use Initialize(IDetailedStoreListener, ConfigurationBuilder)", False)]
	public static void Initialize(IStoreListener listener, ConfigurationBuilder builder) { }

	public static void Initialize(IDetailedStoreListener listener, ConfigurationBuilder builder) { }

	internal static void Initialize(IStoreListener listener, ConfigurationBuilder builder, ILogger logger, string persistentDatapath, IAnalyticsAdapter ugsAnalytics, IAnalyticsAdapter legacyAnalytics, ICatalogProvider catalog, IUnityServicesInitializationChecker unityServicesInitializationChecker) { }

}

