namespace PWC.Level;

public class LevelLineRendererOnDragItemHandler : MonoBehaviour
{
	[SerializeField]
	private LineRenderer _lineRenderer; //Field offset: 0x20
	private LevelItem _levelItem; //Field offset: 0x28

	public LevelLineRendererOnDragItemHandler() { }

	private void Awake() { }

	private void OnBeginDrag(DragDropItemBase item, PointerEventData eventData) { }

	private void OnDestroy() { }

	private void OnEndDrag(DragDropItemBase item, PointerEventData eventData) { }

}

