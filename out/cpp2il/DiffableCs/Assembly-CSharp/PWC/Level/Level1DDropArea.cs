namespace PWC.Level;

public class Level1DDropArea : LevelDropArea
{

	public Level1DDropArea() { }

	public virtual Vector2 GetProperPositionToDropOnFromPosition(Vector2 fromPosition, LevelItem levelItem) { }

	public virtual bool HasSpecialItemPosition() { }

}

