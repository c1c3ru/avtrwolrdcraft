namespace UnityEngine.Purchasing;

public interface IAmazonConfiguration : IStoreConfiguration
{

	public void WriteSandboxJSON(HashSet<ProductDefinition> products) { }

}

