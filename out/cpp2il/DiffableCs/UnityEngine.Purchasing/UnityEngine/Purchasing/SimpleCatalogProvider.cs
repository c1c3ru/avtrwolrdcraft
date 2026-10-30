namespace UnityEngine.Purchasing;

internal class SimpleCatalogProvider : ICatalogProvider
{
	private readonly Action<Action`1<HashSet`1<ProductDefinition>>> m_Func; //Field offset: 0x10

	internal SimpleCatalogProvider(Action<Action`1<HashSet`1<ProductDefinition>>> func) { }

	public override void FetchProducts(Action<HashSet`1<ProductDefinition>> callback) { }

}

