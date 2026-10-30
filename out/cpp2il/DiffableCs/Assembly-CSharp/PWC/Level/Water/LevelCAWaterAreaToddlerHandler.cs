namespace PWC.Level.Water;

public class LevelCAWaterAreaToddlerHandler : LevelCADropAreaHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x80

	public LevelCAWaterAreaToddlerHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual SpineType GetSpineType() { }

	protected virtual bool IsAllowedInWaterArea() { }

	public virtual bool IsSingleCAInMenu() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	protected virtual void OnTargetClick(DragDropItemBase dragDropItem, PointerEventData eventData) { }

	protected virtual bool ShouldRegisterToEventSystemTargetEvents() { }

}

