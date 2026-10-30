namespace Game.Level;

public class LevelCookingStickArea : LevelSingleItemDropArea
{
	[SerializeField]
	private Transform _parent; //Field offset: 0xD8
	[SerializeField]
	private LevelCookingStick _stick; //Field offset: 0xE0

	public LevelCookingStick Stick
	{
		 get { } //Length: 8
	}

	public LevelCookingStickArea() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

	public LevelCookingStick get_Stick() { }

	public virtual void OnItemBeginDrop(LevelItem levelItem) { }

}

