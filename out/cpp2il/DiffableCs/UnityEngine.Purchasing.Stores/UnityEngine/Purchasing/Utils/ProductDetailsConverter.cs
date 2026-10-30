namespace UnityEngine.Purchasing.Utils;

[Nullable(0)]
[NullableContext(1)]
internal class ProductDetailsConverter : IProductDetailsConverter
{

	public ProductDetailsConverter() { }

	internal static ProductDescription BuildProductDescription(AndroidJavaObject productDetails) { }

	public override List<ProductDescription> ConvertOnQueryProductDetailsResponse(IEnumerable<AndroidJavaObject> productDetails) { }

	private static ProductDescription ToProductDescription(AndroidJavaObject productDetails) { }

}

