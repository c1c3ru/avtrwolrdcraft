namespace Game.Level;

[DisallowMultipleComponent]
public class LevelTimedCounterHandler : MonoBehaviour
{
	private const string DefaultTextFormat = "{0}"; //Field offset: 0x0
	private const float DefaultTimePerIncrease = 0,5; //Field offset: 0x0
	[Header("Counting")]
	[SerializeField]
	private int _minValue; //Field offset: 0x20
	[SerializeField]
	private int _maxValue; //Field offset: 0x24
	[SerializeField]
	private int _increaseBy; //Field offset: 0x28
	[SerializeField]
	private float _timePerIncrease; //Field offset: 0x2C
	[SerializeField]
	private bool _restartFromMinOnStart; //Field offset: 0x30
	[Header("View")]
	[SerializeField]
	private TMP_Text _counterText; //Field offset: 0x38
	[SerializeField]
	[Tooltip("Ignored when _counterText is assigned")]
	private TextMesh _counterTextMesh; //Field offset: 0x40
	[SerializeField]
	private string _textFormat; //Field offset: 0x48
	[SerializeField]
	private LevelProgressBarBase _progressBar; //Field offset: 0x50
	[Header("Events")]
	public UnityEvent<Int32> onValueChanged; //Field offset: 0x58
	public UnityEvent onCountingStarted; //Field offset: 0x60
	public UnityEvent onCountingStopped; //Field offset: 0x68
	public UnityEvent onMaxValueReached; //Field offset: 0x70
	private int _currentValue; //Field offset: 0x78
	private int _tweenId; //Field offset: 0x7C
	private bool _isCounting; //Field offset: 0x80
	private bool _hasReachedMax; //Field offset: 0x81
	private string _lastSetText; //Field offset: 0x88

	public int CurrentValue
	{
		 get { } //Length: 8
	}

	public bool IsAtMax
	{
		 get { } //Length: 20
	}

	public bool IsCounting
	{
		 get { } //Length: 8
	}

	public int MaxValue
	{
		 get { } //Length: 8
	}

	public int MinValue
	{
		 get { } //Length: 8
	}

	public LevelTimedCounterHandler() { }

	public void AddValue(int amount) { }

	private void Awake() { }

	private void CancelTween() { }

	private void ClampValues(bool shouldLog) { }

	private string FormatValue(int value) { }

	public int get_CurrentValue() { }

	public bool get_IsAtMax() { }

	public bool get_IsCounting() { }

	public int get_MaxValue() { }

	public int get_MinValue() { }

	private bool HasCounterText() { }

	private void OnDestroy() { }

	private void OnIncreaseStep() { }

	private void RefreshView(bool isInstant = false) { }

	public void ResetCounter() { }

	private void SetCounterText(string text) { }

	public void SetValue(int value) { }

	private void SetValueInternal(int newValue, bool invokeEvents) { }

	public void StartCounting() { }

	public void StopCounting() { }

	private void ValidateTextFormat() { }

	private void ValidateView() { }

}

