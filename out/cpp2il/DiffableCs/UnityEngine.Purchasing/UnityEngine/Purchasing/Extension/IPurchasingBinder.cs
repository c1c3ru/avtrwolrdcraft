namespace UnityEngine.Purchasing.Extension;

public interface IPurchasingBinder
{

	public void RegisterConfiguration(T instance) { }

	public void RegisterExtension(T instance) { }

	public void RegisterStore(string name, IStore store) { }

	public void SetCatalogProvider(ICatalogProvider provider) { }

	public void SetCatalogProviderFunction(Action<Action`1<HashSet`1<ProductDefinition>>> func) { }

}

