namespace Game.Level;

public class LevelDigHoleArea : LevelDigArea, ILevelSpawnInRandomLocationTarget
{
	[SerializeField]
	private SpriteRenderer _plants; //Field offset: 0x58
	[SerializeField]
	private GameObject _hole; //Field offset: 0x60
	[SerializeField]
	private LevelContainerArea _containerArea; //Field offset: 0x68
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x70
	private List<LevelItem> _containerAreaLevelItems; //Field offset: 0x78
	private PDPrefab _prefab; //Field offset: 0x80
	private LevelSpawnerInRandomLocations _mySpawner; //Field offset: 0x88
	private LevelDigHolesManager _manager; //Field offset: 0x90
	private int _index; //Field offset: 0x98

	public LevelDigHoleArea() { }

	protected virtual void Awake() { }

	private void DetachContainerAreaChildrenIfNeeded() { }

	public override void Init(LevelSpawnerInRandomLocations spawner, int index) { }

	private void OnBeforeSceneLoadStage1() { }

	protected virtual void OnDestroy() { }

	private void OnGamePause() { }

	private void OnGameResume() { }

	protected virtual void OnSetPersistentData() { }

	public virtual void OnShovelDig() { }

	public override void SetInteracted() { }

	public void SetManager(LevelDigHolesManager manager) { }

	public void SetPrefab(PDPrefab prefab) { }

	private void SyncState() { }

}

