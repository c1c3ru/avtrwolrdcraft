namespace Game.Level.ContextualAnimation;

public class LevelCAFabregeEggItemHandler : LevelCAItemSpineNoSkinHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCAFabregeEggItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

}

