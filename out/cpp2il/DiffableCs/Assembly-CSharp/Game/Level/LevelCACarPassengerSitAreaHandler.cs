namespace Game.Level;

public class LevelCACarPassengerSitAreaHandler : LevelCADropAreaHandlerWithData
{
	[SerializeField]
	private LevelPlayerVehicle _playerVehicle; //Field offset: 0x98

	public LevelCACarPassengerSitAreaHandler() { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

