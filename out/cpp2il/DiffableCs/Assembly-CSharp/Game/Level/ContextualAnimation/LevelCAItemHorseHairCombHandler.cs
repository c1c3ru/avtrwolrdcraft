namespace Game.Level.ContextualAnimation;

public class LevelCAItemHorseHairCombHandler : LevelCAItemHandlerBase
{
	[SerializeField]
	private LevelReactionOfAvatarsOnCAAnimationHandler _radiusEventHandler; //Field offset: 0x88
	private LevelHorse _refHorse; //Field offset: 0x90
	private string _currentExtraData; //Field offset: 0x98
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0

	public LevelCAItemHorseHairCombHandler() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public void OnAvatarSetHair(ILevelAvatar avatar) { }

	protected virtual void OnDestroy() { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

}

