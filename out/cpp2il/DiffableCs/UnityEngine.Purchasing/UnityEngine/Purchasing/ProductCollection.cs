namespace UnityEngine.Purchasing;

public class ProductCollection
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Product, String> <>9__3_0; //Field offset: 0x8
		public static Func<Product, String> <>9__3_1; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal string <AddProducts>b__3_0(Product x) { }

		internal string <AddProducts>b__3_1(Product x) { }

	}

	private Dictionary<String, Product> m_IdToProduct; //Field offset: 0x10
	private Dictionary<String, Product> m_StoreSpecificIdToProduct; //Field offset: 0x18
	[CompilerGenerated]
	private readonly HashSet<Product> <set>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private Product[] <all>k__BackingField; //Field offset: 0x28

	public private Product[] all
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public HashSet<Product> set
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	internal ProductCollection(Product[] products) { }

	internal void AddProducts(IEnumerable<Product> products) { }

	[CompilerGenerated]
	public Product[] get_all() { }

	[CompilerGenerated]
	public HashSet<Product> get_set() { }

	[CompilerGenerated]
	private void set_all(Product[] value) { }

	public Product WithID(string id) { }

	public Product WithStoreSpecificID(string id) { }

}

