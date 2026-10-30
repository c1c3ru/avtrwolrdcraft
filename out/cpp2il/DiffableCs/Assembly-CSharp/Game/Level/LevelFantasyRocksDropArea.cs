namespace Game.Level;

public class LevelFantasyRocksDropArea : LevelSingleItemDropArea
{

	public LevelFantasyRocksDropArea() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

	public virtual void OnItemBeginDrop(LevelItem levelItem) { }

	public virtual void OnItemPickUp(LevelItem levelItem) { }

	protected virtual void OnLevelPostInit() { }

}

