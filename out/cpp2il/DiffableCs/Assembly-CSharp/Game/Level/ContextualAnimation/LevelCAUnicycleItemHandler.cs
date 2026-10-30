namespace Game.Level.ContextualAnimation;

public class LevelCAUnicycleItemHandler : LevelCAItemSpineNoSkinHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCAUnicycleItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

}

