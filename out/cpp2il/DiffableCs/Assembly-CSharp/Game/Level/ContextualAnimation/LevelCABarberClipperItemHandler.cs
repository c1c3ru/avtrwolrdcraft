namespace Game.Level.ContextualAnimation;

public class LevelCABarberClipperItemHandler : LevelCAItemHandlerBase
{
	private const string WIPING_OFF_SWEAT_ANIMATION_NAME = "Wiping_Off_Sweat_Clipper"; //Field offset: 0x0
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90

	public LevelCABarberClipperItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

}

