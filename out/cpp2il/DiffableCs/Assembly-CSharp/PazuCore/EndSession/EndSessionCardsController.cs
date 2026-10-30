namespace PazuCore.EndSession;

public class EndSessionCardsController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Boolean> <>9__16_1; //Field offset: 0x8
		public static Func<Boolean> <>9__20_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal bool <InitWithNextGameData>b__20_0() { }

		internal bool <WaitForInit>b__16_1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass21_0
	{
		public string op; //Field offset: 0x10
		public EndSessionCardsController <>4__this; //Field offset: 0x18

		public <>c__DisplayClass21_0() { }

		internal void <InitWithSimpleData>b__0(string responseText) { }

	}

	[CompilerGenerated]
	private struct <>c__DisplayClass23_0
	{
		public int lastScrollPosition; //Field offset: 0x0

	}

	[CompilerGenerated]
	private sealed class <AutoScroll>d__17 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public EndSessionCardsController <>4__this; //Field offset: 0x20
		private float <interval>5__2; //Field offset: 0x28
		private float <timer>5__3; //Field offset: 0x2C

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
		public <AutoScroll>d__17(int <>1__state) { }

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
	private sealed class <WaitForInit>d__16 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public EndSessionCardsController <>4__this; //Field offset: 0x20

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
		public <WaitForInit>d__16(int <>1__state) { }

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
	private static bool <AllowVisible>k__BackingField; //Field offset: 0x0
	[SerializeField]
	private ListPositionCtrl _listPositionCtrl; //Field offset: 0x20
	[SerializeField]
	private EndSessionCardsDots _dots; //Field offset: 0x28
	[SerializeField]
	private EndSessionCard _cardPrefab; //Field offset: 0x30
	[SerializeField]
	private Text _headline; //Field offset: 0x38
	private Vector3 _animateInOffset; //Field offset: 0x40
	private bool _isInited; //Field offset: 0x4C
	private bool _isInitedDefault; //Field offset: 0x4D
	private bool _threeLikeTwo; //Field offset: 0x4E
	private int _fourLikeTwoDotIndex; //Field offset: 0x50

	public static bool AllowVisible
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		 set { } //Length: 96
	}

	private static EndSessionCardsController() { }

	public EndSessionCardsController() { }

	[CompilerGenerated]
	internal static int <CreateCards>g__GetNextScrollPosition|23_0(ref <>c__DisplayClass23_0 unnamed_param_0) { }

	[CompilerGenerated]
	private void <Init>b__18_0() { }

	[CompilerGenerated]
	private void <InitWithNextGameData>b__20_1() { }

	[CompilerGenerated]
	private void <InitWithNextGameData>b__20_2() { }

	[CompilerGenerated]
	private bool <WaitForInit>b__16_0() { }

	[IteratorStateMachine(typeof(<AutoScroll>d__17))]
	private IEnumerator AutoScroll() { }

	private void Awake() { }

	private void ClearCards() { }

	private void CreateCards(CardsModel cardsModel) { }

	[CompilerGenerated]
	public static bool get_AllowVisible() { }

	public void Init(List<CardsModel> cardsModels) { }

	public void InitDefault() { }

	public void InitWithNextGameData() { }

	public void InitWithSimpleData() { }

	private EndSessionCard InstantiateCard() { }

	private void OnStop(ListBox listBox) { }

	[CompilerGenerated]
	public static void set_AllowVisible(bool value) { }

	private void SetHeadlineText() { }

	private void Start() { }

	[IteratorStateMachine(typeof(<WaitForInit>d__16))]
	private IEnumerator WaitForInit() { }

}

