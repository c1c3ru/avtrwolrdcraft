namespace PWC.AvatarMaker;

public class AvatarMakerCategoriesManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<AvatarMakerSubcategory> <>9__30_2; //Field offset: 0x8
		public static Action<AvatarMakerSubcategory> <>9__30_3; //Field offset: 0x10
		public static Action<AvatarMakerSubcategory> <>9__30_9; //Field offset: 0x18

		private static <>c() { }

		public <>c() { }

		internal void <AnimateSubcategories>b__30_2(AvatarMakerSubcategory subcategory) { }

		internal void <AnimateSubcategories>b__30_3(AvatarMakerSubcategory subcategory) { }

		internal void <AnimateSubcategories>b__30_9(AvatarMakerSubcategory subcategory) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass30_0
	{
		public AvatarMakerCategoriesManager <>4__this; //Field offset: 0x10
		public bool isParentCategory; //Field offset: 0x18
		public Vector2 currentAnchoredPosition; //Field offset: 0x1C
		public Func<SubcategoryData, Boolean> <>9__7; //Field offset: 0x28
		public Action<Object> <>9__4; //Field offset: 0x30
		public Action <>9__5; //Field offset: 0x38

		public <>c__DisplayClass30_0() { }

		internal void <AnimateSubcategories>b__0(object anchoredPosition) { }

		internal void <AnimateSubcategories>b__1() { }

		internal void <AnimateSubcategories>b__4(object anchoredPosition) { }

		internal void <AnimateSubcategories>b__5() { }

		internal bool <AnimateSubcategories>b__7(SubcategoryData subcategoryData) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass30_1
	{
		public HashSet<Int32> categoriesHash; //Field offset: 0x10
		public <>c__DisplayClass30_0 CS$<>8__locals1; //Field offset: 0x18

		public <>c__DisplayClass30_1() { }

		internal bool <AnimateSubcategories>b__6(SubcategoryData subcategoryData) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass30_2
	{
		public int defaultIndex; //Field offset: 0x10
		public <>c__DisplayClass30_1 CS$<>8__locals2; //Field offset: 0x18

		public <>c__DisplayClass30_2() { }

		internal void <AnimateSubcategories>b__8() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass31_0
	{
		public int defaultCategoryType; //Field offset: 0x10

		public <>c__DisplayClass31_0() { }

		internal bool <GetDefaultSubcategoryIndex>b__0(SubcategoryData subcategoryData) { }

	}

	private const float SUBCATEGORIES_ANIMATION_SPEED = 1000; //Field offset: 0x0
	[CompilerGenerated]
	private int <CurrentCategoryType>k__BackingField; //Field offset: 0x20
	[SerializeField]
	private List<AvatarMakerSubcategory> _subcategories; //Field offset: 0x28
	[SerializeField]
	private AvatarMakerCategory _categoryPrefab; //Field offset: 0x30
	[SerializeField]
	private Transform _categoriesParent; //Field offset: 0x38
	[SerializeField]
	private RectTransform _subcategoriesParent; //Field offset: 0x40
	[SerializeField]
	private RectTransform _expnansionPackCategoriesParent; //Field offset: 0x48
	[SerializeField]
	private RectTransform _expansionPackCategoriesArea; //Field offset: 0x50
	[SerializeField]
	private GameObject _subcategoriesArea; //Field offset: 0x58
	[SerializeField]
	private GridLayoutGroup _gridLayoutGroup; //Field offset: 0x60
	[SerializeField]
	private RectTransform _categoriesIndicator; //Field offset: 0x68
	[SerializeField]
	private RectTransform _subcategoriesIndicator; //Field offset: 0x70
	[SerializeField]
	private LayoutElement _thumbsViewport; //Field offset: 0x78
	[SerializeField]
	private bool _isPremade; //Field offset: 0x80
	private Vector2 _enabledSubcategoriesAnchoredPosition; //Field offset: 0x84
	private readonly Vector2 _disabledSubcategoriesAnchoredPosition; //Field offset: 0x8C
	private SerializableDictionaryBase<Int32, SubcategoryDataList> _subcategoriesData; //Field offset: 0x98
	private AvatarMakerSubcategoriesConfigBase _subcategoriesConfig; //Field offset: 0xA0
	private List<AvatarMakerCategory> _categories; //Field offset: 0xA8

	public private int CurrentCategoryType
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public SerializableDictionaryBase<Int32, SubcategoryDataList> subcategoriesData
	{
		 get { } //Length: 8
	}

	public AvatarMakerCategoriesManager() { }

	[CompilerGenerated]
	private void <Init>b__24_0(AvatarMakerSubcategory subcategory) { }

	private void AnimateSubcategories(bool isParentCategory) { }

	public void AnimateSubcategoriesIfNeeded(int categoryType) { }

	private static void ClickTheCategoryToLandOn(SpineType spineType) { }

	private static bool DoesExpansionPackAddColors(InventoryFlagType flagType, int categoryType) { }

	private bool DoesExpansionPackNeedCategories(int categoryType, bool shouldAnimateCategories) { }

	[CompilerGenerated]
	public int get_CurrentCategoryType() { }

	public SerializableDictionaryBase<Int32, SubcategoryDataList> get_subcategoriesData() { }

	private int GetDefaultSubcategoryIndex(List<SubcategoryData> subcategoryDatas) { }

	public void Init() { }

	private void OnCategoryButtonClick(int categoryType) { }

	private void OnDestroy() { }

	private void OnExpansionPackCategoryButtonClick(AvatarMakerExpansionPackCategory expansionPackCategory) { }

	[CompilerGenerated]
	private void set_CurrentCategoryType(int value) { }

}

