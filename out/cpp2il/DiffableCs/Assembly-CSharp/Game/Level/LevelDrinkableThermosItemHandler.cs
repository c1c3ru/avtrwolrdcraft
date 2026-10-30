namespace Game.Level;

public class LevelDrinkableThermosItemHandler : LevelDrinkableItemHandler
{
	[SerializeField]
	private LevelFoldableItem _thermos; //Field offset: 0xB0

	public LevelDrinkableThermosItemHandler() { }

	public virtual bool CanBeDrinked() { }

}

