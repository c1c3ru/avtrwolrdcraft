namespace PWC.Level;

public class LevelBag : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	protected SpriteRenderer _spriteRenderer; //Field offset: 0x20
	[SerializeField]
	protected bool _isOpen; //Field offset: 0x28
	[SerializeField]
	protected Sprite _openedSprite; //Field offset: 0x30
	[SerializeField]
	protected Sprite _closedSprite; //Field offset: 0x38
	[FormerlySerializedAs("_containerArea")]
	[SerializeField]
	protected LevelDropArea _containerArea; //Field offset: 0x40
	[SerializeField]
	protected GameObject _front; //Field offset: 0x48
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x50
	[SerializeField]
	private string _openSoundName; //Field offset: 0x58
	[SerializeField]
	private string _closeSoundName; //Field offset: 0x60
	[SerializeField]
	private bool _allowLivingBeings; //Field offset: 0x68
	[SerializeField]
	private List<GameObject> _openGameObjects; //Field offset: 0x70
	[SerializeField]
	private List<GameObject> _closedGameObjects; //Field offset: 0x78
	[SerializeField]
	private UnityEvent _openState; //Field offset: 0x80
	[SerializeField]
	private UnityEvent _closeState; //Field offset: 0x88

	public LevelBag() { }

	protected override void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	protected override void SetSprite(Sprite sprite) { }

	protected void SyncState() { }

}

