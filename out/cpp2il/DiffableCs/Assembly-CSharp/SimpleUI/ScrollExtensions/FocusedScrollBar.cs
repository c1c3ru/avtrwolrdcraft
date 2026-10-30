namespace SimpleUI.ScrollExtensions;

public class FocusedScrollBar : MonoBehaviour, IEndDragHandler, IEventSystemHandler
{
	public ScrollFocusController focusController; //Field offset: 0x20

	public FocusedScrollBar() { }

	public override void OnEndDrag(PointerEventData eventData) { }

}

