namespace Game.Level;

public class LevelMusicRecordPlayerHandler : MusicRecordPlayerHandlerBase, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private GameObject _needle; //Field offset: 0x68
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x70
	[SerializeField]
	private string _onSound; //Field offset: 0x78
	[SerializeField]
	private string _offSound; //Field offset: 0x80
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x88
	[SerializeField]
	private Sprite _offState; //Field offset: 0x90
	[SerializeField]
	private Sprite _onState; //Field offset: 0x98
	public UnityEvent<LevelMusicRecord> OnRecordChanged; //Field offset: 0xA0
	public UnityEvent<Boolean> OnStateChanged; //Field offset: 0xA8
	private bool _isOn; //Field offset: 0xB0
	private int _recordTweenId; //Field offset: 0xB4
	private int _needleTweenId; //Field offset: 0xB8
	private Vector2 _recordOnPlayerStartPosition; //Field offset: 0xBC
	private Vector2 _needleStartPosition; //Field offset: 0xC4
	private SpriteRenderer _spriteRenderer; //Field offset: 0xD0

	public LevelMusicRecordPlayerHandler() { }

	protected virtual void Awake() { }

	public void DestroyRecord() { }

	public LevelItem GetCurrentRecordName() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public virtual void OnPointerClick(PointerEventData eventData) { }

	protected virtual bool OnPreBeginDrag(GameObject receiver, PointerEventData eventData) { }

	protected virtual bool OnPreClick(GameObject receiver, PointerEventData eventData) { }

	public virtual void PutRecord(LevelMusicRecord record, bool forceTurnOn = true) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetState(bool isOn) { }

	public void SwitchState() { }

	private void SyncState() { }

	private void ToggleMusic() { }

}

