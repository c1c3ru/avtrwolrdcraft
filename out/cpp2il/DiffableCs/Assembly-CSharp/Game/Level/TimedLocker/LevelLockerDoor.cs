namespace Game.Level.TimedLocker;

public class LevelLockerDoor : LevelDoor
{
	[SerializeField]
	private LevelTimedLocker _levelLocker; //Field offset: 0x90

	public LevelLockerDoor() { }

	public void CloseDoorAfterPickUp() { }

	public virtual void OnPointerClick(PointerEventData eventData) { }

	public virtual void ToggleState(bool silent = false) { }

}

