namespace UnityEngine.Purchasing.Interfaces;

internal interface IProductDetailsResponseConsolidator
{

	public void Consolidate(IGoogleBillingResult billingResult, IEnumerable<AndroidJavaObject> productDetails) { }

}

