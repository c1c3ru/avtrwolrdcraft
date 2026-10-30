namespace PWC.Level.Maker;

public class LevelMakerCeilingItem : LevelMakerItem
{
	[SerializeField]
	protected Transform _ceilingPoint; //Field offset: 0x188
	private Nullable<Single> _ceilingYOffset; //Field offset: 0x190

	public LevelMakerCeilingItem() { }

	protected virtual void Awake() { }

	private void CheckIfOverlapCeilingItem() { }

	private bool FixPositionIfNeeded(ref Vector2 position) { }

	public Vector2 GetCeilingPositionFotXPosition(float forXPosition) { }

	public Transform GetCeilingSortingParentForXPosition() { }

	public float GetCeilingYOffset() { }

	protected virtual int GetDefaultSortingOrder() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	protected virtual void OnDestroy() { }

	public virtual void OnDrag(PointerEventData eventData) { }

	protected virtual void OnEndDragInternal(PointerEventData eventData) { }

	private void OnItemRotated(LevelMakerRotatingItemHandlerBase nextItem) { }

	protected virtual void OnReadyPostLoad() { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SnapToCeilingPosition() { }

	private void UpdateSortingGroup() { }

}

