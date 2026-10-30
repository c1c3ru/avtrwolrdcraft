namespace PWC.Level;

public class LevelSpineAnimationOnDragItemHandler : MonoBehaviour
{
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x20
	[SerializeField]
	[SpineAnimation(null, null, True, False, False, dataField = "_skeletonAnimation")]
	private string _idleAnimation; //Field offset: 0x28
	[SerializeField]
	[SpineAnimation(null, null, True, False, False, dataField = "_skeletonAnimation")]
	private string _dragAnimation; //Field offset: 0x30
	private LevelItem _levelItem; //Field offset: 0x38

	public LevelSpineAnimationOnDragItemHandler() { }

	private void Awake() { }

	private void OnBeginDrag(DragDropItemBase item, PointerEventData eventData) { }

	private void OnDestroy() { }

	private void OnEndDrag(DragDropItemBase item, PointerEventData eventData) { }

}

