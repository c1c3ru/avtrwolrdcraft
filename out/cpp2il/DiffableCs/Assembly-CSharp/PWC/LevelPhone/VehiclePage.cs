namespace PWC.LevelPhone;

public class VehiclePage : GameUIElement, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<VehicleThumb> <>9__38_0; //Field offset: 0x8
		public static Action<VehicleThumb> <>9__38_1; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal void <ResetVehicles>b__38_0(VehicleThumb vehicle) { }

		internal void <ResetVehicles>b__38_1(VehicleThumb vehicle) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass38_0
	{
		public VehicleThumb vehicle; //Field offset: 0x10

		public <>c__DisplayClass38_0() { }

		internal void <ResetVehicles>b__2() { }

	}

	[CompilerGenerated]
	private static Action<ContactsAppPageSwipeType> OnVehiclesPageSwipeAction; //Field offset: 0x0
	private const int EMPTY_PAGE_PADDING_TOP = 180; //Field offset: 0x0
	private const float PAGE_SPACING = 5; //Field offset: 0x0
	private const int PAGE_PADDING_TOP = 140; //Field offset: 0x0
	private const int FULL_PAGE_PADDING_TOP = 160; //Field offset: 0x0
	private const float THUMB_DELAY_PER_SLOT = 0,05; //Field offset: 0x0
	private const float ADD_BUTTON_SCALE_TIME = 0,15; //Field offset: 0x0
	private const float FULL_PAGE_SPACING = 45; //Field offset: 0x0
	private const float SWIPE_THRESHOLD = 300; //Field offset: 0x0
	[CompilerGenerated]
	private static Action OnSyncVehiclePhoneStateAction; //Field offset: 0x8
	[SerializeField]
	private VerticalLayoutGroup _verticalLayoutGroup; //Field offset: 0x28
	[SerializeField]
	private GameObject _addButton; //Field offset: 0x30
	[SerializeField]
	private VerticalLayoutGroup _makerGrid; //Field offset: 0x38
	[SerializeField]
	private float _emptyPageAddButtonScale; //Field offset: 0x40
	private RectTransform _rectTransform; //Field offset: 0x48
	private int _addButtonScaleTweenID; //Field offset: 0x50
	private VehicleContent _content; //Field offset: 0x58
	private ContactsAppPagePositionType _currentPagePositionType; //Field offset: 0x60
	private List<VehicleThumb> _vehicles; //Field offset: 0x68
	private bool _isInteractable; //Field offset: 0x70
	private List<Int32> _currentPageIDs; //Field offset: 0x78

	public static event Action OnSyncVehiclePhoneStateAction
	{
		[CompilerGenerated]
		 add { } //Length: 188
		[CompilerGenerated]
		 remove { } //Length: 188
	}

	public static event Action<ContactsAppPageSwipeType> OnVehiclesPageSwipeAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public VehiclePage() { }

	[CompilerGenerated]
	private void <AnimateSwipe>b__33_0(float value) { }

	[CompilerGenerated]
	private void <AnimateSwipe>b__33_1(float value) { }

	[CompilerGenerated]
	private void <AnimateSwipe>b__33_2() { }

	[CompilerGenerated]
	public static void add_OnSyncVehiclePhoneStateAction(Action value) { }

	[CompilerGenerated]
	public static void add_OnVehiclesPageSwipeAction(Action<ContactsAppPageSwipeType> value) { }

	public void AddButtonSetActive() { }

	private void AnimateAddButtonScale(bool isVisible, bool isAnimate = true) { }

	private void AnimateSwipe(ContactsAppPagePositionType desiredPagePositionType, bool isInstant) { }

	private void Awake() { }

	private float GetAddButtonScale() { }

	public void GetVehiclesIfNeeded() { }

	public void Init(VehicleContent content) { }

	public override void OnBeginDrag(PointerEventData eventData) { }

	public override void OnDrag(PointerEventData eventData) { }

	public override void OnEndDrag(PointerEventData eventData) { }

	public void PrepareForSwipe(ContactsAppPageSwipeType pageSwipeType) { }

	[CompilerGenerated]
	public static void remove_OnSyncVehiclePhoneStateAction(Action value) { }

	[CompilerGenerated]
	public static void remove_OnVehiclesPageSwipeAction(Action<ContactsAppPageSwipeType> value) { }

	public void ResetVehicles(bool isAnimate) { }

	public void SetEmpty() { }

	private void SyncGridSpacing(int cars, bool hasAddButton) { }

	private void SyncPageAlignment(int usedSlots) { }

	public void UpdatePhoneState() { }

}

