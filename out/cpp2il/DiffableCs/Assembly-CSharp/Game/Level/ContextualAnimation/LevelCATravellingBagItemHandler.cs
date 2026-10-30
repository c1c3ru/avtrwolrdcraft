namespace Game.Level.ContextualAnimation;

public class LevelCATravellingBagItemHandler : LevelCAItemHandlerWithData
{
	[SerializeField]
	private LevelDoor _levelDoor; //Field offset: 0x90
	[SerializeField]
	private Sprite _thumbSprite; //Field offset: 0x98

	public LevelCATravellingBagItemHandler() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

