namespace PazuCore;

public class ParentalGateDate : MonoBehaviour
{
	[CompilerGenerated]
	private static Action<Boolean> OnCloseAction; //Field offset: 0x0
	[SerializeField]
	private GameObject _window; //Field offset: 0x20
	[SerializeField]
	private Text[] _dateDigitsTexts; //Field offset: 0x28
	private Action _onRightAnswer; //Field offset: 0x30
	private Action _onWrongAnswer; //Field offset: 0x38
	private int _currentdigit; //Field offset: 0x40
	private Vector3 _startScale; //Field offset: 0x44
	private Quaternion _startRotation; //Field offset: 0x50
	private bool _isEnteredLastNumber; //Field offset: 0x60
	private string _context; //Field offset: 0x68

	public static event Action<Boolean> OnCloseAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public ParentalGateDate() { }

	[CompilerGenerated]
	private void <OnTapClose>b__18_0() { }

	[CompilerGenerated]
	private void <OnTapNumber>b__16_0() { }

	[CompilerGenerated]
	private void <OnTapNumber>b__16_1() { }

	[CompilerGenerated]
	public static void add_OnCloseAction(Action<Boolean> value) { }

	private void Awake() { }

	private void FitToScreen() { }

	public void Init(Action onRightAnswer, Action onWrongAnswer = null, string context = "") { }

	public void OnTapClose() { }

	public void OnTapNumber(int number) { }

	public void OnTapUndo() { }

	[CompilerGenerated]
	public static void remove_OnCloseAction(Action<Boolean> value) { }

	private void ResetDate() { }

}

