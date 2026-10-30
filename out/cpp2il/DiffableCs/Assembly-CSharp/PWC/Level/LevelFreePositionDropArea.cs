namespace PWC.Level;

public class LevelFreePositionDropArea : LevelDropArea
{

	public LevelFreePositionDropArea() { }

	public virtual bool CanItemFallOnSelf(LevelItem levelItem) { }

	public virtual Vector2 GetProperPositionToDropOnFromPosition(Vector2 fromPosition, LevelItem levelItem) { }

	public virtual bool HasSpecialItemPosition() { }

}

