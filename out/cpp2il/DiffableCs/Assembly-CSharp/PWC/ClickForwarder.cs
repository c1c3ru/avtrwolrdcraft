namespace PWC;

public class ClickForwarder : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerDownHandler, IPointerUpHandler, ILevelMakerDisabledWhileInEditMode
{
	[SerializeField]
	private GameObject _target; //Field offset: 0x20

	public ClickForwarder() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void OnPointerDown(PointerEventData eventData) { }

	public override void OnPointerUp(PointerEventData eventData) { }

}

