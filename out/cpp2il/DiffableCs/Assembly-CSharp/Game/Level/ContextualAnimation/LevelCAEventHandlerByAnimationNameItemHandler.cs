namespace Game.Level.ContextualAnimation;

public class LevelCAEventHandlerByAnimationNameItemHandler : LevelCAItemHandlerWithData
{
	[SerializeField]
	private String[] _animationNames; //Field offset: 0x90
	[SerializeField]
	private UnityEvent[] _animationEventHandler; //Field offset: 0x98

	public LevelCAEventHandlerByAnimationNameItemHandler() { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

