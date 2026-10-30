namespace Game.Level.ContextualAnimation;

public class LevelCAShovelSmallToddlerItemHandler : LevelCAItemHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88

	public LevelCAShovelSmallToddlerItemHandler() { }

	private void EnsureSitting(ICATarget target, bool returnToIdle = true) { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

}

