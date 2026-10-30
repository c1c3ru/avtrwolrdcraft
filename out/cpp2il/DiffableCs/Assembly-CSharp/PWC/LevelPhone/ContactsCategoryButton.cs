namespace PWC.LevelPhone;

public class ContactsCategoryButton : GameUIElement, IPointerDownHandler, IEventSystemHandler
{
	[SerializeField]
	private ContactsCategoryType _categoryType; //Field offset: 0x24
	[SerializeField]
	private GameObject _indicator; //Field offset: 0x28
	[SerializeField]
	private Image _image; //Field offset: 0x30
	[SerializeField]
	private Sprite _disabledSprite; //Field offset: 0x38
	private ContactsContent _contentMenu; //Field offset: 0x40
	private bool _isDisabled; //Field offset: 0x48

	public ContactsCategoryButton() { }

	public void Deselect() { }

	public ContactsCategoryType GetCategoryType() { }

	public void Init(ContactsContent contentMenu) { }

	public virtual void OnPointerDown(PointerEventData eventData) { }

	public void SetDisabled() { }

	public void SetSelected() { }

}

