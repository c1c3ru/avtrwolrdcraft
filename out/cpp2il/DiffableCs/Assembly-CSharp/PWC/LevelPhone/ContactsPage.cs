namespace PWC.LevelPhone;

public class ContactsPage : GameUIElement, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<ContactsThumb> <>9__27_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <HasActiveContacts>b__27_0(ContactsThumb x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass28_0
	{
		public bool isAnimate; //Field offset: 0x10

		public <>c__DisplayClass28_0() { }

		internal void <ResetContacts>b__0(ContactsThumb contact) { }

	}

	[CompilerGenerated]
	private static Action<ContactsAppPageSwipeType> OnContactsPageSwipeAction; //Field offset: 0x0
	private const float SWIPE_THRESHOLD = 300; //Field offset: 0x0
	[SerializeField]
	private VerticalLayoutGroup _verticalLayoutGroup; //Field offset: 0x28
	[SerializeField]
	private GameObject _addButton; //Field offset: 0x30
	[SerializeField]
	private GridLayoutGroup _makerGrid; //Field offset: 0x38
	[SerializeField]
	private LayoutElement _premadeSeparator; //Field offset: 0x40
	[SerializeField]
	private GridLayoutGroup _premadeGrid; //Field offset: 0x48
	private RectTransform _rectTransform; //Field offset: 0x50
	private ContactsContent _contentMenu; //Field offset: 0x58
	private ContactsAppPagePositionType _currentPagePositionType; //Field offset: 0x60
	private List<ContactsThumb> _contacts; //Field offset: 0x68
	private bool _isInteractable; //Field offset: 0x70
	private bool _isBothCategories; //Field offset: 0x71
	private int _addButtonScaleTweenID; //Field offset: 0x74
	private List<Int32> _currentPageIDs; //Field offset: 0x78
	private AvatarType _avatarType; //Field offset: 0x80

	public static event Action<ContactsAppPageSwipeType> OnContactsPageSwipeAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public ContactsPage() { }

	[CompilerGenerated]
	private void <AnimatePremadeSeperator>b__25_0(float height) { }

	[CompilerGenerated]
	private void <AnimateSwipe>b__23_0(float value) { }

	[CompilerGenerated]
	private void <AnimateSwipe>b__23_1(float value) { }

	[CompilerGenerated]
	private void <AnimateSwipe>b__23_2() { }

	[CompilerGenerated]
	private bool <GetContactsIfNeeded>b__26_1(int id) { }

	[CompilerGenerated]
	private bool <GetContactsIfNeeded>b__26_2(int id) { }

	[CompilerGenerated]
	private bool <GetContactsIfNeeded>g__IsProperAvatarType|26_0(int id) { }

	[CompilerGenerated]
	public static void add_OnContactsPageSwipeAction(Action<ContactsAppPageSwipeType> value) { }

	private void AddButtonSetActive() { }

	private void AnimatePremadeSeperator(bool value, bool isSnap = false) { }

	private void AnimateSwipe(ContactsAppPagePositionType desiredPagePositionType, bool isInstant) { }

	private void Awake() { }

	public void GetContactsIfNeeded() { }

	public bool HasActiveContacts() { }

	public void Init(ContactsContent content) { }

	public bool IsLastContactInPage(int id) { }

	public override void OnBeginDrag(PointerEventData eventData) { }

	public override void OnDrag(PointerEventData eventData) { }

	public override void OnEndDrag(PointerEventData eventData) { }

	public void PrepareForSwipe(ContactsAppPageSwipeType pageSwipeType) { }

	[CompilerGenerated]
	public static void remove_OnContactsPageSwipeAction(Action<ContactsAppPageSwipeType> value) { }

	public void ResetContacts(bool isAnimate) { }

	public void SetEmpty() { }

}

