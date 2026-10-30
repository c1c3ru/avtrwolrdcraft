namespace PWC.Level;

public class LevelCooker : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerClickHandler, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass19_0
	{
		public LevelCookableItemHandler cookable; //Field offset: 0x10

		public <>c__DisplayClass19_0() { }

		internal void <CookItem>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass20_0
	{
		public string sceneGUID; //Field offset: 0x10

		public <>c__DisplayClass20_0() { }

		internal bool <StopCookItem>b__0(LevelCookerItemData item) { }

	}

	[SerializeField]
	private bool _isOn; //Field offset: 0x20
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x28
	[SerializeField]
	private GameObject _onState; //Field offset: 0x30
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x38
	[SerializeField]
	private string _soundName; //Field offset: 0x40
	[SerializeField]
	private float _volume; //Field offset: 0x48
	[SerializeField]
	protected UnityEvent _onCookEvent; //Field offset: 0x50
	[SerializeField]
	protected UnityEvent _onStopCookEvent; //Field offset: 0x58
	private readonly List<LevelCookerItemData> _itemsData; //Field offset: 0x60

	public LevelCooker() { }

	private void Awake() { }

	private void CookItem(LevelItem levelItem) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnItemEndDrop(LevelItem levelItem) { }

	private void OnItemPickUp(LevelItem levelItem) { }

	private void OnLevelPostInit() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void OnPointerDown(PointerEventData eventData) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void StopCookItem(LevelItem levelItem) { }

	private void SyncCookingState() { }

	private void SyncOnState() { }

	private void SyncSound() { }

}

