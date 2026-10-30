namespace UnityEngine.Purchasing;

internal class NativeStoreProvider : INativeStoreProvider
{

	public NativeStoreProvider() { }

	public override INativeStore GetAndroidStore(IUnityCallback callback, AppStore store, IPurchasingBinder binder, IUtil util) { }

	private INativeStore GetAndroidStoreHelper(IUnityCallback callback, AppStore store, IPurchasingBinder binder, IUtil util) { }

	public override INativeAppleStore GetStorekit(IUnityCallback callback) { }

}

