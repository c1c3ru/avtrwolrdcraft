namespace Game.Level;

public class LevelStaticConditionsResolverWithParkedVehicles : LevelStaticConditionsResolverWithVehiclesBase
{
	[SerializeField]
	[Tooltip("Empty = all parking spots on the LevelVehicleAreaHolder")]
	private List<LevelVehicleParkingSpotAreaHandler> _parkingSpots; //Field offset: 0x38

	public LevelStaticConditionsResolverWithParkedVehicles() { }

	protected virtual void CollectVehicles(List<LevelPlayerVehicle> vehicles) { }

}

