namespace UnityEngine.Purchasing;

internal class ProductDetailsResponseConsolidator : IProductDetailsResponseConsolidator
{
	private const int k_RequiredNumberOfCallbacks = 2; //Field offset: 0x0
	private int m_NumberReceivedCallbacks; //Field offset: 0x10
	private readonly Action<IProductDetailsQueryResponse> m_OnProductDetailsResponseConsolidated; //Field offset: 0x18
	private readonly IProductDetailsQueryResponse m_Responses; //Field offset: 0x20
	private readonly IUtil m_Util; //Field offset: 0x28
	private readonly ITelemetryDiagnostics m_TelemetryDiagnostics; //Field offset: 0x30

	internal ProductDetailsResponseConsolidator(IUtil util, ITelemetryDiagnostics telemetryDiagnostics, Action<IProductDetailsQueryResponse> onProductDetailsResponseConsolidated) { }

	public override void Consolidate(IGoogleBillingResult billingResult, IEnumerable<AndroidJavaObject> productDetails) { }

}

