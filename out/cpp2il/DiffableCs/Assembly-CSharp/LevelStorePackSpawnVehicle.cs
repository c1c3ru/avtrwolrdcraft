//Type is in global namespace

public class LevelStorePackSpawnVehicle : MonoBehaviour
{
	[SerializeField]
	private GeneralVehicleData _generalVehicleData; //Field offset: 0x20
	[SerializeField]
	private VehicleType _vehicleType; //Field offset: 0x28

	public VehicleType VehicleType
	{
		 get { } //Length: 8
	}

	public LevelStorePackSpawnVehicle() { }

	public VehicleType get_VehicleType() { }

	public void SpawnVehicle() { }

}

