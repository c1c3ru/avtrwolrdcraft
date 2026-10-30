namespace Game.Level.ContextualAnimation;

public class LevelCACharacterCarrierSpineSkinHandler : LevelCASpecialClothingSpineSkinHandler, ICarrierNotifiable
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xB8
	private ILevelAvatar _heldBabyOrToddler; //Field offset: 0xC0

	public LevelCACharacterCarrierSpineSkinHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	protected virtual int GetSpecialCategoryType() { }

	protected virtual String[] GetSwitchableTextures() { }

	protected virtual string GetTextureSurffix() { }

	public override void NotifyAvatarAdded(ILevelAvatar babyOrToddler) { }

	public override void NotifyAvatarRemoved() { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	protected virtual void TakeOffClothing(ICATarget avatar) { }

}

