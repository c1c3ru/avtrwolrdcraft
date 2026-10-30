namespace Game.Level;

public class LevelBasketballScoreBoard : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private static Action<LevelBasketballScoreBoard> OnScoreUpdateAction; //Field offset: 0x0
	[SerializeField]
	private TextMesh _leftScoreText; //Field offset: 0x20
	[SerializeField]
	private TextMesh _rightScoreText; //Field offset: 0x28
	[SerializeField]
	private LevelBSHoop _leftHoop; //Field offset: 0x30
	[SerializeField]
	private LevelBSHoop _rightHoop; //Field offset: 0x38
	private int _leftScore; //Field offset: 0x40
	private int _rightScore; //Field offset: 0x44

	public static event Action<LevelBasketballScoreBoard> OnScoreUpdateAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public int LeftScore
	{
		 get { } //Length: 8
	}

	public int RightScore
	{
		 get { } //Length: 8
	}

	public LevelBasketballScoreBoard() { }

	[CompilerGenerated]
	private void <OnScore>b__17_0() { }

	[CompilerGenerated]
	public static void add_OnScoreUpdateAction(Action<LevelBasketballScoreBoard> value) { }

	private void Awake() { }

	public int get_LeftScore() { }

	public int get_RightScore() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void IncrementScore(ref int score, TextMesh scoreText) { }

	public void IncrementScoreLeft() { }

	public void IncrementScoreRight() { }

	private void OnDestroy() { }

	private void OnScore(LevelBSBasketballItemHandler itemHandler, LevelBSHoop hoop) { }

	private void PlaySound() { }

	[CompilerGenerated]
	public static void remove_OnScoreUpdateAction(Action<LevelBasketballScoreBoard> value) { }

	public void ResetScore() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SetScore(ref int score, int value, TextMesh scoreText) { }

	private void SyncScoreText(int score, TextMesh scoreText) { }

}

