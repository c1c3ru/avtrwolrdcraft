namespace PWC.Level;

public class LevelBox : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerClickHandler, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	protected SpriteRenderer _spriteRenderer; //Field offset: 0x20
	[SerializeField]
	protected bool _isOpen; //Field offset: 0x28
	[SerializeField]
	private Sprite _openedSprite; //Field offset: 0x30
	[SerializeField]
	private Sprite _closedSprite; //Field offset: 0x38
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x40
	[SerializeField]
	private LevelDropArea _topDropArea; //Field offset: 0x48
	[SerializeField]
	private GameObject _front; //Field offset: 0x50
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x58
	[SerializeField]
	private string _openedSound; //Field offset: 0x60
	[SerializeField]
	private string _closedSound; //Field offset: 0x68
	[SerializeField]
	private GameObject[] _openedGameObjects; //Field offset: 0x70
	[SerializeField]
	private GameObject[] _closedGameObjects; //Field offset: 0x78
	[SerializeField]
	private bool _isJump; //Field offset: 0x80
	[SerializeField]
	private bool _allowLivingBeings; //Field offset: 0x81
	private bool _didLoadPersistentData; //Field offset: 0x82
	public UnityEvent OnBoxOpenedAction; //Field offset: 0x88
	public UnityEvent OnBoxClosedAction; //Field offset: 0x90

	public LevelBox() { }

	protected override void Awake() { }

	public void Close(bool snap) { }

	public LevelDropArea GetDropArea() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	protected override void OnDestroy() { }

	private void OnLevelPostInit() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void OnPointerDown(PointerEventData eventData) { }

	public void Open(bool snap) { }

	private void PlaySound() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	protected override void SetSprite(Sprite sprite) { }

	protected override void SyncState() { }

	public override void ToggleState(bool snap) { }

}

