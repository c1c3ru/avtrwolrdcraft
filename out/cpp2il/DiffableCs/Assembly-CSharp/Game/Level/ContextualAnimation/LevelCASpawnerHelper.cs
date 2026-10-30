namespace Game.Level.ContextualAnimation;

public class LevelCASpawnerHelper : MonoBehaviour
{
	private struct SpawnedItem
	{
		[FormerlySerializedAs("PrefabRef")]
		public PDPrefabReference prefabRef; //Field offset: 0x0
		[FormerlySerializedAs("CAIndex")]
		public int caIndex; //Field offset: 0x8
		[FormerlySerializedAs("SpawnPosition")]
		public SpawnPositionType spawnPositionType; //Field offset: 0xC
		[ConditionalField("spawnPositionType", SpawnPositionType::Point (3), True, (array) null)]
		[FormerlySerializedAs("LocalSpawnPoint")]
		public Transform spawnPoint; //Field offset: 0x10
		[ConditionalField("spawnPositionType", SpawnPositionType::Point (3), True, (array) null)]
		public Transform parent; //Field offset: 0x18
		public bool isPoofEffect; //Field offset: 0x20
		public SpawnEventType spawnEventType; //Field offset: 0x24
		[ConditionalField("spawnEventType", SpawnEventType::Event (2), True, (array) null)]
		public string eventName; //Field offset: 0x28

	}

	private enum SpawnEventType
	{
		Begin = 0,
		End = 1,
		Event = 2,
	}

	private enum SpawnPositionType
	{
		None = 0,
		LeftHand = 1,
		RightHand = 2,
		Point = 3,
	}

	[SerializeField]
	private LevelCAHandlerBase _caHandler; //Field offset: 0x20
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x28
	[SerializeField]
	private int _maxInstances; //Field offset: 0x30
	[SerializeField]
	private bool _useFifo; //Field offset: 0x34
	[SerializeField]
	private List<SpawnedItem> _spawnedItems; //Field offset: 0x38
	private readonly List<LevelItem> _spawnedLevelItems; //Field offset: 0x40

	public LevelCASpawnerHelper() { }

	private void Awake() { }

	private void CallSpawnDuringGameplay(LevelSpawn spawn) { }

	private void CollectLevelItems(LevelSpawn spawn) { }

	private Vector2 GetHandPosition(ICATarget target, AvatarHandType handType) { }

	private AvatarHandType GetHandType(SpawnedItem spawnedItem) { }

	private void MoveLevelItemsToSpawnPosition(Vector2 position) { }

	private void OnAnimationBegin(LevelCAHandlerBase caHandlerBase, ICATarget target, LevelCAConfig config) { }

	private void OnAnimationEnd(LevelCAHandlerBase caHandlerBase, ICATarget target, LevelCAConfig config) { }

	private void OnAnimationEvent(LevelCAHandlerBase caHandlerBase, ICATarget target, TrackEntry entry, Event spineEvent) { }

	private void OnDestroy() { }

	private void PlayPoofEffect(LevelSpawn spawn) { }

	private void PutInHand(SpawnedItem spawnedItem, ICATarget target) { }

	private void SpawnItemsForEvent(SpawnEventType eventType, ICATarget target, LevelCAConfig config, string eventName = null) { }

	private bool TryGetSpawnPosition(SpawnedItem spawnedItem, ICATarget target, out Vector2 position, out Transform parent) { }

	private void TrySpawnItem(SpawnedItem spawnedItem, ICATarget target) { }

}

