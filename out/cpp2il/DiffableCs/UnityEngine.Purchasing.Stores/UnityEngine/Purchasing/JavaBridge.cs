namespace UnityEngine.Purchasing;

internal class JavaBridge : AndroidJavaProxy, IUnityCallback
{
	private readonly IUnityCallback forwardTo; //Field offset: 0x20

	public JavaBridge(IUnityCallback forwardTo) { }

	public JavaBridge(IUnityCallback forwardTo, string javaInterface) { }

	public override void OnProductsRetrieved(string json) { }

	public override void OnPurchaseFailed(string json) { }

	public override void OnPurchaseSucceeded(string id, string receipt, string transactionID) { }

	public override void OnSetupFailed(string json) { }

}

