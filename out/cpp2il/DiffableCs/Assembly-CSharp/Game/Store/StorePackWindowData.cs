namespace Game.Store;

public class StorePackWindowData
{
	internal class Icon
	{
		public string artName; //Field offset: 0x10
		public int amount; //Field offset: 0x18
		public string name; //Field offset: 0x20

		public Icon() { }

	}

	public string key; //Field offset: 0x10
	public string title; //Field offset: 0x18
	public string titleBackgroundArtName; //Field offset: 0x20
	public List<Icon> icons; //Field offset: 0x28

	public StorePackWindowData() { }

}

