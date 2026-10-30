namespace Game.Level.ContextualAnimation;

public class LevelCAScarecrowClothingSpineSkinHandler : LevelCAHalloweenCustomSpineSkinHandler
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0

	public LevelCAScarecrowClothingSpineSkinHandler() { }

	public virtual bool AllowReturnToIdleAnimationWhenRemovedFromTarget() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

