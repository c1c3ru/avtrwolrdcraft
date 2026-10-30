namespace PWC.Level.HintBubble;

public static class LevelHintBubbleTargets
{
	private static readonly Dictionary<LevelHintBubbleType, Dictionary`2<Int32, List`1<ILevelHintBubbleTarget>>> _instances; //Field offset: 0x0

	private static LevelHintBubbleTargets() { }

	public static void AddItem(ILevelHintBubbleTarget item) { }

	private static void AddItemInternal(LevelHintBubbleType type, int matchId, ILevelHintBubbleTarget item) { }

	public static void Clear() { }

	public static bool RemoveItem(ILevelHintBubbleTarget item) { }

	private static bool RemoveItemInternal(LevelHintBubbleType type, int matchId, ILevelHintBubbleTarget item) { }

	public static bool TryGetItems(LevelHintBubbleType type, int matchId, out List<ILevelHintBubbleTarget>& items) { }

}

