namespace Game.Level.ContextualAnimation;

public class LevelCAConeItemHandler : LevelCAItemHandlerBase
{
	public LevelEnsurePickupItemHandler Cone; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90

	public LevelCAConeItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual bool ShouldPlayPreAnimation(LevelCAConfig config) { }

}

