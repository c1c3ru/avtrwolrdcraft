namespace UnityEngine.Purchasing;

[Nullable(0)]
[NullableContext(1)]
internal class StoreListenerProxy : IInternalStoreListener
{
	private readonly IAnalyticsClient m_Analytics; //Field offset: 0x10
	private readonly IStoreListener m_ForwardTo; //Field offset: 0x18
	private readonly IExtensionProvider m_Extensions; //Field offset: 0x20

	public StoreListenerProxy(IStoreListener forwardTo, IAnalyticsClient analytics, IExtensionProvider extensions) { }

	public override void OnInitialized(IStoreController controller) { }

	[NullableContext(2)]
	public override void OnInitializeFailed(InitializationFailureReason error, string message) { }

	public override void OnPurchaseFailed(Product i, PurchaseFailureDescription p) { }

	public override PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e) { }

	public override void SendTransactionEvent(Product product) { }

}

