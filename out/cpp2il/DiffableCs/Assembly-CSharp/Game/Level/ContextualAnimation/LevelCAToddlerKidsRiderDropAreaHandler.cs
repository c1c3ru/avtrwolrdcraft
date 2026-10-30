namespace Game.Level.ContextualAnimation;

public class LevelCAToddlerKidsRiderDropAreaHandler : LevelCADropAreaHandlerBase, IArcadePlayable
{
	[SerializeField]
	private SkeletonAnimation _rider; //Field offset: 0x80
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x88
	[SerializeField]
	private string _soundName; //Field offset: 0x90
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCAToddlerKidsRiderDropAreaHandler() { }

	[CompilerGenerated]
	private void <Play>b__11_0(TrackEntry e) { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	public override void Play() { }

	private void TurnOff() { }

}

