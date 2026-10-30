namespace Game.Level.ContextualAnimation;

public class LevelCAArmCastSpineSkinHandler : LevelCASpineSkinHandlerBase
{
	private const string REACTIONS_DATA_PATH = "Level/AnimationsReactions/Character/CharacterArmCastAnimationsReactionsData"; //Field offset: 0x0
	private LevelReactionOfAvatarsOnCAAnimationHandler _radiusEventHandler; //Field offset: 0x98
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0
	private List<Int32> _castNumbers; //Field offset: 0xA8

	public LevelCAArmCastSpineSkinHandler() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	public void OnReactionEnd(ILevelAvatar avatar) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	private void TakeOfCast(LevelCharacter character) { }

}

