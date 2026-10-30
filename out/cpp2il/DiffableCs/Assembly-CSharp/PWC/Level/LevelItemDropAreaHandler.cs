namespace PWC.Level;

[DisallowMultipleComponent]
[RequireComponent(typeof(LevelItem))]
public class LevelItemDropAreaHandler : MonoBehaviour
{
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x20
	protected LevelItem _levelItem; //Field offset: 0x28
	protected readonly List<LevelItem> _itemsInsideDropArea; //Field offset: 0x30

	public LevelItemDropAreaHandler() { }

	private void Awake() { }

	protected override void OnBeginDrag(DragDropItemBase item, PointerEventData eventData) { }

	private void OnDestroy() { }

	protected override void OnEndLand(LevelDropArea dropArea) { }

	private void OnItemDropInsideMyDropArea(LevelItem levelItem) { }

	protected override void OnItemDropInsideMyDropAreaInternal(LevelItem levelItem) { }

	private void OnItemPickUpFromMyDropArea(LevelItem levelItem) { }

	protected override void OnItemPickUpFropMyDropAreaInternal(LevelItem levelItem) { }

	protected override void OnLevelPostInit() { }

}

