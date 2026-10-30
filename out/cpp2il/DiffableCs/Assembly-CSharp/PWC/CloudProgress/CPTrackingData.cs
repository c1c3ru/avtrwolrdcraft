namespace PWC.CloudProgress;

public class CPTrackingData
{
	[JsonIgnore]
	public const string KEY_PREFIX = "AW_CloudProgress_LastSaveState_"; //Field offset: 0x0
	public Dictionary<String, String> lastSaveFilesState; //Field offset: 0x10

	public CPTrackingData() { }

	public static void DeleteAllData() { }

	private static string GetKey() { }

	public static void Save(CPTrackingData trackingData) { }

	public static bool TryLoadData(out CPTrackingData trackingData) { }

}

