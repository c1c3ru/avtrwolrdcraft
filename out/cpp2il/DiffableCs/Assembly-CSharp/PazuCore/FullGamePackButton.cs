namespace PazuCore;

public class FullGamePackButton : ButtonBase
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Boolean> <>9__19_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <Init>b__19_0() { }

	}

	[CompilerGenerated]
	private sealed class <Init>d__19 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public FullGamePackButton <>4__this; //Field offset: 0x20
		private bool <isSubscriptionMode>5__2; //Field offset: 0x28

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <Init>d__19(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private static Action OverrideClickAction; //Field offset: 0x0
	[SerializeField]
	private Vector2 _animateInOffset; //Field offset: 0x20
	[SerializeField]
	private Text _text; //Field offset: 0x28
	[SerializeField]
	private Text _gamesNumberText; //Field offset: 0x30
	[SerializeField]
	private Text _gamesTitleText; //Field offset: 0x38
	[SerializeField]
	private Text _daysNumberText; //Field offset: 0x40
	[SerializeField]
	private Text _daysTitleText; //Field offset: 0x48
	[SerializeField]
	private Text _subscriptionCtaText; //Field offset: 0x50
	[SerializeField]
	private GameObject _subscriptionContent; //Field offset: 0x58
	[SerializeField]
	private GameObject _fullversionContent; //Field offset: 0x60
	[SerializeField]
	private GameObject _trialBadge; //Field offset: 0x68
	[SerializeField]
	private Image _buttonImage; //Field offset: 0x70
	private bool _initOnStart; //Field offset: 0x78
	private CanvasGroup _canvasGroup; //Field offset: 0x80

	public static event Action OverrideClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 184
		[CompilerGenerated]
		 remove { } //Length: 184
	}

	public FullGamePackButton() { }

	[CompilerGenerated]
	private void <Awake>b__16_0() { }

	[CompilerGenerated]
	public static void add_OverrideClickAction(Action value) { }

	protected virtual void Awake() { }

	[IteratorStateMachine(typeof(<Init>d__19))]
	private IEnumerator Init() { }

	private void InitMarketing(Texts texts) { }

	protected virtual void OnClick() { }

	private void OnDestroy() { }

	public void OnInnerButtonClick() { }

	private void OnSync(SyncType syncType) { }

	[CompilerGenerated]
	public static void remove_OverrideClickAction(Action value) { }

	private void Start() { }

}

