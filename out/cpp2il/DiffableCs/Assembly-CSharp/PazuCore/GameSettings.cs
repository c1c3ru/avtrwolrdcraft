namespace PazuCore;

public class GameSettings : ScriptableObject
{
	internal enum AndroidStoreType
	{
		GooglePlay = 1,
		AmazonAppStore = 2,
		HUAWEIAppGallery = 3,
	}

	internal class IOSAlternativeIconsFolders
	{
		public String[] elements; //Field offset: 0x10

		public IOSAlternativeIconsFolders() { }

	}

	internal class Product
	{
		public string name; //Field offset: 0x10
		public string id; //Field offset: 0x18
		public ProductType type; //Field offset: 0x20

		public Product() { }

	}

	internal enum ProductType
	{
		Consumable = 0,
		NonConsumable = 1,
		Subscription = 2,
	}

	public string iconsPathRelativeToAssetsFolder; //Field offset: 0x18
	public bool useIOSAlternativeIcons; //Field offset: 0x20
	[ConditionalField("useIOSAlternativeIcons", True, True, (array) null)]
	public IOSAlternativeIconsFolders iconsFolders; //Field offset: 0x28
	[Header("Android In App Purchase")]
	public string fullVersionPlayerPrefsKey; //Field offset: 0x30
	public string productNameAndroid; //Field offset: 0x38
	public AndroidStoreType androidStore; //Field offset: 0x40
	public List<Product> products; //Field offset: 0x48
	public List<Product> backwardProducts; //Field offset: 0x50
	[Header("IOS In App Purchase")]
	public List<Product> extraIOSProducts; //Field offset: 0x58
	[Header("In App Purchase")]
	public bool newProductIdsFormat; //Field offset: 0x60
	[Header("Package Info")]
	public int gameId; //Field offset: 0x64
	public string schemeUrl; //Field offset: 0x68
	public string productName; //Field offset: 0x70
	public string companyName; //Field offset: 0x78
	public string version; //Field offset: 0x80
	public int bundleVersionCode; //Field offset: 0x88
	public string androidIdentifier; //Field offset: 0x90
	public string iosIdentifier; //Field offset: 0x98
	public string huaweiStoreId; //Field offset: 0xA0

	public GameSettings() { }

}

