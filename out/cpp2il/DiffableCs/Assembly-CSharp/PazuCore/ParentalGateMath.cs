namespace PazuCore;

public class ParentalGateMath : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_0
	{
		public ParentalGateMath <>4__this; //Field offset: 0x10
		public int buttonIndex; //Field offset: 0x18

		public <>c__DisplayClass12_0() { }

		internal void <Hide>b__0() { }

	}

	private const string DRILL_FORMAT = "{0}x{1}="; //Field offset: 0x0
	public static Action<Boolean> OnCloseAction; //Field offset: 0x0
	[SerializeField]
	private WindowWithCat _windowWithCat; //Field offset: 0x20
	[SerializeField]
	private Text drill; //Field offset: 0x28
	[SerializeField]
	private Text[] answersTexts; //Field offset: 0x30
	private Action _onRightAnswer; //Field offset: 0x38
	private Action _onWrongAnswer; //Field offset: 0x40
	private int _correctAnswerIndex; //Field offset: 0x48
	private string _context; //Field offset: 0x50

	public ParentalGateMath() { }

	[CompilerGenerated]
	private void <OnCloseButtonClick>b__11_0() { }

	private void Awake() { }

	public void Hide(int buttonIndex) { }

	public void Init(Action onRightAnswer, Action onWrongAnswer = null, string context = "") { }

	public void OnCloseButtonClick() { }

}

