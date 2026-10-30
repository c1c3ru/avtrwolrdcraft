namespace PWC.AvatarSpeech;

public class AvatarSpeechUICategoryItem : GameUIElement
{
	private static AvatarSpeechUICategoryItem _selectedCategory; //Field offset: 0x0
	private static AvatarSpeechUICategoryItem _selectedSubcategory; //Field offset: 0x8
	[SerializeField]
	private Image _image; //Field offset: 0x28
	[SerializeField]
	private GameObject _indicator; //Field offset: 0x30
	private AvatarSpeechUIMenu _menu; //Field offset: 0x38
	private string _categoryName; //Field offset: 0x40
	private bool _isSubcategory; //Field offset: 0x48
	private bool _isComingSoon; //Field offset: 0x49

	public string CategoryName
	{
		 get { } //Length: 8
	}

	public AvatarSpeechUICategoryItem() { }

	private void Awake() { }

	public void Deselect() { }

	public string get_CategoryName() { }

	public void Init(AvatarSpeechUIMenu menu, string categoryName, bool isSubcategory, bool isComingSoon, string parentCategoryName = null) { }

	private void OnClick() { }

	public void Select(bool isUserAction) { }

}

