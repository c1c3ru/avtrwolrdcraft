namespace Game.Level.ContextualAnimation;

public class LevelCASleepingNecklaceSpineSkinHandler : LevelCANecklaceSpineSkinHandler
{
	private bool isAddedBaseAnimations; //Field offset: 0xA0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA8

	public LevelCASleepingNecklaceSpineSkinHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

}

