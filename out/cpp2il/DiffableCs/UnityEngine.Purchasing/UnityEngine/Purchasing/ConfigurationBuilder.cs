namespace UnityEngine.Purchasing;

public class ConfigurationBuilder
{
	[CompilerGenerated]
	private bool <useCatalogProvider>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private bool <logUnavailableProducts>k__BackingField; //Field offset: 0x11
	[CompilerGenerated]
	private readonly HashSet<ProductDefinition> <products>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private readonly PurchasingFactory <factory>k__BackingField; //Field offset: 0x20

	internal PurchasingFactory factory
	{
		[CompilerGenerated]
		internal get { } //Length: 8
	}

	public bool logUnavailableProducts
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public HashSet<ProductDefinition> products
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public bool useCatalogProvider
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	internal ConfigurationBuilder(PurchasingFactory factory) { }

	public ConfigurationBuilder AddProduct(string id, ProductType type) { }

	public ConfigurationBuilder AddProduct(string id, ProductType type, IDs storeIDs) { }

	public ConfigurationBuilder AddProduct(string id, ProductType type, IDs storeIDs, PayoutDefinition payout) { }

	public ConfigurationBuilder AddProduct(string id, ProductType type, IDs storeIDs, IEnumerable<PayoutDefinition> payouts) { }

	public ConfigurationBuilder AddProducts(IEnumerable<ProductDefinition> products) { }

	public T Configure() { }

	[CompilerGenerated]
	internal PurchasingFactory get_factory() { }

	[CompilerGenerated]
	public bool get_logUnavailableProducts() { }

	[CompilerGenerated]
	public HashSet<ProductDefinition> get_products() { }

	[CompilerGenerated]
	public bool get_useCatalogProvider() { }

	public static ConfigurationBuilder Instance(IPurchasingModule first, IPurchasingModule[] rest) { }

	[CompilerGenerated]
	public void set_logUnavailableProducts(bool value) { }

	[CompilerGenerated]
	public void set_useCatalogProvider(bool value) { }

}

