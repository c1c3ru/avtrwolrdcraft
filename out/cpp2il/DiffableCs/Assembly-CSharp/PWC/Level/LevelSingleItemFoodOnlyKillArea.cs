namespace PWC.Level;

public class LevelSingleItemFoodOnlyKillArea : LevelKillArea
{
	[SerializeField]
	private EaterType _eaterType; //Field offset: 0x148

	public LevelSingleItemFoodOnlyKillArea() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

}

