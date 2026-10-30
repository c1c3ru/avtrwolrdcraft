namespace Game.Level.ContextualAnimation;

public class LevelCAPregnancyMaternityClothingSpineSkinHandler : LevelCASpineSkinHandlerBase
{
	private const string REACTIONS_DATA_PATH = "Level/AnimationsReactions/Character/CharacterPregnancyMaternityAnimationsReactionsData"; //Field offset: 0x0
	private LevelReactionOfAvatarsOnCAAnimationHandler _radiusEventHandler; //Field offset: 0x98
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0

	public LevelCAPregnancyMaternityClothingSpineSkinHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

}

