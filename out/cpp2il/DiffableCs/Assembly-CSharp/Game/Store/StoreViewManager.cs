namespace Game.Store;

public class StoreViewManager : StoreViewManagerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass30_0
	{
		public Action onBeforeLoadSceneAction; //Field offset: 0x10

		public <>c__DisplayClass30_0() { }

		internal void <Show>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass45_0
	{
		public StoreViewManager <>4__this; //Field offset: 0x10
		public Nullable<Int32> focusOnItemIndex; //Field offset: 0x18
		public float scrollPosition; //Field offset: 0x20
		public Action<StorePackItemBase> onFocusAction; //Field offset: 0x28

		public <>c__DisplayClass45_0() { }

		internal void <ShowGroup>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass45_1
	{
		public Item itemData; //Field offset: 0x10

		public <>c__DisplayClass45_1() { }

		internal bool <ShowGroup>b__1(MonoBehaviour x) { }

	}

	[CompilerGenerated]
	private struct <>c__DisplayClass46_0
	{
		public StoreViewManager <>4__this; //Field offset: 0x0
		public int itemIndex; //Field offset: 0x8
		public Action<StorePackItemBase> onFocusAction; //Field offset: 0x10

	}

	[CompilerGenerated]
	private static StoreViewManager <Instance>k__BackingField; //Field offset: 0x0
	public static Action<StoreCategoryItem> OnCategoryItemSelectedAction; //Field offset: 0x8
	[SerializeField]
	private Transform _categoryItemsParent; //Field offset: 0x60
	[SerializeField]
	private Transform _subcategoryItemsParent; //Field offset: 0x68
	[SerializeField]
	private Transform _packItemsParent; //Field offset: 0x70
	[SerializeField]
	private StoreCategoryItem _categoryItemPrefab; //Field offset: 0x78
	[SerializeField]
	private StoreSubcategoryItem _subcategoryItemPrefab; //Field offset: 0x80
	[SerializeField]
	private Canvas _canvas; //Field offset: 0x88
	[SerializeField]
	private ScrollRect _ItemsScrollRect; //Field offset: 0x90
	[SerializeField]
	private GameObject _itemsMainParent; //Field offset: 0x98
	[SerializeField]
	private GameObject _categoriesMainParent; //Field offset: 0xA0
	private List<MonoBehaviour> _packItems; //Field offset: 0xA8
	private readonly Dictionary<String, StoreCategoryItem> _categoryItems; //Field offset: 0xB0
	private readonly Dictionary<String, StoreSubcategoryItem> _subcategoryItems; //Field offset: 0xB8
	private StoreCategoryItem _selectedCategoryItem; //Field offset: 0xC0
	private StoreSubcategoryItem _selectedSubcategoryItem; //Field offset: 0xC8
	private StoreCategoryItem _promotionCategoryItem; //Field offset: 0xD0
	private readonly Dictionary<Int32, Single> _scrollPositions; //Field offset: 0xD8
	private Nullable<Int32> _defaultItemsLayoutGroupPadding; //Field offset: 0xE0
	private GameObject _categoryBackground; //Field offset: 0xE8

	public int CurrentSelectedCategoryIndex
	{
		 get { } //Length: 128
	}

	public int CurrentSelectedSubcategoryIndex
	{
		 get { } //Length: 128
	}

	public private static StoreViewManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public StoreViewManager() { }

	[CompilerGenerated]
	private void <FocusOnItem>g__SelectItemInGroup|46_0(Group group, int groupIndex, ref <>c__DisplayClass46_0 unnamed_param_2) { }

	protected virtual void Awake() { }

	private void ClearSubcategories() { }

	public void FocusOnItem(int itemIndex, Action<StorePackItemBase> onFocusAction = null) { }

	public int get_CurrentSelectedCategoryIndex() { }

	public int get_CurrentSelectedSubcategoryIndex() { }

	[CompilerGenerated]
	public static StoreViewManager get_Instance() { }

	private Sprite GetCategoryButtonSprite(string categoryKey, string state) { }

	private Sprite GetSubcategoryButtonSprite(string categoryKey) { }

	protected virtual void Init() { }

	protected virtual void OnBackButtonClickImplement() { }

	protected virtual void OnCloseWindow() { }

	protected virtual void OnDestroy() { }

	protected virtual void OnShowWindow() { }

	private void RefreshCategoryBackground(Group group) { }

	public void SelectCategoryItem(StoreCategoryItem categoryItem, Nullable<Int32> focusOnItemIndex = null, Action<StorePackItemBase> onFocusAction = null) { }

	public void SelectSubcategoryItem(StoreSubcategoryItem subcategoryItem, Nullable<Int32> focusOnItemIndex = null, Action<StorePackItemBase> onFocusAction = null) { }

	[CompilerGenerated]
	private static void set_Instance(StoreViewManager value) { }

	private void SetPackItemsLeftPaddingForSubcategories(bool isSubcategoriesVisible) { }

	public static void Show(Action onBeforeLoadSceneAction = null) { }

	private void ShowGroup(string groupKey, Action<StorePackItemBase> onFocusAction = null) { }

	private void ShowGroup(int groupIndex, Nullable<Int32> focusOnItemIndex = null, bool updateScrollPosition = true, Action<StorePackItemBase> onFocusAction = null) { }

	private static void ShowImplement() { }

	protected virtual void ShowStoreScene() { }

	private void ShowSubgroupsMenu(Group group) { }

}

