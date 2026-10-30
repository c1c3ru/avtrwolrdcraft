namespace Game.Level;

public class LevelHayContainerHandler : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private PDPrefabReference _hayStackPrefab; //Field offset: 0x20
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x28
	[SerializeField]
	private Transform _spawnPoint; //Field offset: 0x30
	[SerializeField]
	private string _spawnSoundName; //Field offset: 0x38
	[SerializeField]
	private string _fillSoundName; //Field offset: 0x40
	[SerializeField]
	private int _maxNumberOfHayStacks; //Field offset: 0x48
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x50
	[SerializeField]
	private Sprite[] _containerFilledState; //Field offset: 0x58
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x60
	[SerializeField]
	private CShape _shape; //Field offset: 0x68
	[SerializeField]
	private UnityEvent onFullEvent; //Field offset: 0x70
	[SerializeField]
	private UnityEvent onEmptyEvent; //Field offset: 0x78
	[SerializeField]
	private UnityEvent onHalfEvent; //Field offset: 0x80
	private int _currentNumberOfStacks; //Field offset: 0x88

	public LevelHayContainerHandler() { }

	private void Awake() { }

	[ContextMenu("Fill Stack")]
	public void FillStack() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private LevelSpawn GetPrefabToSpawn() { }

	private void OnDestroy() { }

	private void OnItemEndDrop(LevelItem levelItem) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private void OnPostInit() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void UpdateHayAction() { }

	private void UpdateStackSprite() { }

}

