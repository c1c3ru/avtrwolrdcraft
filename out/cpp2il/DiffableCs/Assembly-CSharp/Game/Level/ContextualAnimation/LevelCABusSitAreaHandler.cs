namespace Game.Level.ContextualAnimation;

public class LevelCABusSitAreaHandler : LevelCADefaultSitAreaHandler
{
	[SerializeField]
	private UnityEvent _onItemSpawnAction; //Field offset: 0x90
	private LevelSitArea _sitArea; //Field offset: 0x98
	private readonly List<LevelCAConfig> _newConfigs; //Field offset: 0xA0
	private readonly String[] _findItemsNames; //Field offset: 0xA8

	public LevelCABusSitAreaHandler() { }

	protected virtual void Awake() { }

	public virtual bool CanTargetHoldItems() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	protected virtual void OnTargetClick(DragDropItemBase dragDropItem, PointerEventData eventData) { }

	protected virtual bool ShouldRegisterToEventSystemTargetEvents() { }

}

