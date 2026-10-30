namespace Game.Level.Arcade;

public class LevelArcadeSecretSlushyManager : MonoBehaviour
{
	internal enum Direction
	{
		Left = 0,
		Right = 1,
	}

	[SerializeField]
	private PDPrefab _spawn; //Field offset: 0x20
	[SerializeField]
	private LevelToggleableSprite[] _levelToggleableSprites; //Field offset: 0x28
	[SerializeField]
	private UnityEvent _onSequenceCompletedEvent; //Field offset: 0x30
	private Direction[] _sequence; //Field offset: 0x38
	private int _index; //Field offset: 0x40

	public LevelArcadeSecretSlushyManager() { }

	private void Awake() { }

	public Dictionary<String, Object> GetPersistentData() { }

	private void GetSlushyInput(Direction input) { }

	private void InitPresent() { }

	private void OnDestroy() { }

	public void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

