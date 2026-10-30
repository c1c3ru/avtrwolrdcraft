namespace PWC.CarsMaker;

public static class CarPremadeDataManager
{
	public const string PREMADE_CARS_RESOURCES_PATH = "PremadeCarsData/"; //Field offset: 0x0
	private static Dictionary<Int32, AvatarSpineData> _dataByCarId; //Field offset: 0x0

	public static void ClearCache() { }

	private static void EnsureLoaded() { }

	public static List<AvatarSpineData> GetAll() { }

	public static List<Int32> GetAllIDs() { }

	public static bool TryGetData(int carId, out AvatarSpineData data) { }

}

