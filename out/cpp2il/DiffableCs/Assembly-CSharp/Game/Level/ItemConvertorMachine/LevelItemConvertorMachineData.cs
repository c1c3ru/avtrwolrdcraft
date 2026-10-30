namespace Game.Level.ItemConvertorMachine;

[CreateAssetMenu(menuName = "AvatarWorld/Level/Item Convertor Machine Data")]
public class LevelItemConvertorMachineData : ScriptableObject
{
	internal class Item
	{
		public PDPrefabReference input; //Field offset: 0x10
		public PDPrefabReference output; //Field offset: 0x18

		public Item() { }

	}

	public List<Item> items; //Field offset: 0x18

	public LevelItemConvertorMachineData() { }

}

