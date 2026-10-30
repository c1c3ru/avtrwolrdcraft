namespace Game.Level;

[AddComponentMenu(null)]
public class LevelWashingMachineInsideDropArea : LevelDropArea
{

	public LevelWashingMachineInsideDropArea() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

	public virtual bool ShouldAllowOverlappingItems() { }

}

