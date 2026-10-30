namespace PWC.Level;

public class LevelAvatarOneTimeSpawner : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass11_0
	{
		public PDPrefab pdPrefabInstance; //Field offset: 0x10

		public <>c__DisplayClass11_0() { }

		internal void <SpawnAvatar>b__0(PDPrefab spawn) { }

	}

	[CompilerGenerated]
	private struct <>c__DisplayClass12_0
	{
		public LevelAvatarOneTimeSpawner <>4__this; //Field offset: 0x0
		public int avatarId; //Field offset: 0x8

	}

	[SerializeField]
	private int _avatarId; //Field offset: 0x20
	[SerializeField]
	private Transform _spawnPoint; //Field offset: 0x28
	[SerializeField]
	private bool _playAnimation; //Field offset: 0x30
	[SerializeField]
	private bool _allowSpawnWhenAlreadyInGame; //Field offset: 0x31
	[SerializeField]
	private PDPrefabReference _prefabOverride; //Field offset: 0x38
	[SerializeField]
	private bool _isFlipped; //Field offset: 0x40
	private bool _didSpawn; //Field offset: 0x41
	private bool _isValid; //Field offset: 0x42

	public LevelAvatarOneTimeSpawner() { }

	[CompilerGenerated]
	private bool <OnLevelPrePostInit>b__10_0(ILevelAvatar x) { }

	[CompilerGenerated]
	private ILevelAvatar <PlaceAvatarInScene>g__Spawn|12_0(Vector2 position, ref <>c__DisplayClass12_0 unnamed_param_1) { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void HandleCAHandlers(ILevelAvatar avatar) { }

	private void OnDestroy() { }

	private void OnLevelPrePostInit() { }

	private ILevelAvatar PlaceAvatarInScene(Transform point, int avatarId) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private ILevelAvatar SpawnAvatar(int avatarId, Vector2 position, PDPrefabReference prefabOverride) { }

}

