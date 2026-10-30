namespace PWC.Level;

public class LevelZoomInItemHandler : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private LevelItem _levelItem; //Field offset: 0x20
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x28
	[SerializeField]
	private SpriteRenderer _zoomedInSprite; //Field offset: 0x30
	[SerializeField]
	private GameSoundPlayer _gameSoundPlayer; //Field offset: 0x38
	[SerializeField]
	private string _openSound; //Field offset: 0x40
	[SerializeField]
	private string _closeSound; //Field offset: 0x48
	[SerializeField]
	public UnityEvent onZoomIn; //Field offset: 0x50
	[SerializeField]
	public UnityEvent onZoomOut; //Field offset: 0x58
	private bool _isZoomedIn; //Field offset: 0x60

	public LevelZoomInItemHandler() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnGameCameraPointerDown() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private void Start() { }

	private void ZoomIn() { }

}

