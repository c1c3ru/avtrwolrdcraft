namespace UnityEngine.Purchasing.Interfaces;

internal interface IGooglePurchaseBuilder
{

	public IGooglePurchase BuildPurchase(AndroidJavaObject purchase) { }

	public IEnumerable<IGooglePurchase> BuildPurchases(IEnumerable<AndroidJavaObject> purchases) { }

}

