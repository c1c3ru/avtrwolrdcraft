namespace SimpleUI.ScrollExtensions;

public class ScrollPoint : UIBehaviour
{
	[CompilerGenerated]
	private static Action<ScrollPoint> OnFocusAction; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<ScrollPoint> OnFocusLostAction; //Field offset: 0x8
	[CompilerGenerated]
	private RectTransform <Rect>k__BackingField; //Field offset: 0x20
	private bool initialized; //Field offset: 0x28
	protected Vector2 centeredPosition; //Field offset: 0x2C
	protected ScrollRectController scrollController; //Field offset: 0x38
	protected ScrollRect scrollRect; //Field offset: 0x40
	protected float distance; //Field offset: 0x48
	private bool dirty; //Field offset: 0x4C
	[CompilerGenerated]
	private Action OnDirty; //Field offset: 0x50

	public event Action OnDirty
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public static event Action<ScrollPoint> OnFocusAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public static event Action<ScrollPoint> OnFocusLostAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public bool AboveFocus
	{
		 get { } //Length: 60
	}

	public bool BelowFocus
	{
		 get { } //Length: 60
	}

	public Vector2 DifferenceToFocus
	{
		 get { } //Length: 200
	}

	public bool Dirty
	{
		 get { } //Length: 8
		 set { } //Length: 36
	}

	public float DistanceToFocus
	{
		 get { } //Length: 64
	}

	public bool LeftOfFocus
	{
		 get { } //Length: 60
	}

	public private RectTransform Rect
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public bool RightOfFocus
	{
		 get { } //Length: 60
	}

	public Vector2 ScrollPosition
	{
		 get { } //Length: 96
	}

	public ScrollPoint() { }

	public float AbsoluteDistanceToPosition(Vector2 normalizedPosition) { }

	[CompilerGenerated]
	public void add_OnDirty(Action value) { }

	[CompilerGenerated]
	public static void add_OnFocusAction(Action<ScrollPoint> value) { }

	[CompilerGenerated]
	public static void add_OnFocusLostAction(Action<ScrollPoint> value) { }

	protected virtual void Awake() { }

	public void Defocus() { }

	public float DistanceToPosition(Vector2 normalizedPosition) { }

	public void Focus() { }

	public bool get_AboveFocus() { }

	public bool get_BelowFocus() { }

	public Vector2 get_DifferenceToFocus() { }

	public bool get_Dirty() { }

	public float get_DistanceToFocus() { }

	public bool get_LeftOfFocus() { }

	[CompilerGenerated]
	public RectTransform get_Rect() { }

	public bool get_RightOfFocus() { }

	public Vector2 get_ScrollPosition() { }

	private void Initialize() { }

	protected virtual void OnRectTransformDimensionsChange() { }

	public void RefreshPosition() { }

	[CompilerGenerated]
	public void remove_OnDirty(Action value) { }

	[CompilerGenerated]
	public static void remove_OnFocusAction(Action<ScrollPoint> value) { }

	[CompilerGenerated]
	public static void remove_OnFocusLostAction(Action<ScrollPoint> value) { }

	public void set_Dirty(bool value) { }

	[CompilerGenerated]
	private void set_Rect(RectTransform value) { }

}

