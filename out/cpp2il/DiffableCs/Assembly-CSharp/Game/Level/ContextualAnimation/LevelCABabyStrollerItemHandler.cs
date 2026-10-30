namespace Game.Level.ContextualAnimation;

public class LevelCABabyStrollerItemHandler : LevelCAItemOnBoneHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98
	private LevelItemInCharacterBoneTransformOverride _boneTransformOverride; //Field offset: 0xA0
	private Vector2 _boneOverrideStartPosition; //Field offset: 0xA8

	public LevelCABabyStrollerItemHandler() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	protected virtual string GetBoneName() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	private void OnBeforePlacedOnCharacter(ILevelAvatar avatar, ItemOnAvatarType type) { }

	protected virtual void OnDestroy() { }

}

