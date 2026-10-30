namespace PWC.Level.Maker.Customization;

public class LevelMakerItemCustomizationMenu : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<LevelMakerCustomizationHandlerBase, String> <>9__46_0; //Field offset: 0x8
		public static Func<String, Boolean> <>9__46_1; //Field offset: 0x10
		public static Func<String, String> <>9__46_2; //Field offset: 0x18
		public static Comparison<LevelMakerCCBase> <>9__51_1; //Field offset: 0x20

		private static <>c() { }

		public <>c() { }

		internal string <Show>b__46_0(LevelMakerCustomizationHandlerBase x) { }

		internal bool <Show>b__46_1(string x) { }

		internal string <Show>b__46_2(string x) { }

		internal int <ShowItemsInCategory>b__51_1(LevelMakerCCBase lhs, LevelMakerCCBase rhs) { }

	}

	[CompilerGenerated]
	private struct <>c__DisplayClass46_0
	{
		public LevelMakerCustomizationObjectHandlerBase objectHandler; //Field offset: 0x0
		public LevelMakerItemCustomizationMenu <>4__this; //Field offset: 0x8

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass46_1
	{
		public CustomizationCategoryType customizationCategoryType; //Field offset: 0x10

		public <>c__DisplayClass46_1() { }

		internal bool <Show>b__4(CustomizationCategoryData data) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass51_0
	{
		public CustomizationCategoryType mainCategory; //Field offset: 0x10

		public <>c__DisplayClass51_0() { }

		internal bool <ShowItemsInCategory>b__0(LevelMakerCustomizationHandlerBase x) { }

	}

	[SerializeField]
	private Canvas _canvas; //Field offset: 0x20
	[SerializeField]
	private GameObject _view; //Field offset: 0x28
	[SerializeField]
	private Transform _categoryItemsParent; //Field offset: 0x30
	[SerializeField]
	private ScrollRect _itemsScrollRect; //Field offset: 0x38
	[SerializeField]
	private CategoryCustomizationUIItem _categoryItemPrefab; //Field offset: 0x40
	[SerializeField]
	private ColorCustomizationUIItem _colorItemPrefab; //Field offset: 0x48
	[SerializeField]
	private TextureCustomizationUIItem _textureItemPrefab; //Field offset: 0x50
	[SerializeField]
	private TextureCustomizationUIItem _premiumTextureItemPrefab; //Field offset: 0x58
	[SerializeField]
	private List<CustomizationCategoryData> _categoriesData; //Field offset: 0x60
	[SerializeField]
	private LevelMakerRotationButton _rotationButton; //Field offset: 0x68
	[SerializeField]
	private LevelFurnitureReturnButton _returnFurnitureButton; //Field offset: 0x70
	[SerializeField]
	private LevelMakerItemDestroyButton _destroyItemButton; //Field offset: 0x78
	[SerializeField]
	private LevelMakerItemSaveAsPresetButton _saveAsPresetItemButton; //Field offset: 0x80
	private List<CategoryCustomizationUIItem> _categoryUIItems; //Field offset: 0x88
	private List<ColorCustomizationUIItem> _colorUIItems; //Field offset: 0x90
	private List<TextureCustomizationUIItem> _textureUIItems; //Field offset: 0x98
	private List<TextureCustomizationUIItem> _premiumTextureUIItems; //Field offset: 0xA0
	private UIItemPool<CategoryCustomizationUIItem> _categoryUIItemsPool; //Field offset: 0xA8
	private UIItemPool<ColorCustomizationUIItem> _colorUIItemsPool; //Field offset: 0xB0
	private UIItemPool<TextureCustomizationUIItem> _textureUIItemsPool; //Field offset: 0xB8
	private UIItemPool<TextureCustomizationUIItem> _premiumTextureUIItemsPool; //Field offset: 0xC0
	private RectTransform _rectTransform; //Field offset: 0xC8
	private LevelMakerCustomizationObjectHandlerBase _currentObjectHandler; //Field offset: 0xD0
	private int _hoverTweenID; //Field offset: 0xD8
	public Action OnMenuHideAction; //Field offset: 0xE0
	public Action<Boolean> OnShowCategoryAction; //Field offset: 0xE8
	public Action OnCustomizationItemHandlerClickEndAction; //Field offset: 0xF0
	private string _currentCategory; //Field offset: 0xF8

	public string CurrentCategory
	{
		 get { } //Length: 8
	}

	public LevelMakerCustomizationObjectHandlerBase CurrentObjectHandler
	{
		 get { } //Length: 8
	}

	public LevelMakerItemCustomizationMenu() { }

	[CompilerGenerated]
	private Sprite <Show>g__GetCategorySprite|46_3(string category, ref <>c__DisplayClass46_0 unnamed_param_1) { }

	private void Awake() { }

	public List<LevelMakerCCBase> FilterConfigsByFlag(LevelMakerCCBase[] configs) { }

	public string get_CurrentCategory() { }

	public LevelMakerCustomizationObjectHandlerBase get_CurrentObjectHandler() { }

	public void Hide() { }

	private void HoverSetActive(bool value) { }

	private void Init() { }

	private bool IsVisible() { }

	private void OnCustomizationItemHandlerClick(LevelMakerCustomizationObjectHandlerBase objectHandler) { }

	private void OnCustomizationItemHandlerClickDestroy(LevelMakerCustomizationObjectHandlerBase objectHandler) { }

	private void OnDestroy() { }

	private void OnGameCameraPointerDown() { }

	private void OnItemBeginDrag(DragDropItemBase item, PointerEventData eventData) { }

	private void OnLevelMakerItemDestroyButtonClick(ILevelMakerDeletableByUIItem _) { }

	private void OnMakerModeChanged(bool isEditMode) { }

	private void OnRotatingItemByUIButton(ILevelMakerRotatableByUIItem menuHandler) { }

	private void SetHeight() { }

	private void SetNewItemTargetForMenu(LevelMakerCustomizationObjectHandlerBase objectHandler) { }

	private void SetPosition(LevelMakerCustomizationObjectHandlerBase objectHandler) { }

	private void SetReturnButtonPositionIfNeeded() { }

	private void SetRotationButtonPositionIfNeeded() { }

	private void Show(LevelMakerCustomizationObjectHandlerBase objectHandler) { }

	public void ShowCategory(LevelMakerCustomizationObjectHandlerBase objectHandler, string category) { }

	public void ShowItemsInCategory(LevelMakerCCBase[] configs, LevelMakerCustomizationObjectHandlerBase objectHandler, string category) { }

	private void Start() { }

}

