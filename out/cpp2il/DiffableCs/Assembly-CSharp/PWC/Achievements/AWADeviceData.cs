namespace PWC.Achievements;

public class AWADeviceData
{
	private const string FILE_PATH = "AWA_DeviceData"; //Field offset: 0x0
	[JsonProperty]
	private Dictionary<String, String> _ids; //Field offset: 0x10

	public AWADeviceData() { }

	public bool AddAchievement(string id, out string hash) { }

	public bool AddAchievements(HashSet<String> ids) { }

	public Dictionary<String, String> GetAchievements() { }

	public bool HasAchievements() { }

	public bool RemoveAchievements(HashSet<String> ids) { }

	public static void SaveData(AWADeviceData data) { }

	public static bool TryLoadData(out AWADeviceData data) { }

}

