namespace Game.Level;

[AddComponentMenu(null)]
public class LevelMusicRecordPlayer : LevelSimpleStationaryConsumerBase, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private Camera _camera; //Field offset: 0x60
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x68
	[SerializeField]
	private GameObject _needle; //Field offset: 0x70
	[SerializeField]
	private SpriteRenderer _recordOnPlayer; //Field offset: 0x78
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x80
	private bool _isOn; //Field offset: 0x88
	private int _recordTweenId; //Field offset: 0x8C
	private int _needleTweenId; //Field offset: 0x90
	private LevelMusicRecord _currentRecord; //Field offset: 0x98
	private Vector2 _recordOnPlayerStartPosition; //Field offset: 0xA0
	private Vector2 _needleStartPosition; //Field offset: 0xA8

	public LevelMusicRecordPlayer() { }

	[CompilerGenerated]
	private bool <PutRecord>b__16_0(GameObject receiver, PointerEventData eventData) { }

	[CompilerGenerated]
	private bool <PutRecord>b__16_1(GameObject receiver, PointerEventData eventData) { }

	protected virtual void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public void PutRecord(LevelMusicRecord record, bool forceTurnOn = true) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetState(bool isOn) { }

	private void SyncState() { }

	private void ToggleMusic() { }

}

