namespace PWC.Street;

public class StreetHouseLayout : GameUIElement, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private WorldMakerBuildingType _worldMakerBuildingType; //Field offset: 0x24
	[SerializeField]
	private DynamicScrollPoint _dynamicScrollPoint; //Field offset: 0x28
	[SerializeField]
	private SizeDeltaFocusEffect _focusEffect; //Field offset: 0x30

	public SizeDeltaFocusEffect FocusEffect
	{
		 get { } //Length: 8
	}

	public StreetHouseLayout() { }

	public SizeDeltaFocusEffect get_FocusEffect() { }

	public override void OnPointerClick(PointerEventData eventData) { }

}

