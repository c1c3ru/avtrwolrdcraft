namespace StarsPass;

public static class StarsPassTotalStarsSave
{
	public const string COMPACT_BAR_KEY = "StarsPass_LastShownTotal"; //Field offset: 0x0
	public const string LONG_BAR_KEY = "StarsPass_LongBar_LastShownTotal"; //Field offset: 0x0
	public const string CATEGORY_NEW_BADGE_KEY = "StarsPass_CategoryNewBadgeSeen"; //Field offset: 0x0
	public const string BAR_NEW_BADGE_KEY = "StarsPass_BarNewBadgeSeen"; //Field offset: 0x0

	public static void DeleteSave(string key) { }

	public static int LoadLastShownTotal(string key) { }

	public static void MarkNewBadgeSeen(string key) { }

	public static void SaveLastShownTotal(string key, int totalStars) { }

	public static void SeedIfMissing(string key) { }

	public static void SeedIfMissing(string key, int seedValue) { }

	public static bool ShouldShowNewBadge(string key) { }

}

