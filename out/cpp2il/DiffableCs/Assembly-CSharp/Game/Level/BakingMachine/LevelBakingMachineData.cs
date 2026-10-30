namespace Game.Level.BakingMachine;

[CreateAssetMenu(menuName = "AvatarWorld/Level/Baking Machine Data")]
public class LevelBakingMachineData : ScriptableObject
{
	internal class Item
	{
		public TopType topType; //Field offset: 0x10
		public BaseType baseType; //Field offset: 0x14
		public PDPrefabReference prefabReference; //Field offset: 0x18

		public Item() { }

	}

	public List<Item> items; //Field offset: 0x18

	public LevelBakingMachineData() { }

}

