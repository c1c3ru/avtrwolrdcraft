namespace Game.Level.ContextualAnimation;

public class LevelCABalletPianoSitAreaHandler : LevelCAPianoSitAreaHandler, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private PDPrefab _spawn; //Field offset: 0x90
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x98
	[SerializeField]
	private Transform _spawnPoint; //Field offset: 0xA0
	[SerializeField]
	private SkeletonAnimation _pianoSpine; //Field offset: 0xA8
	[SerializeField]
	[Space]
	private UnityEvent _onSpawnedEvent; //Field offset: 0xB0
	private bool _isSpawned; //Field offset: 0xB8

	public LevelCABalletPianoSitAreaHandler() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

