namespace PWC.Level.Maker;

public class LevelMakerItemsMenu : GameUIElement
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<PrefabData, String> <>9__48_0; //Field offset: 0x8
		public static Func<IGrouping`2<String, PrefabData>, String> <>9__48_1; //Field offset: 0x10
		public static Func<PrefabData, Single> <>9__58_0; //Field offset: 0x18
		public static Func<PrefabData, Single> <>9__58_1; //Field offset: 0x20
		public static Func<LevelMakerCreateItemButtonBase, Single> <>9__59_0; //Field offset: 0x28
		public static Func<LevelMakerCreateItemButtonBase, Single> <>9__59_1; //Field offset: 0x30

		private static <>c() { }

		public <>c() { }

		internal float <CreateDefaultSortedListAsCopy>b__58_0(PrefabData x) { }

		internal float <CreateDefaultSortedListAsCopy>b__58_1(PrefabData x) { }

		internal string <ShowSubCategory>b__48_0(PrefabData x) { }

		internal string <ShowSubCategory>b__48_1(IGrouping<String, PrefabData> x) { }

		internal float <SortItemsList>b__59_0(LevelMakerCreateItemButtonBase x) { }

		internal float <SortItemsList>b__59_1(LevelMakerCreateItemButtonBase x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass46_0
	{
		public LevelMakerItemsMenu <>4__this; //Field offset: 0x10
		public Node category; //Field offset: 0x18
		public bool shouldSyncCategoriesPanelOnClick; //Field offset: 0x20

		public <>c__DisplayClass46_0() { }

		internal void <TrySpawnCategoryButton>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass47_0
	{
		public LevelMakerItemsMenu <>4__this; //Field offset: 0x10
		public Node category; //Field offset: 0x18

		public <>c__DisplayClass47_0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass47_1
	{
		public string packName; //Field offset: 0x10
		public NewIndicatorType newIndicatorType; //Field offset: 0x18
		public <>c__DisplayClass47_0 CS$<>8__locals1; //Field offset: 0x20

		public <>c__DisplayClass47_1() { }

		internal void <SyncCategoriesPanel>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass49_0
	{
		public string section; //Field offset: 0x10
		public LevelMakerItemsMenu <>4__this; //Field offset: 0x18

		public <>c__DisplayClass49_0() { }

		internal void <CreateItemsSectionsAndClickOnFirstOne>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass50_0
	{
		public string itemsSection; //Field offset: 0x10

		public <>c__DisplayClass50_0() { }

		internal bool <ShowItemsSection>b__0(PrefabData x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass57_0
	{
		public string subcategoryName; //Field offset: 0x10

		public <>c__DisplayClass57_0() { }

		internal bool <TryGetCategoriesPathListForSubcategory>b__0(Node x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass64_0
	{
		public LevelMakerItemsMenu <>4__this; //Field offset: 0x10
		public Node category; //Field offset: 0x18

		public <>c__DisplayClass64_0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass64_1
	{
		public string packName; //Field offset: 0x10
		public <>c__DisplayClass64_0 CS$<>8__locals1; //Field offset: 0x18

		public <>c__DisplayClass64_1() { }

		internal void <ShowCategory>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass64_2
	{
		public Node iNode; //Field offset: 0x10
		public <>c__DisplayClass64_0 CS$<>8__locals2; //Field offset: 0x18

		public <>c__DisplayClass64_2() { }

		internal void <ShowCategory>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <CreateItemsWithIntervalsCoroutine>d__56 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelMakerItemsMenu <>4__this; //Field offset: 0x20
		public List<PrefabData> prefabDatas; //Field offset: 0x28
		private MultisizeItemGrid <grid>5__2; //Field offset: 0x30
		private float <sizeFactor>5__3; //Field offset: 0x38
		private int <i>5__4; //Field offset: 0x3C

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <CreateItemsWithIntervalsCoroutine>d__56(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	internal enum SortingType
	{
		None = 0,
		LayoutFromFile = 1,
		ASC = 2,
		DESC = 3,
	}

	private static readonly HashSet<DataType> _newPacksMarked; //Field offset: 0x0
	[CompilerGenerated]
	private static LevelMakerItemsMenu <Instance>k__BackingField; //Field offset: 0x8
	public static Action<Boolean> OnSetVisibleAction; //Field offset: 0x10
	[SerializeField]
	private GameObject _view; //Field offset: 0x28
	[SerializeField]
	private RectTransform _openMenuButton; //Field offset: 0x30
	[SerializeField]
	private ScrollRect _itemsScrollRect; //Field offset: 0x38
	[SerializeField]
	private RectTransform _itemsScrollRectParent; //Field offset: 0x40
	[SerializeField]
	private RectTransform _categoriesScrollRectParent; //Field offset: 0x48
	[SerializeField]
	private RectTransform _itemsSectionsParent; //Field offset: 0x50
	[SerializeField]
	private RectTransform _itemsParent; //Field offset: 0x58
	[SerializeField]
	private RectTransform _categoriesParent; //Field offset: 0x60
	[SerializeField]
	private LevelMakerSmallCategoryButton _smallCategoryButtonPrefab; //Field offset: 0x68
	[SerializeField]
	private LevelMakerCreateItemButtonBase _itemPrefab; //Field offset: 0x70
	[SerializeField]
	private LevelMakerCategoryButton _categoryButtonPrefab; //Field offset: 0x78
	[SerializeField]
	private LevelMakerItemsSectionButton _itemsSectionButtonPrefab; //Field offset: 0x80
	[SerializeField]
	private GameObject _backButton; //Field offset: 0x88
	[SerializeField]
	private GameObject _sortingItemsPanel; //Field offset: 0x90
	[SerializeField]
	private Image _categoryTitle; //Field offset: 0x98
	[SerializeField]
	private Image _categoryIcon; //Field offset: 0xA0
	[SerializeField]
	private Sprite _noCategorySelectedIcon; //Field offset: 0xA8
	[SerializeField]
	private Sprite _noCategorySelectedTitle; //Field offset: 0xB0
	[SerializeField]
	private DataType _itemsDataType; //Field offset: 0xB8
	private LevelMakerItemsCategoriesData _itemsCategoriesData; //Field offset: 0xC0
	private string _insideSubcategory; //Field offset: 0xC8
	private Node _insideCategory; //Field offset: 0xD0
	private Coroutine _createItemsCoroutine; //Field offset: 0xD8
	private int _currentAvailableSortingTypesIndex; //Field offset: 0xE0
	private readonly List<SortingType> _currentAvailableSortingTypes; //Field offset: 0xE8
	private readonly List<LevelMakerCreateItemButtonBase> _currentItems; //Field offset: 0xF0
	private bool isFirstOpenInLevel; //Field offset: 0xF8

	public private static LevelMakerItemsMenu Instance
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		private set { } //Length: 96
	}

	private static LevelMakerItemsMenu() { }

	public LevelMakerItemsMenu() { }

	[CompilerGenerated]
	private void <ShowTopCategoriesPanel>g__SetTop|60_0(float value) { }

	private void Awake() { }

	private bool CanShowPack(string packPrefabGuid) { }

	private void ClearChildren(Transform root) { }

	private void ClearCurrentItems() { }

	private void ClearNormalGridLayoutGroup() { }

	private List<PrefabData> CreateDefaultSortedListAsCopy(List<PrefabData> prefabDatas, bool isFromBigToSmall) { }

	private void CreateItemsFromCategoryWithIntervals(CategoryData categoryData) { }

	private void CreateItemsSectionsAndClickOnFirstOne(List<String> sections) { }

	private void CreateItemsWithIntervals(List<PrefabData> prefabDatas) { }

	[IteratorStateMachine(typeof(<CreateItemsWithIntervalsCoroutine>d__56))]
	private IEnumerator CreateItemsWithIntervalsCoroutine(List<PrefabData> prefabDatas) { }

	private bool DoesNodeContainsNewPackForUser(AllData data, Node node, DataType dataType, int recursiveCallsCounter = 0) { }

	[CompilerGenerated]
	public static LevelMakerItemsMenu get_Instance() { }

	public RectTransform GetOpenMenuButton() { }

	public float GetPanelWorldWidth() { }

	private float GetSizeFactorForMultisizeItemGrid() { }

	public void Hide() { }

	private void InitNormalGridLayoutGroup(Vector2 cellSize) { }

	public bool IsVisible() { }

	public void OnBackButtonClick() { }

	public void OnCloseButtonClick() { }

	private void OnDestroy() { }

	private void OnItemsMenuButtonClick() { }

	private void OnSplitLevelModeChange(bool value) { }

	public void OnToggleItemsSortingButtonClick() { }

	[CompilerGenerated]
	private static void set_Instance(LevelMakerItemsMenu value) { }

	public void Show() { }

	public void ShowCategory(Node category, bool shouldSyncCategoriesPanel) { }

	public void ShowItemsSection(string itemsSection) { }

	public void ShowSubCategory(Node category, string subCategoryName, bool shouldSyncCategoriesPanel) { }

	private void ShowTopCategoriesPanel(bool show) { }

	public void ShowTopMenu(bool needsToClearCurrentItems = true) { }

	private void SortItemsList(List<LevelMakerCreateItemButtonBase> list, bool isFromBigToSmall) { }

	private void SyncCategoriesPanel(Node category, string subCategoryName) { }

	private void ToggleView() { }

	public bool TryGetCategoriesPathListForSubcategory(string subcategoryName, out Node category) { }

	private bool TrySpawnCategoryButton(AllData data, Node category, bool isSmallPanel, List<String> packNames, Transform parent, LevelMakerCategoryButton prefab, bool shouldSyncCategoriesPanelOnClick, out LevelMakerCategoryButton instance, float itemSizeFactor = 1) { }

}

