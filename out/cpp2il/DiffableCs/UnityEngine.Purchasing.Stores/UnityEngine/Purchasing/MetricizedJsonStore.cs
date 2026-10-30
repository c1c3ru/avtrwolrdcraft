namespace UnityEngine.Purchasing;

internal class MetricizedJsonStore : JSONStore
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass2_0
	{
		public MetricizedJsonStore <>4__this; //Field offset: 0x10
		public ReadOnlyCollection<ProductDefinition> products; //Field offset: 0x18

		public <>c__DisplayClass2_0() { }

		internal void <RetrieveProducts>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass3_0
	{
		public MetricizedJsonStore <>4__this; //Field offset: 0x10
		public ProductDefinition product; //Field offset: 0x18
		public string developerPayload; //Field offset: 0x20

		public <>c__DisplayClass3_0() { }

		internal void <Purchase>b__0() { }

	}

	private readonly ITelemetryMetricsService m_TelemetryMetricsService; //Field offset: 0x60

	public MetricizedJsonStore(ITelemetryMetricsService telemetryMetricsService) { }

	[CompilerGenerated]
	[DebuggerHidden]
	private void <>n__0(ReadOnlyCollection<ProductDefinition> products) { }

	[CompilerGenerated]
	[DebuggerHidden]
	private void <>n__1(ProductDefinition product, string developerPayload) { }

	public virtual void Purchase(ProductDefinition product, string developerPayload) { }

	public virtual void RetrieveProducts(ReadOnlyCollection<ProductDefinition> products) { }

}

