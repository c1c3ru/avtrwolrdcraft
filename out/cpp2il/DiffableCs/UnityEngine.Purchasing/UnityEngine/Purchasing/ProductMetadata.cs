namespace UnityEngine.Purchasing;

public class ProductMetadata
{
	[CompilerGenerated]
	private string <localizedPriceString>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private string <localizedTitle>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private string <localizedDescription>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private string <isoCurrencyCode>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private decimal <localizedPrice>k__BackingField; //Field offset: 0x30

	public internal string isoCurrencyCode
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	public internal string localizedDescription
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	public internal decimal localizedPrice
	{
		[CompilerGenerated]
		 get { } //Length: 12
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	public internal string localizedPriceString
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	public internal string localizedTitle
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	public ProductMetadata(string priceString, string title, string description, string currencyCode, decimal localizedPrice) { }

	public ProductMetadata(ProductMetadata productMetadata) { }

	public ProductMetadata() { }

	[CompilerGenerated]
	public string get_isoCurrencyCode() { }

	[CompilerGenerated]
	public string get_localizedDescription() { }

	[CompilerGenerated]
	public decimal get_localizedPrice() { }

	[CompilerGenerated]
	public string get_localizedPriceString() { }

	[CompilerGenerated]
	public string get_localizedTitle() { }

	[CompilerGenerated]
	internal void set_isoCurrencyCode(string value) { }

	[CompilerGenerated]
	internal void set_localizedDescription(string value) { }

	[CompilerGenerated]
	internal void set_localizedPrice(decimal value) { }

	[CompilerGenerated]
	internal void set_localizedPriceString(string value) { }

	[CompilerGenerated]
	internal void set_localizedTitle(string value) { }

}

