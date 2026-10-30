namespace Game.Level;

public class LevelSoccerScoreBoard : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private TextMesh _leftScoreText; //Field offset: 0x20
	[SerializeField]
	private TextMesh _rightScoreText; //Field offset: 0x28
	[SerializeField]
	private LevelSSGoal _leftGoal; //Field offset: 0x30
	[SerializeField]
	private LevelSSGoal _rightGoal; //Field offset: 0x38
	private int _leftScore; //Field offset: 0x40
	private int _rightScore; //Field offset: 0x44

	public LevelSoccerScoreBoard() { }

	[CompilerGenerated]
	private void <OnScore>b__8_0() { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void IncrementScore(ref int score, TextMesh scoreText) { }

	private void OnDestroy() { }

	private void OnScore(LevelSSSoccerballItemHandler itemHandler, LevelSSGoal goal) { }

	private void PlaySound() { }

	public void ResetScore() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SetScore(ref int score, int value, TextMesh scoreText) { }

	private void SyncScoreText(int score, TextMesh scoreText) { }

}

