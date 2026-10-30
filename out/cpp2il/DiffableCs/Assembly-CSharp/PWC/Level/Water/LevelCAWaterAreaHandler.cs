namespace PWC.Level.Water;

public class LevelCAWaterAreaHandler : LevelCADropAreaHandlerBase
{
	[SerializeField]
	private float _minHightOnBackOffset; //Field offset: 0x80
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88

	public LevelCAWaterAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	protected virtual bool IsAllowedInWaterArea() { }

	public virtual bool IsSingleCAInMenu() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	protected virtual void OnTargetClick(DragDropItemBase dragDropItem, PointerEventData eventData) { }

	protected virtual bool ShouldRegisterToEventSystemTargetEvents() { }

}

