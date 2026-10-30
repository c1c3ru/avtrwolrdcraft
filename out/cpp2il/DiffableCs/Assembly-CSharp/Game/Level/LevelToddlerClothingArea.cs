namespace Game.Level;

public class LevelToddlerClothingArea : LevelAvatarClothingAreaBase
{
	[SerializeField]
	private ToddlerClothingType[] _clothingTypes; //Field offset: 0x78

	public LevelToddlerClothingArea() { }

	protected virtual void Awake() { }

}

