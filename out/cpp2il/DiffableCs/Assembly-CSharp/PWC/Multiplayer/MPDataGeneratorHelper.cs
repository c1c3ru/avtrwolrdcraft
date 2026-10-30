namespace PWC.Multiplayer;

public static class MPDataGeneratorHelper
{
	private static int _seedCounter; //Field offset: 0x0
	private static int _guidGeneratorCounter; //Field offset: 0x4
	private static int _oneCallGuidGeneratorCounter; //Field offset: 0x8
	private static string _nextGuidPrefix; //Field offset: 0x10

	public static void ClearAllData() { }

	public static void ClearCurrentNextGuidPrefix() { }

	public static void ClearGuidGeneratorCounters() { }

	public static string GetNextGuidPrefixForGuidGenerator() { }

	public static MPOneCallGeneratorData GetNextOneCallGeneratorData(bool includeRandom = true, bool includeGuidPrefix = true) { }

	private static string GetNextOneCallGuidPrefixForGuidGenerator() { }

	public static int GetNextSeedForRandomGenerator() { }

}

