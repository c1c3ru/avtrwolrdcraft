namespace Game.Level;

public class LevelPaddleArea : LevelSingleCenteredItemDropArea
{

	public LevelPaddleArea() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

	public virtual void ReleaseItems(Predicate<LevelItem> predicate = null) { }

}

