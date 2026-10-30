namespace PWC.Level;

[AddComponentMenu(null)]
public class LevelBagItem : LevelItem
{
	[SerializeField]
	private bool _isOpen; //Field offset: 0x342
	[SerializeField]
	private Sprite _openedSprite; //Field offset: 0x348
	[SerializeField]
	private Sprite _closedSprite; //Field offset: 0x350
	[SerializeField]
	private LevelContainerArea _containerArea; //Field offset: 0x358
	[SerializeField]
	private GameObject _front; //Field offset: 0x360
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x368
	[SerializeField]
	private string _openSoundName; //Field offset: 0x370
	[SerializeField]
	private string _closeSoundName; //Field offset: 0x378

	public LevelBagItem() { }

	protected virtual void Awake() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SyncState() { }

}

