namespace UnityEngine.Purchasing;

[Obsolete("UDP support will be removed in the next major update of In-App Purchasing. Right now, the UDP SDK will still function normally in tandem with IAP.")]
public interface IUDPExtensions : IStoreExtension
{

	public void EnableDebugLog(bool enable) { }

	public string GetLastInitializationError() { }

	public object GetUserInfo() { }

	public void RegisterPurchaseDeferredListener(Action<Product> action) { }

}

