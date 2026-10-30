namespace Game.Level.ContextualAnimation;

public class LevelCAMonsterClothingSpineSkinHandler : LevelCAHalloweenCustomSpineSkinHandler
{
	public static readonly Dictionary<String, String> SKINS_TO_INDEXES; //Field offset: 0x0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0

	private static LevelCAMonsterClothingSpineSkinHandler() { }

	public LevelCAMonsterClothingSpineSkinHandler() { }

	public virtual bool AllowReturnToIdleAnimationWhenRemovedFromTarget() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

