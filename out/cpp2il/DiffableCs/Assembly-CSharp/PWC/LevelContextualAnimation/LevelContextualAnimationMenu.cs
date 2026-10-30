namespace PWC.LevelContextualAnimation;

public class LevelContextualAnimationMenu : GameUIElement, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<LevelCAHandlerBase> <>9__64_1; //Field offset: 0x8
		public static Predicate<LevelContextualAnimationItem> <>9__77_0; //Field offset: 0x10
		public static Predicate<LevelContextualAnimationPanelCircle> <>9__77_2; //Field offset: 0x18
		public static Func<CACategoryType, Boolean> <>9__96_0; //Field offset: 0x20

		private static <>c() { }

		public <>c() { }

		internal bool <.ctor>b__96_0(CACategoryType x) { }

		internal bool <GetPanelLength>b__77_0(LevelContextualAnimationItem animationItem) { }

		internal bool <GetPanelLength>b__77_2(LevelContextualAnimationPanelCircle circle) { }

		internal bool <OnTargetUpdateCAList>b__64_1(LevelCAHandlerBase x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass73_0
	{
		public LevelContextualAnimationMenu <>4__this; //Field offset: 0x10
		public int localCallCounter; //Field offset: 0x18
		public bool isImmediateInternal; //Field offset: 0x1C
		public Action onCompleteAction; //Field offset: 0x20
		public Action <>9__5; //Field offset: 0x28
		public Action <>9__4; //Field offset: 0x30

		public <>c__DisplayClass73_0() { }

		internal void <AnimatePanel>b__0() { }

		internal void <AnimatePanel>b__1() { }

		internal void <AnimatePanel>b__2() { }

		internal void <AnimatePanel>b__4() { }

		internal void <AnimatePanel>b__5() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass73_1
	{
		public Vector2 sizeDelta; //Field offset: 0x10
		public <>c__DisplayClass73_0 CS$<>8__locals1; //Field offset: 0x18

		public <>c__DisplayClass73_1() { }

		internal void <AnimatePanel>b__3(float width) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass77_0
	{
		public float thumbslength; //Field offset: 0x10
		public float circlesLength; //Field offset: 0x14

		public <>c__DisplayClass77_0() { }

		internal void <GetPanelLength>b__1(LevelContextualAnimationItem animationItem) { }

		internal void <GetPanelLength>b__3(LevelContextualAnimationPanelCircle circle) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass91_0
	{
		public Vector2 sizeDelta; //Field offset: 0x10
		public LevelContextualAnimationMenu <>4__this; //Field offset: 0x18

		public <>c__DisplayClass91_0() { }

		internal void <Swipe>b__1(float width) { }

	}

	internal class Page
	{
		public LevelContextualAnimationMenu menu; //Field offset: 0x10
		public LevelCAHandlerBase caHandler; //Field offset: 0x18
		public List<LevelCAConfig> items; //Field offset: 0x20

		public Page(LevelContextualAnimationMenu menu, LevelCAHandlerBase caHandler) { }

	}

	[CompilerGenerated]
	private static Action OnAnimationMenuOpenAction; //Field offset: 0x0
	private const float SWIPE_THRESHOLD = 1; //Field offset: 0x0
	private const string MORE_THAN_ONE_PAGE_FTUE_PLAYER_PREFS_KEY = "LevelContextualAnimationMenuMoreThanOnePageFTUEKey"; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<Page> OnAnimationPageTurnedAction; //Field offset: 0x8
	[CompilerGenerated]
	private static LevelContextualAnimationMenu <Instance>k__BackingField; //Field offset: 0x10
	[SerializeField]
	private GameObject _button; //Field offset: 0x28
	[SerializeField]
	private GameObject _categoryButton; //Field offset: 0x30
	[SerializeField]
	private GameObject _indication; //Field offset: 0x38
	[SerializeField]
	private Image _thumb; //Field offset: 0x40
	[SerializeField]
	private Image _categoryThumb; //Field offset: 0x48
	[SerializeField]
	private RectTransform _panel; //Field offset: 0x50
	[SerializeField]
	private HorizontalLayoutGroup _circlesLayoutGroup; //Field offset: 0x58
	[SerializeField]
	private HorizontalLayoutGroup _animationItemsLayoutGroup; //Field offset: 0x60
	[SerializeField]
	private LevelContextualAnimationPanelCircle _circlePrefab; //Field offset: 0x68
	[SerializeField]
	private List<LevelContextualAnimationItem> _animationItems; //Field offset: 0x70
	[SerializeField]
	private string _clickSoundName; //Field offset: 0x78
	private bool _animateFTUE; //Field offset: 0x80
	private int _thumbTweenID; //Field offset: 0x84
	private int _buttonScaleTweenID; //Field offset: 0x88
	private int _buttonRotateTweenID; //Field offset: 0x8C
	private int _panelValueTweenID; //Field offset: 0x90
	private int _panelDelayedCallTweenID; //Field offset: 0x94
	private int _circlesScaleTweenID; //Field offset: 0x98
	private bool _isOpen; //Field offset: 0x9C
	private bool _isActive; //Field offset: 0x9D
	private bool _isImmediate; //Field offset: 0x9E
	private bool _isInteractable; //Field offset: 0x9F
	private Image _panelImage; //Field offset: 0xA0
	private Sprite _defaultPanelSprite; //Field offset: 0xA8
	private LevelCAHandlerBase _currentAnimationHandler; //Field offset: 0xB0
	private IReadOnlyList<LevelCAHandlerBase> _currentHandlers; //Field offset: 0xB8
	private readonly List<Page> _animationPages; //Field offset: 0xC0
	private readonly List<LevelContextualAnimationPanelCircle> _circles; //Field offset: 0xC8
	private ICATarget _selectedTarget; //Field offset: 0xD0
	private int _animatePanelCallsCounter; //Field offset: 0xD8
	private Camera _camera; //Field offset: 0xE0
	private readonly CACategoryType[] _categoryTypes; //Field offset: 0xE8
	private List<CACategoryType> _dynamicCategoryTypes; //Field offset: 0xF0
	private readonly Dictionary<CACategoryType, List`1<LevelCAHandlerBase>> _handlersByCategories; //Field offset: 0xF8
	[CompilerGenerated]
	private bool <IsPanelAnimationInProgress>k__BackingField; //Field offset: 0x100

	public static event Action OnAnimationMenuOpenAction
	{
		[CompilerGenerated]
		 add { } //Length: 184
		[CompilerGenerated]
		 remove { } //Length: 184
	}

	public static event Action<Page> OnAnimationPageTurnedAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public private static LevelContextualAnimationMenu Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public private bool IsPanelAnimationInProgress
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public ICATarget SelectedTarget
	{
		 get { } //Length: 8
	}

	public LevelContextualAnimationMenu() { }

	[CompilerGenerated]
	private void <AnimateWiggle>b__79_0() { }

	[CompilerGenerated]
	private void <AssignCurrentHandlersAndSetCategoryThumb>g__Add|58_0(CACategoryType categoryType, LevelCAHandlerBase handler) { }

	[CompilerGenerated]
	private bool <InitPages>b__66_0(Page x) { }

	[CompilerGenerated]
	private void <OnTargetSelected>b__62_0() { }

	[CompilerGenerated]
	private void <OnTargetUpdateCAList>g__InitMenuAndShow|64_0() { }

	[CompilerGenerated]
	private void <Swipe>b__91_0() { }

	[CompilerGenerated]
	private void <Swipe>b__91_2() { }

	[CompilerGenerated]
	public static void add_OnAnimationMenuOpenAction(Action value) { }

	[CompilerGenerated]
	public static void add_OnAnimationPageTurnedAction(Action<Page> value) { }

	private void AnimateButtonInOutIfNeeded(bool value) { }

	private void AnimateCircles(bool value, bool isImmediate) { }

	private void AnimateItemsIn(bool isImmediate, out float duration) { }

	private void AnimateItemsOut(bool isImmediate, out float shortestDuration, out float longestDuration) { }

	private void AnimatePanel(Action onCompleteAction = null) { }

	private void AnimateThumb() { }

	private void AnimateWiggle() { }

	private void AssignCurrentHandlersAndSetCategoryThumb() { }

	private void Awake() { }

	public void ForceCloseMenu() { }

	public void ForcePanel(bool value) { }

	[CompilerGenerated]
	public static LevelContextualAnimationMenu get_Instance() { }

	[CompilerGenerated]
	public bool get_IsPanelAnimationInProgress() { }

	public ICATarget get_SelectedTarget() { }

	public int GetMaxAnimationItemsPerPage() { }

	private CACategoryType GetNextCategoryType(CACategoryType categoryType) { }

	private float GetPanelLength() { }

	private void InitAnimations() { }

	private void InitCircles() { }

	private void InitPages() { }

	private void InitWholeMenu() { }

	private bool IsOverrideNext(IReadOnlyList<LevelCAHandlerBase> newHandlers, out CACategoryType nextCategory) { }

	private void OnAfterCharacterSpawn(ILevelAvatar character) { }

	private void OnAnimationItemClick(LevelCAHandlerBase handler, LevelCAConfig animationConfig) { }

	private void OnBeforeDestroyLevelItem(LevelItem levelItem) { }

	public override void OnBeginDrag(PointerEventData eventData) { }

	public void OnButtonClick() { }

	public void OnCategoryButtonClick() { }

	private void OnDestroy() { }

	public override void OnDrag(PointerEventData eventData) { }

	public override void OnEndDrag(PointerEventData eventData) { }

	private void OnPhoneBeginAnimate(bool value) { }

	private void OnTargetSelected(ICATarget target, bool isDrag) { }

	private void OnTargetUpdateCAList(ICATarget target, bool isAdded, bool isSilent) { }

	[CompilerGenerated]
	public static void remove_OnAnimationMenuOpenAction(Action value) { }

	[CompilerGenerated]
	public static void remove_OnAnimationPageTurnedAction(Action<Page> value) { }

	[CompilerGenerated]
	private static void set_Instance(LevelContextualAnimationMenu value) { }

	[CompilerGenerated]
	private void set_IsPanelAnimationInProgress(bool value) { }

	private void SetCategoryButton(CATargetStateHandler stateHandler, CACategoryType categoryType) { }

	public void SetCategoryButtonByType(CACategoryType categoryType, ICATarget target) { }

	private void SetCategoryThumbSprite(CACategoryType categoryType) { }

	private void SetCurrentPageIndex(int index) { }

	private void SetDesiredCircleSelected() { }

	private void SetPanelSprite() { }

	private void SetThumbSprite() { }

	private void SetThumbSpriteForCAHandler(LevelCAHandlerBase caHandler, Image thumb) { }

	private void Swipe() { }

	private bool TryGetCATargetStateHandler(out CATargetStateHandler stateHandler) { }

	private bool TryGetCATargetStateHandler(ICATarget target, out CATargetStateHandler stateHandler) { }

	private void UpdateNewAnimationsIndication() { }

}

