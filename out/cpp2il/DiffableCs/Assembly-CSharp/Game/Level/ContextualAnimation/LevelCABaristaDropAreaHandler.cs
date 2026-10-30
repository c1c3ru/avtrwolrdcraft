namespace Game.Level.ContextualAnimation;

public class LevelCABaristaDropAreaHandler : LevelCADropAreaHandlerBase
{
	private const string FREAK_OUT_ANIMATION_NAME = "Makes_Coffee_Freaks_Out"; //Field offset: 0x0
	[SerializeField]
	private LevelBaristaMachine _baristaMachine; //Field offset: 0x80
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88

	public LevelCABaristaDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

}

