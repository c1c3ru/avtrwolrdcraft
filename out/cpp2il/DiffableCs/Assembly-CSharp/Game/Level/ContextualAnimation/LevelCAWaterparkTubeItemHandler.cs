namespace Game.Level.ContextualAnimation;

public class LevelCAWaterparkTubeItemHandler : LevelCAItemHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88

	public LevelCAWaterparkTubeItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsSilent() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

}

