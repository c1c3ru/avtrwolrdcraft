namespace PWC.Level;

public class LevelBagItemHandler : LevelBag
{
	[SerializeField]
	private Sprite _hangSprite; //Field offset: 0x90
	protected LevelItem _levelItem; //Field offset: 0x98
	private LevelHangHandler _hangHandler; //Field offset: 0xA0

	public LevelBagItemHandler() { }

	protected virtual void Awake() { }

	private void OnBeginDrag(DragDropItemBase _, PointerEventData __) { }

	private void OnDestroy() { }

	private void OnHang(LevelHangArea area) { }

	public virtual void OnPointerClick(PointerEventData eventData) { }

	protected virtual void SetSprite(Sprite sprite) { }

}

