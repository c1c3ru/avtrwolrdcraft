namespace PWC;

public class StationaryInteractableItem : InteractableItem, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler
{

	public StationaryInteractableItem() { }

	public override void OnBeginDrag(PointerEventData eventData) { }

	public override void OnDrag(PointerEventData eventData) { }

	public override void OnEndDrag(PointerEventData eventData) { }

}

