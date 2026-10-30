namespace Game.Level.ContextualAnimation;

public class LevelCAToggleGameObjectEventItemHandler : LevelCAItemHandlerWithData
{
	[SerializeField]
	private LevelToggleableGameObject _toggleableGameObjact; //Field offset: 0x90

	public LevelCAToggleGameObjectEventItemHandler() { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

