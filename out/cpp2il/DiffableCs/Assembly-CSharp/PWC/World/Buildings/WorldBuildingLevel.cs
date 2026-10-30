namespace PWC.World.Buildings;

public class WorldBuildingLevel : StationaryInteractableItem, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private LevelType _levelType; //Field offset: 0x3C
	private WorldBuilding _worldBuilding; //Field offset: 0x40

	public LevelType LevelType
	{
		 get { } //Length: 8
	}

	public WorldBuildingLevel() { }

	protected virtual void Awake() { }

	public LevelType get_LevelType() { }

	public override void OnPointerClick(PointerEventData eventData) { }

}

