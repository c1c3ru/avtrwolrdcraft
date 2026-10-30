namespace Game.Level.ContextualAnimation;

public class LevelCADartItemHandler : LevelCAItemHandlerBase
{
	private LevelDartsDropAreaHandler _dropAreaHandler; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90
	private Random _random; //Field offset: 0x98

	public LevelCADartItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsRelevantForTarget(ICATarget target) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

