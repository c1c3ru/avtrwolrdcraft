namespace UnityEngine.Purchasing.Interfaces;

[NullableContext(1)]
internal interface IGoogleQueryPurchasesService
{

	public IGooglePurchase GetPurchaseByToken(string token, string skuType) { }

	public Task<List`1<IGooglePurchase>> QueryPurchases() { }

}

