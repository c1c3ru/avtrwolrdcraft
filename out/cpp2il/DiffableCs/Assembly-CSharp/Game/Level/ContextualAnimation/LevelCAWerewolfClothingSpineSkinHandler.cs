namespace Game.Level.ContextualAnimation;

public class LevelCAWerewolfClothingSpineSkinHandler : LevelCAHalloweenCustomSpineSkinHandler
{
	[SerializeField]
	private Sprite _thumb; //Field offset: 0xA0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA8

	public LevelCAWerewolfClothingSpineSkinHandler() { }

	public virtual bool AllowReturnToIdleAnimationWhenRemovedFromTarget() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

