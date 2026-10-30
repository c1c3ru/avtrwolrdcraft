namespace Game.Level.ContextualAnimation;

public class LevelCATransformOptionsItemHandler : LevelCAItemHandlerWithData
{
	[SerializeField]
	private LevelTransformableWithOptionsItemHandler _transformableHandler; //Field offset: 0x90
	private int _index; //Field offset: 0x98

	public LevelCATransformOptionsItemHandler() { }

	public virtual bool AllowReturnToIdleAnimationWhenRemovedFromTarget() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

