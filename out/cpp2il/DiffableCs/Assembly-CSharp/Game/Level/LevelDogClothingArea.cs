namespace Game.Level;

public class LevelDogClothingArea : LevelAvatarClothingAreaBase
{
	[SerializeField]
	private DogClothingType[] _clothingTypes; //Field offset: 0x78

	public LevelDogClothingArea() { }

	protected virtual void Awake() { }

}

