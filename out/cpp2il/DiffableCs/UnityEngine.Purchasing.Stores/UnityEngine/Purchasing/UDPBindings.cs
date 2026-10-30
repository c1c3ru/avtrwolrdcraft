namespace UnityEngine.Purchasing;

internal class UDPBindings : INativeUDPStore, INativeStore
{
	private readonly object m_Bridge; //Field offset: 0x10
	private Action<Boolean, String> m_RetrieveProductsCallbackCache; //Field offset: 0x18

	public UDPBindings() { }

	public override void FinishTransaction(ProductDefinition productDefinition, string transactionID) { }

	public override void FinishTransaction(string productJSON, string transactionID) { }

	public override void Initialize(Action<Boolean, String> callback) { }

	private void OnInventoryQueried(bool success, object payload) { }

	public override void Purchase(string productId, Action<Boolean, String> callback, string developerPayload = null) { }

	public override void Purchase(string productJSON, string developerPayload) { }

	public override void RetrieveProducts(ReadOnlyCollection<ProductDefinition> products, Action<Boolean, String> callback) { }

	public override void RetrieveProducts(string json) { }

	internal static Dictionary<String, String> StringPropertyToDictionary(object info) { }

}

