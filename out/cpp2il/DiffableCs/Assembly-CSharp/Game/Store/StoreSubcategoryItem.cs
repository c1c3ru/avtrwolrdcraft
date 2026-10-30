namespace Game.Store;

public class StoreSubcategoryItem : MonoBehaviour
{
	[SerializeField]
	private Image _image; //Field offset: 0x20
	[SerializeField]
	private Image _backImage; //Field offset: 0x28
	[SerializeField]
	private Sprite _normalBack; //Field offset: 0x30
	[SerializeField]
	private Sprite _pressedBack; //Field offset: 0x38
	private int _categoryIndex; //Field offset: 0x40
	private StoreViewManager _storeWindow; //Field offset: 0x48

	public int CategoryIndex
	{
		 get { } //Length: 8
	}

	public StoreSubcategoryItem() { }

	public void Deselect() { }

	public int get_CategoryIndex() { }

	public void Init(StoreViewManager storeWindow, Sprite sprite, int categoryIndex) { }

	public void OnSubcategoryButtonClick() { }

	public void Select(Nullable<Int32> focusOnItemIndex = null, Action<StorePackItemBase> onFocusAction = null) { }

}

