namespace UnityEngine.Purchasing;

internal interface INativeStoreProvider
{

	public INativeStore GetAndroidStore(IUnityCallback callback, AppStore store, IPurchasingBinder binder, IUtil util) { }

	public INativeAppleStore GetStorekit(IUnityCallback callback) { }

}

