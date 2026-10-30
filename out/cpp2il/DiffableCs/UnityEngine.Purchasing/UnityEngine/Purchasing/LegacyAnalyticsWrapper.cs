namespace UnityEngine.Purchasing;

internal class LegacyAnalyticsWrapper : IAnalyticsAdapter, ICoreServicesEnvironmentObserver
{
	private bool m_Enabled; //Field offset: 0x10
	private IAnalyticsAdapter m_LegacyAdapter; //Field offset: 0x18
	private IAnalyticsAdapter m_EmptyAdapter; //Field offset: 0x20

	private IAnalyticsAdapter m_AnalyticsAdapter
	{
		private get { } //Length: 28
	}

	internal LegacyAnalyticsWrapper(IAnalyticsAdapter legacyAdapter, IAnalyticsAdapter emptyAdapter) { }

	private IAnalyticsAdapter get_m_AnalyticsAdapter() { }

	public override void OnUpdatedCoreServicesEnvironment(string currentEnvironment) { }

	public override void SendTransactionEvent(Product product) { }

	public override void SendTransactionFailedEvent(Product product, PurchaseFailureDescription description) { }

}

