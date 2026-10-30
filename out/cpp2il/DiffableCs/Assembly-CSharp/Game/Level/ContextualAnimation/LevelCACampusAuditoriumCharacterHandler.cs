namespace Game.Level.ContextualAnimation;

public class LevelCACampusAuditoriumCharacterHandler : LevelCAHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x80

	public LevelCACampusAuditoriumCharacterHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

