namespace Game.Level;

public class LevelCACarDriverSitAreaHandler : LevelCADropAreaHandlerWithData
{
	[SerializeField]
	private LevelPlayerVehicle _playerVehicle; //Field offset: 0x98

	public LevelCACarDriverSitAreaHandler() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

