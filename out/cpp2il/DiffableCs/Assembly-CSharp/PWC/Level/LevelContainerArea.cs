namespace PWC.Level;

public class LevelContainerArea : LevelDropArea
{

	public LevelContainerArea() { }

	public virtual Vector2 GetProperPositionToDropOnFromPosition(Vector2 fromPosition, LevelItem levelItem) { }

	public virtual bool HasSpecialItemPosition() { }

	public virtual bool ShouldAllowOverlappingItems() { }

}

