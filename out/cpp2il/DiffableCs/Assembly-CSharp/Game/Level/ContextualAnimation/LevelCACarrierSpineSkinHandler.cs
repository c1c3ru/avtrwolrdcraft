namespace Game.Level.ContextualAnimation;

public class LevelCACarrierSpineSkinHandler : LevelCASpineSkinHandlerBase, ICarrierNotifiable
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98
	private ILevelAvatar _heldBabyOrToddler; //Field offset: 0xA0

	public LevelCACarrierSpineSkinHandler() { }

	public virtual bool AllowReturnToIdleAnimationWhenRemovedFromTarget() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual int GetPriority() { }

	public virtual bool IsSilent() { }

	public override void NotifyAvatarAdded(ILevelAvatar babyOrToddler) { }

	public override void NotifyAvatarRemoved() { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	protected void TakeOffClothing(ICATarget avatar) { }

}

