namespace PWC.Level;

public class LevelFlatItemHandler : MonoBehaviour, ILevelSpawnDuringGameplay
{
	private LevelItem _levelItem; //Field offset: 0x20
	private SortingGroup _sortingGroup; //Field offset: 0x28

	public LevelFlatItemHandler() { }

	private void Awake() { }

	private void OnBeginDrag(DragDropItemBase dragDropItem, PointerEventData eventData) { }

	private void OnClick(DragDropItemBase dragDropItem, PointerEventData eventData) { }

	private void OnDestroy() { }

	private void OnEndLand(LevelDropArea dropArea) { }

	private void OnLevelPostInit() { }

	private void OnReadyPostLoad() { }

	private override void PWC.Level.ILevelSpawnDuringGameplay.OnSpawnDuringGameplay() { }

	private void SetFlatMode(bool isFlat) { }

}

