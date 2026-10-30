namespace Game.Level;

public class LevelAirHockeyScoreBoard : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject, IArcadePlayable
{
	[SerializeField]
	private TextMesh _leftScoreText; //Field offset: 0x20
	[SerializeField]
	private TextMesh _rightScoreText; //Field offset: 0x28
	[SerializeField]
	private LevelAirHockeyGoal _leftGoal; //Field offset: 0x30
	[SerializeField]
	private LevelAirHockeyGoal _rightGoal; //Field offset: 0x38
	[SerializeField]
	private LevelSpawner _levelSpawner; //Field offset: 0x40
	[SerializeField]
	private LevelSpawn _levelSpawn; //Field offset: 0x48
	[SerializeField]
	private LevelHockeyDropArea _dropArea; //Field offset: 0x50
	[SerializeField]
	private Transform[] _spawnPoints; //Field offset: 0x58
	private int _leftScore; //Field offset: 0x60
	private int _rightScore; //Field offset: 0x64

	public LevelAirHockeyScoreBoard() { }

	[CompilerGenerated]
	private void <OnScore>b__13_0() { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void IncrementScore(ref int score, TextMesh scoreText) { }

	private void OnDestroy() { }

	private void OnScore(LevelHockeyPuckItemHandler itemHandler, LevelAirHockeyGoal goal) { }

	public override void Play() { }

	private void PlaySound() { }

	public void ResetScore() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SetScore(ref int score, int value, TextMesh scoreText) { }

	private void SyncScoreText(int score, TextMesh scoreText) { }

}

