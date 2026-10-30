namespace Game.Level.ContextualAnimation;

public class LevelCAHeartLocketClothingSpineSkinHandler : LevelCAPlayAnimationOnOthersClothingSpineSkinHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA8

	public LevelCAHeartLocketClothingSpineSkinHandler() { }

	public virtual bool AllowReturnToIdleAnimationWhenRemovedFromTarget() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	protected virtual void SetVariables() { }

}

