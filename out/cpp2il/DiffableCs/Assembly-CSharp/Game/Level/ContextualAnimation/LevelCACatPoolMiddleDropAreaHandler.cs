namespace Game.Level.ContextualAnimation;

public class LevelCACatPoolMiddleDropAreaHandler : LevelCADropAreaHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x80

	public LevelCACatPoolMiddleDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

