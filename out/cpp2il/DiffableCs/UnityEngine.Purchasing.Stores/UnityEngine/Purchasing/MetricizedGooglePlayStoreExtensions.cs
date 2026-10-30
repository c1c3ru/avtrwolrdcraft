namespace UnityEngine.Purchasing;

[Nullable(0)]
[NullableContext(1)]
internal class MetricizedGooglePlayStoreExtensions : GooglePlayStoreExtensions
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass2_0
	{
		[Nullable(0)]
		public MetricizedGooglePlayStoreExtensions <>4__this; //Field offset: 0x10
		[Nullable(0)]
		public string oldSku; //Field offset: 0x18
		[Nullable(0)]
		public string newSku; //Field offset: 0x20
		public GooglePlayReplacementMode desiredReplacementMode; //Field offset: 0x28

		public <>c__DisplayClass2_0() { }

		internal void <UpgradeDowngradeSubscription>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass3_0
	{
		[Nullable(0)]
		public MetricizedGooglePlayStoreExtensions <>4__this; //Field offset: 0x10
		[Nullable(0)]
		public Action<Boolean> callback; //Field offset: 0x18

		public <>c__DisplayClass3_0() { }

		internal void <RestoreTransactions>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass4_0
	{
		[Nullable(0)]
		public MetricizedGooglePlayStoreExtensions <>4__this; //Field offset: 0x10
		[Nullable(new IL2CPP_TYPE_U1[] {0, 2})]
		public Action<Boolean, String> callback; //Field offset: 0x18

		public <>c__DisplayClass4_0() { }

		internal void <RestoreTransactions>b__0() { }

	}

	private readonly ITelemetryMetricsService m_TelemetryMetricsService; //Field offset: 0x48

	internal MetricizedGooglePlayStoreExtensions(IGooglePlayStoreService googlePlayStoreService, IGooglePurchaseStateEnumProvider googlePurchaseStateEnumProvider, ILogger logger, ITelemetryDiagnostics telemetryDiagnostics, ITelemetryMetricsService telemetryMetricsService) { }

	[CompilerGenerated]
	[DebuggerHidden]
	private void <>n__0(string oldSku, string newSku, GooglePlayReplacementMode desiredReplacementMode) { }

	[CompilerGenerated]
	[DebuggerHidden]
	[NullableContext(2)]
	private void <>n__1(Action<Boolean> callback) { }

	[CompilerGenerated]
	[DebuggerHidden]
	[NullableContext(2)]
	private void <>n__2(Action<Boolean, String> callback) { }

	[NullableContext(2)]
	[Obsolete("RestoreTransactions(Action<bool> callback) is deprecated, please use RestoreTransactions(Action<bool, string> callback) instead.")]
	public virtual void RestoreTransactions(Action<Boolean> callback) { }

	[NullableContext(2)]
	public virtual void RestoreTransactions(Action<Boolean, String> callback) { }

	public virtual void UpgradeDowngradeSubscription(string oldSku, string newSku, GooglePlayReplacementMode desiredReplacementMode) { }

}

