namespace Game.Level;

[AddComponentMenu(null)]
public class LevelBucketDropArea : LevelSingleItemDropArea
{

	public LevelBucketDropArea() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

}

