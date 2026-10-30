namespace PWC.LevelPhone;

public class ContactsAddButton : GameUIElement, IPointerDownHandler, IEventSystemHandler
{
	private FTUEUIButton _ftueUIButton; //Field offset: 0x28
	private ContactsContent _menu; //Field offset: 0x30

	public ContactsAddButton() { }

	public void Init(ContactsContent menu) { }

	public virtual void OnPointerDown(PointerEventData eventData) { }

	private void Start() { }

}

