namespace PWC.LevelPhone;

public class ContactsThumbFavoriteButton : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private GameObject _indicator; //Field offset: 0x20
	private int _id; //Field offset: 0x28
	private ContactsContent _menu; //Field offset: 0x30

	public ContactsThumbFavoriteButton() { }

	public void Init(int id, ContactsContent content) { }

	private override void UnityEngine.EventSystems.IPointerClickHandler.OnPointerClick(PointerEventData eventData) { }

}

