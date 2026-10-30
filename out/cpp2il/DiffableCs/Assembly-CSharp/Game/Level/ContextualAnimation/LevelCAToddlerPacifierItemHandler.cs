namespace Game.Level.ContextualAnimation;

public class LevelCAToddlerPacifierItemHandler : LevelCAItemHandlerBase
{
	[SerializeField]
	private LevelBabyPacifierHandler _pacifierHandler; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90
	private LevelToddler _toddler; //Field offset: 0x98

	public LevelCAToddlerPacifierItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetAnimationSuffix() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

}

