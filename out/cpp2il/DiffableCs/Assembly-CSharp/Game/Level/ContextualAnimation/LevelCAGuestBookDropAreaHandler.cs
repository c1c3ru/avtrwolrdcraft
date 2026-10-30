namespace Game.Level.ContextualAnimation;

public class LevelCAGuestBookDropAreaHandler : LevelCADropAreaHandlerBase
{
	[SerializeField]
	private SkeletonAnimation _guestBook; //Field offset: 0x80
	private GameSoundPlayer _bookSoundPlayer; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90

	public LevelCAGuestBookDropAreaHandler() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

