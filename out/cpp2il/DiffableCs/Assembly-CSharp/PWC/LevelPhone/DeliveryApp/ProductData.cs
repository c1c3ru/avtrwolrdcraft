namespace PWC.LevelPhone.DeliveryApp;

public class ProductData
{
	public PDPrefabReference pdPrefabReference; //Field offset: 0x10
	public List<Int32> categoryIndex; //Field offset: 0x18
	public bool useFullPrefab; //Field offset: 0x20
	[ConditionalField("useFullPrefab", False, True, (array) null)]
	public Sprite spriteOverride; //Field offset: 0x28

	public string PrefabGuid
	{
		 get { } //Length: 28
	}

	public ProductData() { }

	public string get_PrefabGuid() { }

}

