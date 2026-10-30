namespace UnityEngine.Purchasing.Interfaces;

internal interface IProductDetailsQueryResponse
{

	public void AddResponse(IGoogleBillingResult billingResult, IEnumerable<AndroidJavaObject> productDetails) { }

	public IGoogleBillingResult GetGoogleBillingResult() { }

	public bool IsRecoverable() { }

	public List<AndroidJavaObject> ProductDetails() { }

}

