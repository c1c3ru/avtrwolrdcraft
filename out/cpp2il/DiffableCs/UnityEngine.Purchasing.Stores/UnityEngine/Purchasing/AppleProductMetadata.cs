namespace UnityEngine.Purchasing;

public class AppleProductMetadata : ProductMetadata
{
	[CompilerGenerated]
	private readonly bool <isFamilyShareable>k__BackingField; //Field offset: 0x40

	public bool isFamilyShareable
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	internal AppleProductMetadata(ProductMetadata baseProductMetadata, string isFamilyShareable) { }

	internal AppleProductMetadata(string priceString, string title, string description, string currencyCode, decimal localizedPrice, string isFamilyShareable) { }

	[CompilerGenerated]
	public bool get_isFamilyShareable() { }

}

