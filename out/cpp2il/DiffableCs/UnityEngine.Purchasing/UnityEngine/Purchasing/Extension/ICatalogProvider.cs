namespace UnityEngine.Purchasing.Extension;

public interface ICatalogProvider
{

	public void FetchProducts(Action<HashSet`1<ProductDefinition>> callback) { }

}

