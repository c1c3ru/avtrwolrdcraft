namespace PWC.Level;

public class LevelSlider : DragDropItemBase, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass45_0
	{
		public LevelSlider <>4__this; //Field offset: 0x10
		public SliderDestinationType destinationType; //Field offset: 0x18

		public <>c__DisplayClass45_0() { }

		internal void <PerformClickAction>b__0() { }

		internal void <PerformClickAction>b__1() { }

		internal void <PerformClickAction>b__2() { }

	}

	internal enum SliderType
	{
		None = 0,
		Horizontal = 1,
		Vertical = 2,
		Both = 3,
	}

	[SerializeField]
	protected GameObject _movingGameObject; //Field offset: 0x110
	[SerializeField]
	protected bool _canDrag; //Field offset: 0x118
	[SerializeField]
	private bool _canClick; //Field offset: 0x119
	[SerializeField]
	protected SliderType _sliderType; //Field offset: 0x11C
	[ConditionalField("_sliderType", null, True, new IL2CPP_TYPE_OBJECT[] {SliderType::Vertical (2), SliderType::Horizontal (1)})]
	[SerializeField]
	private float _minValue; //Field offset: 0x120
	[ConditionalField("_sliderType", null, True, new IL2CPP_TYPE_OBJECT[] {SliderType::Vertical (2), SliderType::Horizontal (1)})]
	[SerializeField]
	private float _maxValue; //Field offset: 0x124
	[ConditionalField("_sliderType", SliderType::Both (3), True, (array) null)]
	[SerializeField]
	protected Vector2 _minValueVector; //Field offset: 0x128
	[ConditionalField("_sliderType", SliderType::Both (3), True, (array) null)]
	[SerializeField]
	protected Vector2 _maxValueVector; //Field offset: 0x130
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x138
	[SerializeField]
	private string _soundName; //Field offset: 0x140
	[SerializeField]
	private float _onClickSlideDuration; //Field offset: 0x148
	[SerializeField]
	private UnityEvent OnSlideEndedAtMax; //Field offset: 0x150
	[SerializeField]
	private UnityEvent OnSlideEndedAtMin; //Field offset: 0x158
	[SerializeField]
	private UnityEvent OnSlideDragAtMax; //Field offset: 0x160
	[SerializeField]
	private UnityEvent OnSlideDragAtMin; //Field offset: 0x168
	[SerializeField]
	private UnityEvent OnSlideDragBegin; //Field offset: 0x170
	[SerializeField]
	private UnityEvent OnSlideDragEnd; //Field offset: 0x178
	[SerializeField]
	private bool _isSaveLocation; //Field offset: 0x180
	private bool _isMoving; //Field offset: 0x181
	private float _lastDestination; //Field offset: 0x184
	private Vector2 _lastDestinationVector; //Field offset: 0x188
	private bool _isInSliderTypeBothYDominate; //Field offset: 0x190
	private int _tweenID; //Field offset: 0x194
	protected Vector2 _lastPointerPosition; //Field offset: 0x198
	[CompilerGenerated]
	private Action<SliderDestinationType> OnSliderBeginAnimationAction; //Field offset: 0x1A0
	[CompilerGenerated]
	private Action<SliderDestinationType> OnSliderEndAnimationAction; //Field offset: 0x1A8
	[CompilerGenerated]
	private Action<LevelSlider, Vector2> OnSliderSyncPositionAction; //Field offset: 0x1B0

	public event Action<SliderDestinationType> OnSliderBeginAnimationAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Action<SliderDestinationType> OnSliderEndAnimationAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Action<LevelSlider, Vector2> OnSliderSyncPositionAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public LevelSlider() { }

	[CompilerGenerated]
	public void add_OnSliderBeginAnimationAction(Action<SliderDestinationType> value) { }

	[CompilerGenerated]
	public void add_OnSliderEndAnimationAction(Action<SliderDestinationType> value) { }

	[CompilerGenerated]
	public void add_OnSliderSyncPositionAction(Action<LevelSlider, Vector2> value) { }

	protected virtual void Awake() { }

	private void CheckIfSlideAtEndPoints() { }

	public void ForceClick() { }

	public void ForceSlideToMax() { }

	public void ForceSlideToMin() { }

	public float GetMaxY() { }

	public float GetMinY() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public float GetVerticalPosition() { }

	private void Init() { }

	public bool IsExactlyAtMax() { }

	public bool IsExactlyAtMin() { }

	public virtual void OnBeginDrag(PointerEventData eventData) { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	public virtual void OnDrag(PointerEventData eventData) { }

	public virtual void OnEndDrag(PointerEventData eventData) { }

	public virtual void OnPointerClick(PointerEventData eventData) { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	protected void OnSliderSyncPosition(Vector2 position) { }

	protected virtual void OnSyncPosition(Vector2 pointerPosition) { }

	private void PerformClickAction() { }

	private void PlaySound() { }

	[CompilerGenerated]
	public void remove_OnSliderBeginAnimationAction(Action<SliderDestinationType> value) { }

	[CompilerGenerated]
	public void remove_OnSliderEndAnimationAction(Action<SliderDestinationType> value) { }

	[CompilerGenerated]
	public void remove_OnSliderSyncPositionAction(Action<LevelSlider, Vector2> value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

