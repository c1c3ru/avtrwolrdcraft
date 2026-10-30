namespace PWC.World;

public abstract class WorldEnterableEntity : StationaryInteractableItem, IPointerClickHandler, IEventSystemHandler
{

	protected WorldEnterableEntity() { }

	protected override void LoadScene(string scenName) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	protected abstract void OnPointerClickInternal() { }

}

