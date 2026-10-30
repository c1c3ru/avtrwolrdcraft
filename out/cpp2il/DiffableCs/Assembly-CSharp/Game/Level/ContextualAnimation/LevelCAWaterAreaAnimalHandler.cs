namespace Game.Level.ContextualAnimation;

public class LevelCAWaterAreaAnimalHandler : LevelCADropAreaHandlerBase
{
	private SpineType _currentType; //Field offset: 0x80
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88

	public LevelCAWaterAreaAnimalHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsSingleCAInMenu() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	protected virtual void OnTargetClick(DragDropItemBase dragDropItem, PointerEventData eventData) { }

	protected virtual bool ShouldRegisterToEventSystemTargetEvents() { }

	public virtual bool TryOverrideConfigThumb(int configIndex, out Sprite sprite) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

