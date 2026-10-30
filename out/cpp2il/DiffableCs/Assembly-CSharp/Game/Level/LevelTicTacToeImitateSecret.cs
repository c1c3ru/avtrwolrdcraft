namespace Game.Level;

public class LevelTicTacToeImitateSecret : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private LevelTicTacToe[] _ticTacToes; //Field offset: 0x20
	[SerializeField]
	private State[] _winStates; //Field offset: 0x28
	[SerializeField]
	private UnityEvent _winEvents; //Field offset: 0x30
	private bool _isAwardGiven; //Field offset: 0x38

	public LevelTicTacToeImitateSecret() { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void TicTacToeStateChanged(TicTacToeLine[] possibleWinLines, State state) { }

}

