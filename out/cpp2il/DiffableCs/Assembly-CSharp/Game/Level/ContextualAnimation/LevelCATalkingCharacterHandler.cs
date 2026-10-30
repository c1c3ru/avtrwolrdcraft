namespace Game.Level.ContextualAnimation;

public class LevelCATalkingCharacterHandler : LevelCAHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x80

	public LevelCATalkingCharacterHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	protected virtual bool IsAllowedInWaterArea() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

}

