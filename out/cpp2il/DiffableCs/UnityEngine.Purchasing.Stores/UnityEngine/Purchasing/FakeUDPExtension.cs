namespace UnityEngine.Purchasing;

[Obsolete("UDP support will be removed in the next major update of In-App Purchasing. Right now, the UDP SDK will still function normally in tandem with IAP.")]
public class FakeUDPExtension : IUDPExtensions, IStoreExtension
{

	public FakeUDPExtension() { }

	public override void EnableDebugLog(bool enable) { }

	public override string GetLastInitializationError() { }

	public string GetLastPurchaseError() { }

	public override object GetUserInfo() { }

	public override void RegisterPurchaseDeferredListener(Action<Product> action) { }

}

