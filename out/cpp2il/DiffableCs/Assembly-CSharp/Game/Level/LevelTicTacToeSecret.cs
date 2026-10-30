namespace Game.Level;

public class LevelTicTacToeSecret : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private LevelTicTacToe[] _ticTacToes; //Field offset: 0x20
	[SerializeField]
	private PDPrefabReference _carToSpawn; //Field offset: 0x28
	[SerializeField]
	private Transform _sliderArea; //Field offset: 0x30
	[SerializeField]
	private UnityEvent _winEvents; //Field offset: 0x38
	private bool _gotCar; //Field offset: 0x40

	public LevelTicTacToeSecret() { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SpawnCar() { }

	private void TicTacToeStateChanged(TicTacToeLine[] possibleWinLines, State state) { }

}

