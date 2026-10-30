namespace SimpleUI.ScrollExtensions;

public class EasedScrollRectMover : MonoBehaviour, IInitializePotentialDragHandler, IEventSystemHandler, IBeginDragHandler
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass14_0
	{
		public EasedScrollRectMover <>4__this; //Field offset: 0x10
		public Action onEndAnimation; //Field offset: 0x18

		public <>c__DisplayClass14_0() { }

		internal void <MoveTo>b__0(float scrollValue) { }

		internal void <MoveTo>b__1(float scrollValue) { }

		internal void <MoveTo>b__2() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass15_0
	{
		public EasedScrollRectMover <>4__this; //Field offset: 0x10
		public Action onEndAnimation; //Field offset: 0x18

		public <>c__DisplayClass15_0() { }

		internal void <MoveTo>b__1(Vector2 scroll) { }

		internal void <MoveTo>g__onFinished|0() { }

	}

	public ScrollRectController scrollController; //Field offset: 0x20
	public ScrollRect scrollRect; //Field offset: 0x28
	public CanvasGroup canvasGroup; //Field offset: 0x30
	[Tooltip("Either block User Input during Movement or end the Movement on User Input")]
	public bool blockInputDuringScroll; //Field offset: 0x38
	public TweenSettings settings; //Field offset: 0x40
	private UniqueCoroutine scrollRoutine; //Field offset: 0x48
	[CompilerGenerated]
	private bool <Moving>k__BackingField; //Field offset: 0x50

	public private bool Moving
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public EasedScrollRectMover() { }

	public void AbortScrollMovement() { }

	private void BlockScrollRectInput() { }

	[CompilerGenerated]
	public bool get_Moving() { }

	public void MoveTo(RectTransform rect) { }

	public void MoveTo(float scrollPosition) { }

	public void MoveTo(Vector2 scrollPosition) { }

	public void MoveTo(RectTransform rect, Action onEndAnimation = null) { }

	public void MoveTo(float scrollPosition, Action onEndAnimation = null) { }

	public void MoveTo(Vector2 scrollPosition, Action onEndAnimation = null) { }

	public override void OnBeginDrag(PointerEventData eventData) { }

	public override void OnInitializePotentialDrag(PointerEventData eventData) { }

	private void ResetScrollRectInput() { }

	[CompilerGenerated]
	private void set_Moving(bool value) { }

}

