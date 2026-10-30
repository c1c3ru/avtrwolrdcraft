namespace PWC.Level;

public class LevelSpawner : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	private readonly List<LevelSpawn> _instances; //Field offset: 0x20
	[CompilerGenerated]
	private Action<LevelSpawner, LevelSpawn> OnSpawnAction; //Field offset: 0x28
	[CompilerGenerated]
	private Action<LevelSpawner, LevelSpawn> OnSpawnRemovedAction; //Field offset: 0x30

	public event Action<LevelSpawner, LevelSpawn> OnSpawnAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<LevelSpawner, LevelSpawn> OnSpawnRemovedAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public IReadOnlyList<LevelSpawn> Instances
	{
		 get { } //Length: 8
	}

	public LevelSpawner() { }

	[CompilerGenerated]
	public void add_OnSpawnAction(Action<LevelSpawner, LevelSpawn> value) { }

	[CompilerGenerated]
	public void add_OnSpawnRemovedAction(Action<LevelSpawner, LevelSpawn> value) { }

	public IReadOnlyList<LevelSpawn> get_Instances() { }

	public int GetInstancesCount() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	[CompilerGenerated]
	public void remove_OnSpawnAction(Action<LevelSpawner, LevelSpawn> value) { }

	[CompilerGenerated]
	public void remove_OnSpawnRemovedAction(Action<LevelSpawner, LevelSpawn> value) { }

	public void RemoveSpawn(LevelSpawn levelSpawn) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public bool TryInstantiate(LevelSpawn prefab, Vector2 position, Transform parent, int maxInstances, bool useFifo, out LevelSpawn outInstance, bool forceCircleShapeOnVanish = false, Action<LevelSpawn> onFifo = null) { }

}

