namespace Game.Level;

[DisallowMultipleComponent]
public class LevelNewEventCounterHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[Header("Counting")]
	[SerializeField]
	private int _targetCount; //Field offset: 0x20
	[SerializeField]
	private bool _clampToTargetCount; //Field offset: 0x24
	[SerializeField]
	private bool _allowNegativeCount; //Field offset: 0x25
	[Header("Target")]
	[SerializeField]
	private bool _canUnreachTarget; //Field offset: 0x26
	[Header("Persistence")]
	[SerializeField]
	private bool _saveCount; //Field offset: 0x27
	[ConditionalField("_saveCount", True, True, (array) null)]
	[SerializeField]
	private bool _invokeTargetReachedOnLoad; //Field offset: 0x28
	[ConditionalField("_saveCount", True, True, (array) null)]
	[SerializeField]
	private bool _invokeCountChangedOnLoad; //Field offset: 0x29
	[Header("Events")]
	public UnityEvent onTargetReached; //Field offset: 0x30
	public UnityEvent onTargetUnreached; //Field offset: 0x38
	public UnityEvent onTargetAlreadyReachedOnLoad; //Field offset: 0x40
	public UnityEvent onCountIncreased; //Field offset: 0x48
	public UnityEvent onCountDecreased; //Field offset: 0x50
	public UnityEvent<Int32> onCountChanged; //Field offset: 0x58
	private int _count; //Field offset: 0x60
	private bool _hasReachedTarget; //Field offset: 0x64
	private bool _isSyncedOnLoad; //Field offset: 0x65

	public int Count
	{
		 get { } //Length: 8
	}

	public bool HasReachedTarget
	{
		 get { } //Length: 8
	}

	public bool IsSavingCount
	{
		 get { } //Length: 8
	}

	public int TargetCount
	{
		 get { } //Length: 8
	}

	public LevelNewEventCounterHandler() { }

	public void AddToCounter(int amount) { }

	private void Awake() { }

	public void DecreaseCounter() { }

	private void EvaluateTarget(bool invokeEvents) { }

	public int get_Count() { }

	public bool get_HasReachedTarget() { }

	public bool get_IsSavingCount() { }

	public int get_TargetCount() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public void IncreaseCounter() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	public void ResetCounter() { }

	public void SetCounter(int value) { }

	private void SetCountInternal(int newCount, bool invokeEvents) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void Start() { }

}

