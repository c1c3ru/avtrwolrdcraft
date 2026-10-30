namespace UnityEngine.Purchasing.Models;

internal class ProductDescriptionQuery
{
	internal ReadOnlyCollection<ProductDefinition> products; //Field offset: 0x10
	internal Action<List`1<ProductDescription>, IGoogleBillingResult> onProductsReceived; //Field offset: 0x18
	internal Action<GoogleRetrieveProductsFailureReason, GoogleBillingResponseCode> onRetrieveProductsFailed; //Field offset: 0x20

	internal ProductDescriptionQuery(ReadOnlyCollection<ProductDefinition> products, Action<List`1<ProductDescription>, IGoogleBillingResult> onProductsReceived, Action<GoogleRetrieveProductsFailureReason, GoogleBillingResponseCode> onRetrieveProductsFailed) { }

}

