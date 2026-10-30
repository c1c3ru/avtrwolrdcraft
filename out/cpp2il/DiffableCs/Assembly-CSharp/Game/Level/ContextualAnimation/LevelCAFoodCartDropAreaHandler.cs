namespace Game.Level.ContextualAnimation;

public class LevelCAFoodCartDropAreaHandler : LevelCADropAreaHandlerBase
{
	[SerializeField]
	private LevelSlider _slider; //Field offset: 0x80
	private LevelCharacter _currentCharacter; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90

	public LevelCAFoodCartDropAreaHandler() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	protected virtual void OnDestroy() { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	private void StopSyncCharacterWithCart(DragDropItemBase dragDrop, PointerEventData eventData) { }

	private void SyncCharacterWithCart(DragDropItemBase dragDrop, PointerEventData eventData) { }

}

