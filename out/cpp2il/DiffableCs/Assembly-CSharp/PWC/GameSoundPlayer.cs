namespace PWC;

public class GameSoundPlayer : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	public static readonly List<GameSoundPlayer> List; //Field offset: 0x0
	[SerializeField]
	protected bool _ignoreDistance; //Field offset: 0x20
	[SerializeField]
	private bool _ignorePD; //Field offset: 0x21
	[SerializeField]
	private float _distanceFactor; //Field offset: 0x24
	private AudioSource _audioSource; //Field offset: 0x28
	private float _screenWidth; //Field offset: 0x30
	private float _screenExtent; //Field offset: 0x34
	private bool _isPlaying; //Field offset: 0x38
	private bool _isLoop; //Field offset: 0x39
	private bool _isMuted; //Field offset: 0x3A
	private float _baseVolume; //Field offset: 0x3C

	private static GameSoundPlayer() { }

	public GameSoundPlayer() { }

	private void Awake() { }

	private void EnsureAudioSource() { }

	public AudioSource GetAudioSource() { }

	public float GetDistanceFactor() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	protected override float GetVolumeFactorForDistance(Vector2 cameraPosition, Vector2 soundSourcePosition) { }

	public bool IsPlaying() { }

	private void OnDestroy() { }

	protected override void OnDisable() { }

	protected override void OnEnable() { }

	private void OnGameCameraChangePosition(Vector2 cameraPosition) { }

	private void OnPersistentDataLoaded(Scene scene) { }

	protected override void OnPlay() { }

	protected override void OnStop() { }

	public float Play(string clipName, bool loop = false, float volume = 1) { }

	public void SetDistanceFactor(float distanceFactor) { }

	public void SetIgnorePD(bool value) { }

	public void SetMute(bool mute) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetPitch(float pitch) { }

	public void SetVolume(float volume) { }

	private void Start() { }

	public void Stop() { }

	public void SyncVolumeToCameraPosition(Vector2 cameraPosition) { }

}

