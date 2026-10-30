namespace Game.Level.ContextualAnimation;

public class LevelCAHalloweenVampireSpineSkinHandler : LevelCAHalloweenCustomSpineSkinHandler
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0

	public LevelCAHalloweenVampireSpineSkinHandler() { }

	public virtual bool AllowReturnToIdleAnimationWhenRemovedFromTarget() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	private void TakeOfBackItem(LevelCharacter character) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

