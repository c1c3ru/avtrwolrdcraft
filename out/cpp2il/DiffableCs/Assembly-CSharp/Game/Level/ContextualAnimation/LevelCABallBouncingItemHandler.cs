namespace Game.Level.ContextualAnimation;

public class LevelCABallBouncingItemHandler : LevelCAItemOnBoneHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCABallBouncingItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	protected virtual string GetBoneName() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

}

