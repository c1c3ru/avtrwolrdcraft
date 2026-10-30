namespace PWC.Level;

public class LevelReleaseItemsOnBeginDragDropAreaHandler : MonoBehaviour
{
	private LevelItem _levelItem; //Field offset: 0x20
	private LevelDropArea _dropArea; //Field offset: 0x28
	private HashSet<LevelItem> _droppingItems; //Field offset: 0x30

	public LevelReleaseItemsOnBeginDragDropAreaHandler() { }

	private void Awake() { }

	private void OnBeginDrag(DragDropItemBase _, PointerEventData __) { }

	private void OnDestroy() { }

	private void OnItemBeginDrop(LevelItem item) { }

	private void OnItemEndDrop(LevelItem item) { }

}

