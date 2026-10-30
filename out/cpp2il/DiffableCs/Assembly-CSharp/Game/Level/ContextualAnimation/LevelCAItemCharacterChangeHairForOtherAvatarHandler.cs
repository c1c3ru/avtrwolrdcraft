namespace Game.Level.ContextualAnimation;

public class LevelCAItemCharacterChangeHairForOtherAvatarHandler : LevelCAItemCharacterChangeHairHandler
{
	[SerializeField]
	private LevelReactionOfAvatarsOnCAAnimationHandler _reactionEventHandler; //Field offset: 0xB8

	public LevelCAItemCharacterChangeHairForOtherAvatarHandler() { }

	protected virtual void Awake() { }

	protected virtual void OnDestroy() { }

}

