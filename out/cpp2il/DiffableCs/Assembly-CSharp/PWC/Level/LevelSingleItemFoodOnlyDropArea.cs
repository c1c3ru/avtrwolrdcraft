namespace PWC.Level;

public class LevelSingleItemFoodOnlyDropArea : LevelSingleItemDropArea
{
	[SerializeField]
	private EaterType _eaterType; //Field offset: 0xD8

	public LevelSingleItemFoodOnlyDropArea() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

}

