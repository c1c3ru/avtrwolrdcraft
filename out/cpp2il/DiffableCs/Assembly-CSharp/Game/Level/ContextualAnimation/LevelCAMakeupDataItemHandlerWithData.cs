namespace Game.Level.ContextualAnimation;

public class LevelCAMakeupDataItemHandlerWithData : LevelCAItemHandlerWithData
{
	[SerializeField]
	protected LevelMakeupDataItemHandler[] _makeupDataItemHandlers; //Field offset: 0x90
	[SerializeField]
	protected LevelMakeupDragItemHandler[] _makeupDragItemHandlers; //Field offset: 0x98
	[SerializeField]
	protected LevelMakeupRemoverItemHandler _levelMakeupRemoverItemHandler; //Field offset: 0xA0
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0xA8

	public LevelCAMakeupDataItemHandlerWithData() { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

