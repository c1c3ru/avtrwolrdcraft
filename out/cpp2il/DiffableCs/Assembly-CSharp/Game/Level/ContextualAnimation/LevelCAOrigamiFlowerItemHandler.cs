namespace Game.Level.ContextualAnimation;

public class LevelCAOrigamiFlowerItemHandler : LevelCAOrigamiItemHandler
{
	protected readonly LevelCAConfig _config; //Field offset: 0x90

	public LevelCAOrigamiFlowerItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

}

