namespace Game.Level;

public class LevelCampfireDropArea : LevelDropArea
{
	[SerializeField]
	private LevelCampfireFireSpine _fireCampFire; //Field offset: 0xD8

	public LevelCampfireDropArea() { }

	public virtual void OnItemEndDrop(LevelItem levelItem) { }

	public virtual void OnItemPickUp(LevelItem levelItem) { }

	public virtual bool ShouldAllowOverlappingItems() { }

}

