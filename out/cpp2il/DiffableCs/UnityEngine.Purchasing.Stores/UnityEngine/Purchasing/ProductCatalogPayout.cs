namespace UnityEngine.Purchasing;

public class ProductCatalogPayout
{
	internal enum ProductCatalogPayoutType
	{
		Other = 0,
		Currency = 1,
		Item = 2,
		Resource = 3,
	}

	public const int MaxSubtypeLength = 64; //Field offset: 0x0
	public const int MaxDataLength = 1024; //Field offset: 0x0
	[SerializeField]
	private string t; //Field offset: 0x10
	[SerializeField]
	private string st; //Field offset: 0x18
	[SerializeField]
	private double q; //Field offset: 0x20
	[SerializeField]
	private string d; //Field offset: 0x28

	public string data
	{
		 get { } //Length: 8
		 set { } //Length: 160
	}

	public double quantity
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public string subtype
	{
		 get { } //Length: 8
		 set { } //Length: 160
	}

	public ProductCatalogPayoutType type
	{
		 get { } //Length: 348
		 set { } //Length: 128
	}

	public string typeString
	{
		 get { } //Length: 8
	}

	public ProductCatalogPayout() { }

	public string get_data() { }

	public double get_quantity() { }

	public string get_subtype() { }

	public ProductCatalogPayoutType get_type() { }

	public string get_typeString() { }

	public void set_data(string value) { }

	public void set_quantity(double value) { }

	public void set_subtype(string value) { }

	public void set_type(ProductCatalogPayoutType value) { }

}

