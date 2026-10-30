namespace UnityEngine.Purchasing;

internal class InventoryInterface
{
	private static Type s_typeCache; //Field offset: 0x0

	public InventoryInterface() { }

	internal static Type GetClassType() { }

	internal static MethodInfo GetProductListMethod() { }

	internal static MethodInfo GetPurchaseInfoMethod() { }

	internal static MethodInfo HasPurchaseMethod() { }

}

