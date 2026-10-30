namespace Game.Level.ContextualAnimation;

public class LevelCARingRemovalOnlySpineSkinHandler : LevelCASpineSkinHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCARingRemovalOnlySpineSkinHandler() { }

	public virtual bool AllowReturnToIdleAnimationWhenRemovedFromTarget() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual int GetPriority() { }

	public virtual bool IsSilent() { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	private void TakeOfRing(LevelCharacter character) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

