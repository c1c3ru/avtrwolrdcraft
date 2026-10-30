namespace Game.Level.ContextualAnimation;

public class LevelCAEconomySeatAirplaneDropAreaHandler : LevelCADropAreaHandlerBase
{
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x80
	[SerializeField]
	private LevelSitArea _sitArea; //Field offset: 0x88
	private bool _isUpright; //Field offset: 0x90
	private bool _isBeltOn; //Field offset: 0x91
	private readonly List<LevelCAConfig> _uprightConfigs; //Field offset: 0x98
	private readonly List<LevelCAConfig> _inclinedConfigs; //Field offset: 0xA0

	public LevelCAEconomySeatAirplaneDropAreaHandler() { }

	private void AddBelt(LevelCharacter character) { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual int GetPriority() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	private void OnAvatarPickUp(LevelAvatarRestAreaBase sitArea, ILevelAvatar avatar) { }

	protected virtual void OnDestroy() { }

	private void RemoveBelt(LevelCharacter character) { }

}

