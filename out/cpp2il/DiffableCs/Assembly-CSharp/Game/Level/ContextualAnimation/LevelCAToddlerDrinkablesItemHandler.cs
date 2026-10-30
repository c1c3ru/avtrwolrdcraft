namespace Game.Level.ContextualAnimation;

public class LevelCAToddlerDrinkablesItemHandler : LevelCAItemHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88
	private LevelToddler _toddler; //Field offset: 0x90

	public LevelCAToddlerDrinkablesItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetAnimationSuffix() { }

	public virtual string GetFolderName() { }

	public virtual int GetPriority() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

}

