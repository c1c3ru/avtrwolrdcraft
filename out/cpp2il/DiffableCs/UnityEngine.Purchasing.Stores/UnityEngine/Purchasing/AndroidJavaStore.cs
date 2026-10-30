namespace UnityEngine.Purchasing;

internal class AndroidJavaStore : INativeStore
{
	private readonly AndroidJavaObject m_Store; //Field offset: 0x10

	public AndroidJavaStore(AndroidJavaObject store) { }

	public override void FinishTransaction(string productJSON, string transactionID) { }

	protected AndroidJavaObject GetStore() { }

	public override void Purchase(string productJSON, string developerPayload) { }

	public override void RetrieveProducts(string json) { }

}

