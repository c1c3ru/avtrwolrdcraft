namespace Game.Level.ContextualAnimation;

public class LevelCAPutOnMakeupItemHandlerWithData : LevelCAItemHandlerWithData
{
	[SerializeField]
	private LevelMakeupDropItemHandler _makeupHandler; //Field offset: 0x90

	public LevelCAPutOnMakeupItemHandlerWithData() { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

