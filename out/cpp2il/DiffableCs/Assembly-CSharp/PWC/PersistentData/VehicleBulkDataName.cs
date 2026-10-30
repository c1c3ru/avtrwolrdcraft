namespace PWC.PersistentData;

public static class VehicleBulkDataName
{
	private const string PREFIX = "BulkData_"; //Field offset: 0x0

	public static string Create(string persistenceKey) { }

	public static bool TryGetVehicleKey(string bulkDataName, out string vehicleKey) { }

}

