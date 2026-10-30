namespace Game.Level.ContextualAnimation;

public class LevelCABabyGymDropAreaHandler : LevelCADropAreaHandlerBase
{
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x80
	[SerializeField]
	[SpineAnimation(null, "_skeletonAnimation", True, False, False)]
	private string _animationName; //Field offset: 0x88
	[SerializeField]
	private GameSoundPlayer _gameSoundPlayer; //Field offset: 0x90
	[SerializeField]
	private string _soundName; //Field offset: 0x98
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0

	public LevelCABabyGymDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

}

