namespace PWC.Level;

public class LevelSingleItemDropArea : LevelDropArea
{

	public LevelSingleItemDropArea() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

	public virtual Vector2 GetProperPositionToDropOnFromPosition(Vector2 fromPosition, LevelItem levelItem) { }

	public LevelItem GetSingleLevelItem() { }

	public virtual bool IsAvailableForItems() { }

	public virtual bool IsCentering() { }

}

