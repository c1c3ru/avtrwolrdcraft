namespace BWYW;

public static class BWYWUtils
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action <>9__50_0; //Field offset: 0x8
		public static Func<PDPrefab, String> <>9__70_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal string <GetGiftsPrefabGuidsOfChapter>b__70_0(PDPrefab x) { }

		internal void <TryFinishDay>b__50_0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass54_0
	{
		public int sum; //Field offset: 0x10

		public <>c__DisplayClass54_0() { }

		internal void <GetTotalXPInADay>b__0(DailyTaskBase x) { }

	}

	private const string BWYW_TASKS_MAP_DATA_PATH_BASE = "BWYW/Tasks_Maps/BWYW_"; //Field offset: 0x0
	private const string BWYW_GIFTS_MAP_DATA_PATH_BASE = "BWYW/Gifts_Maps/BWYW_Gifts_"; //Field offset: 0x0
	private const string BWYW_SKILL_MAP_DATA_PATH_SUFFIX = "_Map"; //Field offset: 0x0
	public const string BWYW_DATA_KEY_BASE = "BWYW_Data_"; //Field offset: 0x0
	public const string ACTIVE_SKILL_TYPE_KEY = "BWYW_ACTIVE_SKILL_TYPE_KEY"; //Field offset: 0x0
	private static Dictionary<SkillType, BWYWSkillMap> skillMapsDictionary; //Field offset: 0x0
	private static Dictionary<SkillType, BWYWGiftData> giftsMapsDictionary; //Field offset: 0x8
	private static SkillData _currentSkillData; //Field offset: 0x10
	private static SkillType _currentSkillType; //Field offset: 0x18

	private static BWYWUtils() { }

	public static void ClearCache() { }

	public static void DeleteAllBWYWData() { }

	public static bool FindTaskIdsIfExist(SkillType skillType, TaskType type, string subTaskName, string extraInfo, out List<Int32>& taskIds, bool ensureIgnoreExtraData = false) { }

	public static SkillType GetActiveSkillType() { }

	public static List<SkillType> GetAllChaptersNames(SkillType skillType) { }

	public static List<SkillType> GetAllMainSkillTypes() { }

	public static List<SkillType> GetAllValidSkillTypes() { }

	public static int GetChapterNumFromSkillType(SkillType skillType) { }

	public static int GetCharacterOfSkillType(SkillType skillType) { }

	public static List<Int32> GetCharactersOfAllSkillTypes() { }

	public static string GetCleanSkillName(SkillType skillType) { }

	public static int GetCurrentActiveChapter(SkillType skillType) { }

	public static SkillType GetCurrentActiveChapterNameFromSkillType(SkillType skillType) { }

	public static int GetCurrentDay(SkillType skillType) { }

	public static DailyTasksData GetDailyTasksData(SkillType skillType, int day) { }

	public static DateTime GetDateFromUnixTime(long unixTime) { }

	public static Nullable<DateTime> GetDayCompletionDateIfExist(SkillType skillType) { }

	public static Sprite GetFinalTaskSprite(SkillType skillType) { }

	public static BWYWGiftData GetGiftsDataMap(SkillType skillType) { }

	private static void GetGiftsPrefabGuidsOfChapter(SkillType skillType, out HashSet<String>& prefabGuids) { }

	public static int GetNumOfSkillChapters(SkillType SkillType) { }

	public static int GetNumOfTasksInADay(SkillType skillType, int day) { }

	public static int GetProgressInTask(SkillType skillType, int day, int taskId) { }

	public static string GetSkillCode(SkillType skillType) { }

	public static BWYWSkillMap GetSkillMap(SkillType skillType) { }

	public static Sprite GetSkillSpriteFromSkillType(SkillType skillType) { }

	public static Sprite GetSpriteOfSkillTypeTitle(SkillType skillType) { }

	public static DailyTaskBase GetTaskBase(SkillType skillType, int taskId) { }

	private static List<Int32> GetTaskIDBySubTaskName(SkillType skillType, TaskType taskType, string subTaskName, string extraInfo, bool ensureIgnoreExtraData = false) { }

	public static string GetTitleOfSkillFromSkillType(SkillType skillType) { }

	public static int GetTotalDaysInSkill(SkillType skillType) { }

	public static int GetTotalXPInADay(SkillType skillType, int day) { }

	public static SkillData GetUserSkillData(SkillType skillType) { }

	public static bool HasUnclaimedGift(SkillType skillType) { }

	public static bool HasUnclaimedTask(SkillType skillType) { }

	public static bool IsAnyProgressExist(SkillType skillType) { }

	public static bool IsCurrentDayDone(SkillType skillType) { }

	public static bool IsDayDone(SkillType skillType, SkillData userSkillData, int day) { }

	public static bool IsNewSkill(SkillType skillType) { }

	public static bool IsSkillComingSoon(SkillType type) { }

	public static bool IsSkillFinished(SkillType skillType) { }

	public static bool IsSkillLastDay(SkillType currentSkillType) { }

	public static bool IsSkillOneDayBeforeLastDay(SkillType currentSkillType) { }

	public static bool IsStarteKitNeeded(SkillType skillType) { }

	public static bool IsTaskComplete(SkillType skillType, int taskId) { }

	private static bool IsTaskConditionsValid(SkillType skillType, int taskId, ILevelAvatar avatar) { }

	public static void MigrateFilesLocationForAndroidBuildIfNeeded() { }

	public static void ResetChapterClaimedGifts(SkillType skillType) { }

	public static void ResetClaimedGifts() { }

	private static void ResetClaimedGiftsOfSkillType(SkillType skillType) { }

	private static void SaveData(SkillType skillType, SkillData userSkillData) { }

	public static void SetActiveSkillType(SkillType skillType) { }

	public static void SetGiftClaimed(SkillType skillType, int giftId) { }

	public static void SetNotNewSkill(SkillType skillType) { }

	public static void SetStarterKitGiven(SkillType skillType) { }

	public static void SetTaskClaimed(SkillType skillType, int taskId, out bool isNotOnline) { }

	public static void SetTaskRevealed(SkillType skillType, int taskId) { }

	public static void StartNextDay(SkillType skillType) { }

	public static bool TryFinishDay(SkillType skillType) { }

	public static bool TryGetSecondsUntilNextUpdate(DateTime completionDate, out int timeUntilTomorrow) { }

	public static bool TryUpdateAnimationTaskProgress(SkillType skillType, int taskId, string subTaskName, ILevelAvatar avatar, out int taskProgress, out bool isFinished) { }

	public static bool TryUpdatePutClothingTaskProgress(SkillType skillType, int taskId, List<String> skinsNames, out int taskProgress, out bool isFinished) { }

	public static bool TryUpdateSecretTaskProgress(SkillType skillType, int taskId, LevelType levelType, SecretData secretData, string subTaskName, out int taskProgress, out bool isFinished) { }

	public static string TypeToGiftsMapResourcesPath(string type) { }

	public static string TypeToSkillsMapResourcesPath(string type) { }

}

