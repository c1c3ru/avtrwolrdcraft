namespace Game.Level.ContextualAnimation;

public class LevelCAPutOnMakeupFromTransformableItemHandlerWithData : LevelCAItemHandlerWithData
{
	[SerializeField]
	private LevelTransformableItemHandler _transformableItemHandler; //Field offset: 0x90

	public LevelCAPutOnMakeupFromTransformableItemHandlerWithData() { }

	private void AddMakeupItem(LevelCharacter character, PDPrefab instance) { }

	protected virtual void Awake() { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

