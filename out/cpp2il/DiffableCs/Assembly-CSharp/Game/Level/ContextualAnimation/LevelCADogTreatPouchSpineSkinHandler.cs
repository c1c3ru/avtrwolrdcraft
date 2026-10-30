namespace Game.Level.ContextualAnimation;

public class LevelCADogTreatPouchSpineSkinHandler : LevelCASpineSkinHandlerBase
{
	private const string REACTIONS_DATA_PATH = "Level/AnimationsReactions/Dog/DogTreatPouchAnimationsReactionsData"; //Field offset: 0x0
	private LevelReactionOfAvatarsOnCAAnimationHandler _radiusEventHandler; //Field offset: 0x98
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0
	private LevelItem _spawnedTreat; //Field offset: 0xA8

	public LevelCADogTreatPouchSpineSkinHandler() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

}

