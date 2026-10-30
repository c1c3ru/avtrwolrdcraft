namespace PWC.Level;

[AddComponentMenu(null)]
public class LevelBoxItem : LevelItem
{
	[SerializeField]
	protected bool _isOpen; //Field offset: 0x342
	[SerializeField]
	private Sprite _openedSprite; //Field offset: 0x348
	[SerializeField]
	private Sprite _closedSprite; //Field offset: 0x350
	[SerializeField]
	private LevelContainerArea _containerArea; //Field offset: 0x358
	[SerializeField]
	private LevelDropArea _topDropArea; //Field offset: 0x360
	[SerializeField]
	private GameObject _front; //Field offset: 0x368
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x370
	[SerializeField]
	private string _openedSound; //Field offset: 0x378
	[SerializeField]
	private string _closedSound; //Field offset: 0x380
	[SerializeField]
	private UnityEvent _onOpen; //Field offset: 0x388
	[SerializeField]
	private UnityEvent _onClose; //Field offset: 0x390

	public LevelBoxItem() { }

	protected virtual void Awake() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnLevelPostInit() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	private void PlaySound() { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetState(bool value) { }

	protected override void SyncState() { }

}

