namespace Game.Level;

[AddComponentMenu(null)]
public class LevelConeConsumerArea : LevelSingleItemDropArea
{

	public LevelConeConsumerArea() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

}

