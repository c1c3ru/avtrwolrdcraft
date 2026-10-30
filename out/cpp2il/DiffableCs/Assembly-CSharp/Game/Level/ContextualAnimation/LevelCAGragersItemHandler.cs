namespace Game.Level.ContextualAnimation;

public class LevelCAGragersItemHandler : LevelCAItemHandlerBase
{
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x88
	private LevelCharacter _currentCharacter; //Field offset: 0x90
	private LevelToddler _closestToddler; //Field offset: 0x98
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0

	public LevelCAGragersItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	private void LevelCAGragersItemHandler_Complete(TrackEntry trackEntry) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	private bool TryGetClosestToddler() { }

}

