namespace Game.Level.ContextualAnimation;

public class LevelCASuspiciousGlassesClothingSpineSkinHandler : LevelCASpineSkinHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCASuspiciousGlassesClothingSpineSkinHandler() { }

	public virtual bool AllowReturnToIdleAnimationWhenRemovedFromTarget() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

