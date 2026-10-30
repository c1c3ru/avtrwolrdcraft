namespace PWC.LevelPhone.DeliveryApp;

public class DeliveryProgressBar : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass17_0
	{
		public DeliveryProgressBar <>4__this; //Field offset: 0x10
		public bool shouldAnimateOnComplete; //Field offset: 0x18

		public <>c__DisplayClass17_0() { }

		internal void <ShowProgress>b__0(float value) { }

		internal void <ShowProgress>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass18_0
	{
		public bool value; //Field offset: 0x10
		public DeliveryProgressBar <>4__this; //Field offset: 0x18
		public Action onCompleteSetActiveAction; //Field offset: 0x20

		public <>c__DisplayClass18_0() { }

		internal void <Animate>b__0() { }

	}

	[CompilerGenerated]
	private static Action OnProgressBarFullAction; //Field offset: 0x0
	[SerializeField]
	private bool _shouldInitOnEnable; //Field offset: 0x20
	[SerializeField]
	private bool _shouldCallOnFullAction; //Field offset: 0x21
	[SerializeField]
	protected GameObject _view; //Field offset: 0x28
	[SerializeField]
	private Image _fill; //Field offset: 0x30
	[SerializeField]
	private RectTransform _icon; //Field offset: 0x38
	[SerializeField]
	private float _startingFillValueBuffer; //Field offset: 0x40
	[SerializeField]
	private float _endingFillValue; //Field offset: 0x44
	[SerializeField]
	private float _iconStartingXPosition; //Field offset: 0x48
	[SerializeField]
	private bool _isFillSound; //Field offset: 0x4C
	[SerializeField]
	private string _fillSoundName; //Field offset: 0x50
	private int _scaleTwennID; //Field offset: 0x58
	private int _progressTweenID; //Field offset: 0x5C

	public static event Action OnProgressBarFullAction
	{
		[CompilerGenerated]
		 add { } //Length: 184
		[CompilerGenerated]
		 remove { } //Length: 184
	}

	public DeliveryProgressBar() { }

	[CompilerGenerated]
	public static void add_OnProgressBarFullAction(Action value) { }

	public override void Animate(bool value, Action onCompleteSetActiveAction = null) { }

	public bool InitIfNeeded(bool shouldAnimateOnComplete = false) { }

	private void OnEnable() { }

	[CompilerGenerated]
	public static void remove_OnProgressBarFullAction(Action value) { }

	public void ShowProgress(float startValue, float endValue, float time, bool shouldAnimateOnComplete = false, bool easeOutExpo = false) { }

}

