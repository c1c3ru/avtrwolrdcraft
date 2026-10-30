namespace Game.Level;

[AddComponentMenu(null)]
public class LevelDropAllowOverlappingItemsArea : LevelDropArea
{

	public LevelDropAllowOverlappingItemsArea() { }

	public virtual bool ShouldAllowOverlappingItems() { }

}

