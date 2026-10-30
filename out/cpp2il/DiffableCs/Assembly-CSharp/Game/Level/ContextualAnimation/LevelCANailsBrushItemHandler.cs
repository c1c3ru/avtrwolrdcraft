namespace Game.Level.ContextualAnimation;

public class LevelCANailsBrushItemHandler : LevelCAItemHandlerBase
{
	private const float _minDelay = 2,75; //Field offset: 0x0
	[SerializeField]
	protected LevelNailBrushDragItemHandler _nailsBrushItemHandlerLeft; //Field offset: 0x88
	[SerializeField]
	protected LevelNailBrushDragItemHandler _nailsBrushItemHandlerRight; //Field offset: 0x90
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCANailsBrushItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

