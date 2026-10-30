namespace Game;

public static class HolidayConfig
{
	public static string PLAYERPREFS_Exclude_Holidays; //Field offset: 0x0
	private const int EXCLUDE_HOLIDAYS_DEFAULT_VALUE = 1; //Field offset: 0x0
	public static readonly HashSet<String> HolidayKeys; //Field offset: 0x8
	public static readonly Dictionary<String, StorePackType> PackTypeMap; //Field offset: 0x10

	private static HolidayConfig() { }

	public static int GetExcludeHolidaysValue() { }

	public static bool IsHolidayPackHidden(string packName) { }

}

