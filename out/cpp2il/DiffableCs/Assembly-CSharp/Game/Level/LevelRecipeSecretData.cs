namespace Game.Level;

public static class LevelRecipeSecretData
{
	private static bool _didInitCollection; //Field offset: 0x0
	private static readonly Dictionary<ValueTuple`2<String, String>, LevelRecipeSecret> _recipes; //Field offset: 0x8

	private static LevelRecipeSecretData() { }

	public static void InitCollectionIfNeeded() { }

	public static bool TryGetRecipeOutcome(LevelItem item1, LevelItem item2, out string outcome) { }

}

