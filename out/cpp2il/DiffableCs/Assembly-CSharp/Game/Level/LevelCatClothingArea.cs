namespace Game.Level;

public class LevelCatClothingArea : LevelAvatarClothingAreaBase
{
	[SerializeField]
	private CatClothingType[] _clothingTypes; //Field offset: 0x78

	public LevelCatClothingArea() { }

	protected virtual void Awake() { }

}

