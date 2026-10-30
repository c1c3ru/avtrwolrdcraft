namespace Game.Level;

public class LevelHiddenDoorPlatformDropArea : LevelSingleItemDropArea
{
	[SerializeField]
	private HiddenDoorPlushType _plushType; //Field offset: 0xD8

	public HiddenDoorPlushType PlushType
	{
		 get { } //Length: 8
	}

	public LevelHiddenDoorPlatformDropArea() { }

	public HiddenDoorPlushType get_PlushType() { }

}

