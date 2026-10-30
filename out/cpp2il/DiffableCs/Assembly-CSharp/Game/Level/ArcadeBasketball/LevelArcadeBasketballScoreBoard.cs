namespace Game.Level.ArcadeBasketball;

public class LevelArcadeBasketballScoreBoard : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private TextMesh _highScoreText; //Field offset: 0x20
	[SerializeField]
	private TextMesh _roundScoreText; //Field offset: 0x28
	[SerializeField]
	private LevelBSHoop _hoop; //Field offset: 0x30
	private int _highScore; //Field offset: 0x38
	private int _roundScore; //Field offset: 0x3C

	public LevelArcadeBasketballScoreBoard() { }

	[CompilerGenerated]
	private void <OnScore>b__7_0() { }

	private void Awake() { }

	public int GetHighScore() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void IncrementScore(ref int score, TextMesh scoreText) { }

	private void OnDestroy() { }

	private void OnScore(LevelBSBasketballItemHandler itemHandler, LevelBSHoop hoop) { }

	private void PlaySound() { }

	public void ResetCurrentScore() { }

	public void SetHighScore(int score) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SetScore(ref int score, int value, TextMesh scoreText) { }

	private void SyncScoreText(int score, TextMesh scoreText) { }

}

