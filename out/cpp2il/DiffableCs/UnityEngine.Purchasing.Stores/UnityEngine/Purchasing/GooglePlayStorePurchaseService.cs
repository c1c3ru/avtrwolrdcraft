namespace UnityEngine.Purchasing;

internal class GooglePlayStorePurchaseService : IGooglePlayStorePurchaseService
{
	private readonly IGooglePlayStoreService m_GooglePlayStoreService; //Field offset: 0x10

	internal GooglePlayStorePurchaseService(IGooglePlayStoreService googlePlayStoreService) { }

	public override void Purchase(ProductDefinition product) { }

}

