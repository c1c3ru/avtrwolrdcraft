namespace PWC.Level;

[Extension]
public static class LevelEntityExtensionMethods
{

	[Extension]
	public static List<LevelDropArea> GetDropAreas(ILevelEntity levelEntity, bool includeInactive = false) { }

	[Extension]
	public static LevelDropArea GetFirstDropArea(ILevelEntity levelEntity) { }

	[Extension]
	public static IItemsHolderArea GetFirstItemsHolderArea(ILevelEntity levelEntity) { }

	[Extension]
	public static LevelSitArea GetFirstSitArea(ILevelEntity levelEntity) { }

	[Extension]
	public static LevelSleepArea GetFirstSleepArea(ILevelEntity levelEntity) { }

	[Extension]
	public static bool IsAlive(ILevelEntity levelEntity) { }

	[Extension]
	public static void ReleaseItemsOnSelf(ILevelEntity levelEntity) { }

}

