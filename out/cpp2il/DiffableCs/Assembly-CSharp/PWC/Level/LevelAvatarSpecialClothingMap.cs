namespace PWC.Level;

[CreateAssetMenu(menuName = "PazuWorld/Level/Avatar Special Clothing Map")]
public class LevelAvatarSpecialClothingMap : ScriptableObject
{
	internal enum ClothingType
	{
		None = 0,
		Hoodie = 1,
		Sleeves_Shirt = 2,
		ZippersAndCollar = 3,
		Buttons = 4,
		GlassesUp = 5,
		Sleeves_Jacket = 6,
		Turn_Hat = 7,
		Tie_Jacket = 8,
		Carrier = 10,
		Helmet_Buckle = 11,
	}

	internal class Item
	{
		public ClothingType type; //Field offset: 0x10
		public string skin; //Field offset: 0x18

		public Item() { }

	}

	public List<Item> items; //Field offset: 0x18
	private Dictionary<String, Item> _dictionary; //Field offset: 0x20

	public LevelAvatarSpecialClothingMap() { }

	public bool TryGetData(string skinName, out Item dataItem) { }

}

