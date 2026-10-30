namespace Game.Level.ContextualAnimation;

public class LevelCAStarsBoulevardCharacterHandler : LevelCAHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x80

	public LevelCAStarsBoulevardCharacterHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

}

