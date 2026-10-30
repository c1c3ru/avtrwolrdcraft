namespace Game.Level.ContextualAnimation;

public class LevelCAKeytarItemHandler : LevelCAMusicalInstrumentItemHandlerBase
{
	protected readonly List<LevelCAConfig> _configs; //Field offset: 0xD8

	public LevelCAKeytarItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	protected virtual string GetBoneName() { }

	public virtual string GetFolderName() { }

	protected virtual string GetSkinName() { }

}

