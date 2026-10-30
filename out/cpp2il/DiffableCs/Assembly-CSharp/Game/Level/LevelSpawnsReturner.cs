namespace Game.Level;

public class LevelSpawnsReturner : MonoBehaviour
{
	[SerializeField]
	private LevelSpawner[] _Spawners; //Field offset: 0x20

	public LevelSpawnsReturner() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void OnSpawnRemoved(LevelSpawner arg1, LevelSpawn arg2) { }

}

