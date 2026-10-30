namespace UnityEngine.Purchasing;

internal class PurchasingFactory : IPurchasingBinder, IExtensionProvider
{
	private readonly Dictionary<Type, IStoreConfiguration> m_ConfigMap; //Field offset: 0x10
	private readonly Dictionary<Type, IStoreExtension> m_ExtensionMap; //Field offset: 0x18
	private IStore m_Store; //Field offset: 0x20
	private ICatalogProvider m_CatalogProvider; //Field offset: 0x28
	[CompilerGenerated]
	private string <storeName>k__BackingField; //Field offset: 0x30

	public IStore service
	{
		 get { } //Length: 92
		 set { } //Length: 8
	}

	public private string storeName
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public PurchasingFactory(IPurchasingModule first, IPurchasingModule[] remainingModules) { }

	public IStore get_service() { }

	[CompilerGenerated]
	public string get_storeName() { }

	internal ICatalogProvider GetCatalogProvider() { }

	public T GetConfig() { }

	public override T GetExtension() { }

	public override void RegisterConfiguration(T instance) { }

	public override void RegisterExtension(T instance) { }

	public override void RegisterStore(string name, IStore s) { }

	public void set_service(IStore value) { }

	[CompilerGenerated]
	private void set_storeName(string value) { }

	public override void SetCatalogProvider(ICatalogProvider provider) { }

	public override void SetCatalogProviderFunction(Action<Action`1<HashSet`1<ProductDefinition>>> func) { }

}

