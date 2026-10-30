namespace SimpleUI.ScrollExtensions;

[AddComponentMenu("Simple UI/ Scroll View Extensions/ Scroll Focus Controller", 1001)]
public class ScrollFocusController : UIBehaviour, IInitializePotentialDragHandler, IEventSystemHandler, IBeginDragHandler, IEndDragHandler, IScrollHandler
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<ScrollPoint> <>9__26_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <SetPointsDirty>b__26_0(ScrollPoint point) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass24_0
	{
		public Vector2 currentPosition; //Field offset: 0x10

		public <>c__DisplayClass24_0() { }

		internal float <FindNearest>b__0(ScrollPoint x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass28_0
	{
		public ScrollPoint point; //Field offset: 0x10

		public <>c__DisplayClass28_0() { }

		internal void <MoveTo>b__0() { }

	}

	[CompilerGenerated]
	private static Action OnBeginDragAction; //Field offset: 0x0
	public ScrollRect scrollRect; //Field offset: 0x20
	public EasedScrollRectMover scrollMover; //Field offset: 0x28
	public List<ScrollPoint> focusPoints; //Field offset: 0x30
	public float scrollTimeOut; //Field offset: 0x38
	public bool snap; //Field offset: 0x3C
	[Header("In case inertia is enabled, elements will snap at this threshold")]
	public float minVelocityForSnap; //Field offset: 0x40
	private ScrollPoint current; //Field offset: 0x48
	private bool scrolling; //Field offset: 0x50
	private float scrollPauseTime; //Field offset: 0x54
	private UniqueCoroutine inertiaWatchRoutine; //Field offset: 0x58
	public Action<ScrollPoint> OnBeforeSnapToScrollPoint; //Field offset: 0x60

	public static event Action OnBeginDragAction
	{
		[CompilerGenerated]
		 add { } //Length: 184
		[CompilerGenerated]
		 remove { } //Length: 184
	}

	public ScrollFocusController() { }

	[CompilerGenerated]
	public static void add_OnBeginDragAction(Action value) { }

	private void ChangeFocus(ScrollPoint point) { }

	public ScrollPoint FindNearest() { }

	public ScrollPoint GetCurrentItem() { }

	public void MovementFinished() { }

	public void MovementStarted() { }

	public void MoveTo(ScrollPoint point, Action onEndAnimation = null) { }

	public override void OnBeginDrag(PointerEventData eventData) { }

	public override void OnEndDrag(PointerEventData eventData) { }

	public override void OnInitializePotentialDrag(PointerEventData eventData) { }

	protected virtual void OnRectTransformDimensionsChange() { }

	public override void OnScroll(PointerEventData eventData) { }

	public void OnScrollMove() { }

	[CompilerGenerated]
	public static void remove_OnBeginDragAction(Action value) { }

	public void ResetFocusPoints() { }

	public void SetPointsDirty() { }

	private void Update() { }

	private bool VelocityBelowMinimum() { }

}

