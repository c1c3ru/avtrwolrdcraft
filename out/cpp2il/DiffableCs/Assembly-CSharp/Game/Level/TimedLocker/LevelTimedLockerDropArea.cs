namespace Game.Level.TimedLocker;

public class LevelTimedLockerDropArea : LevelSingleItemDropArea
{
	[SerializeField]
	private LevelLockerDoor _lockerDoor; //Field offset: 0xD8
	[SerializeField]
	private Transform _point; //Field offset: 0xE0

	public LevelTimedLockerDropArea() { }

	public virtual void OnItemPickUp(LevelItem levelItem) { }

}

