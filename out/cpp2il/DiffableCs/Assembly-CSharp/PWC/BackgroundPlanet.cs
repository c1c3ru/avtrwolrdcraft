namespace PWC;

public class BackgroundPlanet : StationaryInteractableItem, IPointerClickHandler, IEventSystemHandler, IMultiplayer_IgnoreInputEvents
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass40_0
	{
		public BackgroundPlanet <>4__this; //Field offset: 0x10
		public TimeOfDay timeOfDay; //Field offset: 0x18
		public float usedDuration; //Field offset: 0x1C
		public Action<Single> <>9__2; //Field offset: 0x20
		public Action <>9__3; //Field offset: 0x28

		public <>c__DisplayClass40_0() { }

		internal void <Animate>b__0(float value) { }

		internal void <Animate>b__1() { }

		internal void <Animate>b__2(float value) { }

		internal void <Animate>b__3() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass41_0
	{
		public float initialSkyLightIntensity; //Field offset: 0x10
		public float maxIntensity; //Field offset: 0x14
		public bool shouldManipulateOverlay; //Field offset: 0x18
		public SpriteRenderer overlay; //Field offset: 0x20
		public Color halfTransparentWhite; //Field offset: 0x28
		public BackgroundPlanet <>4__this; //Field offset: 0x38
		public float initialSmoothness; //Field offset: 0x40
		public float initialMiddle; //Field offset: 0x44
		public Color initialTopColor; //Field offset: 0x48
		public Color initialBottomColor; //Field offset: 0x58
		public Color origianlOverlayColor; //Field offset: 0x68
		public Action<Single> <>9__3; //Field offset: 0x78

		public <>c__DisplayClass41_0() { }

		internal void <PlayLightningEffect>b__0() { }

		internal void <PlayLightningEffect>b__1() { }

		internal void <PlayLightningEffect>b__3(float value) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass41_1
	{
		public Color nextColor; //Field offset: 0x10
		public <>c__DisplayClass41_0 CS$<>8__locals1; //Field offset: 0x20

		public <>c__DisplayClass41_1() { }

		internal void <PlayLightningEffect>b__2(float value) { }

	}

	[CompilerGenerated]
	private static Action OnLoadIsDayAction; //Field offset: 0x0
	private const float SUN_WIDTH = 1,4; //Field offset: 0x0
	private const string PLAYERPREFS_KEY = "PazuWorld_IsDay"; //Field offset: 0x0
	public const float ANIMATION_DURATION = 2; //Field offset: 0x0
	[CompilerGenerated]
	private static Action OnBackgroundPlanetClickAction; //Field offset: 0x8
	[CompilerGenerated]
	private static bool <IsDay>k__BackingField; //Field offset: 0x10
	public static TimeOfDay CurrentTimeOfDay; //Field offset: 0x14
	private static readonly TimeOfDay[] _timesOfDay; //Field offset: 0x18
	[CompilerGenerated]
	private static BackgroundPlanet <Instance>k__BackingField; //Field offset: 0x20
	[SerializeField]
	private SkeletonAnimation _celestialObject; //Field offset: 0x40
	[SerializeField]
	private SkeletonAnimation _reflectedObject; //Field offset: 0x48
	[SerializeField]
	private BackgroundSky _sky; //Field offset: 0x50
	[SerializeField]
	private List<BackgroundSky> _water; //Field offset: 0x58
	[SerializeField]
	private float _xPadding; //Field offset: 0x60
	private Camera _camera; //Field offset: 0x68
	private Vector2 _startPosition; //Field offset: 0x70
	private float _currentAnimationTime; //Field offset: 0x78
	[CompilerGenerated]
	private Action<TimeOfDay> OnClickAction; //Field offset: 0x80
	private bool _isMoving; //Field offset: 0x88

	public static event Action OnBackgroundPlanetClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 220
		[CompilerGenerated]
		 remove { } //Length: 220
	}

	public event Action<TimeOfDay> OnClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public static event Action OnLoadIsDayAction
	{
		[CompilerGenerated]
		 add { } //Length: 216
		[CompilerGenerated]
		 remove { } //Length: 216
	}

	public private static BackgroundPlanet Instance
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		private set { } //Length: 96
	}

	public private static bool IsDay
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		private set { } //Length: 96
	}

	private static BackgroundPlanet() { }

	public BackgroundPlanet() { }

	[CompilerGenerated]
	public static void add_OnBackgroundPlanetClickAction(Action value) { }

	[CompilerGenerated]
	public void add_OnClickAction(Action<TimeOfDay> value) { }

	[CompilerGenerated]
	public static void add_OnLoadIsDayAction(Action value) { }

	private void Animate(TimeOfDay timeOfDay, float duration) { }

	private void AnimateTransition() { }

	protected virtual void Awake() { }

	[CompilerGenerated]
	public static BackgroundPlanet get_Instance() { }

	[CompilerGenerated]
	public static bool get_IsDay() { }

	public float GetCurrentAnimationCompletionPercent() { }

	private Vector2 GetPositionForAngle(float fromAngle, float toAngle, float t, float radius) { }

	public void Init() { }

	private void LoadIsDay() { }

	protected virtual void OnDestroy() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public void PerformClickWithSpecificValue(TimeOfDay timeOfDay) { }

	public void PlayLightningEffect(int numberOfFlashes = 2) { }

	[CompilerGenerated]
	public static void remove_OnBackgroundPlanetClickAction(Action value) { }

	[CompilerGenerated]
	public void remove_OnClickAction(Action<TimeOfDay> value) { }

	[CompilerGenerated]
	public static void remove_OnLoadIsDayAction(Action value) { }

	[CompilerGenerated]
	private static void set_Instance(BackgroundPlanet value) { }

	[CompilerGenerated]
	private static void set_IsDay(bool value) { }

	public static void SetIsDayData(TimeOfDay timeOfDay) { }

	private void SetSunCShapeSize() { }

	private void SyncAppearance() { }

	private void UpdateLights(TimeOfDay timeOfDay, float value) { }

}

