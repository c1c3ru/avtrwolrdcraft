namespace PWC.Level;

[DisallowMultipleComponent]
public class LevelColorChangingLight : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerClickHandler, IHasPersistentData, IRequirePDSceneObject
{
	private enum ParticleSystemActivationType
	{
		None = 0,
		On = 1,
		Off = 2,
		Toggle = 3,
	}

	[SerializeField]
	private bool _isOn; //Field offset: 0x20
	[SerializeField]
	private GameObject[] _lightOnObjects; //Field offset: 0x28
	[SerializeField]
	private GameObject[] _lightOffObjects; //Field offset: 0x30
	[SerializeField]
	private CShape _cShape; //Field offset: 0x38
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x40
	[SerializeField]
	private Sprite _onSprite; //Field offset: 0x48
	[SerializeField]
	private Sprite _offSprite; //Field offset: 0x50
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x58
	[SerializeField]
	private string _onSoundName; //Field offset: 0x60
	[SerializeField]
	private string _offSoundName; //Field offset: 0x68
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x70
	[SerializeField]
	private ParticleSystemActivationType _particleSystemActivationType; //Field offset: 0x78
	[SerializeField]
	private PWSpriteColorType _colorType; //Field offset: 0x7C
	[SerializeField]
	private SpriteRenderer[] _lights; //Field offset: 0x80
	[SerializeField]
	private Color[] _colors; //Field offset: 0x88
	[SerializeField]
	private List<IndexEvent> _indexEvents; //Field offset: 0x90
	[SerializeField]
	public UnityEvent OnClickEvents; //Field offset: 0x98
	private readonly Color WHITE_COLOR; //Field offset: 0xA0
	private Color _currentColor; //Field offset: 0xB0
	private int _colorIndex; //Field offset: 0xC0
	private bool _hasInitData; //Field offset: 0xC4
	private LightSource[] _lightSources; //Field offset: 0xC8
	private LitSpriteRenderer _litSpriteRenderer; //Field offset: 0xD0

	public LevelColorChangingLight() { }

	private void Awake() { }

	public int GetColorIndex() { }

	public Color[] GetColors() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void OnPointerDown(PointerEventData eventData) { }

	private void PlaySound() { }

	public void RemoteClick() { }

	public void SetColor() { }

	public void SetColorIndex(int colorIndex) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetState(bool isOn) { }

	public void SetStateSilent(bool isOn) { }

	private void Start() { }

	private void SyncState() { }

}

