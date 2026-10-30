namespace UnityEngine.Purchasing;

internal class JSONSerializer
{

	public JSONSerializer() { }

	private static string BuildPurchaseFailureDescriptionMessage(Dictionary<String, Object> dic) { }

	public static PurchaseFailureDescription DeserializeFailureReason(string json) { }

	public static Dictionary<String, String> DeserializeProductDetails(string json) { }

	public static Dictionary<String, String> DeserializeSubscriptionDescriptions(string json) { }

	private static Dictionary<String, Object> EncodeProductDef(ProductDefinition product) { }

	private static Dictionary<String, Object> EncodeProductDesc(ProductDescription product) { }

	private static Dictionary<String, Object> EncodeProductMeta(ProductMetadata product) { }

	public static string SerializeProductDef(ProductDefinition product) { }

	public static string SerializeProductDefs(IEnumerable<ProductDefinition> products) { }

	public static string SerializeProductDescs(ProductDescription product) { }

	public static string SerializeProductDescs(IEnumerable<ProductDescription> products) { }

}

