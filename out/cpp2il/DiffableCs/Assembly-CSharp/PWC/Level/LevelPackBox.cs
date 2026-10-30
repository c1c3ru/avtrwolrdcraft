namespace PWC.Level;

public class LevelPackBox : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerClickHandler, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	protected bool _isOpen; //Field offset: 0x20
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x28
	[SerializeField]
	private LevelDropArea _topDropArea; //Field offset: 0x30
	[SerializeField]
	private GameObject _closed; //Field offset: 0x38
	[SerializeField]
	private GameObject _open; //Field offset: 0x40
	[SerializeField]
	private GameObject _front; //Field offset: 0x48
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x50
	[SerializeField]
	private string _openedSound; //Field offset: 0x58
	[SerializeField]
	private string _closedSound; //Field offset: 0x60
	[SerializeField]
	private GameObject[] _openedGameObjects; //Field offset: 0x68
	[SerializeField]
	private GameObject[] _closedGameObjects; //Field offset: 0x70
	[SerializeField]
	private bool _isJump; //Field offset: 0x78
	[SerializeField]
	private bool _allowLivingBeings; //Field offset: 0x79
	private bool _didLoadPersistentData; //Field offset: 0x7A

	public LevelPackBox() { }

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

	protected override void SyncState() { }

	public override void ToggleState(bool snap) { }

}

