namespace PWC.LevelPhone;

public class ContactsContent : ApplicationContentBase
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<ContactsPage> <>9__40_0; //Field offset: 0x8
		public static Action<ContactsPage> <>9__40_1; //Field offset: 0x10
		public static Predicate<Int32> <>9__41_0; //Field offset: 0x18
		public static Predicate<Int32> <>9__41_1; //Field offset: 0x20
		public static Predicate<Int32> <>9__41_2; //Field offset: 0x28
		public static Predicate<Int32> <>9__41_3; //Field offset: 0x30
		public static Predicate<Int32> <>9__42_0; //Field offset: 0x38
		public static Predicate<List`1<Int32>> <>9__44_1; //Field offset: 0x40
		public static Action<ContactsPage> <>9__46_1; //Field offset: 0x48
		public static Action <>9__51_0; //Field offset: 0x50

		private static <>c() { }

		public <>c() { }

		internal void <GetIDs>b__46_1(ContactsPage page) { }

		internal void <OnCompleteSwipeAnimation>b__51_0() { }

		internal bool <OnSetActive>b__40_0(ContactsPage x) { }

		internal void <OnSetActive>b__40_1(ContactsPage page) { }

		internal bool <SelectCategory>b__41_0(int id) { }

		internal bool <SelectCategory>b__41_1(int id) { }

		internal bool <SelectCategory>b__41_2(int id) { }

		internal bool <SelectCategory>b__41_3(int id) { }

		internal bool <SetAvatarCategory>b__44_1(List<Int32> x) { }

		internal bool <SetHumanWithMakerAvatars>b__42_0(int id) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass41_0
	{
		public int id; //Field offset: 0x10

		public <>c__DisplayClass41_0() { }

		internal bool <SelectCategory>b__4(ILevelAvatar x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass43_0
	{
		public bool value; //Field offset: 0x10

		public <>c__DisplayClass43_0() { }

		internal void <OnPhoneEndAnimation>b__0(ContactsPage page) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass44_0
	{
		public bool showArrow; //Field offset: 0x10

		public <>c__DisplayClass44_0() { }

		internal void <SetAvatarCategory>b__2(ContactsArrow arrow) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass45_0
	{
		public ContactsAppPageSwipeType pageSwipeType; //Field offset: 0x10

		public <>c__DisplayClass45_0() { }

		internal void <OnContactsPageSwipe>b__0(ContactsPage page) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass46_0
	{
		public Predicate<Int32> predicate; //Field offset: 0x10
		public ContactsContent <>4__this; //Field offset: 0x18
		public bool allowedToHavePremades; //Field offset: 0x20

		public <>c__DisplayClass46_0() { }

		internal bool <GetIDs>b__0(int id) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass46_1
	{
		public int makerAvatarsCounter; //Field offset: 0x10
		public int maxMakerAvatars; //Field offset: 0x14
		public <>c__DisplayClass46_0 CS$<>8__locals1; //Field offset: 0x18

		public <>c__DisplayClass46_1() { }

		internal bool <GetIDs>b__2(int id) { }

	}

	private const int MAX_CONTACTS_PER_PAGE = 6; //Field offset: 0x0
	public const string FAVORITES_KEY = "Phone_ContactsContent_Favorites"; //Field offset: 0x0
	private const string PAZU_WORLD_CONTACTS_FIRST_TIME_KEY = "PazuWorldContactsFirstTime"; //Field offset: 0x0
	[CompilerGenerated]
	private int <CurrentPageIndex>k__BackingField; //Field offset: 0x34
	[CompilerGenerated]
	private bool <IsAnimatedSeparatorOnce>k__BackingField; //Field offset: 0x38
	[SerializeField]
	private ContactsThumb _contactPrefab; //Field offset: 0x40
	[SerializeField]
	private FTUEUIButton _addButtonFTUE; //Field offset: 0x48
	[SerializeField]
	private List<ContactsAddButton> _addContactButtons; //Field offset: 0x50
	[SerializeField]
	private SerializableDictionaryBase<SpineType, AvatarSpineSkinsManagerBase> _contactSpinePrefabBySpineType; //Field offset: 0x58
	[SerializeField]
	private List<ContactsPage> _pages; //Field offset: 0x60
	[SerializeField]
	private List<ContactsArrow> _arrows; //Field offset: 0x68
	[SerializeField]
	private List<ContactsCategoryButton> _categoryButtons; //Field offset: 0x70
	private bool _didSetupFirstTimeInScene; //Field offset: 0x78
	private ContactsAppPageSwipeType _lastPageSwipeType; //Field offset: 0x7C
	private List<List`1<Int32>> _contactIDsPerPage; //Field offset: 0x80
	private bool _isSetActiveFalseAfterThumbsEndAnimation; //Field offset: 0x88
	private bool _isPageLoading; //Field offset: 0x89
	private AvatarType _avatarType; //Field offset: 0x8C
	private List<Int32> _favorites; //Field offset: 0x90
	private List<Int32> _worldAvatars; //Field offset: 0x98
	private List<Int32> _currentLevelDefaults; //Field offset: 0xA0
	private ContactsCategoryType _lastContactsCategoryTypeSelected; //Field offset: 0xA8
	[CompilerGenerated]
	private bool <IsSelectingCategory>k__BackingField; //Field offset: 0xAC
	[CompilerGenerated]
	private ContactsCategoryButton <SelectedContactsCategoryButton>k__BackingField; //Field offset: 0xB0

	public ContactsThumb ContactPrefab
	{
		 get { } //Length: 8
	}

	public private int CurrentPageIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public bool IsAnimatedSeparatorOnce
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public private bool IsSelectingCategory
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public private ContactsCategoryButton SelectedContactsCategoryButton
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public ContactsContent() { }

	[CompilerGenerated]
	private void <Awake>b__38_0(ContactsAddButton x) { }

	[CompilerGenerated]
	private void <SetAvatarCategory>b__44_0(ContactsPage page) { }

	[CompilerGenerated]
	private void <SetAvatarCategory>b__44_3() { }

	[CompilerGenerated]
	private void <SetAvatarCategory>b__44_4() { }

	protected virtual void Awake() { }

	public void DownArrow() { }

	public void EnsureFavorites() { }

	public void EnsureLevelDefaults() { }

	private void EnsureWorldAvatars() { }

	public ContactsThumb get_ContactPrefab() { }

	[CompilerGenerated]
	public int get_CurrentPageIndex() { }

	[CompilerGenerated]
	public bool get_IsAnimatedSeparatorOnce() { }

	[CompilerGenerated]
	public bool get_IsSelectingCategory() { }

	[CompilerGenerated]
	public ContactsCategoryButton get_SelectedContactsCategoryButton() { }

	public AvatarType GetAvatarType() { }

	public List<Int32> GetContactsForCurrentPageIndex() { }

	public AvatarSpineSkinsManagerBase GetContactSpinePrefab(SpineType spineType) { }

	private void GetIDs(List<Int32> overrideIds = null, Predicate<Int32> predicate = null, bool allowedToHavePremades = false) { }

	public bool GetIsInFavorites(int id) { }

	public static bool IsContactsFirstTime() { }

	protected virtual void OnApplicationEndAnimation(bool value) { }

	protected virtual void OnBackButtonClick() { }

	public void OnCompleteSwipeAnimation() { }

	private void OnContactsPageSwipe(ContactsAppPageSwipeType pageSwipeType) { }

	private void OnContactsThumbEndAnimation(bool value) { }

	protected virtual void OnDestroy() { }

	private void OnPhoneEndAnimation(bool value) { }

	protected virtual void OnSetActive(bool value) { }

	public void SelectCategory(ContactsCategoryButton button) { }

	[CompilerGenerated]
	private void set_CurrentPageIndex(int value) { }

	[CompilerGenerated]
	public void set_IsAnimatedSeparatorOnce(bool value) { }

	[CompilerGenerated]
	private void set_IsSelectingCategory(bool value) { }

	[CompilerGenerated]
	private void set_SelectedContactsCategoryButton(ContactsCategoryButton value) { }

	public void SetAvatarCategory(AvatarType avatarType, List<Int32> overrideIds = null, Predicate<Int32> predicate = null, bool initPages = true, bool allowedToHavePremades = false) { }

	public static void SetContactsFirstTime() { }

	private void SetHumanWithMakerAvatars(bool initPages) { }

	public void SetIsInFavorites(int id, bool isInFavorites) { }

	private bool TrySpecificTimerCondition() { }

	public void UpArrow() { }

}

