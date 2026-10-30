namespace Game.Store;

public class StoreCategoryItem : MonoBehaviour
{
	[SerializeField]
	private Image _image; //Field offset: 0x20
	[SerializeField]
	private GameObject _claimStarsRewardLabel; //Field offset: 0x28
	[SerializeField]
	private GameObject _nonSelectedTextGameObject; //Field offset: 0x30
	[SerializeField]
	private GameObject _selectedTextGameObject; //Field offset: 0x38
	[SerializeField]
	private TMP_Text _text; //Field offset: 0x40
	[SerializeField]
	private TMP_Text _selectedText; //Field offset: 0x48
	[SerializeField]
	private Image _bg; //Field offset: 0x50
	[SerializeField]
	private AFCLocalizedTextMeshPro _afcLocalizedText; //Field offset: 0x58
	[SerializeField]
	private AFCLocalizedTextMeshPro _selectedafcLocalizedText; //Field offset: 0x60
	[SerializeField]
	private GameObject _newBadge; //Field offset: 0x68
	private int _categoryIndex; //Field offset: 0x70
	private bool _isStarsPassCategory; //Field offset: 0x74
	private StoreViewManager _storeWindow; //Field offset: 0x78
	private Sprite _spriteNormal; //Field offset: 0x80
	private Sprite _spritePressed; //Field offset: 0x88

	public int CategoryIndex
	{
		 get { } //Length: 8
	}

	public StoreCategoryItem() { }

	public void Deselect() { }

	private void DismissStarsPassNewBadge() { }

	public int get_CategoryIndex() { }

	public void Init(StoreViewManager storeWindow, string key, Sprite spriteNormal, Sprite spritePressed, int categoryIndex, bool isNew = false) { }

	public void OnCategoryButtonClick() { }

	public void Select(Nullable<Int32> focusOnItemIndex = null, Action<StorePackItemBase> onFocusAction = null) { }

}

