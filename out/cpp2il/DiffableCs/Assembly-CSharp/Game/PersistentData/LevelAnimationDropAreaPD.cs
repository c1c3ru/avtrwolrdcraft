namespace Game.PersistentData;

public class LevelAnimationDropAreaPD
{
	internal class LevelItemData
	{
		public string sceneGuid; //Field offset: 0x10
		public string animationName; //Field offset: 0x18

		public LevelItemData() { }

	}

	public List<LevelItemData> dataList; //Field offset: 0x10

	public LevelAnimationDropAreaPD() { }

}

