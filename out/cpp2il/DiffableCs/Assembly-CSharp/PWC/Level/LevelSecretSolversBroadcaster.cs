namespace PWC.Level;

public class LevelSecretSolversBroadcaster : MonoBehaviour
{
	[SerializeField]
	private string _secretLabel; //Field offset: 0x20
	[SerializeField]
	private List<Int32> _numbersInSequence; //Field offset: 0x28
	private ICanSolveSecrets[] _secrets; //Field offset: 0x30
	private int _secretsSolved; //Field offset: 0x38

	public Int32[] NumbersInSequence
	{
		 get { } //Length: 80
	}

	public string SecretLabel
	{
		 get { } //Length: 8
	}

	public LevelSecretSolversBroadcaster() { }

	private void Awake() { }

	private void CallTheSecretsEventBus(bool solved) { }

	public Int32[] get_NumbersInSequence() { }

	public string get_SecretLabel() { }

	private void OnDestroy() { }

	public void Solve() { }

	public void Unsolve() { }

}

