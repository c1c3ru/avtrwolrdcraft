namespace PWC.Level;

public class LevelToggleableAudio : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject, ISoundHubTarget, ILevelMakerDisabledWhileInEditMode
{
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x20
	[SerializeField]
	protected bool _isOn; //Field offset: 0x28
	[SerializeField]
	private Sprite _onSprite; //Field offset: 0x30
	[SerializeField]
	private Sprite _offSprite; //Field offset: 0x38
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x40
	[SerializeField]
	protected string _soundName; //Field offset: 0x48
	[SerializeField]
	protected bool _isLoop; //Field offset: 0x50
	[Range(0.1, 1)]
	[SerializeField]
	private float _volume; //Field offset: 0x54
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x58
	[SerializeField]
	private string _onSoundName; //Field offset: 0x60
	[SerializeField]
	private string _offSoundName; //Field offset: 0x68
	[SerializeField]
	private bool _notLitWhileOn; //Field offset: 0x70
	[SerializeField]
	private GameObject[] _onObjects; //Field offset: 0x78
	[SerializeField]
	private GameObject[] _offObjects; //Field offset: 0x80
	private int _tweenID; //Field offset: 0x88
	private bool _hasPersistentData; //Field offset: 0x8C
	public UnityEvent OnActiveEvent; //Field offset: 0x90
	public UnityEvent OnInactiveEvent; //Field offset: 0x98

	public bool IsOn
	{
		 get { } //Length: 8
	}

	public LevelToggleableAudio() { }

	[CompilerGenerated]
	private void <PlaySound>b__35_0() { }

	private void Awake() { }

	public bool get_IsOn() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void OnLevelPreInit() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	protected override void PlaySound(string soundName) { }

	private override void PWC.ISoundHubTarget.PerformRemoteClick() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetSoundName(string soundName) { }

	public void SetSoundName(LevelMusicRecord record) { }

	protected override void SetSprite(Sprite sprite) { }

	public void SetState(bool isOn, bool silent = false) { }

	public void SetState(bool isOn) { }

	public void StopSound() { }

	private void SyncGameObjects() { }

	private void SyncLight() { }

	private void SyncParticleSystem() { }

	protected void SyncSound() { }

	private void SyncSprite() { }

	public override void ToggleState() { }

}

