namespace Game.Level;

public abstract class LevelStaticConditionsResolverWithVehiclesBase : LevelStaticConditionsResolver
{
	[SerializeField]
	[Tooltip("Also passes the vehicles' passengers as avatar context, so avatar conditions can be used too")]
	private bool _includePassengersAsAvatars; //Field offset: 0x30

	protected LevelStaticConditionsResolverWithVehiclesBase() { }

	protected abstract void CollectVehicles(List<LevelPlayerVehicle> vehicles) { }

	public virtual void OnConditionsCheck() { }

	protected static bool TryGetVehicleAreaHolder(out LevelVehicleAreaHolder vehicleAreaHolder) { }

}

