namespace Game.Level.ContextualAnimation;

public class LevelCABlindfoldedClothingSpineSkinHandler : LevelCASpineSkinHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCABlindfoldedClothingSpineSkinHandler() { }

	public virtual bool AllowReturnToIdleAnimationWhenRemovedFromTarget() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

}

