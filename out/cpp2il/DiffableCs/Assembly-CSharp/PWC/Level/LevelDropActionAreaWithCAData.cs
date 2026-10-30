namespace PWC.Level;

public class LevelDropActionAreaWithCAData : LevelDropActionArea
{
	[SerializeField]
	private LevelCAHandlerBase _caHandler; //Field offset: 0x78
	[SerializeField]
	private DragDropItemBase _ownerItem; //Field offset: 0x80
	private List<ICATarget> _targets; //Field offset: 0x88

	public LevelDropActionAreaWithCAData() { }

	protected virtual void Awake() { }

	public void OnBeginDrag(DragDropItemBase dragDropItem, PointerEventData eventData) { }

	protected virtual void OnDestroy() { }

	protected virtual void OnItemEndLand(LevelItem levelItem) { }

	private void OnItemPostDetachFromParentIfExistsCall(LevelItem levelItem) { }

}

