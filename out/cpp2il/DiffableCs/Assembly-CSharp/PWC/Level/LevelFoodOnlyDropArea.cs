namespace PWC.Level;

public class LevelFoodOnlyDropArea : LevelDropArea
{
	[SerializeField]
	private EaterType _eaterType; //Field offset: 0xD8

	public LevelFoodOnlyDropArea() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

}

