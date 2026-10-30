namespace Game.Level.BarbershopMachine;

public class LevelBarbershopMachineHairsData
{
	internal class Hair
	{
		public String[] skins; //Field offset: 0x10
		public string color; //Field offset: 0x18
		public string colorTop; //Field offset: 0x20
		public string colorBottom; //Field offset: 0x28
		public bool isPremium; //Field offset: 0x30

		public Hair() { }

	}

	public List<Hair> hairs; //Field offset: 0x10

	public LevelBarbershopMachineHairsData() { }

}

