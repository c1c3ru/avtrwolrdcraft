namespace PWC.Level;

public class LevelSpawn : MonoBehaviour
{
	private LevelSpawner _spawner; //Field offset: 0x20

	public LevelSpawn() { }

	public LevelSpawner GetSpawner() { }

	private void OnDestroy() { }

	public void SetSpawner(LevelSpawner spawner) { }

	public static bool TryGetSpawn(PDPrefabReference pdPrefabReference, out LevelSpawn levelSpawn) { }

}

