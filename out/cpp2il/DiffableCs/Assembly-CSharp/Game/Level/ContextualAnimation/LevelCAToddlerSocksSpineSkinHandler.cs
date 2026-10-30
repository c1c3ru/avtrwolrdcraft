namespace Game.Level.ContextualAnimation;

public class LevelCAToddlerSocksSpineSkinHandler : LevelCASpineSkinHandlerBase
{
	protected LevelToddler _toddler; //Field offset: 0x98
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0

	public LevelCAToddlerSocksSpineSkinHandler() { }

	public virtual bool AllowReturnToIdleAnimationWhenRemovedFromTarget() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual int GetPriority() { }

	public virtual bool IsSilent() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	private void TakeOffSocks(LevelToddler toddler) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

