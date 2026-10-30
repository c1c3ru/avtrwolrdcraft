namespace PWC.LevelPhone;

public class VehiclesAddButton : GameUIElement, IPointerDownHandler, IEventSystemHandler
{
	private FTUEUIButton _ftueUIButton; //Field offset: 0x28
	private VehicleContent _menu; //Field offset: 0x30

	public VehiclesAddButton() { }

	public void Init(VehicleContent menu) { }

	public virtual void OnPointerDown(PointerEventData eventData) { }

	private void Start() { }

}

