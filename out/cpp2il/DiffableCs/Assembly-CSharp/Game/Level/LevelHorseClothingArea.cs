namespace Game.Level;

public class LevelHorseClothingArea : LevelAvatarClothingAreaBase
{
	[SerializeField]
	private HorseClothingType[] _clothingTypes; //Field offset: 0x78

	public LevelHorseClothingArea() { }

	protected virtual void Awake() { }

}

