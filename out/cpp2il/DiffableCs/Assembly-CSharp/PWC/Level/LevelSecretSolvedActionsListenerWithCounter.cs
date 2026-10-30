namespace PWC.Level;

public class LevelSecretSolvedActionsListenerWithCounter : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private string _secretLabel; //Field offset: 0x20
	[SerializeField]
	private int _targetCount; //Field offset: 0x28
	[SerializeField]
	private bool _solveInSequence; //Field offset: 0x2C
	[SerializeField]
	private bool _canBeUnsolved; //Field offset: 0x2D
	public Action OnSecretsCounterReached; //Field offset: 0x30
	public Action OnSecretsCounterUnreached; //Field offset: 0x38
	private int _currentCount; //Field offset: 0x40
	private bool _isSolved; //Field offset: 0x44
	private ICanListenForSecrets _secretWaiter; //Field offset: 0x48

	public string SecretLabel
	{
		 get { } //Length: 8
	}

	public int TargetCounter
	{
		 get { } //Length: 8
	}

	public LevelSecretSolvedActionsListenerWithCounter() { }

	private void AddToCurrentCount(int ammount) { }

	private void Awake() { }

	public string get_SecretLabel() { }

	public int get_TargetCounter() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void SecretSolved(string label, Int32[] numbersInSequence) { }

	private void SecretUnsolved(string label) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

