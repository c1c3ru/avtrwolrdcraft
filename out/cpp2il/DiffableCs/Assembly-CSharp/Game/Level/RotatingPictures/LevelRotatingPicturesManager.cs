namespace Game.Level.RotatingPictures;

public class LevelRotatingPicturesManager : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private PDPrefab _spawn; //Field offset: 0x20
	[SerializeField]
	private int _endCounter; //Field offset: 0x28
	[SerializeField]
	private bool _isPack; //Field offset: 0x2C
	[SerializeField]
	[Space]
	private UnityEvent _onDoneEvent; //Field offset: 0x30
	private int _counter; //Field offset: 0x38

	public LevelRotatingPicturesManager() { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void IncrementCounter() { }

	private void InitBag() { }

	private void OnDestroy() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

