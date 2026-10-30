namespace Game.Level.ContextualAnimation;

public class LevelCAInkQuillItemHandler : LevelCAItemHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88

	public LevelCAInkQuillItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

}

