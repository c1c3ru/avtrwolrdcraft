//Type is in global namespace

public class LevelCAHatSpineSkinHandler : LevelCASpineSkinHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCAHatSpineSkinHandler() { }

	public virtual bool AllowReturnToIdleAnimationWhenRemovedFromTarget() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual int GetPriority() { }

	public virtual bool IsSilent() { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	private void TakeOffHat(LevelCharacter character) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

