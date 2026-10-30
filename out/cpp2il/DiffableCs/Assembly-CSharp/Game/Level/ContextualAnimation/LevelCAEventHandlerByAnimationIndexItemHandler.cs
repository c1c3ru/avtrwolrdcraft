namespace Game.Level.ContextualAnimation;

public class LevelCAEventHandlerByAnimationIndexItemHandler : LevelCAItemHandlerWithData
{
	[SerializeField]
	private Int32[] _animationIndex; //Field offset: 0x90
	[SerializeField]
	private UnityEvent[] _animationEventHandler; //Field offset: 0x98
	[SerializeField]
	private string _eventName; //Field offset: 0xA0

	public LevelCAEventHandlerByAnimationIndexItemHandler() { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

