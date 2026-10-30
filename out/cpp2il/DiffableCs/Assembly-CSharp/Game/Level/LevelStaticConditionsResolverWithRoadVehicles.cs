namespace Game.Level;

public class LevelStaticConditionsResolverWithRoadVehicles : LevelStaticConditionsResolverWithVehiclesBase
{
	[SerializeField]
	private bool _excludeParkedVehicles; //Field offset: 0x31

	public LevelStaticConditionsResolverWithRoadVehicles() { }

	protected virtual void CollectVehicles(List<LevelPlayerVehicle> vehicles) { }

}

