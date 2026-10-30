namespace PWC.Level;

public class LevelSwitcherOnClick : StationaryInteractableItem, IPointerClickHandler, IEventSystemHandler, IMultiplayer_IgnoreInputEvents
{
	[SerializeField]
	private WorldBuildingType _buildingType; //Field offset: 0x3C
	[SerializeField]
	private LevelType _levelType; //Field offset: 0x40
	[SerializeField]
	private int _id; //Field offset: 0x44

	public LevelSwitcherOnClick() { }

	public void LoadScene() { }

	public override void OnPointerClick(PointerEventData eventData) { }

}

