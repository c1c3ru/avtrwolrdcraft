namespace Game.Level.ContextualAnimation;

public class LevelCAPinataStickItemHandler : LevelCAItemHandlerBase
{
	[SerializeField]
	private LevelDragActionItemHandlerBase _levelDragActionItemHandler; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90

	public LevelCAPinataStickItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

}

