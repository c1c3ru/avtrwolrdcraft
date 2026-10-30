namespace Game.Level.ContextualAnimation;

public class LevelCAArcadeBoxingDropAreaHandler : LevelCADropAreaHandlerBase, IArcadePlayable
{
	[SerializeField]
	private SkeletonAnimation _boxing; //Field offset: 0x80
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x88
	[SerializeField]
	private LevelDropArea _levelDropArea; //Field offset: 0x90
	private String[] _animataions; //Field offset: 0x98
	private bool _isActive; //Field offset: 0xA0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA8

	public LevelCAArcadeBoxingDropAreaHandler() { }

	protected virtual void Awake() { }

	private void DisableMachine(TrackEntry trackEntry) { }

	private void EnableMachine(TrackEntry trackEntry) { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	public override void Play() { }

	private void PlayFoldedIdle(TrackEntry trackEntry) { }

}

