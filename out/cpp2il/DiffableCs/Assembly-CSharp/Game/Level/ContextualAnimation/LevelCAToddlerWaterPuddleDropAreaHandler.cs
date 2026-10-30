namespace Game.Level.ContextualAnimation;

public class LevelCAToddlerWaterPuddleDropAreaHandler : LevelCADropAreaHandlerBase
{
	private LevelToddler _toddler; //Field offset: 0x80
	private readonly List<LevelCAConfig> _configsSitting; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configsStanding; //Field offset: 0x90

	public LevelCAToddlerWaterPuddleDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

}

