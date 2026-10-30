namespace PWC;

public class BackgroundPlanetClickableAreaForMovingWindows : BackgroundPlanetClickableArea, IPointerClickHandler, IEventSystemHandler
{
	private Camera _camera; //Field offset: 0x28

	public BackgroundPlanetClickableAreaForMovingWindows() { }

	protected virtual void Awake() { }

	public override void OnPointerClick(PointerEventData eventData) { }

}

