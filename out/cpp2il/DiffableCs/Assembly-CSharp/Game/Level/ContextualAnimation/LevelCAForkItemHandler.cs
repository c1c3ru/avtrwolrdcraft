namespace Game.Level.ContextualAnimation;

public class LevelCAForkItemHandler : LevelCAItemHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88

	public LevelCAForkItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

}

