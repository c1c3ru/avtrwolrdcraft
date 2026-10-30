namespace PWC.LevelPhone.VehicleApp;

[CreateAssetMenu(fileName = "AllVehicleData", menuName = "AvatarWorld/LevelPhone/AllVehicleData")]
public class GeneralVehicleData : ScriptableObject
{
	public VehicleData[] vehiclesData; //Field offset: 0x18
	private Dictionary<VehicleType, VehicleData> _vehiclesDictionary; //Field offset: 0x20

	public GeneralVehicleData() { }

	private void EnsureDictionary() { }

	public void TryGetVehicleData(VehicleType value, out VehicleData vehicleData) { }

	public bool TryGetVehicleDataByPrefabGuid(string prefabGuid, out VehicleData vehicleData) { }

	public bool TryGetVehicleDataWithSceneDefaultLevelData(string sceneName, out VehicleData vehicleData) { }

}

