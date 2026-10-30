namespace PWC.AvatarSpeech;

public class AvatarSpeechUIMenu : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass24_0
	{
		public string lastCategory; //Field offset: 0x10
		public string lastSubcategory; //Field offset: 0x18

		public <>c__DisplayClass24_0() { }

		internal bool <Init>b__0(AvatarSpeechUICategoryItem x) { }

		internal bool <Init>b__1(AvatarSpeechUICategoryItem x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass30_0
	{
		public Item config; //Field offset: 0x10

		public <>c__DisplayClass30_0() { }

		internal bool <TryAddToRecent>b__0(string id) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass31_0
	{
		public string subcategoryToSelect; //Field offset: 0x10

		public <>c__DisplayClass31_0() { }

		internal bool <SelectCategory>b__0(AvatarSpeechUICategoryItem x) { }

	}

	internal class UserData
	{
		public List<String> recentTextsIds; //Field offset: 0x10

		public UserData() { }

	}

	private const string USER_DATA_KEY_PREFIX = "AW_AvatarSpeech_UserData_"; //Field offset: 0x0
	[SerializeField]
	private GameObject _content; //Field offset: 0x20
	[SerializeField]
	private Transform _textItemsParent; //Field offset: 0x28
	[SerializeField]
	private Transform _categoryItemsParent; //Field offset: 0x30
	[SerializeField]
	private Transform _subcategoryItemsParent; //Field offset: 0x38
	[SerializeField]
	private AvatarSpeechUITextItem _textItemPrefab; //Field offset: 0x40
	[SerializeField]
	private AvatarSpeechUICategoryItem _categoryItemPrefab; //Field offset: 0x48
	[SerializeField]
	private GameObject _menuButton; //Field offset: 0x50
	private AvatarSpeechAvatarHandler _target; //Field offset: 0x58
	private Data _data; //Field offset: 0x60
	private string _currentCategory; //Field offset: 0x68
	private string _currentSubcategory; //Field offset: 0x70
	private UserData _userData; //Field offset: 0x78
	private readonly Dictionary<Int32, String> _lastAvatarCategories; //Field offset: 0x80
	private readonly Dictionary<Int32, String> _lastAvatarSubcategories; //Field offset: 0x88
	private readonly List<AvatarSpeechUICategoryItem> _currentCategoryItems; //Field offset: 0x90
	private readonly List<AvatarSpeechUICategoryItem> _currentSubcategoryItems; //Field offset: 0x98

	public AvatarSpeechUIMenu() { }

	private void Awake() { }

	private void DestroyTransformChildren(Transform target) { }

	private float GetTextItemsScrollRectWidth() { }

	public void Init(ICATarget target, Data data) { }

	private void OnBeforeDestroyLevelItem(LevelItem levelItem) { }

	private void OnBeforeSceneLoadStage1() { }

	private void OnCATargetSelected(ICATarget target, bool isDrag) { }

	private void OnDestroy() { }

	private void OnPreSaveProgres(Scene scene) { }

	public void OnTextItemClick(Item config) { }

	public void OnToggleMenuButtonClick() { }

	public void SelectCategory(string categoryName, bool shouldSelectSubcategory) { }

	public void SelectSubcategory(string subcategoryName) { }

	private void TryAddToRecent(Item config) { }

	private bool TryGetCustomTextItems(string subcategoryName, out List<Item>& textItems) { }

	private void TryLoadUserDataFromFile() { }

	private void TrySaveUserDataToFile() { }

}

