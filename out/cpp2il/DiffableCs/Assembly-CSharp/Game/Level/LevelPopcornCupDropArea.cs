namespace Game.Level;

public class LevelPopcornCupDropArea : LevelSingleItemFoodOnlyDropArea
{

	public LevelPopcornCupDropArea() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

	public virtual Vector2 GetProperPositionToDropOnFromPosition(Vector2 fromPosition, LevelItem levelItem) { }

}

