namespace PWC.Level.Maker;

public abstract class LevelMakerCreateItemButtonBase : GameUIElement, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private GameObject _notAvailableCover; //Field offset: 0x28
	protected string _prefabGuid; //Field offset: 0x30
	private Transform _makerItemInstanceHolder; //Field offset: 0x38
	private LevelMakerItemsMenu _menu; //Field offset: 0x40
	private Vector2 _size; //Field offset: 0x48
	private StoreTweenToolipHandle _maxItemsReachedTooltipHandle; //Field offset: 0x50
	private float _lastClickTime; //Field offset: 0x58

	protected LevelMakerCreateItemButtonBase() { }

	private void Awake() { }

	protected abstract bool DidReachMaxLevelMakerItems() { }

	public Vector2 GetSize() { }

	public void Init(LevelMakerItemsMenu menu, string prefabGuid, Vector2 size) { }

	protected abstract bool IsItemUnavaliable() { }

	private void OnDestroy() { }

	private void OnDestroyItemButtonClick(ILevelMakerDeletableByUIItem levelMakerItem) { }

	private void OnPrefabRuntimeSpawn(PDPrefab pdPrefab, bool _) { }

	private void OnSaveAsPresetButtonClick(LevelMakerCustomizationObjectHandlerBase handler, HashSet<String> connectedPrefabGuids = null) { }

	public void PlayScaleTween() { }

	protected void SyncAvailableCount() { }

	private void SyncAvailableCountText() { }

	private void SyncIsItemUnavaliable() { }

	protected override bool TrySetIsItemUnavaliable(GameObject prefab) { }

	protected abstract void TrySpawnInternal() { }

	private bool TryUseBulkData(ref GameObject instance) { }

	private override void UnityEngine.EventSystems.IPointerClickHandler.OnPointerClick(PointerEventData eventData) { }

}

