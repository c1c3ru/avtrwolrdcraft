namespace Game.Level;

public class LevelEventCounterHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	public UnityEvent onTargetCountReachedAction; //Field offset: 0x20
	[SerializeField]
	public UnityEvent onTargetCountUnreachedAction; //Field offset: 0x28
	[SerializeField]
	public UnityEvent onSceneLoadAfterAlreadySolved; //Field offset: 0x30
	[SerializeField]
	private int _targetCount; //Field offset: 0x38
	[SerializeField]
	private bool _canBeUnsolve; //Field offset: 0x3C
	[SerializeField]
	private bool _saveCounter; //Field offset: 0x3D
	public UnityEvent onCounterIncreased; //Field offset: 0x40
	public UnityEvent onCounterDecreased; //Field offset: 0x48
	private bool _reachedTarget; //Field offset: 0x50
	private int _totalCount; //Field offset: 0x54

	public bool IsSaveCounter
	{
		 get { } //Length: 8
	}

	public int TotalCount
	{
		 get { } //Length: 8
	}

	public LevelEventCounterHandler() { }

	private void Awake() { }

	public void DecreaseCounter() { }

	public bool get_IsSaveCounter() { }

	public int get_TotalCount() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public int GetTotalCount() { }

	public void IncreaseCounter() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	public void ResetCounter() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

