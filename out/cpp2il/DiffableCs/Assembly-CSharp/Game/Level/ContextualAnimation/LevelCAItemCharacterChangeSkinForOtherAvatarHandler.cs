namespace Game.Level.ContextualAnimation;

public class LevelCAItemCharacterChangeSkinForOtherAvatarHandler : LevelCAItemCharacterChangeSkinHandler
{
	[SerializeField]
	private LevelReactionOfAvatarsOnCAAnimationHandler _reactionEventHandler; //Field offset: 0xE8

	public LevelCAItemCharacterChangeSkinForOtherAvatarHandler() { }

	protected virtual void Awake() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	protected virtual void OnDestroy() { }

	protected virtual bool ShouldApplyToCATarget() { }

}

