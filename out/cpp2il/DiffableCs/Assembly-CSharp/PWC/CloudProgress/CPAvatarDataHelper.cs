namespace PWC.CloudProgress;

public static class CPAvatarDataHelper
{
	private const string AVATARS_DATA_FOLDER_PATH = "/AvatarDataForCloudProgress/"; //Field offset: 0x0
	private const string AVATARS_DATA_FOLDER_SPINE_PATH = "/AvatarDataForCloudProgress/SpineData/"; //Field offset: 0x0
	private const string AVATARS_DATA_FOLDER_LEVEL_PATH = "/AvatarDataForCloudProgress/LevelData/"; //Field offset: 0x0

	public static void ApplyAvatarsData(string absoluteRoot) { }

	private static void ApplyAvatarsLevelData(string absoluteRoot) { }

	private static void ApplyAvatarsSpineData(string absoluteRoot) { }

	public static void DeleteCPAvatarData(string absoluteRoot) { }

	public static void TryAddAvatarsData(string absoluteRoot, List<String> filePaths) { }

	private static void TryAddAvatarsLevelData(string absoluteRoot, List<String> filePaths) { }

	private static void TryAddAvatarsSpineData(string absoluteRoot, List<String> filePaths) { }

}

