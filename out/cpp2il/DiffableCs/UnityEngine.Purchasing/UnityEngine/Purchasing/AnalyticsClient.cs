namespace UnityEngine.Purchasing;

internal class AnalyticsClient : IAnalyticsClient
{
	private readonly IAnalyticsAdapter m_Analytics; //Field offset: 0x10
	private readonly IAnalyticsAdapter m_LegacyAnalytics; //Field offset: 0x18

	public AnalyticsClient(IAnalyticsAdapter analytics, IAnalyticsAdapter legacyAnalytics) { }

	public override void OnPurchaseFailed(Product product, PurchaseFailureDescription description) { }

	public override void OnPurchaseSucceeded(Product product) { }

}

