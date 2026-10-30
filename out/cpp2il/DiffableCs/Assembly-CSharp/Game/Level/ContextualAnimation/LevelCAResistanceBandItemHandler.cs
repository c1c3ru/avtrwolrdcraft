namespace Game.Level.ContextualAnimation;

public class LevelCAResistanceBandItemHandler : LevelCAItemWithSkinHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xB0

	public LevelCAResistanceBandItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	protected virtual string GetSkinName() { }

	public virtual SpineType GetSpineType() { }

}

