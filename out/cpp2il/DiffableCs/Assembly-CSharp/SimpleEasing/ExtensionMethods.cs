namespace SimpleEasing;

[Extension]
public static class ExtensionMethods
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass0_0
	{
		public Transform trans; //Field offset: 0x10

		public <>c__DisplayClass0_0() { }

		internal void <MoveTo>b__0(Vector3 pos) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		public CanvasGroup cgroup; //Field offset: 0x10

		public <>c__DisplayClass10_0() { }

		internal void <FadeTo>b__0(float newAlpha) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass11_0
	{
		public Image image; //Field offset: 0x10

		public <>c__DisplayClass11_0() { }

		internal void <EaseFill>b__0(float newFill) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_0
	{
		public LayoutElement layout; //Field offset: 0x10

		public <>c__DisplayClass12_0() { }

		internal void <EaseLayoutMinValues>b__0(Vector2 newDimensions) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_0
	{
		public ScrollRect scrollRect; //Field offset: 0x10

		public <>c__DisplayClass13_0() { }

		internal void <Jump>b__0(Vector2 newPosition) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass14_0
	{
		public ScrollRect scrollRect; //Field offset: 0x10

		public <>c__DisplayClass14_0() { }

		internal void <JumpVertical>b__0(float newPosition) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass15_0
	{
		public ScrollRect scrollRect; //Field offset: 0x10

		public <>c__DisplayClass15_0() { }

		internal void <JumpHorizontal>b__0(float newPosition) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass16_0
	{
		public RectTransform rect; //Field offset: 0x10

		public <>c__DisplayClass16_0() { }

		internal void <AnchoredPositionEase>b__0(Vector3 newPosition) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass17_0
	{
		public RectTransform rect; //Field offset: 0x10

		public <>c__DisplayClass17_0() { }

		internal void <PivotEase>b__0(Vector2 newPivot) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass18_0
	{
		public RectTransform rect; //Field offset: 0x10

		public <>c__DisplayClass18_0() { }

		internal void <AnchorMaxEase>b__0(Vector2 newMax) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass19_0
	{
		public RectTransform rect; //Field offset: 0x10

		public <>c__DisplayClass19_0() { }

		internal void <AnchorMinEase>b__0(Vector2 newMin) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass2_0
	{
		public Transform trans; //Field offset: 0x10

		public <>c__DisplayClass2_0() { }

		internal void <LocalMoveTo>b__0(Vector3 pos) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass20_0
	{
		public RectTransform rect; //Field offset: 0x10

		public <>c__DisplayClass20_0() { }

		internal void <OffsetMaxEase>b__0(Vector2 newMax) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass21_0
	{
		public RectTransform rect; //Field offset: 0x10

		public <>c__DisplayClass21_0() { }

		internal void <OffsetMinEase>b__0(Vector2 newMin) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass22_0
	{
		public RectTransform rect; //Field offset: 0x10

		public <>c__DisplayClass22_0() { }

		internal void <SizeDeltaEase>b__0(Vector2 newDelta) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass23_0
	{
		public Material material; //Field offset: 0x10

		public <>c__DisplayClass23_0() { }

		internal void <EaseMainColor>b__0(Color newColor) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass4_0
	{
		public Transform trans; //Field offset: 0x10

		public <>c__DisplayClass4_0() { }

		internal void <ScaleTo>b__0(Vector3 scale) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public Transform trans; //Field offset: 0x10

		public <>c__DisplayClass9_0() { }

		internal void <RotateTo>b__0(Quaternion rot) { }

	}


	[Extension]
	public static Coroutine AnchoredPositionEase(RectTransform rect, Vector3 target, float length, EasingTypes easingChoice, bool unscaled = false, TweenRepeat repeat = 0, Action onComplete = null) { }

	[Extension]
	public static Coroutine AnchorMaxEase(RectTransform rect, Vector2 target, float length, EasingTypes easingChoice, bool unscaled = false, TweenRepeat repeat = 0, Action onComplete = null) { }

	[Extension]
	public static Coroutine AnchorMinEase(RectTransform rect, Vector2 target, float length, EasingTypes easingChoice, bool unscaled = false, TweenRepeat repeat = 0, Action onComplete = null) { }

	[Extension]
	public static Coroutine EaseFill(Image image, float target, float length, EasingTypes easingChoice, bool unscaled = false, TweenRepeat repeat = 0, Action onComplete = null) { }

	[Extension]
	public static Coroutine EaseLayoutMinValues(LayoutElement layout, Vector2 target, float length, EasingTypes easingChoice, bool unscaled = false, TweenRepeat repeat = 0, Action onComplete = null) { }

	[Extension]
	public static Coroutine EaseMainColor(Material material, Color target, float length, EasingTypes easingChoice, bool unscaled = false, TweenRepeat repeat = 0, Action onComplete = null) { }

	[Extension]
	public static Coroutine FadeTo(CanvasGroup cgroup, float target, float length, EasingTypes easingChoice, bool unscaled = false, TweenRepeat repeat = 0, Action onComplete = null) { }

	[Extension]
	public static Coroutine Jump(ScrollRect scrollRect, Vector2 target, float length, EasingTypes easingChoice, bool unscaled = false, TweenRepeat repeat = 0, Action onComplete = null) { }

	[Extension]
	public static Coroutine JumpHorizontal(ScrollRect scrollRect, float target, float length, EasingTypes easingChoice, bool unscaled = false, TweenRepeat repeat = 0, Action onComplete = null) { }

	[Extension]
	public static Coroutine JumpVertical(ScrollRect scrollRect, float target, float length, EasingTypes easingChoice, bool unscaled = false, TweenRepeat repeat = 0, Action onComplete = null) { }

	[Extension]
	public static Coroutine LocalMoveTo(Transform trans, Vector3 start, Vector3 target, float length, EasingTypes easingChoice, bool unscaled = false, TweenRepeat repeat = 0, Action onComplete = null) { }

	[Extension]
	public static Coroutine LocalMoveTo(Transform trans, Vector3 target, float length, EasingTypes easingChoice, bool unscaled = false, TweenRepeat repeat = 0, Action onComplete = null) { }

	[Extension]
	public static Coroutine MoveTo(Transform trans, Vector3 target, float length, EasingTypes easingChoice, bool unscaled = false, TweenRepeat repeat = 0, Action onComplete = null) { }

	[Extension]
	public static Coroutine MoveTo(Transform trans, Vector3 start, Vector3 target, float length, EasingTypes easingChoice, bool unscaled = false, TweenRepeat repeat = 0, Action onComplete = null) { }

	[Extension]
	public static Coroutine OffsetMaxEase(RectTransform rect, Vector2 target, float length, EasingTypes easingChoice, bool unscaled = false, TweenRepeat repeat = 0, Action onComplete = null) { }

	[Extension]
	public static Coroutine OffsetMinEase(RectTransform rect, Vector2 target, float length, EasingTypes easingChoice, bool unscaled = false, TweenRepeat repeat = 0, Action onComplete = null) { }

	[Extension]
	public static Coroutine PivotEase(RectTransform rect, Vector2 target, float length, EasingTypes easingChoice, bool unscaled = false, TweenRepeat repeat = 0, Action onComplete = null) { }

	[Extension]
	public static Coroutine RotateTo(Transform trans, Quaternion start, Quaternion target, float length, EasingTypes easingChoice, bool unscaled = false, TweenRepeat repeat = 0, Action onComplete = null) { }

	[Extension]
	public static Coroutine RotateTo(Transform trans, Quaternion target, float length, EasingTypes easingChoice, bool unscaled = false, TweenRepeat repeat = 0, Action onComplete = null) { }

	[Extension]
	public static Coroutine RotateTo(Transform trans, Vector3 target, float length, EasingTypes easingChoice, bool unscaled = false, TweenRepeat repeat = 0, Action onComplete = null) { }

	[Extension]
	public static Coroutine RotateTo(Transform trans, Vector3 start, Vector3 target, float length, EasingTypes easingChoice, bool unscaled = false, TweenRepeat repeat = 0, Action onComplete = null) { }

	[Extension]
	public static Coroutine ScaleTo(Transform trans, Vector3 target, float length, EasingTypes easingChoice, bool unscaled = false, TweenRepeat repeat = 0, Action onComplete = null) { }

	[Extension]
	public static Coroutine ScaleTo(Transform trans, Vector3 start, Vector3 target, float length, EasingTypes easingChoice, bool unscaled = false, TweenRepeat repeat = 0, Action onComplete = null) { }

	[Extension]
	public static Coroutine SizeDeltaEase(RectTransform rect, Vector2 target, float length, EasingTypes easingChoice, bool unscaled = false, TweenRepeat repeat = 0, Action onComplete = null) { }

}

