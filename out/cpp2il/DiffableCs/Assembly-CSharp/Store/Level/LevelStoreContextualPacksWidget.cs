namespace Store.Level;

public class LevelStoreContextualPacksWidget : LevelStoreContextualPacksBase, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private Image _image; //Field offset: 0x38
	[SerializeField]
	private GameObject _content; //Field offset: 0x40
	[SerializeField]
	private GameObject _bundleTitle; //Field offset: 0x48
	[SerializeField]
	private PromotionPopUpTitleLocalization _promotionPopUpTitleLocalization; //Field offset: 0x50
	private MonoBehaviour _monoBahaviorForTimers; //Field offset: 0x58

	public LevelStoreContextualPacksWidget() { }

	protected virtual void Awake() { }

	private void Init() { }

	private void OnEnable() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	protected virtual bool ShouldSpawnClaimedPrefabInCurrentScene(PDPrefab prefab) { }

	private void ShowWidget(Item item) { }

	private void SyncWithCloudAndInit() { }

	protected virtual void TryOverrideOnClaimItemSuccess(StoreClaimItemCloudResponse response, ref bool didOverride) { }

	private bool TryPrepareBundleTitle(out AFCLocalizedTextMeshPro localizedText) { }

}

