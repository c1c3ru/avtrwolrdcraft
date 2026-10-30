namespace UnityEngine.Purchasing.Interfaces;

internal interface IQueryProductDetailsService
{

	public void QueryAsyncProduct(ProductDefinition product, Action<List`1<AndroidJavaObject>, IGoogleBillingResult> onProductDetailsResponse) { }

	public void QueryAsyncProduct(ReadOnlyCollection<ProductDefinition> products, Action<List`1<AndroidJavaObject>, IGoogleBillingResult> onProductDetailsResponse) { }

	public void QueryAsyncProduct(ReadOnlyCollection<ProductDefinition> products, Action<List`1<ProductDescription>, IGoogleBillingResult> onProductDetailsResponse) { }

}

