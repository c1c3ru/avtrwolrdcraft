namespace PWC.Level;

public class LevelReleaseItemsChildrenDropAreaOnBeginDragHandler : MonoBehaviour
{
	[SerializeField]
	private bool _dropAvatars; //Field offset: 0x20
	[SerializeField]
	private bool _dropItems; //Field offset: 0x21
	private DragDropItemBase _item; //Field offset: 0x28

	public LevelReleaseItemsChildrenDropAreaOnBeginDragHandler() { }

	private void Awake() { }

	private void OnBeginDragHandler(DragDropItemBase _, PointerEventData __) { }

	private void OnDestroy() { }

	private void OnEndDragHandler(DragDropItemBase _, PointerEventData __) { }

}

