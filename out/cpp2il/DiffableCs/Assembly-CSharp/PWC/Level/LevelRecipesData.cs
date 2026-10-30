namespace PWC.Level;

public static class LevelRecipesData
{
	private static bool _didInitCollection; //Field offset: 0x0
	private static readonly Dictionary<String, Dictionary`2<String, String>> _recipes; //Field offset: 0x8
	[TupleElementNames(new IL2CPP_TYPE_STRING[] {"item1PrefabGuid", "item2PrefabGuid"})]
	private static readonly Dictionary<String, List`1<ValueTuple`2<String, String>>> _recipeSourcesByOutcome; //Field offset: 0x10

	private static LevelRecipesData() { }

	public static void InitCollectionIfNeeded() { }

	public static bool TryGetRandomRecipeSources(string outcomePrefabGuid, out string item1PrefabGuid, out string item2PrefabGuid) { }

	public static bool TryGetRecipeOutcome(string item1PrefabGuid, string item2PrefabGuid, out string outcomePrefabGuid) { }

}

