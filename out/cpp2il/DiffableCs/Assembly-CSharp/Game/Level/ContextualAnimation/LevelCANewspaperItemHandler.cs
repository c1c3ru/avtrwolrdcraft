namespace Game.Level.ContextualAnimation;

public class LevelCANewspaperItemHandler : LevelCAItemHandlerBase
{
	[SerializeField]
	private Transform _openNewspaperTransform; //Field offset: 0x88
	[SerializeField]
	private Transform _closeNewspaperTransform; //Field offset: 0x90
	[SerializeField]
	private LevelDoor _door; //Field offset: 0x98
	private Vector2 _noAnimationOpenPosition; //Field offset: 0xA0
	private readonly Vector2 _animationOpenPosition; //Field offset: 0xA8
	private Vector2 _releseClosedPosition; //Field offset: 0xB0
	private Vector2 _inHandClosedPosition; //Field offset: 0xB8
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xC0

	public LevelCANewspaperItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

}

