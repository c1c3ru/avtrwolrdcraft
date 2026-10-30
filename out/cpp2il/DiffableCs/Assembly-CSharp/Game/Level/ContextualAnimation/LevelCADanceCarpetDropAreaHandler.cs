namespace Game.Level.ContextualAnimation;

public class LevelCADanceCarpetDropAreaHandler : LevelCADropAreaHandlerBase
{
	[SerializeField]
	private LevelDanceCarpet _danceCarpet; //Field offset: 0x80
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88

	public LevelCADanceCarpetDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

}

