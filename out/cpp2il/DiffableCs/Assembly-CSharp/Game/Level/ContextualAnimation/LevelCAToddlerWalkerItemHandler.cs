namespace Game.Level.ContextualAnimation;

public class LevelCAToddlerWalkerItemHandler : LevelCAItemOnBoneHandlerBase
{
	private const string TRANSITION_ANIMATION_NAME = "Stand_Up_With_Cart"; //Field offset: 0x0
	private LevelToddler _toddler; //Field offset: 0x98
	private GameSoundPlayer _soundPlayer; //Field offset: 0xA0
	private readonly List<LevelCAConfig> _configsSitting; //Field offset: 0xA8
	private readonly List<LevelCAConfig> _configsStanding; //Field offset: 0xB0

	public LevelCAToddlerWalkerItemHandler() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	protected virtual string GetBoneName() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	protected virtual void OnTargetBeginDrag(DragDropItemBase dragDropItem, PointerEventData eventData) { }

	protected virtual void OnTargetEndDrag(DragDropItemBase dragDropItem, PointerEventData eventData) { }

	protected virtual bool ShouldRegisterToEventSystemTargetEvents() { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

