namespace PWC.PersistentData;

public class LevelItemPD
{
	public string parent; //Field offset: 0x10
	public Vector2 position; //Field offset: 0x18
	public bool isMoving; //Field offset: 0x20
	public ItemOnAvatarType itemOnAvatarType; //Field offset: 0x24
	public ItemOnAvatarType itemOnCharacterType; //Field offset: 0x28
	public bool isFlipped; //Field offset: 0x2C

	public LevelItemPD() { }

}

