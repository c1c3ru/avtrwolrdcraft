namespace PWC.Level;

[DisallowMultipleComponent]
public class LevelPoopable : MonoBehaviour
{
	[SerializeField]
	private LevelSpawn _poopPrefab; //Field offset: 0x20
	[SerializeField]
	private Transform _poopSpawnPoint; //Field offset: 0x28
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x30

	public LevelPoopable() { }

	public bool TryPoop() { }

}

