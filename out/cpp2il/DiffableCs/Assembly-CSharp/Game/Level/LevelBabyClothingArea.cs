namespace Game.Level;

public class LevelBabyClothingArea : LevelAvatarClothingAreaBase
{
	[SerializeField]
	private BabyClothingType[] _clothingTypes; //Field offset: 0x78

	public LevelBabyClothingArea() { }

	protected virtual void Awake() { }

}

