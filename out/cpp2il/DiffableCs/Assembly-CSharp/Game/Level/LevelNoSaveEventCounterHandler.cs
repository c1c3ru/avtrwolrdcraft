namespace Game.Level;

public class LevelNoSaveEventCounterHandler : MonoBehaviour
{
	[SerializeField]
	private int _targetCount; //Field offset: 0x20
	[SerializeField]
	public UnityEvent onTargetCountReachedAction; //Field offset: 0x28
	[SerializeField]
	public UnityEvent onTargetCountUnreachedAction; //Field offset: 0x30
	private bool _reachedTarget; //Field offset: 0x38
	private int _totalCount; //Field offset: 0x3C
	public UnityEvent onCounterIncreased; //Field offset: 0x40
	public UnityEvent onCounterDecreased; //Field offset: 0x48

	public LevelNoSaveEventCounterHandler() { }

	public void DecreaseCounter() { }

	public Dictionary<String, Object> GetPersistentData() { }

	public void IncreaseCounter() { }

	public void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

