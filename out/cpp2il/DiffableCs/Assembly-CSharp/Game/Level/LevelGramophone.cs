namespace Game.Level;

[AddComponentMenu(null)]
public class LevelGramophone : LevelSimpleConsumerItemBase, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x348
	[SerializeField]
	private GameObject _needle; //Field offset: 0x350
	[SerializeField]
	private SpriteRenderer _recordOnPlayer; //Field offset: 0x358
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x360
	private bool _isOn; //Field offset: 0x368
	private int _recordTweenId; //Field offset: 0x36C
	private int _needleTweenId; //Field offset: 0x370
	private LevelMusicRecord _currentRecord; //Field offset: 0x378
	private Vector2 _recordOnPlayerStartPosition; //Field offset: 0x380
	private Vector2 _needleStartPosition; //Field offset: 0x388

	public LevelGramophone() { }

	[CompilerGenerated]
	private bool <PutRecord>b__15_0(GameObject receiver, PointerEventData eventData) { }

	[CompilerGenerated]
	private bool <PutRecord>b__15_1(GameObject receiver, PointerEventData eventData) { }

	protected virtual void Awake() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	public void PutRecord(LevelMusicRecord record, bool forceTurnOn = true) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetState(bool isOn) { }

	private void SyncState() { }

	private void ToggleMusic() { }

}

