namespace Game.Level.Arcade;

public class LevelArcadeSecretLightsManager : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	internal enum Direction
	{
		Left = 0,
		Right = 1,
		Up = 2,
		Down = 3,
	}

	private static List<Direction[]> _sequences; //Field offset: 0x0
	[SerializeField]
	private PDPrefab[] _spawns; //Field offset: 0x20
	[SerializeField]
	private string _soundName; //Field offset: 0x28
	[SerializeField]
	[Space]
	private UnityEvent _onSolvedSequenceEvent; //Field offset: 0x30
	private bool _wasInit; //Field offset: 0x38
	private Int32[] _indexes; //Field offset: 0x40
	private Int32[] _solvedSequences; //Field offset: 0x48

	private static LevelArcadeSecretLightsManager() { }

	public LevelArcadeSecretLightsManager() { }

	private void Awake() { }

	private void GetLightInput(Direction input) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void InitPresent(int index) { }

	private void OnDestroy() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

