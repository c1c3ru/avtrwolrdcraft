namespace PWC.ScavengerHunt;

public class ScavengerHuntTypeState
{
	internal class SpawnState
	{
		public int spawnerId; //Field offset: 0x10
		public string prefabGuid; //Field offset: 0x18
		public bool didSpawn; //Field offset: 0x20
		public bool didUserInteractWithItem; //Field offset: 0x21

		public SpawnState() { }

	}

	private static readonly Random _random; //Field offset: 0x0
	public bool isGameRunning; //Field offset: 0x10
	public string gameGuid; //Field offset: 0x18
	public int gameNumber; //Field offset: 0x20
	public int timeLeft; //Field offset: 0x24
	public bool useTimeLimit; //Field offset: 0x28
	public List<SpawnState> spawnStates; //Field offset: 0x30
	private Dictionary<Int32, SpawnState> _hashedSpawnState; //Field offset: 0x38

	private static ScavengerHuntTypeState() { }

	public ScavengerHuntTypeState() { }

	public void ResetCurrentGame() { }

	public bool StartNewGame(int newGameNumber, int timeLimit, String[] itemsPrefabGuids, int spawnersCount, List<SceneData> sceneDataList) { }

	public bool TryGetSpawnState(int spawnerId, out SpawnState spawnState) { }

}

