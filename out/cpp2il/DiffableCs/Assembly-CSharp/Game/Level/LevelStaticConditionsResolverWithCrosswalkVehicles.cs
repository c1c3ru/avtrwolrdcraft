namespace Game.Level;

public class LevelStaticConditionsResolverWithCrosswalkVehicles : LevelStaticConditionsResolverWithVehiclesBase
{
	[SerializeField]
	[Tooltip("Empty = all crosswalks on the LevelVehicleAreaHolder")]
	private List<LevelCrossWalkAreaHandler> _crosswalks; //Field offset: 0x38

	public LevelStaticConditionsResolverWithCrosswalkVehicles() { }

	protected virtual void CollectVehicles(List<LevelPlayerVehicle> vehicles) { }

}

