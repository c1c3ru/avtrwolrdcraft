namespace Game.Level;

public class LevelToggleableGameobjectsSequenceHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private LevelToggleableGameObject[] _toggleableGameobjects; //Field offset: 0x20
	[SerializeField]
	private Int32[] _sequence; //Field offset: 0x28
	[SerializeField]
	private bool _isSolvedOnce; //Field offset: 0x30
	private bool solved; //Field offset: 0x31
	private List<Int32> _currentSequence; //Field offset: 0x38
	public UnityEvent OnSequecneComplete; //Field offset: 0x40

	public LevelToggleableGameobjectsSequenceHandler() { }

	public void AddNextSequenceNumber(int given) { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void ResetSequence() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetStates(int satate) { }

}

