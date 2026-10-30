namespace TMPro;

public class TMP_ScrollbarEventHandler : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, ISelectHandler, IDeselectHandler
{
	public bool isSelected; //Field offset: 0x20

	public TMP_ScrollbarEventHandler() { }

	public override void OnDeselect(BaseEventData eventData) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void OnSelect(BaseEventData eventData) { }

}

