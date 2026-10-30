namespace Game.Level.ContextualAnimation;

public abstract class LevelCAHalloweenCustomSpineSkinHandler : LevelCASpineSkinHandlerBase
{
	private const float SCARE_RADIUS = 4; //Field offset: 0x0
	private const float SCARE_CIRCLE_X_OFFSET = 4; //Field offset: 0x0
	private static readonly String[] SCARED_ANIMATIONS_NAMES; //Field offset: 0x0
	private LevelCharacter _currentCharacter; //Field offset: 0x98

	private static LevelCAHalloweenCustomSpineSkinHandler() { }

	protected LevelCAHalloweenCustomSpineSkinHandler() { }

	private List<LevelCharacter> GetAllCharactersInCircle() { }

	private Vector3 GetCircleCenter() { }

	public virtual string GetFolderName() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	private void ScareOtherAvatars() { }

	private void ScareOtherNonAvatarsEntities() { }

	private void StartScareAnimation(LevelCharacter character) { }

}

