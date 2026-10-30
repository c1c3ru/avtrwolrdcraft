namespace UnityEngine.Purchasing;

internal class UDPImpl : JSONStore, IUDPExtensions, IStoreExtension
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		public UDPImpl <>4__this; //Field offset: 0x10
		public ReadOnlyCollection<ProductDefinition> products; //Field offset: 0x18

		public <>c__DisplayClass10_0() { }

		internal void <RetrieveProducts>b__1(bool success, string message) { }

		internal void <RetrieveProducts>g__retrieveCallback|0(bool success, string json) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass11_0
	{
		public ProductDefinition product; //Field offset: 0x10
		public UDPImpl <>4__this; //Field offset: 0x18

		public <>c__DisplayClass11_0() { }

		internal void <Purchase>b__0(bool success, string message) { }

	}

	private const string k_Unknown = "Unknown"; //Field offset: 0x0
	private const int PURCHASE_PENDING_CODE = -303; //Field offset: 0x0
	private const string k_Errorcode = "errorCode"; //Field offset: 0x0
	private INativeUDPStore m_Bindings; //Field offset: 0x60
	private object m_UserInfo; //Field offset: 0x68
	private string m_LastInitError; //Field offset: 0x70
	private bool m_Initialized; //Field offset: 0x78
	private Action<Product> m_DeferredCallback; //Field offset: 0x80

	public UDPImpl() { }

	private static void DictionaryToStringProperty(Dictionary<String, Object> dic, object info) { }

	public override void EnableDebugLog(bool enable) { }

	public virtual void FinishTransaction(ProductDefinition product, string transactionId) { }

	public override string GetLastInitializationError() { }

	public override object GetUserInfo() { }

	public virtual void Initialize(IStoreCallback callback) { }

	private void OnPurchaseDeferred(string productId) { }

	public virtual void Purchase(ProductDefinition product, string developerPayload) { }

	public override void RegisterPurchaseDeferredListener(Action<Product> callback) { }

	public virtual void RetrieveProducts(ReadOnlyCollection<ProductDefinition> products) { }

	public void SetNativeStore(INativeUDPStore nativeUdpStore) { }

}

